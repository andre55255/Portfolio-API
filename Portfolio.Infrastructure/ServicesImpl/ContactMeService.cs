using AutoMapper;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.ContactMe;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;
using Portfolio.Core.RepositoriesInterface.Sql;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;

namespace Portfolio.Infrastructure.ServicesImpl
{
    public class ContactMeService : IContactMeService
    {
        private readonly IContactMeRepository _contactMeRepo;
        private readonly IMapper _mapper;
        private readonly ILogService _logService;
        private readonly IPortfolioConfigService _portfolioService;
        private readonly IPortfolioConfigRepository _portfolioRepo;

        public ContactMeService(IContactMeRepository contactMeRepo, IMapper mapper, ILogService logService, IPortfolioConfigService portfolioService, IPortfolioConfigRepository portfolioRepo)
        {
            _contactMeRepo = contactMeRepo;
            _mapper = mapper;
            _logService = logService;
            _portfolioService = portfolioService;
            _portfolioRepo = portfolioRepo;
        }

        public async Task<ListAllEntityVO<ContactMeReturnVO>> GetAllAsync(int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<ContactMe> listEntities =
                    await _contactMeRepo.GetAllAsync(limit, page);

                return
                    _mapper.Map<ListAllEntityVO<ContactMeReturnVO>>(listEntities);
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

                return
                    _mapper.Map<List<ContactMeReturnVO>>(listEntities);
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

                return
                    _mapper.Map<ContactMeReturnVO>(entity);
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

                entity = await _contactMeRepo.InsertAsync(entity);

                return
                    _mapper.Map<ContactMeReturnVO>(entity);
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

                entity = await _contactMeRepo.UpdateAsync(entity);

                return
                    _mapper.Map<ContactMeReturnVO>(entity);
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
    }
}
