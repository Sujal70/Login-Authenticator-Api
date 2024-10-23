using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAM.Core.DBEntities
{
    public class HistoryData
    {
        [Key]
        public int HistoryId {  get; set; }
        public int UserId {  get; set; }
        public string IpAddress { get; set; }
        public DateTime LoginTime { get; set; }
        [ForeignKey("UserLogin")]
        public virtual UserLogin UserLogin { get; set; }
    }
}
