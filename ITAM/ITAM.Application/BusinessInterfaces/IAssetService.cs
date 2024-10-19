using ConfigReader.Entities;
using ITAM.Core.ModelEntities;
using Microsoft.AspNetCore.Http;

namespace ITAM.Application.BusinessInterfaces
{
    public interface IAssetService
    {
        BulkUploadModel ProcessExcel(IFormFile filetoprocess, int mainCorpNo, int loginCorpNo, int timeZoneId, Message message);
    }
}
