using LT.Infrastructure.UnitOfWork.Interfaces;
using LT.UnitTest.MockRepos.EFRepos;
using LT.UnitTest.MockRepos.SPRepos;
using LT.Core;
using LT.Data.EFData.Interfaces;
using LT.Data.SPData.Interfaces;

namespace LT.UnitTest.MockRepos.Common
{
    /// <summary>
    /// Implementation of Interface being designed to implement in both Actual and Mock Repositories to instantiate the object of Repositorries 
    /// No need to add the Repos in Depdency Injection Resolver as we are takign care here itself
    /// </summary>
    public class MockUnitOfWork : IUnitOfWork
    {
        private IMSSurveyCorpRepo msSurveyCorpRepo;
        private ICorpSettingsSPRepo corpSettingsSPRepo;
        private ITokenRepo tokenRepo;
        private readonly InboxContext _context = null;
        public MockUnitOfWork()
        {

        }

        public IMSSurveyCorpRepo MSSurveyCorpRepo { get { return msSurveyCorpRepo ??= new MockMSSurveyCorpRepo(_context); } }
        public ICorpSettingsSPRepo CorpSettingsSPRepo { get { return corpSettingsSPRepo ??= new MockCorpSettingsSPRepo(); } }
        public ITokenRepo TokenRepo { get { return tokenRepo ??= new MockTokenRepo(_context); } }
        public void Save()
        {
        }
    }
}
