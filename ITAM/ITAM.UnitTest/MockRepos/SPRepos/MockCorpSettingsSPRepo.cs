using DataHelper.MockRepos;
using LT.Core.SPEntities.ModelEntities;
using LT.Core.SPEntities.SPResults;
using LT.Data.SPData.Interfaces;

namespace LT.UnitTest.MockRepos.SPRepos
{

    public class MockCorpSettingsSPRepo : MockGenericSPRepository<CorpSettingsModel, CorpSettingsResult>, ICorpSettingsSPRepo
    {

    }
}
