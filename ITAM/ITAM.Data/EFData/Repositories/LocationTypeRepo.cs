using ITAM.Data.EFData.Interfaces;
using LT.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAM.Data.EFData.Repositories
{
    public class LocationTypeRepo:ILocationTypeRepo
    {
        public InboxContext _dbContext { get; }
        public LocationTypeRepo(InboxContext dbContext) { _dbContext = dbContext; }
    }
}
