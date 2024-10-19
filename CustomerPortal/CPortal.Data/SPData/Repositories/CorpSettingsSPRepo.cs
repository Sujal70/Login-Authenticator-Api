using DataHelper.SPData.Common.Repositories;
using LT.Core.SPEntities.SPResults;
using LT.Data.SPData.Interfaces;

namespace LT.Data.SPData.Repositories
{
    public class ParentEmailSPRepo : GenericSPRepository<ParentsEmailDetails, ParentsEmailDetails>, IParentEmailSPRepo
    {
        public ParentEmailSPRepo() : base(ProcNames.LoginSelectCorpSettingsSP) { }

        /// <summary>
        /// Override this method to transfer the sp actual result into final model entity 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="spResult"></param>
        /// <returns>List<CorpSettingsModel></returns>
        protected override List<ParentsEmailDetails> SetEntityResult(object message, IEnumerable<ParentsEmailDetails> spResult)
        {
            return spResult.ToList();
        }
    }

}
