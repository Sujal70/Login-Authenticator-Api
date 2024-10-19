using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        public decimal CorpNo { get; set; }

        [JsonIgnore]
        [BindNever]
        public decimal CorpNoSub { get; set; }

        [JsonIgnore]
        [BindNever]
        public decimal ServerTimeZoneId { get; set; }
    }
}
