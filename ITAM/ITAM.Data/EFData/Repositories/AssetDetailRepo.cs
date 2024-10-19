using ITAM.Core.DBEntities;
using ITAM.Core.SearchEntity;
using ITAM.Data.EFData.Interfaces;
using LT.Core;
using Microsoft.EntityFrameworkCore;

namespace ITAM.Data.EFData.Repositories
{
    public class AssetDetailRepo : IAssetDetailRepo
    {
        public InboxContext _dbContext { get; }
        public AssetDetailRepo(InboxContext dbContext) { _dbContext = dbContext; }


        public List<AssetDetail> GetAssetData(AssestSearchEntity assetSearchEntity)
        {
            var result = (from a in _dbContext.AssetDetail
                          join b in _dbContext.AssetMaster on a.AssetId equals b.AssetId
                          join c in _dbContext.AssetType on b.AssetTypeId equals c.AssetTypeId
                          join j in _dbContext.Supplier on c.SupplierId equals j.SupplierId
                          join k in _dbContext.Manufacturer on c.ManufacturerId equals k.ManufacturerId
                          where c.AssetTypeId == assetSearchEntity.AssetTypeId
                          select a).Include(ad => ad.AssetMaster)
                                        .ThenInclude(am => am.AssetType)
                                            .ThenInclude(at => at.Supplier)
                                    .Include(ad => ad.AssetMaster)
                                        .ThenInclude(am => am.AssetType)
                                            .ThenInclude(at => at.Manufacturer)
                                    .ToList();
            return result;
        }
    }
}
