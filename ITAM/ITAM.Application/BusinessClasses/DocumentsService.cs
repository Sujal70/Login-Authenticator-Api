using ConfigReader.Entities;
using DataHelper.HelperClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using ITAM.Data.EFData.Interfaces;

namespace ITAM.Application.BusinessClasses
{
    public class DocumentsService:IDocumentsService
    {
        private readonly IDocumentsRepo _documentsRepo;
        public DocumentsService(IDocumentsRepo documentsRepo)
        {
            _documentsRepo = documentsRepo;
        }

        public void Add(Documents Entity, Message message)
        {
            _documentsRepo.Add(Entity, message);
        }
        public void Update(Documents Entity, Message message)
        {
            _documentsRepo.Update(Entity, message);
        }
        public void Delete(Documents Entity, Message message)
        {
            _documentsRepo.Delete(Entity, message);
        }
        public List<Documents> GetAll(Message message)
        {
            var result = _documentsRepo.ListAll(message);
            return result;
        }
        public Documents GetSingle(Documents searchModel, Message message)
        {
            BaseSpecification<Documents> spec = new()
            {
                Criteria = a => a.ObjectId == searchModel.ObjectId
            };

            var result = _documentsRepo.GetUniqueRecordBySpec(spec, message);
            return result;
        }
    }
}

