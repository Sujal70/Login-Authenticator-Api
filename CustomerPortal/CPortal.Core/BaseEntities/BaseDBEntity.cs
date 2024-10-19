namespace LT.Core.BaseEntities
{
    /// <summary>
    /// Common Properties being used across DB Entities
    /// </summary>
    public abstract class BaseDBEntity
    {
        public long MainCorpNo { get; set; }
        public long LoginCorpNo { get; set; }
    }
}
