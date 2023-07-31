using AutoMapper;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.Configuration;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;
using Portfolio.Core.RepositoriesInterface.Sql;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;

namespace Portfolio.Infrastructure.ServicesImpl
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationRepository _configRepo;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public ConfigurationService(IConfigurationRepository configRepo, ILogService logService, IMapper mapper)
        {
            _configRepo = configRepo;
            _logService = logService;
            _mapper = mapper;
        }

        public async Task<ConfigurationVO> CreateAsync(SaveConfigurationVO modelVO)
        {
            try
            {
                Configuration save = await _configRepo.GetByTokenAsync(modelVO.Token);
                if (save is not null)
                    throw new ConflictException($"Já existe uma configuração com o token {modelVO.Token}");

                Configuration entity = _mapper.Map<Configuration>(modelVO);
                Configuration resultCreate = await _configRepo.InsertAsync(entity);
                return _mapper.Map<ConfigurationVO>(resultCreate);
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
                throw new ConflictException(ex.Message);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperado ao inserir configuração: {modelVO.Token} - {modelVO.Value}", this.GetPlace(), ex);
                throw new ValidException("Falha inpesperada ao inserir configuração", ex);
            }
        }

        public async Task<ConfigurationVO> EditAsync(int? id, ConfigurationVO modelVO)
        {
            try
            {
                if (!id.HasValue)
                    throw new ValidException($"Id de configuração a ser editado não informado na requisição");

                Configuration exist = await _configRepo.GetByIdAsync(id.Value);
                if (exist is null)
                    throw new NotFoundException($"Não foi encontrado uma configuração para editar com o id: {id.Value}");

                Configuration save = await _configRepo.GetByTokenAsync(modelVO.Token);
                if (save is not null && save.Token != modelVO.Token)
                    throw new ConflictException($"Já existe uma configuração com o token {modelVO.Token} e com o valor {modelVO.Value}");

                Configuration entity = _mapper.Map<Configuration>(modelVO);
                entity.Id = id.Value;

                Configuration resultEdit = await _configRepo.UpdateAsync(entity);
                return _mapper.Map<ConfigurationVO>(resultEdit);
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
            catch (ConflictException ex)
            {
                throw new ConflictException(ex.Message);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao editar configuração: {modelVO.Token} - {modelVO.Value}", this.GetPlace(), ex);
                throw new ValidException("Falha ao editar configuração", ex);
            }
        }

        public async Task<ListAllEntityVO<ConfigurationVO>> GetAllAsync(int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<Configuration> list = await _configRepo.GetAllAsync(limit, page);
                if (list is null)
                    throw new NotFoundException($"Não há configurações para listar");

                ListAllEntityVO<ConfigurationVO> response = _mapper.Map<ListAllEntityVO<ConfigurationVO>>(list);
                return response;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao listar configurações", this.GetPlace(), ex);
                throw new ValidException($"Falha ao listar configurações", ex);
            }
        }

        public async Task<ConfigurationVO> GetByIdAsync(int? id)
        {
            try
            {
                if (!id.HasValue)
                    throw new ValidException($"Id de configuração a ser listado não informado na requisição");

                Configuration save = await _configRepo.GetByIdAsync(id.Value);
                if (save is null)
                    throw new NotFoundException($"Configuração não encontrada para o id: {id}");

                ConfigurationVO response = _mapper.Map<ConfigurationVO>(save);
                return response;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao listar configuração, id: {id}", this.GetPlace(), ex);
                throw new ValidException($"Falha ao listar configuração, id: {id}", ex);
            }
        }

        public async Task<ConfigurationVO> RemoveAsync(int? id)
        {
            try
            {
                if (!id.HasValue)
                    throw new ValidException($"Id de configuração a ser listado não informado na requisição");

                Configuration exist = await _configRepo.GetByIdAsync(id.Value);
                if (exist is null)
                    throw new NotFoundException($"Não foi encontrado uma configuração para o id: {id}");

                Configuration resultRmv = await _configRepo.RemoveAsync(id.Value);
                return _mapper.Map<ConfigurationVO>(resultRmv);
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao remover configuração: {id}", this.GetPlace(), ex);
                throw new ValidException("Falha ao remover configuração", ex);
            }
        }
    }
}
