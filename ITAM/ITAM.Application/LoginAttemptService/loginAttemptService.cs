using ITAM.Application.BusinessInterfaces;

namespace ITAM.Application.LoginAttemptServicr
{
    public class loginAttemptService : IloginAttemptService
    {
        private readonly Dictionary<string,int> failedAttempts = new Dictionary<string, int>();
        private readonly int maxAttempts = 3;
        // Method to check if CAPTCHA is needed
        public bool captchaShow(string username)
        {
            // Check if user exists in the failed attempts dictionary
            if (failedAttempts.ContainsKey(username) && failedAttempts[username]>=maxAttempts)
            {
                return true;    // Show CAPTCHA
            }
            return false;  // No CAPTCHA needed
        }
        // Method to log a failed login attempt
        public void RecordFailedAttempt(string username)
        {
            if (failedAttempts.ContainsKey(username)){
                failedAttempts[username]++;
            }
            else
            {
                failedAttempts[username] = 1;   // First failed attempt
            }
        }
        // Method to reset failed attempts after successful login
        public void ResetFailedAttempts(string username)
        {
            if (failedAttempts.ContainsKey(username))
            {
                failedAttempts.Remove(username);
            }
        }
    }
}
