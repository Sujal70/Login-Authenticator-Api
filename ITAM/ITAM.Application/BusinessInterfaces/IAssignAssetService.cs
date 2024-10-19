using ConfigReader.Entities;
using ITAM.Core.DBEntities;
using ITAM.Core.SearchEntity;

namespace ITAM.Application.BusinessInterfaces
{
    public interface IAssignAssetService
    {
        public List<AssignAsset> GetAll(Message message);
        public void Add(AssignAsset entity, Message message);
        public void Update(AssignAsset entity, Message message);
        public void Delete(AssignAsset entity, Message message);
        public AssignAsset GetSingle(AssignAsset searchModel, Message message);
        public List<AssignAsset> GetData(LocationSearchEntity locationSearchEntity);
    }
}
