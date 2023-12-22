using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;
using Portfolio.Core.RepositoriesInterface.Sql;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;
using Portfolio.Infrastructure.Data.Sql.Context;

namespace Portfolio.Infrastructure.RepositoriesImpl.Sql
{
    public class ContactMeRepository : IContactMeRepository
    {
        private readonly IUserRepository _userRepo;
        private readonly SqlDbContext _db;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public ContactMeRepository(SqlDbContext db, ILogService logService, IMapper mapper, IUserRepository userRepo)
        {
            _db = db;
            _logService = logService;
            _mapper = mapper;
            _userRepo = userRepo;
        }

        public async Task<int> CountAsync()
        {
            try
            {
                return
                    await _db.Contacts
                             .Where(x => x.DisabledAt == null)
                             .CountAsync();
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar quantidade de itens na tabela de contatos", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar quantidade de itens na tabela de contatos", ex);
            }
        }

        public async Task<ListAllEntityVO<ContactMe>> GetAllAsync(int? limit = null, int? page = null, int? userId = null)
        {
            try
            {
                int portfolioId =
                    userId.HasValue ?
                    await _userRepo.GetIdPortfolioSelectedCurrentAsync(userId.Value) :
                    -1;

                ListAllEntityVO<ContactMe> response = new ListAllEntityVO<ContactMe>();
                response.TotalItems = await CountAsync();

                if (response.TotalItems <= 0)
                    return response;

                StaticMethods.GetPaginationItems(ref response, ref limit, ref page);

                response.Items =
                    await _db.Contacts
                             .Where(x => x.DisabledAt == null &&
                                         (userId == null || x.PortfolioId == portfolioId))
                             .Include(x => x.Portfolio)
                             .OrderByDescending(x => x.CreatedAt)
                             .ThenBy(x => x.Name)
                             .Skip(limit.Value * page.Value)
                             .Take(limit.Value)
                             .AsNoTracking()
                             .ToListAsync();

                return response;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar contatos da base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar contatos da base de dados", ex);
            }
        }

        public async Task<List<ContactMe>> GetAllByPortfolioIdAsync(int portfolioId)
        {
            try
            {
                return
                    await _db.Contacts
                             .Where(x => x.DisabledAt == null &&
                                         x.PortfolioId == portfolioId)
                             .Include(x => x.Portfolio)
                             .OrderByDescending(x => x.CreatedAt)
                             .ThenBy(x => x.Name)
                             .AsNoTracking()
                             .ToListAsync();
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar contatos do portfolio {portfolioId} da base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar contatos do portfolio {portfolioId} tda base de dados", ex);
            }
        }

        public async Task<ContactMe> GetByIdAsync(int id)
        {
            try
            {
                return
                    await _db.Contacts
                             .Where(x => x.DisabledAt == null &&
                                         x.Id == id)
                             .Include(x => x.Portfolio)
                             .FirstOrDefaultAsync();
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar contato pelo id {id} da base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar contato pelo id {id} tda base de dados", ex);
            }
        }

        public async Task<ContactMe> InsertAsync(ContactMe model)
        {
            try
            {
                model.Id = 0;

                _db.Contacts.Add(model);
                await _db.SaveChangesAsync();

                return await GetByIdAsync(model.Id);
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao inserir contato {model.Name} na base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao inserir contato {model.Name} na base de dados", ex);
            }
        }

        public async Task<ContactMe> RemoveAsync(int id)
        {
            try
            {
                ContactMe save = await GetByIdAsync(id);
                if (save == null)
                    throw new RepositoryException($"Não foi encontrado um contato com o id {id}");

                save.DisabledAt = DateTime.Now;

                await _db.SaveChangesAsync();

                return save;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao remover contato {id} na base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao remover contato {id} na base de dados", ex);
            }
        }

        public async Task<ContactMe> UpdateAsync(ContactMe model)
        {
            try
            {
                ContactMe? save =
                    await _db.Contacts
                             .Where(x => x.Id == model.Id &&
                                         x.DisabledAt == null)
                             .FirstOrDefaultAsync();
                             
                if (save == null)
                    throw new RepositoryException($"Não foi encontrado um contato com o id {model.Id}");

                model.CreatedAt = save.CreatedAt;
                model.UpdatedAt = DateTime.Now;

                _mapper.Map(model, save);
                await _db.SaveChangesAsync();

                return await GetByIdAsync(model.Id);
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao editar contato {model.Id} na base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao editar contato {model.Id} na base de dados", ex);
            }
        }
    }
}
