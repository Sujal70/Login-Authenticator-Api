namespace LT.Core.SPEntities.SPResults
{

    public class ParentsEmailDetails
    {
        public List<ParentDetails> ParentDetails { get; set; }
        public List<StudentDetails> StudentDetails { get; set; }
    }
    public class ParentDetails
    {
        public string ParentName { get; set; }
        public long PhoneNo { get; set; }
        public string Email { get; set; }
    }

    public class StudentDetails
    {
        public string SourceId { get; set; }
        public string StudentName { get; set; }
        public string Residency { get; set; }
        public string Address { get; set; }
        public string Classification { get; set; }
        public string Campus { get; set; }
        public string Route { get; set; }
        public string StopLocation { get; set; }
        public string Grade { get; set; }
        public string SchoolID { get; set; }
        public string Email { get; set; }
        public long PhoneNo { get; set; }
        public string Identifier { get; set; }
        public string SchoolIdentifier { get; set; }
    }


}
