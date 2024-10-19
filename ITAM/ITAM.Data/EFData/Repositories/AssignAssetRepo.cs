using ITAM.Core.DBEntities;
using ITAM.Core.SearchEntity;
using ITAM.Data.EFData.Interfaces;
using LT.Core;
using Microsoft.EntityFrameworkCore;

namespace ITAM.Data.EFData.Repositories
{
    public class AssignAssetRepo:IAssignAssetRepo
    {
        public InboxContext _dbContext { get; }
        public AssignAssetRepo(InboxContext dbContext) { _dbContext = dbContext; }
        public List<AssignAsset> GetAssetData(LocationSearchEntity locationSearchEntity)
        {
            var result = (from a in _dbContext.AssignAsset
                          join b in _dbContext.AssetMaster on a.AssetId equals b.AssetId
                          join c in _dbContext.AssetType on b.AssetTypeId equals c.AssetTypeId
                          join j in _dbContext.Supplier on c.SupplierId equals j.SupplierId
                          join k in _dbContext.Manufacturer on c.ManufacturerId equals k.ManufacturerId
                          join d in _dbContext.LocationMaster on a.LocationId equals d.LocationId
                          join e in _dbContext.LocationType on d.LocationTypeId equals e.LocationTypeId
                          join f in _dbContext.NoteMaster on d.NotesId equals f.NoteId
                          where e.LocationTypeId == locationSearchEntity.LocationTypeId
                          select a).Include(ad => ad.AssetMaster)
                                        .ThenInclude(am => am.AssetType)
                                            .ThenInclude(at => at.Supplier)
                                    .Include(ad => ad.AssetMaster)
                                        .ThenInclude(am => am.AssetType)
                                            .ThenInclude(at => at.Manufacturer)
                                    .Include(ad => ad.LocationMaster)
                                        .ThenInclude(am => am.LocationType)
                                    .Include(ad => ad.LocationMaster)
                                        .ThenInclude(am => am.NoteMaster)
                                    .ToList();
            return result;
        }
    }
}
