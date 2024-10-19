using DataHelper.MockRepos;
using LT.Core;
using LT.Core.DBEntities;
using LT.Data.EFData.Interfaces;

namespace LT.UnitTest.MockRepos.EFRepos
{
    public class MockMSSurveyCorpRepo(CPortalContext dbContext) : MockGenericBaseRepo<MSSurveyCorporate, CPortalContext>(dbContext), IMSSurveyCorpRepo
    {
    }

    public class MockTokenRepo(CPortalContext dbContext) : MockGenericBaseRepo<LTWebApiUsers, CPortalContext>(dbContext), ITokenRepo
    {
    }


}
