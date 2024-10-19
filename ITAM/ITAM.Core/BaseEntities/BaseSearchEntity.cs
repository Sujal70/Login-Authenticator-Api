using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LT.Core.BaseEntities
{
    /// <summary>
    /// Common properties being used across Search model Entities
    /// </summary>
    public class BaseSearchEntity
    {

        [JsonIgnore]
        [BindNever]
        [NotMapped]
        public decimal CorpNo { get; set; }

        [JsonIgnore]
        [BindNever]
        [NotMapped]
        public decimal CorpNoSub { get; set; }

        [JsonIgnore]
        [BindNever]
        [NotMapped]
        public decimal ServerTimeZoneId { get; set; }
    }
}
