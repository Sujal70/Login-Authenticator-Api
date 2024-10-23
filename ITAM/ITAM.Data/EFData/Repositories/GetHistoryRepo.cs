using ITAM.Data.EFData.Interfaces;
using LT.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAM.Data.EFData.Repositories
{
    public class GetHistoryRepo: IGetHistoryRepo
    {

        public InboxContext _dbContext { get; }
        public GetHistoryRepo(InboxContext dbContext) { _dbContext = dbContext; }
    }
}
