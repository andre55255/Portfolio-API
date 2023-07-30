using Microsoft.AspNetCore.Http;
using Portfolio.Communication.ViewObjects.Utlis;

namespace Portfolio.Core.ServicesInterface
{
    public interface IApiInfoService
    {
        public RequestDataVO GetRequestData(HttpRequest request, bool hasAuth = true);
        public APISettingsVO GetAppSettingsData();
    }
}
