using LT.Core;
using LT.Data.EFData.Interfaces;

namespace LT.Data.EFData.Repositories
{
    public class MSSurveyCorpRepo(CPortalContext dbContext) : IMSSurveyCorpRepo
    {
        public CPortalContext _dbContext { get; } = dbContext;
    }

    public class TokenRepo(CPortalContext dbContext) : ITokenRepo
    {
        public CPortalContext _dbContext { get; } = dbContext;
    }
}
