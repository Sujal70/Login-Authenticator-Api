namespace LT.Api.Utilities
{
    /// <summary>
    /// Basic constants being used across the Layer
    /// </summary>
    public static class Constants
    {
        public const string GeneriLargeDataErrorMsg = "Please narrow down your filter criteria as this search retrieves too many records to be displayed.";
        public const string RecordCreatedSuccessfully = "Record Created Successfully.";
        public const string RecordUpdatedSuccessfully = "Record Updated Successfully.";
        public const string RecordUploadedSuccessfully = "Record uploaded Successfully.";
        public const string InsertUpdateCompleted = "Record Saved Successfully.";
        public const string RecordDeletedSuccessfully = "Record Deleted Successfully.";
        public const string Somethingwrong = "Something went wrong.";
        public const string NoRecordFound = "No Record Found";
        public const string ResetEmailSuccess = "Instructions to reset your password have been sent to your email address.";
        public const string InvalidEmail = "No account with this email address exists in our database.";
        public const int SuccessCode = 4022;
        public const int FailureCode = 4145;
    
    }
    public static class ActionFlags
    {
        public const int Add = 1;
        public const int Edit = 2;
        public const int Delete = 3;
        public const int ReActivate = 3;
        public const int Search = 5;
    }
}
