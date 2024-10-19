namespace SMTPCommunication.Entities
{
    public class EmailSettings
    {
        public string EmailQueuePath { get; set; }
        public string AspEmail_RegKey { get; set; }
        public string EmailHost { get; set; }     
        public string EmailUserName { get; set; } 
        public string EmailPassword { get; set; } 
        public string EmailServer { get; set; }
        public string PfxFileName { get; set; } = "k12.pfx";
        public string StaticDomain { get; set; } 
        public string AuthSelector { get; set; } 
        public string StaticSelector { get; set; }  
        public string EmailTemplatePath { get; set; }
        public string TranslationReviewMailSubject { get; set; }
        public string ImageClients { get; set; }
        public string EmailClientsSSL { get; set; }
        public string MSHostSSL { get; set; }
        public string MSHost { get; set; }
        public int EmailPort { get; set; }
        public int EmailTimeout { get; set; }
        public string LanguageCode { get; set; }
        public string NewNumberRequestEmail { get; set; }
        public string ImageServer { get; set; } //\\172.16.1.105\sg-dev-img\
        public string ImageHostSSL { get; set; } //https://sg-dev-img.sevenpv.com/
    }
}
