using DataHelper.EFData.Common.Interfaces;
using LT.Core;
using LT.Core.DBEntities;

namespace LT.Data.EFData.Interfaces
{
    public interface IMSSurveyCorpRepo : IGenericBaseRepo<MSSurveyCorporate, CPortalContext>
    {
    }

    public interface ITokenRepo : IGenericBaseRepo<LTWebApiUsers, CPortalContext>
    {
    }
}
