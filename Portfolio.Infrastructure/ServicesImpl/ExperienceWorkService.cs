using AutoMapper;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.ExperienceWork;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;
using Portfolio.Core.RepositoriesInterface.Sql;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;

namespace Portfolio.Infrastructure.ServicesImpl
{
    public class ExperienceWorkService : IExperienceWorkService
    {
        private readonly IExperienceWorkRepository _experienceWorkRepo;
        private readonly IPortfolioConfigRepository _portfolioRepo;
        private readonly IGenericTypeRepository _genericTypeRepo;
        private readonly IMapper _mapper;
        private readonly ILogService _logService;

        public ExperienceWorkService(IExperienceWorkRepository experienceWorkRepo, IPortfolioConfigRepository portfolioRepo, IGenericTypeRepository genericTypeRepo, IMapper mapper, ILogService logService)
        {
            _experienceWorkRepo = experienceWorkRepo;
            _portfolioRepo = portfolioRepo;
            _genericTypeRepo = genericTypeRepo;
            _mapper = mapper;
            _logService = logService;
        }

        public async Task<ListAllEntityVO<ExperienceWorkReturnVO>> GetAllAsync(int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<ExperienceWork> listEntities =
                    await _experienceWorkRepo.GetAllAsync(limit, page);

                return
                    _mapper.Map<ListAllEntityVO<ExperienceWorkReturnVO>>(listEntities);
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
                _logService.Write($"Falha inesperada ao listar experiências profissionais", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar experiências profissionais", ex);
            }
        }

        public async Task<ExperienceWorkReturnVO> GetByIdAsync(int? id)
        {
            try
            {
                id.IsValidId();

                ExperienceWork save = await _experienceWorkRepo.GetByIdAsync(id.Value);
                if (save == null)
                    throw new NotFoundException($"Não foi encontrado uma experiência profissional com o id {id}");

                return _mapper.Map<ExperienceWorkReturnVO>(save);
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
                _logService.Write($"Falha inesperada ao listar experiência profissional pelo id {id}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar experiência profissional pelo id {id}", ex);
            }
        }

        public async Task<List<ExperienceWorkReturnVO>> GetExperiencesWorkdsByKeyAcessPortfolioAsync(string keyAccess)
        {
            try
            {
                int? idPortfolio =
                    await _portfolioRepo.GetIdByKeyAccessAsync(keyAccess);

                if (idPortfolio == null || idPortfolio.Value <= 0)
                    throw new ValidException($"Ñão foi encontrado um portfolio com a key informada, verifique");

                List<ExperienceWork> listEntities =
                    await _experienceWorkRepo.GetAllByPortfolioIdAsync(idPortfolio.Value);

                return
                    _mapper.Map<List<ExperienceWorkReturnVO>>(listEntities);
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (ConflictException ex)
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
                _logService.Write($"Falha inesperada ao listar experiência profissional pela keyAccess: {keyAccess}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar experiência profissional pela key", ex);
            }
        }

        public async Task<ExperienceWorkReturnVO> InsertAsync(SaveExperienceWorkVO model, RequestDataVO request)
        {
            try
            {
                await ValidConsistenceDataAsync(model, request);

                ExperienceWork entity = _mapper.Map<ExperienceWork>(model);

                entity = await _experienceWorkRepo.InsertAsync(entity);
                return _mapper.Map<ExperienceWorkReturnVO>(entity);
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (ConflictException ex)
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
                _logService.Write($"Falha inesperada ao inserir experiência profissional", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao inserir experiência profissional", ex);
            }
        }

        public async Task<ExperienceWorkReturnVO> RemoveAsync(int? id)
        {
            try
            {
                id.IsValidId();

                ExperienceWork save = await _experienceWorkRepo.RemoveAsync(id.Value);

                return _mapper.Map<ExperienceWorkReturnVO>(save);
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
                _logService.Write($"Falha inesperada ao remover experiência profissional pelo id {id}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao remover experiência profissional pelo id {id}", ex);
            }
        }

        public async Task<ExperienceWorkReturnVO> UpdateAsync(int? id, SaveExperienceWorkVO model, RequestDataVO request)
        {
            try
            {
                id.IsValidId();

                await ValidConsistenceDataAsync(model, request);

                ExperienceWork entity = _mapper.Map<ExperienceWork>(model);
                entity.Id = id.Value;

                entity = await _experienceWorkRepo.UpdateAsync(entity);
                return _mapper.Map<ExperienceWorkReturnVO>(entity);
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (ConflictException ex)
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
                _logService.Write($"Falha inesperada ao inserir experiência profissional", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao inserir experiência profissional", ex);
            }
        }

        private async Task ValidConsistenceDataAsync(SaveExperienceWorkVO model, RequestDataVO request)
        {
            try
            {
                bool isPermissionAccessPortfolio =
                    await _portfolioRepo.IsPermissionAccessByUserIdAsync(model.PortfolioId, request.User.Id);

                if (!isPermissionAccessPortfolio)
                    throw new ValidException($"Acesso negado para incluir/editar itens do portfolio {model.PortfolioId}");

                bool isPortfolioExist =
                    await _portfolioRepo.IsExistByIdAsync(model.PortfolioId);

                if (!isPortfolioExist)
                    throw new ValidException($"Não foi encontrado um portfolio com o id {model.PortfolioId}");

                List<GenericType> statusList = await _genericTypeRepo.GetByTokenAsync(TokensGenericType.ExperienceWorkStatus);
                if (statusList == null)
                    throw new ValidException($"Nenhum status listado da base de dados, verifique");

                bool isStatusExist = statusList.Where(x => x.Id == model.JourneyWorkStatusId)
                                               .Any();

                if (!isStatusExist)
                    throw new ValidException($"Não foi encontrado um status com o id {model.JourneyWorkStatusId}");
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
                _logService.Write($"Falha inesperada ao consistir dados de experiência", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao consistir dados de experiência", ex);
            }

        }
    }
}
