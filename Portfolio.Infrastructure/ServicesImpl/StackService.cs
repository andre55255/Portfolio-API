using AutoMapper;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.Stacks;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;
using Portfolio.Core.RepositoriesInterface.Sql;
using Portfolio.Core.ServicesInterface;
using Portfolio.HandleFiles.Models;
using Portfolio.Helpers;

namespace Portfolio.Infrastructure.ServicesImpl
{
    public class StackService : IStackService
    {
        private readonly IStackRepository _stackRepo;
        private readonly IPortfolioConfigRepository _portfolioRepo;
        private readonly IPortfolioConfigService _portfolioConfigService;
        private readonly IHandleFileService _handleFileService;
        private readonly IMapper _mapper;
        private readonly ILogService _logService;

        public StackService(IStackRepository stackRepo, IPortfolioConfigRepository portfolioRepo, IPortfolioConfigService portfolioConfigService, IMapper mapper, ILogService logService, IHandleFileService handleFileService)
        {
            _stackRepo = stackRepo;
            _portfolioRepo = portfolioRepo;
            _portfolioConfigService = portfolioConfigService;
            _mapper = mapper;
            _logService = logService;
            _handleFileService = handleFileService;
        }

        public async Task<ListAllEntityVO<StackReturnVO>> GetAllAsync(RequestDataVO requestData, int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<Stack> listEntities =
                    await _stackRepo.GetAllAsync(limit, page, requestData.User.Id);

                ListAllEntityVO<StackReturnVO> resp =
                    _mapper.Map<ListAllEntityVO<StackReturnVO>>(listEntities);

                resp.Items = GetFilesStacks(resp.Items);
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
                _logService.Write($"Falha inesperada ao listar stacks", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar stacks", ex);
            }
        }

        public async Task<StackReturnVO> GetByIdAsync(int? id)
        {
            try
            {
                id.IsValidId();

                Stack save = await _stackRepo.GetByIdAsync(id.Value);
                if (save == null)
                    throw new NotFoundException($"Não foi encontrado uma stack com o id {id}");

                StackReturnVO resp = _mapper.Map<StackReturnVO>(save);

                resp.Image =
                    _handleFileService.GetUrlFileUniqueAtDirectory(
                        ConstantsFileService.StackFileEntity,
                        save.Id.ToString(),
                        ConstantsFileService.StackFileName);

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
                _logService.Write($"Falha inesperada ao listar stack pelo id {id}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar stack pelo id {id}", ex);
            }
        }

        public async Task<List<StackReturnVO>> GetStacksByKeyAcessPortfolioAsync(string keyAccess)
        {
            try
            {
                int? idPortfolio =
                    await _portfolioRepo.GetIdByKeyAccessAsync(keyAccess);

                if (idPortfolio == null || idPortfolio.Value <= 0)
                    throw new ValidException($"Ñão foi encontrado uma stack com a key informada, verifique");

                List<Stack> listEntities =
                    await _stackRepo.GetAllByPortfolioIdAsync(idPortfolio.Value);

                List<StackReturnVO> resp =
                    _mapper.Map<List<StackReturnVO>>(listEntities);

                resp = GetFilesStacks(resp);
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
                _logService.Write($"Falha inesperada ao listar stacks pela keyAccess: {keyAccess}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar stacks pela key", ex);
            }
        }

        public async Task<StackReturnVO> InsertAsync(SaveStackVO model, RequestDataVO request)
        {
            try
            {
                await ValidConsistenceDataAsync(model, request);

                Stack entity = _mapper.Map<Stack>(model);

                entity = await _stackRepo.InsertAsync(entity);
                StackReturnVO resp = _mapper.Map<StackReturnVO>(entity);

                _handleFileService.SaveFileUniqueBase64AtDirectory(
                   new FileBase64Model
                   {
                       FileBase64 = model.Image.FileBase64,
                       Name = ConstantsFileService.StackFileName
                   },
                   ConstantsFileService.StackFileEntity,
                   ConstantsFileService.StackFileName,
                   resp.Id.ToString());

                resp.Image =
                    _handleFileService.GetUrlFileUniqueAtDirectory(
                        ConstantsFileService.StackFileEntity,
                        resp.Id.ToString(),
                        ConstantsFileService.StackFileName);

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
                _logService.Write($"Falha inesperada ao inserir stack", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao inserir stack", ex);
            }
        }

        public async Task<StackReturnVO> RemoveAsync(int? id)
        {
            try
            {
                id.IsValidId();

                Stack save = await _stackRepo.RemoveAsync(id.Value);

                return _mapper.Map<StackReturnVO>(save);
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
                _logService.Write($"Falha inesperada ao remover stack pelo id {id}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao remover stack pelo id {id}", ex);
            }
        }

        public async Task<StackReturnVO> UpdateAsync(int? id, SaveStackVO model, RequestDataVO request)
        {
            try
            {
                id.IsValidId();

                await ValidConsistenceDataAsync(model, request);

                Stack entity = _mapper.Map<Stack>(model);
                entity.Id = id.Value;

                entity = await _stackRepo.UpdateAsync(entity);
                StackReturnVO resp = _mapper.Map<StackReturnVO>(entity);

                _handleFileService.UpdateFileUniqueBase64AtDirectory(
                   new FileBase64Model
                   {
                       FileBase64 = model.Image.FileBase64,
                       Name = ConstantsFileService.StackFileName
                   },
                   ConstantsFileService.StackFileEntity,
                   ConstantsFileService.StackFileName,
                   resp.Id.ToString());

                resp.Image =
                   _handleFileService.GetUrlFileUniqueAtDirectory(
                       ConstantsFileService.StackFileEntity,
                       resp.Id.ToString(),
                       ConstantsFileService.StackFileName);

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
                _logService.Write($"Falha inesperada ao editar stack", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao editar stack", ex);
            }
        }

        private async Task ValidConsistenceDataAsync(SaveStackVO model, RequestDataVO request)
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
                _logService.Write($"Falha inesperada ao consistir dados de stack", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao consistir dados de stack", ex);
            }

        }

        private List<StackReturnVO> GetFilesStacks(List<StackReturnVO> items)
        {
            try
            {
                foreach (StackReturnVO item in items)
                {
                    item.Image =
                        _handleFileService.GetUrlFileUniqueAtDirectory(
                            ConstantsFileService.StackFileEntity,
                            item.Id.ToString(),
                            ConstantsFileService.StackFileName);
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
