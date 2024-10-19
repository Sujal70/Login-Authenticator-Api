using AutoMapper;
using ITAM.Core.DBEntities;
using ITAM.Core.ModelEntities;

namespace ITAM.Core.Profiles
{
    public class AssetDetailProfile:Profile
    {
        public AssetDetailProfile() { 
            CreateMap<AssetDetail, AssetDetailModel>()
                .ForMember(dest => dest.SerialNo, opt => opt.MapFrom(src => src.SerialNo))
                .ForMember(dest => dest.MDMLinkId, opt => opt.MapFrom(src => src.MDMLinkId))
                .ForMember(dest => dest.AssetDescription, opt => opt.MapFrom(src => src.AssetMaster.AssetDescription))
                .ForMember(dest => dest.ManufacturerName, opt => opt.MapFrom(src => src.AssetMaster.AssetType.Manufacturer.Name))
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.AssetMaster.AssetType.Supplier.Name))
                .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.AssetMaster.AssetName))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.DeptId, opt => opt.MapFrom(src => src.AssetMaster.DeptId))
                .ReverseMap();
        }
    }
}
