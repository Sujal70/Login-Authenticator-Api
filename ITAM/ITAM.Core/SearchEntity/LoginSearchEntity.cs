using LT.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAM.Core.SearchEntity
{
    public class LoginSearchEntity:BaseSearchEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
