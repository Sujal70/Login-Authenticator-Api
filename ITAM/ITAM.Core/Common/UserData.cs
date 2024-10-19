using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LT.Core.Common
{
    /// <summary>
    /// User basic data bring used to save JWT Token during Authorize process using redis cache
    /// </summary>
    public class UserData
    {
        public long MainCorpNo { get; set; }
        public long LoginCorpNo { get; set; }
        public bool IsSubAdmin { get; set; }
        public string JWTToken { get; set; }
        public string JWTOldToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }
        public bool IsRefresh { get; set; }
    }
}
