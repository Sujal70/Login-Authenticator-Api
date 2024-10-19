using LT.Infrastructure.UnitOfWork.Interfaces;
using LT.Infrastructure.UnitOfWork.Repositories;
using LT.Application.BusinessClasses;
using LT.Application.BusinessInterfaces;
using Microsoft.Extensions.Caching.Distributed;
using ITAM.Data.EFData.Interfaces;
using ITAM.Data.EFData.Repositories;
using ITAM.Application.BusinessInterfaces;
using ITAM.Application.BusinessClasses;
using ITAM.Core.DBEntities;

namespace LT.Api.Core_DI
{

    /// <summary>
    /// seperate static class to avoid loc in program.cs file
    /// Here we should only add dependencies for business classes
    /// Repositories classes are taken care by Unit Of Work
    /// </summary>
    public static class CommonDependencyResolver
    {
        public static IServiceCollection AddBALDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICorpService, CorpService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAssetMasterService, AssetMasterService>();
            services.AddScoped<IAssetDetailService, AssetDetailService>();
            services.AddScoped<IAssetInventoryService, AssetInventoryService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();
            services.AddScoped<IAssetTypeService, AssetTypeService>();
            services.AddScoped< ILocationMasterService, LocationMasterService> ();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ILocationTypeService, LocationTypeService>();
            services.AddScoped<INoteMasterService, NoteMasterService>();
            services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
            services.AddScoped< IPurchaseEntryService, PurchaseEntryService>();
            services.AddScoped<IAssignAssetService, AssignAssetService>();
            services.AddScoped<IDocumentsService, DocumentsService>();
            services.AddScoped<ISystemCodesService, SystemCodesService>();
            services.AddScoped<IUserLoginServices, UserLoginServices>();
            return services; 
        }
        public static IServiceCollection AddDACDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IDistributedCache, MemoryDistributedCache>();
            services.AddScoped<IAssetMasterRepo, AssetMasterRepo>();
            services.AddScoped<IAssetDetailRepo, AssetDetailRepo>();
            services.AddScoped<IAssetInventoryRepo, AssetInventoryRepo>();
            services.AddScoped<IManufacturerRepo, ManufacturerRepo>();
            services.AddScoped< IAssetTypeRepo, AssetTypeRepo> ();
            services.AddScoped<ILocationMasterRepo, LocationMasterRepo> ();
            services.AddScoped< ISupplierRepo, SupplierRepo> ();
            services.AddScoped<ILocationTypeRepo, LocationTypeRepo> ();
            services.AddScoped< INoteMasterRepo, NoteMasterRepo> ();
            services.AddScoped< IPurchaseOrderRepo, PurchaseOrderRepo> ();
            services.AddScoped<IPurchaseEntryRepo, PurchaseEntryRepo> ();
            services.AddScoped< IAssignAssetRepo, AssignAssetRepo> ();
            services.AddScoped<IDocumentsRepo, DocumentsRepo> (); 
            services.AddScoped<ISystemCodesRepo, SystemCodesRepo> ();
            services.AddScoped<IUserLoginRepo, UserLoginRepo>();
            return services;
        }

    }
}
