using ConfigReader.Entities;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.ModelEntities;
using Microsoft.AspNetCore.Http;
using NetTopologySuite.Index.HPRtree;

namespace ITAM.Application.BusinessClasses
{
    public class AssetService : IAssetService
    {
        public BulkUploadModel ProcessExcel(IFormFile filetoprocess, int mainCorpNo, int loginCorpNo, int timeZoneId, Message message)
        {
            BulkUploadModel bulkUploadModel = new();
            try
            {
                //TBD by Durriya
                AssetModel validAssets = new();
                bulkUploadModel.ValidList.Add(validAssets);
            }
            catch (Exception ex)
            {

                InvalidAssets invalidAssets = new()
                {
                    Error = ex.Message.ToString()
                };
                bulkUploadModel.InValidList.Add(invalidAssets);
            }
            return new BulkUploadModel();
        }
    }
}
