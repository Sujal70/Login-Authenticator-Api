﻿namespace ConfigReader.Entities
{
    public enum LogType
    {
        Information = 1,
        Warnings = 2,
        Exception = 3,
        Validation_Steps = 4
    }

    public enum ExceptionLevel
    {
        Low = 5,
        Medium = 6,
        High = 7,
        Critical = 8
    }

    public enum ScreenMasterEnum
    {
        NA_Inbox = 1,
        Listofdialoguesfiled_Assignedtome = 2,
        Listofdialoguesfiled_Team = 3,
        Listofdialoguesfiled_Closed = 4,
        Listofdialoguesfiled_All = 5,
        OpenfiledDialogue = 6,
        ListofBookmarkedDialogues = 7,
        AutoFilteredMessages = 8,
        UserFilteredMessages = 9,
        ListofDrafts = 10,
        WelcomeandAddAccountPage = 11,
        Savetwitterinformationandmessages = 12,
        NewsDashboard = 13,
        SearchDashboard = 14,
        Saved_SearchResult = 15,
        SaveSearchPopup = 16,
        RefineSearch = 17,
        DownloadSearch_WordPopup = 18,
        DownloadSearch_CSVPopup = 19,
        DownloadExportPage = 20,
        Advance_SearchResult = 21,
        NA_PersonalSettings = 22,
        ProfileDashboard = 23,
        PersonalScheduleandRules = 24,
        AccountwideScheduleandRules = 25,
        ListofActivityLogs = 26,
        ListofPermissions = 27,
        MyNotificationSettings_Dashboard = 28,
        MyDigestPreferences_Dashboard = 29,
        NA_Accountsetup = 30,
        GlobalOwner = 31,
        Departments = 32,
        LinkTopics = 33,
        Topics = 34,
        TopicsManagerTranslate = 35,
        Orphans = 36,
        AddCategory = 37,
        AddTopics = 38,
        UsersDashboard = 39,
        AddNewUser = 40,
        AddUsergroup = 41,
        ImportUserPopup = 42,
        Messages_Dashboard = 43,
        SuccessMessageTranslate = 44,
        AddNewmessage = 45,
        EditMessage = 46,
        SaveChangesPopup = 47,
        FormsandTemplateDashboard = 48,
        Previewofform = 49,
        ViewForm = 50,
        ViewTemplateForm = 51,
        FormsTranslate = 52,
        Languages_Translator = 53,
        TranslationofLandingPages = 54,
        NA_Communication = 55,
        NewResponseTemplatePopup = 56,
        ResponseTemplatedashboard = 57,
        CriticalAlertsDashboard = 58,
        CustomerFeedback = 59,
        WorkflowDashboard = 60,
        CreateNewWorkflowPopup = 61,
        NA_FormSetup = 62,
        LandingPage_TabEditorDashboard = 63,
        CreateNewPage = 64,
        LandingPageEditor = 65,
        NA_Channels = 66,
        Lines = 67,
        Queues = 68,
        Recording = 69,
        Texting = 70,
        TwitterDashboard = 71,
        EmailSettingsdashboard = 72,
        NA_Reporting = 73,
        DialogueAgingSettings = 74,
        CalendarSettings = 75,
        TagsDashboard = 76,
        SavedExports = 77,
        ExportLog = 78,
        NA = 79,
        DashboardOverview = 80,
        Benchmark = 81,
        Share_Popup = 82,
        TelephoneReportDashboard = 83,
        CSAT = 84,
        QueueManagement = 85,
        CallMetrics = 86,
        Users = 87,
        Users_Sharepopup = 88,
        Categories = 89,
        Categories_sharepopup = 90,
        Comparison_Topics = 91,
        topics_share = 92,
        SavedReportDashboard = 93,
        ClassicDashboardOverview = 94,
        Insights = 95,
        MyPerformance = 96,
        NA_CampaignManager = 97,
        CampaignDashboard = 98,
        CreateNewCampaign = 99,
        EditDrafts = 100,
        ContactsDashboard = 101,
        Contacts_CreateList = 102,
        Contacts_CreateSublist = 103,
        Contacts_Createlistviatopic = 104,
        Basic = 105,
        SavedTemplates = 106,
        SentTemplates = 107,
        NA_CreateDialogue = 108,
        NewDialogueDashboard = 109,
        DialPad = 110,
        NA_LTAssistant = 111,
        Chat = 112,
        Email = 113,
        ExportWizard = 114,
        LTLogin = 115,
        Nogin = 116,
        SAMLLogin = 117,
        GoogleSSO = 118,
        DualSignIn = 119,
        ADLogin = 120,
        Business_Hours = 121,
        IVR = 122,
        LTAProfile = 123,
        LTADashboard = 124,
        ConfigReader=125,
        Communication =126,
        Admin_DeleteDialogue =127,
        Admin_Feedback = 128,
        Admin_Delete_User = 129,
        Admin_Block_Customer = 130,
        Admin_Set_Account_Relation = 131,
        Admin_Process_Timezone_difference = 132,
        Admin_Export_Raw_Data = 133,
        Admin_Campaign_Trickle = 134,
        Admin_Campaign_Mail_Delivery = 135,
        Admin_Campaign_Dashboard_Mapping = 136,
        Admin_Out_of_Office = 137,
        Admin_Activate_Users = 138,
        Admin_Add_Interest_Area = 139,
        Admin_Aging_Scheduler = 140,
        Admin_Add_Remove_User_Group = 141,
        Admin_Email_Counts = 142,
        Admin_Spam_Email_ID = 143,
        Admin_EXE_status = 144,
        Admin_Pull_Email = 145,
        Admin_Exclude_word_cloud = 146,
        Admin_Campaign_Access = 147,
        Admin_Login_History = 148,
        Admin_Benchmark_values = 149,
        Admin_Edit_Campaign_template = 150,
        Admin_Benchmark_data = 151,
        Admin_Auto_Pull_data_path = 152,
        Admin_Map_Excel_columns = 153,
        Admin_Un_Merge_Dialogue = 154,
        Admin_Set_Description = 155,
        Admin_Account_Email = 156,
        Admin_SIS_Integration = 157,
        Admin_Dialouges_Queue = 158,
        Admin_Block_keywords = 159,
        Admin_Telephony_Data = 160,
        Admin_Chatbot_LiveAgent = 161,
        Admin_Block_IP = 162,
        Admin_Notification_Settings = 163,
        Admin_Cache_Clear = 164,
        Phone_Popup = 165,
        Phone_Hub = 166,
        FAQ = 167,
        ResourceCenter = 168
    }


    public enum Environment
    {
        development = 1,
        intuc = 2,
        qauc = 3,
        beta = 4,
        intprod = 5,
        qaprod = 6,
        betaprod = 7,
        ple = 8,
        production = 9,
        
    }
    public enum LogLevel
    {
        Layer = 1,
        Class = 2,
        Method = 3,
        Exception=4,
    }
}
