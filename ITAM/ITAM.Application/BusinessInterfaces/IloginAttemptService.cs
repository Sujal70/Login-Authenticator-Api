using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAM.Application.BusinessInterfaces
{
    public interface IloginAttemptService
    {
        public bool captchaShow(string username);
        public void RecordFailedAttempt(string username);
        public void ResetFailedAttempts(string username);
    }
}
