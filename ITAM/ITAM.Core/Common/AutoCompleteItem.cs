namespace LT.Core.Common
{
    /// <summary>
    /// Model base class can be used to fill an Autocomplete or dropdown list with some supplemntal data
    /// </summary>
    public class AutoCompleteBase
    {
        public string ItemText { get; set; }
        public int SortNo { get; set; }
        public object SupplementalData { get; set; }
    }

    /// <summary>
    /// Model class inherited from  AutoCompleteBase to fill autocomplete or dropdown list with Item Value as integer
    /// </summary>
    public class AutoCompleteItem : AutoCompleteBase
    {
        public int ItemValue { get; set; }
    }

    /// <summary>
    /// Model class inherited from  AutoCompleteBase to fill autocomplete or dropdown list with Item Value as string
    /// </summary>
    public class AutoCompleteItemString : AutoCompleteBase
    {
        public string ItemValue { get; set; }
    }
}
