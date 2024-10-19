namespace ConfigReader.Entities
{
    public class LoggerEntity
    {
        public Message Message { get; set; }
        public LoggerSetting LoggerSetting { get; set; }
        public int CorpNo { get; set; }
        public int LogTypeEnumId { get; set; }
        public int? ExceptionsLevelEnumId { get;set; }

    }

    public class LoggerSetting
    {
        public string StorageMediaType { get; set; }
        public int Environment { get; set; }
        public string FilePath { get; set; }
        public string RollingInterVal { get; set; }
        public string LogTrailTemplate { get; set; }
        public string FileNameFormat { get; set; }
    }

}
