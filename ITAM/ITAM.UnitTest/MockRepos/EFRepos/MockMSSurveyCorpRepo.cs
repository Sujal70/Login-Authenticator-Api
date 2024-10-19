using DataHelper.MockRepos;
using LT.Core;
using LT.Core.DBEntities;
using LT.Data.EFData.Interfaces;

namespace LT.UnitTest.MockRepos.EFRepos
{
    public class MockMSSurveyCorpRepo(InboxContext dbContext) : MockGenericBaseRepo<MSSurveyCorporate, InboxContext>(dbContext), IMSSurveyCorpRepo
    {
    }

    public class MockTokenRepo(InboxContext dbContext) : MockGenericBaseRepo<LTWebApiUsers, InboxContext>(dbContext), ITokenRepo
    {
    }


}
