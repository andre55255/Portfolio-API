using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.Portfolio;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;
using Portfolio.Core.RepositoriesInterface.Sql;
using Portfolio.Core.ServicesInterface;
using Portfolio.HandleFiles.Models;
using Portfolio.Helpers;
using System.Collections.Generic;

namespace Portfolio.Infrastructure.ServicesImpl
{
    public class PortfolioConfigService : IPortfolioConfigService
    {
        private readonly IPortfolioConfigRepository _portfolioRepo;
        private readonly IHandleFileService _handleFileService;
        private readonly IUserRepository _userRepo;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public PortfolioConfigService(IPortfolioConfigRepository portfolioRepo, ILogService logService, IMapper mapper, IUserRepository userRepo, IHandleFileService handleFileService)
        {
            _portfolioRepo = portfolioRepo;
            _logService = logService;
            _mapper = mapper;
            _userRepo = userRepo;
            _handleFileService = handleFileService;
        }

        public async Task<ListAllEntityVO<PortfolioReturnVO>> GetAllAsync(int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<PortfolioConfig> listEntities = 
                    await _portfolioRepo.GetAllAsync(limit, page);

                ListAllEntityVO<PortfolioReturnVO> resp =
                    _mapper.Map<ListAllEntityVO<PortfolioReturnVO>>(listEntities);

                resp.Items = GetFilesPortfolio(resp.Items);
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
                _logService.Write($"Falha inesperada ao listar portfolios", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar portfolios", ex);
            }
        }

        public async Task<ListAllEntityVO<PortfolioReturnVO>> GetAllAsync(int? limit, int? page, RequestDataVO requestData)
        {
            try
            {
                ListAllEntityVO<PortfolioConfig> listEntities =
                    await _portfolioRepo.GetAllAsync(limit, page, requestData.User.Id);

                ListAllEntityVO<PortfolioReturnVO> resp =
                    _mapper.Map<ListAllEntityVO<PortfolioReturnVO>>(listEntities);

                resp.Items = GetFilesPortfolio(resp.Items);
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

                PortfolioReturnVO resp = _mapper.Map<PortfolioReturnVO>(save);

                resp.ProfileImage =
                    _handleFileService.GetUrlFileUniqueAtDirectory(
                        ConstantsFileService.PortfolioProfileEntity,
                        resp.Id.ToString(),
                        ConstantsFileService.PortfolioProfileImageName);

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

                PortfolioReturnVO resp = _mapper.Map<PortfolioReturnVO>(save);

                resp.ProfileImage =
                    _handleFileService.GetUrlFileUniqueAtDirectory(
                        ConstantsFileService.PortfolioProfileEntity,
                        save.Id.ToString(),
                        ConstantsFileService.PortfolioProfileImageName);

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
                _logService.Write($"Falha inesperada ao listar portfolio pela key {keyAccess}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar portfolio pela key", ex);
            }
        }

        public async Task<List<SelectObjectVO>> GetPortfoliosToSelectObjectAsync(RequestDataVO requestData)
        {
            try
            {
                return await _portfolioRepo.GetAllPortfoliosToSelectObjectByUserIdAsync(requestData.User.Id);
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
                _logService.Write($"Falha inesperada ao listar portfolios para seleção", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar portfolios para seleção", ex);
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

                _handleFileService.SaveFileUniqueBase64AtDirectory(new FileBase64Model
                {
                    Name = ConstantsFileService.PortfolioProfileImageName,
                    FileBase64 = model.ProfileImage.Name
                },
                ConstantsFileService.PortfolioProfileEntity,
                ConstantsFileService.PortfolioProfileImageName,
                portfolioEntity.Id.ToString());

                PortfolioReturnVO resp = _mapper.Map<PortfolioReturnVO>(portfolioEntity);

                resp.ProfileImage =
                    _handleFileService.GetUrlFileUniqueAtDirectory(
                        ConstantsFileService.PortfolioProfileEntity,
                        resp.Id.ToString(),
                        ConstantsFileService.PortfolioProfileImageName);

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

                _handleFileService.UpdateFileUniqueBase64AtDirectory(new FileBase64Model
                {
                    Name = ConstantsFileService.PortfolioProfileImageName,
                    FileBase64 = model.ProfileImage.FileBase64
                },
                ConstantsFileService.PortfolioProfileEntity,
                ConstantsFileService.PortfolioProfileImageName,
                portfolioEntity.Id.ToString());

                PortfolioReturnVO resp = _mapper.Map<PortfolioReturnVO>(portfolioEntity);

                resp.ProfileImage =
                   _handleFileService.GetUrlFileUniqueAtDirectory(
                       ConstantsFileService.PortfolioProfileEntity,
                       resp.Id.ToString(),
                       ConstantsFileService.PortfolioProfileImageName);

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
                _logService.Write($"Falha inesperada ao editar portfolio pelo id {id}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao editar portfolio pelo id {id}", ex);
            }
        }

        public async Task ValidPermissionAccessAsync(int portfolioId, int userId)
        {
            try
            {
                bool isPermissionAccessPortfolio =
                   await _portfolioRepo.IsPermissionAccessByUserIdAsync(portfolioId, userId);

                if (!isPermissionAccessPortfolio)
                    throw new ValidException($"Acesso negado para incluir/editar itens do portfolio {portfolioId}");

                bool isPortfolioExist =
                    await _portfolioRepo.IsExistByIdAsync(portfolioId);

                if (!isPortfolioExist)
                    throw new ValidException($"Não foi encontrado um portfolio com o id {portfolioId}");
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
                _logService.Write($"Falha inesperada ao validar acesso ao portfolio {portfolioId} pelo usuário {userId}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada na validação de acesso ao portfolio", ex);
            }
        }

        private List<PortfolioReturnVO> GetFilesPortfolio(List<PortfolioReturnVO> items)
        {
            try
            {
                foreach (PortfolioReturnVO item in items)
                {
                    item.ProfileImage =
                        _handleFileService.GetUrlFileUniqueAtDirectory(
                            ConstantsFileService.PortfolioProfileEntity,
                            item.Id.ToString(),
                            ConstantsFileService.PortfolioProfileImageName);
                }
                return items;
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar imagens de portfolios", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar imagens de portfolios", ex);
            }
        }
    }
}
