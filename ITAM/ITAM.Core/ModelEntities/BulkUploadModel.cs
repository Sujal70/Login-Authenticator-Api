namespace ITAM.Core.ModelEntities
{
    public class BulkUploadModel
    {
        public BulkUploadModel()
        {
            ValidList = [];
            InValidList = [];
        }
        public List<AssetModel> ValidList { get; set; }
        public List<InvalidAssets> InValidList { get; set; }
    }

    public class InvalidAssets : AssetModel
    {
        public string Error { get; set; }
    }
}
