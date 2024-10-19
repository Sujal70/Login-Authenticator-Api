using LT.Core.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITAM.Core.DBEntities
{
    public class Documents:BaseModelEntity
    {
        [Key]
        public decimal ObjectId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string FilePath { get; set; }
        public string Status { get; set; }
        [ForeignKey("AssetMaster")]
        public decimal AssetId { get; set; }
        [ForeignKey("NoteMaster")]
        public decimal NotesId { get; set; }

    }
}
