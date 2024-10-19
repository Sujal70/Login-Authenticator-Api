using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;

namespace LT.Core.BaseEntities
{
    /// <summary>
    /// Common Properties being used across Model Entities
    /// </summary>
    public class BaseModelEntity
    {
        [BindNever]
        [JsonIgnore]
        public int CorpNo { get; set; }
        [BindNever]
        [JsonIgnore]
        public decimal MainCorpNo { get; set; }
        [BindNever]
        [JsonIgnore]
        public decimal LoginCorpNo { get; set; }
        [BindNever]
        [JsonIgnore]
        public int CreatedBy { get; set; }
        public int Flag { get; set; }
    }
}
