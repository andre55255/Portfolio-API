using AutoMapper;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.ExperienceEducation;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;
using Portfolio.Core.RepositoriesInterface.Sql;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;

namespace Portfolio.Infrastructure.ServicesImpl
{
    public class ExperienceEducationService : IExperienceEducationService
    {
        private readonly IExperienceEducationRepository _experienceEducationRepo;
        private readonly IPortfolioConfigService _portfolioService;
        private readonly IPortfolioConfigRepository _portfolioRepo;
        private readonly IGenericTypeRepository _genericTypeRepo;
        private readonly IMapper _mapper;
        private readonly ILogService _logService;

        public ExperienceEducationService(IExperienceEducationRepository experienceEducationRepo, IPortfolioConfigRepository portfolioRepo, IGenericTypeRepository genericTypeRepo, IMapper mapper, ILogService logService, IPortfolioConfigService portfolioService)
        {
            _experienceEducationRepo = experienceEducationRepo;
            _portfolioRepo = portfolioRepo;
            _genericTypeRepo = genericTypeRepo;
            _mapper = mapper;
            _logService = logService;
            _portfolioService = portfolioService;
        }

        public async Task<ListAllEntityVO<ExperienceEducationReturnVO>> GetAllAsync(int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<ExperienceEducation> listEntities =
                    await _experienceEducationRepo.GetAllAsync(limit, page);

                return
                    _mapper.Map<ListAllEntityVO<ExperienceEducationReturnVO>>(listEntities);
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
                _logService.Write($"Falha inesperada ao listar experiências educacionais", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar experiências educacionais", ex);
            }
        }

        public async Task<ExperienceEducationReturnVO> GetByIdAsync(int? id)
        {
            try
            {
                id.IsValidId();

                ExperienceEducation save = await _experienceEducationRepo.GetByIdAsync(id.Value);
                if (save == null)
                    throw new NotFoundException($"Não foi encontrado uma experiência educacional com o id {id}");

                return _mapper.Map<ExperienceEducationReturnVO>(save);
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
                _logService.Write($"Falha inesperada ao listar experiência educacional pelo id {id}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar experiência educacional pelo id {id}", ex);
            }
        }

        public async Task<List<ExperienceEducationReturnVO>> GetExperiencesEducationByKeyAcessPortfolioAsync(string keyAccess)
        {
            try
            {
                int? idPortfolio =
                    await _portfolioRepo.GetIdByKeyAccessAsync(keyAccess);

                if (idPortfolio == null || idPortfolio.Value <= 0)
                    throw new ValidException($"Ñão foi encontrado um portfolio com a key informada, verifique");

                List<ExperienceEducation> listEntities =
                    await _experienceEducationRepo.GetAllByPortfolioIdAsync(idPortfolio.Value);

                return
                    _mapper.Map<List<ExperienceEducationReturnVO>>(listEntities);
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
                _logService.Write($"Falha inesperada ao listar experiência educacional pela keyAccess: {keyAccess}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar experiência educacional pela key", ex);
            }
        }

        public async Task<ExperienceEducationReturnVO> InsertAsync(SaveExperienceEducationVO model, RequestDataVO request)
        {
            try
            {
                await ValidConsistenceDataAsync(model, request);

                ExperienceEducation entity = _mapper.Map<ExperienceEducation>(model);

                entity = await _experienceEducationRepo.InsertAsync(entity);
                return _mapper.Map<ExperienceEducationReturnVO>(entity);
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
                _logService.Write($"Falha inesperada ao inserir experiência educacional", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao inserir experiência educacional", ex);
            }
        }

        public async Task<ExperienceEducationReturnVO> RemoveAsync(int? id)
        {
            try
            {
                id.IsValidId();

                ExperienceEducation save = await _experienceEducationRepo.RemoveAsync(id.Value);

                return _mapper.Map<ExperienceEducationReturnVO>(save);
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
                _logService.Write($"Falha inesperada ao remover experiência educacional pelo id {id}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao remover experiência educacional pelo id {id}", ex);
            }
        }

        public async Task<ExperienceEducationReturnVO> UpdateAsync(int? id, SaveExperienceEducationVO model, RequestDataVO request)
        {
            try
            {
                id.IsValidId();

                await ValidConsistenceDataAsync(model, request);

                ExperienceEducation entity = _mapper.Map<ExperienceEducation>(model);
                entity.Id = id.Value;

                entity = await _experienceEducationRepo.UpdateAsync(entity);
                return _mapper.Map<ExperienceEducationReturnVO>(entity);
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
                _logService.Write($"Falha inesperada ao inserir experiência educacional", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao inserir experiência educacional", ex);
            }
        }

        private async Task ValidConsistenceDataAsync(SaveExperienceEducationVO model, RequestDataVO request)
        {
            try
            {
                await _portfolioService.ValidPermissionAccessAsync(model.PortfolioId, request.User.Id);

                List<GenericType> statusList = await _genericTypeRepo.GetByTokenAsync(TokensGenericType.EducationStatus);
                if (statusList == null)
                    throw new ValidException($"Nenhum status listado da base de dados, verifique");

                bool isStatusExist = statusList.Where(x => x.Id == model.JourneyEducationStatusId)
                                               .Any();

                if (!isStatusExist)
                    throw new ValidException($"Não foi encontrado um status com o id {model.JourneyEducationStatusId}");
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
