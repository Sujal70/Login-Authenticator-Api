using ConfigReader.Entities;
using LT.Core.ModelEntities;
using LT.Core.SPEntities.ModelEntities;

namespace LT.Application.BusinessInterfaces
{
    public interface ICorpService
    {
        CorpSettingsModel GetCorpSettings(decimal parent, decimal corporateNo, Message message);
        bool GetFolderNameByCorpNo(SurveyCorporateModel corpModel, Message message);
        SurveyCorporateModel GetExpiryDateByCorpNo(decimal parent, Message message);
      
    }
}
