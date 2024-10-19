using LT.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAM.Core.DBEntities
{
    public class SystemCodes:BaseModelEntity
    {
        [Key]
        public int SystemCodeId { get; set; }
        public string Systemcode { get; set; }
        public string Description { get; set; }
    }
}
