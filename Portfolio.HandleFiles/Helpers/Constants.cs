namespace Portfolio.HandleFiles.Helpers
{
    public static class ConstantsMessageFile
    {
        public static string ErrorDeleteFileInDirectory = "";
        public static string ErrorDeleteAllFilesInDirectory = "Falha ao deletar todos os arquivos do diretório: '{0}'";
        public static string ErrorDeleteFileInDirectoryUnexpected = "Falha inesperada ao deletar o arquivo '{0}', verifique";
        public static string ErrorDeleteFilesInDirectoryUnexpected = "Falha inesperada ao deletar arquivos informados, verifique a exceção";
        public static string ErrorDeleteFilesEditInDirectoryUnexpected = "Falha inesperada ao deletar arquivos para preparar edição, verifique a exceção";
        public static string ErrorFileNameNotInformed = "Nome do arquivo não foi informado";
        public static string ErrorDeleteFileNotFoundInDirectory = "Não foi encontrado o arquivo '{0}' no diretório '{1}'";
        public static string ErrorValidConfigs = "Falha ao validar configurações fornecidas, verifique a exceção";
        public static string ErrorDirectoryNotFound = "Diretório '{0}' fornecido não foi encontrado, verifique";
        public static string ErrorFileNotFound = "Arquivo '{0}' não foi encontrado no diretório '{1}', verifique";
        public static string ErrorDirectoryBaseNotInformed = "Diretório base não informado na instância do serviço, verifique";
        public static string ErrorUrlBaseNotInformed = "Url base não informado na instância do serviço, verifique";
        public static string ErrorUrlPathStaticFile = "Rota para acesso estático ao arquivo não informado, verifique";
        public static string ErrorGetFolder = "Falha ao montar caminho para acesso a pasta da entidade {0} de id {1}";
        public static string ErrorGetGenerateZip = "Arquivo de retorno gerado não encontrado no caminho {0}, verifique";
        public static string ErrorGetBase64File = "Falha ao gerar base64 de arquivo para retornar";
        public static string ErrorGetBase64Files = "Falha ao gerar base64 de arquivos para retornar";
        public static string ErrorPrepareEdit = "Falha ao preparar arquivos para edição da entidade '{0}' id '{1}'";
        public static string ErrorGetUrlFiles = "Falha inesperada ao gerar urls etáticas de arquivos para retornar, verifique a exceção";
        public static string ErrorGetUrlFile = "Falha ao gerar url para acesso ao arquivo {0} de forma estática";
        public static string ErrorBase64Data = "Dados de base64 não informados, verifique";
        public static string ErrorBase64DataNotFound = "Não foi encontrado um base64 dentre os informados que corresponda a extensão: ";
        public static string ErrorSaveOneFileBase64 = "Falha ao salvar o arquivo {0} para a entidade {1} de id {2}";
        public static string ErrorSaveManyFileBase64 = "Falha ao salvar galeria de arquivos para a entidade {0} de id {1}";
        public static string ErrorSaveManyFormFile = "Falha ao salvar galeria de arquivos via IFormFile para a entidade {0} de id {1}";
        public static string ErrorSaveManyFormFileNotInformed = "Nenhum arquivo informado no FormFile para salvar, verifique";
        public static string ErrorExSaveOneFileStream = "Falha inesperada ao salvar o arquivo via streaming para a entidade {1} de id {2}";
        public static string ErrorStreamUnSuportedMediaType = "Status Code 415, formato de carga não é suportado, verifique.";
        public static string ErrorExSaveOneFileBase64 = "Falha inesperada ao salvar o arquivo {0} via base64 para a entidade {1} de id {2}";
        public static string ErrorSaveFileInBase64InDirectory = "Falha inesperada ao salvar o arquivo {0} no diretório {1}";
        public static string ErrorStreamFileCountZero = "Não foram encontrados arquivos para upload";
        public static string ErrorBuildBase64File = "Falha ao montar base64 de arquivo {0} para retornar";
        public static string Fail = "DeleteFail";

        public static string InfoFileExist = "Este arquivo já está salvo";
        public static string SuccessFileSave = "Arquivo salvo com sucesso";
    }
}
