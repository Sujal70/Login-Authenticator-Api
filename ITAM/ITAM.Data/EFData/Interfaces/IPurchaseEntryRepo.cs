using DataHelper.EFData.Common.Interfaces;
using ITAM.Core.DBEntities;
using ITAM.Core.SearchEntity;
using LT.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAM.Data.EFData.Interfaces
{
    public interface IPurchaseEntryRepo: IGenericBaseRepo<PurchaseEntry, InboxContext>
    {
        public List<PurchaseEntry> GetOrderData(OrderSearchEntity orderSearchEntity);
    }
}
