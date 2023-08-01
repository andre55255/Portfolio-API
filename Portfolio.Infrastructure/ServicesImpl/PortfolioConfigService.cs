using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.Portfolio;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;
using Portfolio.Core.RepositoriesInterface.Sql;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;

namespace Portfolio.Infrastructure.ServicesImpl
{
    public class PortfolioConfigService : IPortfolioConfigService
    {
        private readonly IPortfolioConfigRepository _portfolioRepo;
        private readonly IUserRepository _userRepo;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public PortfolioConfigService(IPortfolioConfigRepository portfolioRepo, ILogService logService, IMapper mapper, IUserRepository userRepo)
        {
            _portfolioRepo = portfolioRepo;
            _logService = logService;
            _mapper = mapper;
            _userRepo = userRepo;
        }

        public async Task<ListAllEntityVO<PortfolioReturnVO>> GetAllAsync(int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<PortfolioConfig> listEntities = 
                    await _portfolioRepo.GetAllAsync(limit, page);

                return
                    _mapper.Map<ListAllEntityVO<PortfolioReturnVO>>(listEntities);
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
                _logService.Write($"Falha inesperada ao listar portfolios", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar portfolios", ex);
            }
        }

        public async Task<PortfolioReturnVO> GetByIdAsync(int id)
        {
            try
            {
                PortfolioConfig save = await _portfolioRepo.GetByIdAsync(id);
                if (save == null)
                    throw new NotFoundException($"Não foi encontrado um portfolio com o id {id}");

                return _mapper.Map<PortfolioReturnVO>(save);
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
                _logService.Write($"Falha inesperada ao listar portfolio pelo id {id}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar portfolio pelo id {id}", ex);
            }
        }

        public async Task<PortfolioReturnVO> GetByKeyAccessAsync(string keyAccess)
        {
            try
            {
                PortfolioConfig save = await _portfolioRepo.GetByKeyAccessAsync(keyAccess);
                if (save == null)
                    throw new NotFoundException($"Não foi encontrado um portfolio com a key informada");

                return _mapper.Map<PortfolioReturnVO>(save);
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
                _logService.Write($"Falha inesperada ao listar portfolio pela key {keyAccess}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar portfolio pela key", ex);
            }
        }

        public async Task<PortfolioReturnVO> InsertAsync(SavePortfolioVO model, List<int> usersIdsAsociates)
        {
            try
            {
                await _userRepo.ValidUsersIdsAsync(model.UsersIds);

                model.KeyAccess = string.IsNullOrEmpty(model.KeyAccess) ? Guid.NewGuid().ToString("N").ToLower() : model.KeyAccess;

                PortfolioConfig portfolioEntity = _mapper.Map<PortfolioConfig>(model);

                portfolioEntity = await _portfolioRepo.InsertAsync(portfolioEntity, usersIdsAsociates);
                return _mapper.Map<PortfolioReturnVO>(portfolioEntity);
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
                _logService.Write($"Falha inesperada ao inserir portfolio", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao inserir portfolio", ex);
            }
        }

        public async Task<PortfolioReturnVO> RemoveAsync(int id)
        {
            try
            {
                PortfolioConfig save = await _portfolioRepo.RemoveAsync(id);

                return _mapper.Map<PortfolioReturnVO>(save);
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
                _logService.Write($"Falha inesperada ao remover portfolio pelo id {id}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao remover portfolio pelo id {id}", ex);
            }
        }

        public async Task<PortfolioReturnVO> UpdateAsync(int id, SavePortfolioVO model, List<int> usersIdsAsociates)
        {
            try
            {
                await _userRepo.ValidUsersIdsAsync(model.UsersIds);

                model.KeyAccess = string.IsNullOrEmpty(model.KeyAccess) ? Guid.NewGuid().ToString("N").ToLower() : model.KeyAccess;

                PortfolioConfig portfolioEntity = _mapper.Map<PortfolioConfig>(model);
                portfolioEntity.Id = id;

                portfolioEntity = await _portfolioRepo.UpdateAsync(portfolioEntity, usersIdsAsociates);
                return _mapper.Map<PortfolioReturnVO>(portfolioEntity);
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
                _logService.Write($"Falha inesperada ao editar portfolio pelo id {id}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao editar portfolio pelo id {id}", ex);
            }
        }
    }
}
