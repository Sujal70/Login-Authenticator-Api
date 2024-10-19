using ConfigReader.Entities;
using ITAM.Core.DBEntities;
using ITAM.Data.EFData.Interfaces;
using LT.Core.BaseEntities;

namespace ITAM.Application.BusinessInterfaces
{
    public interface IManufacturerService
    {
        public List<Manufacturer> GetAll(Message message);
        public Manufacturer GetSingle(Manufacturer searchModel, Message message);
        public void Add(Manufacturer entity, Message message);
        public void Update(Manufacturer entity, Message message);
        public void Delete(Manufacturer entity, Message message);
    }
}
