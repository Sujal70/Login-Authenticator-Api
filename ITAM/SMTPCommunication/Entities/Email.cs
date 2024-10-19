using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace SMTPCommunication.Entities
{
    /// <summary>
    /// Represents the email entity.
    /// </summary>
    public class Email
    {
        public Email()
        {
            //string strFromMail, string strFromName, string strToMail, string strToName, string strTitle, string strMessage, Int64 intCorpNo
            senderEmailAddress = string.Empty;
            senderName = string.Empty;
            recepientEmailAddress = string.Empty;
            recepientName = string.Empty;
            subject = string.Empty;
            body = string.Empty;
            ccEmailAddress = new List<string>();
            bccEmailAddress = new List<string>();
            replyToEmail = string.Empty;
            replyToName = string.Empty;
            Attachments = null;
            scheduleDate = null;
            CorpNo = 0;
            IsHTML = true;
        }

        private string senderEmailAddress;

        /// <summary>
        /// The sender email address.
        /// </summary>
        [RegularExpression(@"^([a-zA-Z0-9_\.\'\-\+])+\@(([a-zA-Z0-9\-\'])+\.)+([a-zA-Z])+$", ErrorMessage = "Please enter valid email id.")]
        public string SenderEmailAddress
        {
            get
            {
                return senderEmailAddress;
            }
            set
            {
                if (value != null && value.Trim().Length > 0)
                {
                    senderEmailAddress = value.Trim();
                }
                else
                {
                    senderEmailAddress = string.Empty;
                }
            }
        }

        private string senderName;

        /// <summary>
        /// The sender name.
        /// </summary>
        public string SenderName
        {
            get
            {
                return senderName;
            }
            set
            {
                if (value != null && value.Trim().Length > 0)
                {
                    senderName = value.Trim();
                }
                else
                {
                    senderName = string.Empty;
                }
            }
        }

        private string recepientEmailAddress;

        /// <summary>
        /// The recepient email address.
        /// </summary>
        [RegularExpression(@"^([a-zA-Z0-9_\.\'\-\+])+\@(([a-zA-Z0-9\-\'])+\.)+([a-zA-Z])+$", ErrorMessage = "Please enter valid email id.")]
        public string RecepientEmailAddress
        {
            get
            {
                return recepientEmailAddress;
            }
            set
            {
                if (value != null && value.Trim().Length > 0)
                {
                    recepientEmailAddress = value.Trim();
                }
                else
                {
                    recepientEmailAddress = string.Empty;
                }
            }
        }

        private string recepientName;

        /// <summary>
        /// The recepient name.
        /// </summary>
        public string RecepientName
        {
            get
            {
                return recepientName;
            }
            set
            {
                if (value != null && value.Trim().Length > 0)
                {
                    recepientName = value.Trim();
                }
                else
                {
                    recepientName = string.Empty;
                }
            }
        }

        private string subject;

        /// <summary>
        /// The email subject.
        /// </summary>
        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                if (value != null && value.Trim().Length > 0)
                {
                    subject = value.Trim();
                }
                else
                {
                    subject = string.Empty;
                }
            }
        }

        private string body;

        /// <summary>
        /// The HTML body of the email.
        /// </summary>
        public string Body
        {
            get
            {
                return body;
            }
            set
            {
                if (value != null && value.Trim().Length > 0)
                {
                    body = value.Trim();
                }
                else
                {
                    body = string.Empty;
                }
            }
        }


        private List<string> ccEmailAddress;

        /// <summary>
        /// The CC email address.
        /// </summary>
        public List<string> CCEmailAddress
        {
            get
            {
                return ccEmailAddress;
            }
            set
            {
                ccEmailAddress = value;
            }
        }

        private List<string> bccEmailAddress;

        /// <summary>
        /// The BCC email address.
        /// </summary>
        public List<string> BCCEmailAddress
        {
            get
            {
                return bccEmailAddress;
            }
            set
            {
                bccEmailAddress = value;
            }
        }

        private string replyToEmail;

        /// <summary>
        /// Reply to email id.
        /// </summary>
        [RegularExpression(@"^([a-zA-Z0-9_\.\'\-\+])+\@(([a-zA-Z0-9\-\'])+\.)+([a-zA-Z])+$", ErrorMessage = "Please enter valid email id.")]
        public string ReplyToEmail
        {
            get
            {
                return replyToEmail;
            }
            set
            {
                if (value != null && value.Trim().Length > 0)
                {
                    replyToEmail = value.Trim();
                }
                else
                {
                    replyToEmail = string.Empty;
                }
            }
        }

        private string replyToName;

        /// <summary>
        /// Reply to name.
        /// </summary>
        public string ReplyToName
        {
            get
            {
                return replyToName;
            }
            set
            {
                if (value != null && value.Trim().Length > 0)
                {
                    replyToName = value.Trim();
                }
                else
                {
                    replyToName = string.Empty;
                }
            }
        }

        /// <summary>
        /// The mail attachments.
        /// </summary>
        public ArrayList Attachments { get; set; }

        private DateTime? scheduleDate = null;

        /// <summary>
        /// The email schedule date, when value is null the email is sent immediately, else sent on the scheduled date.
        /// </summary>
        public DateTime? ScheduleDate
        {
            get
            {
                return scheduleDate;
            }
            set
            {
                scheduleDate = value;
            }
        }

        public Int64 CorpNo { get; set; }

        /// <summary>
        /// Whether the email body contains HTML.
        /// </summary>
        public bool IsHTML { get; set; }

        public string Domain { get; set; }
        public string CharSet { get; internal set; } = "utf-8";
        public bool IsemailRelay { get; internal set; }
    }
}
