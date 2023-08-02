using AutoMapper;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.Project;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;
using Portfolio.Core.RepositoriesInterface.Sql;
using Portfolio.Core.ServicesInterface;
using Portfolio.HandleFiles.Models;
using Portfolio.Helpers;

namespace Portfolio.Infrastructure.ServicesImpl
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepo;
        private readonly IPortfolioConfigRepository _portfolioRepo;
        private readonly IHandleFileService _handleFileService;
        private readonly IPortfolioConfigService _portfolioConfigService;
        private readonly IMapper _mapper;
        private readonly ILogService _logService;

        public ProjectService(IProjectRepository projectRepo, IPortfolioConfigRepository portfolioRepo, IPortfolioConfigService portfolioConfigService, IMapper mapper, ILogService logService, IHandleFileService handleFileService)
        {
            _projectRepo = projectRepo;
            _portfolioRepo = portfolioRepo;
            _portfolioConfigService = portfolioConfigService;
            _mapper = mapper;
            _logService = logService;
            _handleFileService = handleFileService;
        }

        public async Task<ListAllEntityVO<ProjectReturnVO>> GetAllAsync(int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<Project> listEntities =
                    await _projectRepo.GetAllAsync(limit, page);

                ListAllEntityVO<ProjectReturnVO> resp =
                    _mapper.Map<ListAllEntityVO<ProjectReturnVO>>(listEntities);

                resp.Items = GetFilesProjects(resp.Items);
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
                _logService.Write($"Falha inesperada ao listar projetos", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar projetos", ex);
            }
        }

        public async Task<ProjectReturnVO> GetByIdAsync(int? id)
        {
            try
            {
                id.IsValidId();

                Project save = await _projectRepo.GetByIdAsync(id.Value);
                if (save == null)
                    throw new NotFoundException($"Não foi encontrado um projeto com o id {id}");

                ProjectReturnVO resp = _mapper.Map<ProjectReturnVO>(save);

                resp.FileThumbImg =
                    _handleFileService.GetUrlFileUniqueAtDirectory(
                        ConstantsFileService.ProjectFileEntity,
                        resp.Id.ToString(),
                        ConstantsFileService.ProjectFileName);

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
                _logService.Write($"Falha inesperada ao listar projeto pelo id {id}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar projeto pelo id {id}", ex);
            }
        }

        public async Task<List<ProjectReturnVO>> GetProjectsByKeyAcessPortfolioAsync(string keyAccess)
        {
            try
            {
                int? idPortfolio =
                    await _portfolioRepo.GetIdByKeyAccessAsync(keyAccess);

                if (idPortfolio == null || idPortfolio.Value <= 0)
                    throw new ValidException($"Ñão foi encontrado um portfolio com a key informada, verifique");

                List<Project> listEntities =
                    await _projectRepo.GetAllByPortfolioIdAsync(idPortfolio.Value);

                List<ProjectReturnVO> resp =
                    _mapper.Map<List<ProjectReturnVO>>(listEntities);

                resp = GetFilesProjects(resp);
                return resp;
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
                _logService.Write($"Falha inesperada ao listar projeto pela keyAccess: {keyAccess}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar projeto pela key", ex);
            }
        }

        public async Task<ProjectReturnVO> InsertAsync(SaveProjectVO model, RequestDataVO request)
        {
            try
            {
                await ValidConsistenceDataAsync(model, request);

                Project entity = _mapper.Map<Project>(model);

                entity = await _projectRepo.InsertAsync(entity);
                ProjectReturnVO resp = _mapper.Map<ProjectReturnVO>(entity);

                _handleFileService.SaveFileUniqueBase64AtDirectory(
                    new FileBase64Model
                    {
                        FileBase64 = model.FileThumbImg.FileBase64,
                        Name = ConstantsFileService.ProjectFileName
                    },
                    ConstantsFileService.ProjectFileEntity,
                    ConstantsFileService.ProjectFileName,
                    entity.Id.ToString());

                resp.FileThumbImg =
                    _handleFileService.GetUrlFileUniqueAtDirectory(
                        ConstantsFileService.ProjectFileEntity,
                        entity.Id.ToString(),
                        ConstantsFileService.ProjectFileName);

                return resp;
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
                _logService.Write($"Falha inesperada ao inserir projeto", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao inserir projeto", ex);
            }
        }

        public async Task<ProjectReturnVO> RemoveAsync(int? id)
        {
            try
            {
                id.IsValidId();

                Project save = await _projectRepo.RemoveAsync(id.Value);

                return _mapper.Map<ProjectReturnVO>(save);
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
                _logService.Write($"Falha inesperada ao remover projeto pelo id {id}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao remover projeto pelo id {id}", ex);
            }
        }

        public async Task<ProjectReturnVO> UpdateAsync(int? id, SaveProjectVO model, RequestDataVO request)
        {
            try
            {
                id.IsValidId();

                await ValidConsistenceDataAsync(model, request);

                Project entity = _mapper.Map<Project>(model);
                entity.Id = id.Value;

                entity = await _projectRepo.UpdateAsync(entity);
                ProjectReturnVO resp = _mapper.Map<ProjectReturnVO>(entity);

                _handleFileService.UpdateFileUniqueBase64AtDirectory(
                    new FileBase64Model
                    {
                        FileBase64 = model.FileThumbImg.FileBase64,
                        Name = ConstantsFileService.ProjectFileName
                    },
                    ConstantsFileService.ProjectFileEntity,
                    ConstantsFileService.ProjectFileName,
                    entity.Id.ToString());

                resp.FileThumbImg =
                    _handleFileService.GetUrlFileUniqueAtDirectory(
                        ConstantsFileService.ProjectFileEntity,
                        entity.Id.ToString(),
                        ConstantsFileService.ProjectFileName);

                return resp;
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
                _logService.Write($"Falha inesperada ao editar projeto", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao editar projeto", ex);
            }
        }

        private async Task ValidConsistenceDataAsync(SaveProjectVO model, RequestDataVO request)
        {
            try
            {
                await _portfolioConfigService.ValidPermissionAccessAsync(model.PortfolioId, request.User.Id);
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
                _logService.Write($"Falha inesperada ao consistir dados de projeto", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao consistir dados de projeto", ex);
            }

        }

        private List<ProjectReturnVO> GetFilesProjects(List<ProjectReturnVO> items)
        {
            try
            {
                foreach (ProjectReturnVO item in items)
                {
                    item.FileThumbImg =
                        _handleFileService.GetUrlFileUniqueAtDirectory(
                            ConstantsFileService.ProjectFileEntity,
                            item.Id.ToString(),
                            ConstantsFileService.ProjectFileName);
                }
                return items;
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar imagens de projetos", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar imagens de projetos", ex);
            }
        }
    }
}
