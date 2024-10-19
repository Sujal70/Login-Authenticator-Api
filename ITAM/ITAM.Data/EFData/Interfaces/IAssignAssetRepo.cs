using DataHelper.EFData.Common.Interfaces;
using ITAM.Core.DBEntities;
using ITAM.Core.SearchEntity;
using LT.Core;

namespace ITAM.Data.EFData.Interfaces
{
    public interface IAssignAssetRepo: IGenericBaseRepo<AssignAsset, InboxContext>
    {
        public List<AssignAsset> GetAssetData(LocationSearchEntity locationSearchEntity);
    }
}
