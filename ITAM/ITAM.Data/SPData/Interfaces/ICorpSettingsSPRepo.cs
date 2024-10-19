using DataHelper.SPData.Common.Interfaces;
using LT.Core.SPEntities.ModelEntities;
using LT.Core.SPEntities.SPResults;

namespace LT.Data.SPData.Interfaces
{
    /// <summary>
    /// ICorpSettingsSPRepo
    /// </summary>
    public interface ICorpSettingsSPRepo : IGenericSPRepository<CorpSettingsModel, CorpSettingsResult>
    {
    }
}
