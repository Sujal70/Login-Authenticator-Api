using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SMTPCommunication.Entities
{
    public class EmailModel
    {
        public EmailModel()
        {
            ToList = new List<string>();
            CCList = new List<string>();
        }
        [DataMember]
        public string From { get; set; }
        [DataMember]
        public List<string> ToList { get; set; }
        [DataMember]
        public List<string> CCList { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string Body { get; set; }
    }
}
