using LT.Core;
using LT.Data.EFData.Interfaces;

namespace LT.Data.EFData.Repositories
{
    public class MSSurveyCorpRepo(InboxContext dbContext) : IMSSurveyCorpRepo
    {
        public InboxContext _dbContext { get; } = dbContext;
    }

    public class TokenRepo(InboxContext dbContext) : ITokenRepo
    {
        public InboxContext _dbContext { get; } = dbContext;
    }
}
