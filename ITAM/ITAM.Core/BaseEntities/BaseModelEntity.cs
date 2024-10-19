using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;
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
        [NotMapped]
        public int CorpNo { get; set; }
        [BindNever]
        [JsonIgnore]
        [NotMapped]
        public decimal MainCorpNo { get; set; }
        [BindNever]
        [JsonIgnore]
        [NotMapped]
        public decimal LoginCorpNo { get; set; }
        [BindNever]
        [JsonIgnore]
        [NotMapped]
        public int CreatedBy { get; set; }
        [NotMapped]
        public int Flag { get; set; }
    }
}
