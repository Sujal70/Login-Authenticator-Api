using AutoMapper;
using LT.Core.DBEntities;
using LT.Core.ModelEntities;

namespace LT.Core.Profiles
{
    /// <summary>
    /// Use to transfer the data between two entities
    /// </summary>
    public class SurveyCorporateProfile : Profile
    {
        public override string ProfileName => nameof(SurveyCorporateProfile);
        public SurveyCorporateProfile()
        {
            CreateMap<MSSurveyCorporate, SurveyCorporateModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.First_Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Last_Name))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.Email_Address))
                .ForMember(dest => dest.CorporateName, opt => opt.MapFrom(src => src.Corporate_Name))
                .ForMember(dest => dest.CorporateNo, opt => opt.MapFrom(src => src.Corporate_No))
                .ForMember(dest => dest.CorporateId, opt => opt.MapFrom(src => src.Corporate_Id))
                .ForMember(dest => dest.Parent, opt => opt.MapFrom(src => src.Parent))
                .ForMember(dest => dest.TimezoneId, opt => opt.MapFrom(src => src.Timezone_Id))
                .ForMember(dest => dest.CorporatePassword, opt => opt.MapFrom(src => src.Corporate_Password))
                .ForMember(dest => dest.IpAddress, opt => opt.MapFrom(src => src.Ip_Address))
                .ForMember(dest => dest.LastIpAddress, opt => opt.MapFrom(src => src.Last_Ip_Address))
                .ForMember(dest => dest.Folder, opt => opt.MapFrom(src => src.Folder))
                .ForMember(dest => dest.TimeFormat, opt => opt.MapFrom(src => src.TimeFormat))
                .ForMember(dest => dest.DateFormat, opt => opt.MapFrom(src => src.DateFormat))
                .ForMember(dest => dest.IsSuperAdmin, opt => opt.MapFrom(src => src.IsSuperAdmin))
                .ForMember(dest => dest.AccountType, opt => opt.MapFrom(src => src.Account_Type))
                .ForMember(dest => dest.MSDate, opt => opt.MapFrom(src => src.MS_Date))
                .ForMember(dest => dest.ExpiresOn, opt => opt.MapFrom(src => src.Expires_On))
                .ForMember(dest => dest.IsWLC, opt => opt.MapFrom(src => src.IsWLC))
                .ForMember(dest => dest.IsDelete, opt => opt.MapFrom(src => src.IsDelete))
                .ReverseMap();
        }
    }

}
