using LT.Core.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace ITAM.Core.DBEntities
{
    public class NoteMaster:BaseModelEntity
    {
        [Key]
        public decimal NoteId { get; set; }
        public string Notecontent { get; set; }
        public string Noteauthor  { get; set; }
        public string Status { get; set; }
    }
}
