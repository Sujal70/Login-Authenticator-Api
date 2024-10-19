using ITAM.Data.EFData.Interfaces;
using LT.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAM.Data.EFData.Repositories
{
    public class AssetTypeRepo:IAssetTypeRepo
    {
        public InboxContext _dbContext { get; }
        public AssetTypeRepo(InboxContext dbContext) { _dbContext = dbContext; }
    }
}
