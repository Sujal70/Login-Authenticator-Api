using ITAM.Data.EFData.Interfaces;
using LT.Core;

namespace ITAM.Data.EFData.Repositories
{
    public class NoteMasterRepo:INoteMasterRepo
    {
            public InboxContext _dbContext { get; }
            public NoteMasterRepo(InboxContext dbContext) { _dbContext = dbContext; }

    }

}
