using LT.Data.EFData.Interfaces;
using LT.Data.SPData.Interfaces;

namespace LT.Infrastructure.UnitOfWork.Interfaces
{

    /// <summary>
    /// Interface is design to implement in both Actual and Mock Repositories to instantiate the object of Repositorries 
    /// No need to add the Repos in Depdency Injection Resolver as we are takign care here itself
    /// </summary>
    public interface IUnitOfWork
    {
        IMSSurveyCorpRepo MSSurveyCorpRepo { get; }
        IParentEmailSPRepo ParentEmailSPRepo { get; }
        ITokenRepo TokenRepo { get; }
        void Save();
    }
}


