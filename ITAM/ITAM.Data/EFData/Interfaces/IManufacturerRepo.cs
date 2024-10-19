using DataHelper.EFData.Common.Interfaces;
using ITAM.Core.DBEntities;
using LT.Core;

namespace ITAM.Data.EFData.Interfaces
{
    public interface IManufacturerRepo : IGenericBaseRepo<Manufacturer, InboxContext>
    {
    }
}
