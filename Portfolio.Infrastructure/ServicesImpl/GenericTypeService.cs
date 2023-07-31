using AutoMapper;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.GenericTypes;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;
using Portfolio.Core.RepositoriesInterface.Sql;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;

namespace Portfolio.Infrastructure.ServicesImpl
{
    public class GenericTypeService : IGenericTypeService
    {
        private readonly IGenericTypeRepository _genRepo;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public GenericTypeService(IGenericTypeRepository genRepo, ILogService logService, IMapper mapper)
        {
            _genRepo = genRepo;
            _logService = logService;
            _mapper = mapper;
        }

        public async Task<GenericTypeVO> CreateAsync(SaveGenericTypeVO modelVO)
        {
            try
            {
                List<GenericType> types = await _genRepo.GetByTokenAsync(modelVO.Token);
                if (types is not null && types.Where(x => x.Value == modelVO.Value).Any())
                    throw new ConflictException($"Já existe um tipo genérico com o token {modelVO.Token} e com o valor {modelVO.Value}");

                GenericType entity = _mapper.Map<GenericType>(modelVO);
                GenericType resultCreate = await _genRepo.InsertAsync(entity);
                return _mapper.Map<GenericTypeVO>(resultCreate);
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (ConflictException ex)
            {
                throw ex;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao inserir tipo genérico: {modelVO.Token} - {modelVO.Value}", this.GetPlace(), ex);
                throw new ValidException("Falha ao inserir tipo genérico", ex);
            }
        }

        public async Task<GenericTypeVO> EditAsync(int? id, SaveGenericTypeVO modelVO)
        {
            try
            {
                if (!id.HasValue)
                    throw new ValidException($"Id de tipo de genérico a ser editado não informado na requisição");

                GenericType exist = await _genRepo.GetByIdAsync(id.Value);
                if (exist is null)
                    throw new NotFoundException($"Não foi encontrado um tipo genérico para editar com o id: {id.Value}");

                List<GenericType> types = await _genRepo.GetByTokenAsync(modelVO.Token);
                if (types is not null && types.Where(x => x.Value == modelVO.Value && x.Id != id.Value).Any())
                    throw new ConflictException($"Já existe um tipo genérico com o token {modelVO.Token} e com o valor {modelVO.Value}");

                GenericType entity = _mapper.Map<GenericType>(modelVO);
                entity.Id = id.Value;

                GenericType resultEdit = await _genRepo.UpdateAsync(entity);
                return _mapper.Map<GenericTypeVO>(resultEdit);
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (ConflictException ex)
            {
                throw ex;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao editar tipo genérico: {modelVO.Token} - {modelVO.Value}", this.GetPlace(), ex);
                throw new ValidException("Falha inesperada ao editar tipo genérico", ex);
            }
        }

        public async Task<ListAllEntityVO<GenericTypeVO>> GetAllAsync(int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<GenericType> list = await _genRepo.GetAllAsync(limit, page);
                if (list is null)
                    throw new NotFoundException($"Não há tipos genéricos para listar");

                ListAllEntityVO<GenericTypeVO> response = _mapper.Map<ListAllEntityVO<GenericTypeVO>>(list);
                return response;
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (ConflictException ex)
            {
                throw ex;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao listar tipos genéricos", this.GetPlace(), ex);
                throw new ValidException("Falha inesperada ao listar tipos genéricos", ex);
            }
        }

        public async Task<GenericTypeVO> GetByIdAsync(int? id)
        {
            try
            {
                if (!id.HasValue)
                    throw new ValidException($"Id de tipo de genérico a ser listado não informado na requisição");

                GenericType save = await _genRepo.GetByIdAsync(id.Value);
                if (save is null)
                    throw new NotFoundException($"Tipo genérico não encontrado para o id: {id}");

                GenericTypeVO response = _mapper.Map<GenericTypeVO>(save);
                return response;
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (ConflictException ex)
            {
                throw ex;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao listar tipo genérico, id: {id}", this.GetPlace(), ex);
                throw new ValidException("Falha inesperada ao listar tipo genérico", ex);
            }
        }

        public async Task<GenericTypeVO> RemoveAsync(int? id)
        {
            try
            {
                if (!id.HasValue)
                    throw new ValidException($"Id de tipo de genérico a ser listado não informado na requisição");

                GenericType exist = await _genRepo.GetByIdAsync(id.Value);
                if (exist is null)
                    throw new NotFoundException($"Não foi encontrado um tipo genérico para o id: {id}");

                GenericType resultRmv = await _genRepo.RemoveAsync(id.Value);
                return _mapper.Map<GenericTypeVO>(resultRmv);
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (ConflictException ex)
            {
                throw ex;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao remover tipo genérico: {id}", this.GetPlace(), ex);
                throw new ValidException("Falha ao remover tipo genérico", ex);
            }
        }
    }
}
