using ITAM.Core.DBEntities;
using ITAM.Core.SearchEntity;
using ITAM.Data.EFData.Interfaces;
using LT.Core;
using Microsoft.EntityFrameworkCore;

namespace ITAM.Data.EFData.Repositories
{
    public class PurchaseEntryRepo:IPurchaseEntryRepo
    {
        public InboxContext _dbContext { get; }
        public PurchaseEntryRepo(InboxContext dbContext) { _dbContext = dbContext; }
        public List<PurchaseEntry> GetOrderData(OrderSearchEntity orderSearchEntity)
        {
            var result = (from a in _dbContext.PurchaseEntry
                          join b in _dbContext.PurchaseOrder on a.POId equals b.POId
                          where a.POId == orderSearchEntity.POId
                          select a).Include(ad => ad.PurchaseOrder)
                                    .ToList();
            return result;
        }
    }
}
