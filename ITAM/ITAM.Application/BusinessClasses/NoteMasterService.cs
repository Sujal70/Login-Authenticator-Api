using ConfigReader.Entities;
using DataHelper.HelperClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using ITAM.Data.EFData.Interfaces;
using ITAM.Data.EFData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAM.Application.BusinessClasses
{
    public class NoteMasterService:INoteMasterService
    {
        private readonly INoteMasterRepo _noteMaster;
        public NoteMasterService(INoteMasterRepo noteMaster)
        {
            _noteMaster = noteMaster;
        }

        public void Add(NoteMaster Entity, Message message)
        {
            _noteMaster.Add(Entity, message);
        }
        public void Update(NoteMaster Entity, Message message)
        {
            _noteMaster.Update(Entity, message);
        }
        public void Delete(NoteMaster Entity, Message message)
        {
            _noteMaster.Delete(Entity, message);
        }
        public List<NoteMaster> GetAll(Message message)
        {
            var result = _noteMaster.ListAll(message);
            return result;
        }
        public NoteMaster GetSingle(NoteMaster searchModel, Message message)
        {
            BaseSpecification<NoteMaster> spec = new()
            {
                Criteria = a => a.NoteId == searchModel.NoteId
            };

            var result = _noteMaster.GetUniqueRecordBySpec(spec, message);
            return result;
        }
    }
}
