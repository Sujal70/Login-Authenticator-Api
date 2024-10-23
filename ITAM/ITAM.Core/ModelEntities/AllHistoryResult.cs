using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAM.Core.ModelEntities
{
    public class AllHistoryResult
    {
        public int HistoryId {  get; set; }
        public int IPAddress {  get; set; }
        public string username {  get; set; }
        public DateTime loginTime {  get; set; }
    }
}
