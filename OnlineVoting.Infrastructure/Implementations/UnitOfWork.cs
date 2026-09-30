using OnlineVoting.Domain.UseCases;
using OnlineVoting.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Infrastructure.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VotingContext _context;
        public UnitOfWork(VotingContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Votes = new VoteRepository(_context);
            VoteGroup = new VoteGroupRepository(_context);

        }
        public IUserRepository Users
        {
            get; private set;
        }

        public IVoteRepository Votes
        {
            get; private set;

        }

        public IVoteGroupRepository VoteGroup
        {
            get; private set;

        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
