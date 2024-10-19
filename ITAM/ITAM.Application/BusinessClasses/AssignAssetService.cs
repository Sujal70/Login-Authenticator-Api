using ConfigReader.Entities;
using DataHelper.HelperClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using ITAM.Core.SearchEntity;
using ITAM.Data.EFData.Interfaces;
using ITAM.Data.EFData.Repositories;

namespace ITAM.Application.BusinessClasses
{
    public class AssignAssetService:IAssignAssetService
    {
        private readonly IAssignAssetRepo _assignAsset;
        public AssignAssetService(IAssignAssetRepo assignAsset)
        {
            _assignAsset = assignAsset;
        }
        public void Add(AssignAsset Entity, Message message)
        {
            _assignAsset.Add(Entity, message);
        }
        public void Update(AssignAsset Entity, Message message)
        {
            _assignAsset.Update(Entity, message);
        }
        public void Delete(AssignAsset Entity, Message message)
        {
            _assignAsset.Delete(Entity, message);
        }
        public List<AssignAsset> GetAll(Message message)
        {
            var result = _assignAsset.ListAll(message);
            return result;
        }
        public AssignAsset GetSingle(AssignAsset searchModel, Message message)
        {
            BaseSpecification<AssignAsset> spec = new()
            {
                Criteria = a => a.AssignId == searchModel.AssignId
            };

            var result = _assignAsset.GetUniqueRecordBySpec(spec, message);
            return result;
        }
        public List<AssignAsset> GetData(LocationSearchEntity locationSearchEntity)
        {
            var result = _assignAsset.GetAssetData(locationSearchEntity);
            return result;
        }
    }
}
