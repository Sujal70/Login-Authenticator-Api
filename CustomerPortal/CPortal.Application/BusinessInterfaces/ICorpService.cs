using ConfigReader.Entities;
using LT.Core.ModelEntities;
using LT.Core.SPEntities.SPResults;

namespace LT.Application.BusinessInterfaces
{
    public interface ICorpService
    {
        ParentsEmailDetails GetParentsEmailDetails(Message message);
        bool GetFolderNameByCorpNo(SurveyCorporateModel corpModel, Message message);
        SurveyCorporateModel GetExpiryDateByCorpNo(decimal parent, Message message);
      
    }
}
