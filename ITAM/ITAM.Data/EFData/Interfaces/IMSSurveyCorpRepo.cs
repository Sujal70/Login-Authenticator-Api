using DataHelper.EFData.Common.Interfaces;
using LT.Core;
using LT.Core.DBEntities;
using LT.Core.ModelEntities;

namespace LT.Data.EFData.Interfaces
{
    public interface IMSSurveyCorpRepo : IGenericBaseRepo<MSSurveyCorporate, InboxContext>
    {
    }

    public interface ITokenRepo : IGenericBaseRepo<LoginModel, InboxContext>
    {
    }
}
