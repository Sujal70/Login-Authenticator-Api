using ITAM.Data.EFData.Interfaces;
using LT.Core;

namespace ITAM.Data.EFData.Repositories
{
    public class ManufacturerRepo : IManufacturerRepo
    {
        public InboxContext _dbContext { get; }
        public ManufacturerRepo(InboxContext dbContext) { _dbContext = dbContext; }

    }
}
