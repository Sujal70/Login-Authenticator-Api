﻿using LT.Infrastructure.UnitOfWork.Interfaces;
using LT.Core;
using LT.Data.EFData.Interfaces;
using LT.Data.EFData.Repositories;
using LT.Data.SPData.Interfaces;
using LT.Data.SPData.Repositories;

namespace LT.Infrastructure.UnitOfWork.Repositories
{
    /// <summary>
    /// Implementation of Interface being designed to implement in both Actual and Mock Repositories to instantiate the object of Repositorries 
    /// No need to add the Repos in Depdency Injection Resolver as we are takign care here itself
    /// </summary>
    public class UnitOfWork(InboxContext context) : IUnitOfWork
    {
        private IMSSurveyCorpRepo msSurveyCorpRepo;
        private ICorpSettingsSPRepo selectCorpSettings;
        private ITokenRepo tokenRepo;
        private readonly InboxContext _context = context;

        public IMSSurveyCorpRepo MSSurveyCorpRepo { get { return msSurveyCorpRepo ??= new MSSurveyCorpRepo(_context); } }
        public ICorpSettingsSPRepo CorpSettingsSPRepo { get { return selectCorpSettings ??= new CorpSettingsSPRepo(); } }
        public ITokenRepo TokenRepo { get { return tokenRepo ??= new TokenRepo(_context); } }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}