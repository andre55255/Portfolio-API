﻿using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Core.RepositoriesInterface.Sql
{
    public interface IPortfolioConfigRepository
    {
        public Task<PortfolioConfig> InsertAsync(PortfolioConfig model, List<int> usersIdsAsociates);
        public Task<PortfolioConfig> UpdateAsync(PortfolioConfig model, List<int> usersIdsAsociates);
        public Task<PortfolioConfig> RemoveAsync(int id);
        public Task<PortfolioConfig> GetByIdAsync(int id);
        public Task<PortfolioConfig> GetByKeyAccessAsync(string keyAccess);
        public Task<ListAllEntityVO<PortfolioConfig>> GetAllAsync(int? limit = null, int? page = null);
        public Task<ListAllEntityVO<PortfolioConfig>> GetAllAsync(int? limit, int? page, int userId);
        public Task<int> CountAsync();
        public Task<bool> IsExistByIdAsync(int portfolioId);
        public Task<bool> IsPermissionAccessByUserIdAsync(int portfolioId, int userId);
        public Task<bool> IsExistByKeyAccessAsync(string keyAccess);
        public Task<int?> GetIdByKeyAccessAsync(string keyAccess);
    }
}
