using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.Emails;
using Portfolio.Core.Entities.Sql;
using Portfolio.Core.RepositoriesInterface.Sql;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;
using System.Net.Mail;
using System.Net;

namespace Portfolio.Infrastructure.ServicesImpl
{
    public class SendMailService : ISendMailService
    {
        private readonly IConfigurationRepository _configRepo;
        private readonly ILogService _logService;

        public SendMailService(IConfigurationRepository configRepo, ILogService logService)
        {
            _configRepo = configRepo;
            _logService = logService;
        }

        public async Task SendMailForgotPasswordAsync(EmailDataForgotPassVO data)
        {
            try
            {
                ValidData(data, true);

                SendMailVO active = new SendMailVO();
                active.Body = LoadTemplate(ConstantsEmail.TemplateResetAccount);
                active.Recipients = data.Recipients;
                active.Subject = ConstantsEmail.SubjectResetAccount + data.NameUser;

                active.Body = active.Body.Replace("[[NAME]]", $"{data.NameUser}");
                active.Body = active.Body.Replace("[[PASS]]", data.NewPassword);

                await SendMailAsync(active);
            }
            catch (ValidException ex)
            {
                throw new EmailException(ex.Message, ex);
            }
            catch (EmailException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao enviar email de redefinição de senha, {data.Username}", this.GetPlace(), ex);
                throw new EmailException($"Falha inesperada ao enviar email de redefinição de senha, {data.Username}", ex);
            }
        }

        private string LoadTemplate(string nameTemplate)
        {
            try
            {
                string filepath = Path.Combine(Path.GetFullPath(DirectoriesName.EmailTemplates), nameTemplate);
                using (StreamReader reader = new StreamReader(filepath))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (EmailException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao buscar template para envio de email, nome: {nameTemplate}", this.GetPlace(), ex);
                throw new EmailException($"Falha ao buscar template para envio de email, nome: {nameTemplate}");
            }
        }

        private void ValidData(EmailDataForgotPassVO data, bool isUserValid = false)
        {
            try
            {
                if (isUserValid && string.IsNullOrEmpty(data.NameUser) || string.IsNullOrEmpty(data.NewPassword))
                    throw new EmailException($"Usuário não informado para envio de email");

                if (data.Recipients is null || data.Recipients.Count <= 0)
                    throw new EmailException($"Destinatários não informados para envio de email");
            }
            catch (EmailException ex)
            {
                _logService.Write(ex.Message, this.GetPlace(), ex);
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao validar dados para envio de email", this.GetPlace(), ex);
                throw new EmailException($"Falha inesperada ao validar dados para envio de email", ex);
            }
        }

        private async Task<ConfigurationMailVO> GetCredentailsSendMailAsync()
        {
            try
            {
                Configuration smtpHost = await _configRepo.GetByTokenAsync(ConfigurationTokens.EmailSmtp);
                if (smtpHost is null || string.IsNullOrEmpty(smtpHost.Value))
                    throw new EmailException($"Host smtp para envio de email não encontrado");

                Configuration smtpPort = await _configRepo.GetByTokenAsync(ConfigurationTokens.EmailPort);
                if (smtpPort is null || string.IsNullOrEmpty(smtpPort.Value))
                    throw new EmailException($"Porta de smtp para envio de email não encontrada");

                Configuration loginEmail = await _configRepo.GetByTokenAsync(ConfigurationTokens.EmailLogin);
                if (loginEmail is null || string.IsNullOrEmpty(loginEmail.Value))
                    throw new EmailException($"Login para envio de email não encontrado");

                Configuration passEmail = await _configRepo.GetByTokenAsync(ConfigurationTokens.EmailPass);
                if (passEmail is null || string.IsNullOrEmpty(passEmail.Value))
                    throw new EmailException($"Senha para envio de email não encontrada");

                return new ConfigurationMailVO
                {
                    SmtpHost = smtpHost.Value,
                    SmtpPort = int.Parse(smtpPort.Value),
                    EmailLogin = loginEmail.Value,
                    EmailPass = passEmail.Value
                };
            }
            catch (RepositoryException ex)
            {
                throw new EmailException(ex.Message, ex);
            }
            catch (EmailException ex)
            {
                _logService.Write(ex.Message, this.GetPlace(), ex);
                throw new EmailException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao credenciais para envio de email", this.GetPlace(), ex);
                throw new EmailException($"Falha ao credenciais para envio de email", ex);
            }
        }

        private async Task SendMailAsync(SendMailVO sendMail)
        {
            MailMessage mail = new MailMessage();
            try
            {
                ConfigurationMailVO configs = await GetCredentailsSendMailAsync();
                mail.From = new MailAddress(configs.EmailLogin);

                foreach (string recipients in sendMail.Recipients)
                {
                    mail.To.Add(recipients);
                }
                mail.Subject = sendMail.Subject;
                mail.Body = sendMail.Body;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.Normal;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                if (sendMail.Attachments != null)
                {
                    foreach (Attachment attch in sendMail.Attachments)
                    {
                        mail.Attachments.Add(attch);
                    }
                }

                SmtpClient client = new SmtpClient();
                client.Credentials = new NetworkCredential(configs.EmailLogin, configs.EmailPass);
                client.Host = configs.SmtpHost;
                client.Port = configs.SmtpPort;
                client.EnableSsl = true;

                await client.SendMailAsync(mail);
            }
            catch (EmailException ex)
            {
                throw ex;
            }
            catch (NotFoundException ex)
            {
                throw new EmailException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha no método de disparar email", this.GetPlace(), ex);
                throw new EmailException($"Falha no método de disparar email", ex);
            }
            finally
            {
                mail.Dispose();
            }
        }
    }
}
