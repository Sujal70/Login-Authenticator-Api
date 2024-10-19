using ConfigReader.Entities;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.ModelEntities;
using LT.Api.Controllers.Common;
using LT.Core.Common;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ITAM.Api.Controllers
{
    public class AssetsController : BaseController
    {
        public readonly IAssetService assetService;

        public AssetsController(IAssetService _assetService)
        {
            assetService = _assetService;
        }
        [Route("upload")]
        [HttpPost]
        public MainViewModel<BulkUploadModel> AssetBulkUpload()
        {
            Message message = new();
            message.Messages.Add("Enter->" + MethodBase.GetCurrentMethod());
            var file = Request.Form.Files[0];
            var result = assetService.ProcessExcel(file, base.TokenClaimModel.MainCorpNo, base.TokenClaimModel.LoginCorpNo, base.TokenClaimModel.TimeZoneId, message);
            return new MainViewModel<BulkUploadModel>(result, message);
        }
    }
}
