using AutoMapper;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.ContactMe;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;
using Portfolio.Core.RepositoriesInterface.Sql;
using Portfolio.Core.ServicesInterface;
using Portfolio.HandleFiles.Models;
using Portfolio.Helpers;

namespace Portfolio.Infrastructure.ServicesImpl
{
    public class ContactMeService : IContactMeService
    {
        private readonly IContactMeRepository _contactMeRepo;
        private readonly IMapper _mapper;
        private readonly ILogService _logService;
        private readonly IPortfolioConfigService _portfolioService;
        private readonly IUserRepository _userRepo;
        private readonly IHandleFileService _handleFileService;
        private readonly IPortfolioConfigRepository _portfolioRepo;

        public ContactMeService(IContactMeRepository contactMeRepo, IMapper mapper, ILogService logService, IPortfolioConfigService portfolioService, IPortfolioConfigRepository portfolioRepo, IHandleFileService handleFileService, IUserRepository userRepo)
        {
            _contactMeRepo = contactMeRepo;
            _mapper = mapper;
            _logService = logService;
            _portfolioService = portfolioService;
            _portfolioRepo = portfolioRepo;
            _handleFileService = handleFileService;
            _userRepo = userRepo;
        }

        public async Task<ListAllEntityVO<ContactMeReturnVO>> GetAllAsync(RequestDataVO requestData, int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<ContactMe> listEntities =
                    await _contactMeRepo.GetAllAsync(limit, page, requestData.User.Id);

                ListAllEntityVO<ContactMeReturnVO> resp =
                    _mapper.Map<ListAllEntityVO<ContactMeReturnVO>>(listEntities);

                resp.Items = GetFilesContactMe(resp.Items);
                return resp;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar contatos", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar contatos", ex);
            }
        }

        public async Task<List<ContactMeReturnVO>> GetAllByPortfolioIdAsync(int? portfolioId, RequestDataVO requestData)
        {
            try
            {
                portfolioId.IsValidId();

                await _portfolioService.ValidPermissionAccessAsync(portfolioId.Value, requestData.User.Id);

                List<ContactMe> listEntities =
                    await _contactMeRepo.GetAllByPortfolioIdAsync(portfolioId.Value);

                List<ContactMeReturnVO> resp =
                    _mapper.Map<List<ContactMeReturnVO>>(listEntities);

                resp = GetFilesContactMe(resp);
                return resp;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar contatos do portfolio {portfolioId}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar contatos do portfolio {portfolioId}", ex);
            }
        }

        public async Task<ContactMeReturnVO> GetByIdAsync(int? id)
        {
            try
            {
                id.IsValidId();

                ContactMe entity =
                    await _contactMeRepo.GetByIdAsync(id.Value);

                ContactMeReturnVO resp =
                    _mapper.Map<ContactMeReturnVO>(entity);

                resp.FileAttachment =
                    _handleFileService.GetUrlFileUniqueAtDirectory(
                        ConstantsFileService.ContactMeFileEntity,
                        entity.Id.ToString(),
                        ConstantsFileService.ContactMeFileName);

                return resp;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar contato do id {id}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar contato do id {id}", ex);
            }
        }

        public async Task<ContactMeReturnVO> InsertAsync(SaveContactMeVO model, PublicPageRequestDataVO publicPageRequestData = null, RequestDataVO requestData = null)
        {
            try
            {
                await ValidConsistenceDataAsync(model, publicPageRequestData, requestData);

                ContactMe entity = _mapper.Map<ContactMe>(model);

                if (requestData != null)
                {
                    var portfolioId = await _userRepo.GetIdPortfolioSelectedCurrentAsync(requestData.User.Id);
                    if (portfolioId <= 0)
                        throw new ValidException($"Por favor selecione um portfolio para vincular este contato {requestData.User.Username}");

                    entity.PortfolioId = portfolioId;
                }

                entity = await _contactMeRepo.InsertAsync(entity);

                ContactMeReturnVO resp =
                    _mapper.Map<ContactMeReturnVO>(entity);

                _handleFileService.SaveFileUniqueBase64AtDirectory(
                    new FileBase64Model
                    {
                        FileBase64 = model.FileAttachment == null ? null : model.FileAttachment.FileBase64,
                        Name = ConstantsFileService.ContactMeFileName
                    },
                    ConstantsFileService.ContactMeFileEntity,
                    ConstantsFileService.ContactMeFileName,
                    resp.Id.ToString());

                resp.FileAttachment =
                    _handleFileService.GetUrlFileUniqueAtDirectory(
                        ConstantsFileService.ContactMeFileEntity,
                        resp.Id.ToString(),
                        ConstantsFileService.ContactMeFileName);

                return resp;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao inserir contato", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao inserir contato", ex);
            }
        }

        public async Task<ContactMeReturnVO> RemoveAsync(int? id)
        {
            try
            {
                id.IsValidId();

                ContactMe contact =
                    await _contactMeRepo.RemoveAsync(id.Value);

                return
                    _mapper.Map<ContactMeReturnVO>(contact);
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao remover contato do id {id}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao remover contato do id {id}", ex);
            }
        }

        public async Task<ContactMeReturnVO> UpdateAsync(int? id, SaveContactMeVO model, PublicPageRequestDataVO publicPageRequestData = null, RequestDataVO requestData = null)
        {
            try
            {
                id.IsValidId();

                await ValidConsistenceDataAsync(model, publicPageRequestData, requestData);

                ContactMe entity = _mapper.Map<ContactMe>(model);
                entity.Id = id.Value;

                if (requestData != null)
                {
                    var portfolioId = await _userRepo.GetIdPortfolioSelectedCurrentAsync(requestData.User.Id);
                    if (portfolioId <= 0)
                        throw new ValidException($"Por favor selecione um portfolio para vincular este contato {requestData.User.Username}");

                    entity.PortfolioId = portfolioId;
                }

                entity = await _contactMeRepo.UpdateAsync(entity);

                ContactMeReturnVO resp =
                    _mapper.Map<ContactMeReturnVO>(entity);

                _handleFileService.UpdateFileUniqueBase64AtDirectory(
                    new FileBase64Model
                    {
                        FileBase64 = model.FileAttachment == null ? null : model.FileAttachment.FileBase64,
                        Name = ConstantsFileService.ContactMeFileName
                    },
                    ConstantsFileService.ContactMeFileEntity,
                    ConstantsFileService.ContactMeFileName,
                    resp.Id.ToString());

                resp.FileAttachment =
                   _handleFileService.GetUrlFileUniqueAtDirectory(
                       ConstantsFileService.ContactMeFileEntity,
                       resp.Id.ToString(),
                       ConstantsFileService.ContactMeFileName);

                return resp;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao editar contato do id {id}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao editar contato do id {id}", ex);
            }
        }

        private async Task ValidConsistenceDataAsync(SaveContactMeVO model, PublicPageRequestDataVO publicPageRequestData = null, RequestDataVO requestData = null)
        {
            try
            {
                if (model.PortfolioId != null && requestData != null && requestData.User != null)
                    await _portfolioService.ValidPermissionAccessAsync(model.PortfolioId.Value, requestData.User.Id);
                else if (publicPageRequestData != null && publicPageRequestData.KeyAccess != null)
                {
                    int? idPort = await _portfolioRepo.GetIdByKeyAccessAsync(publicPageRequestData.KeyAccess);
                    if (idPort == null)
                        throw new ValidException($"Não foi encontrado um portfolio com a key informada");

                    model.PortfolioId = idPort;
                    return;
                }
                throw new ValidException($"Não foi informado dados para o portfolio do contato solicitado");
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao consistir dados de contato", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao consistir dados de contato", ex);
            }
        }

        private List<ContactMeReturnVO> GetFilesContactMe(List<ContactMeReturnVO> items)
        {
            try
            {
                foreach (ContactMeReturnVO item in items)
                {
                    item.FileAttachment =
                        _handleFileService.GetUrlFileUniqueAtDirectory(
                            ConstantsFileService.ContactMeFileEntity,
                            item.Id.ToString(),
                            ConstantsFileService.ContactMeFileName);
                }
                return items;
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao pegar imagens de contatos {items.Count}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao pegar imagens de contatos", ex);
            }
        }
    }
}
