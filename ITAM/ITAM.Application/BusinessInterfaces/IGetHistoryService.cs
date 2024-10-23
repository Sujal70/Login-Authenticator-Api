using ConfigReader.Entities;
using ITAM.Core.DBEntities;
using ITAM.Core.ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAM.Application.BusinessInterfaces
{
    public interface IGetHistoryService
    {
        public HistoryData getHistoryData(int userId,Message message);
    }
}
