using QueenFisher.Core.Interfaces;
using QueenFisher.Data.Context;
using QueenFisher.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenFisher.Data.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly QueenFisherDbContext _context;
        private readonly IUpdateMealDetailRepo _updateMealRepository;
        private IUserRepository _userRepository;
        public UnitOfWork(QueenFisherDbContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);

        public IUpdateMealDetailRepo UpdateMealDetailRepo => _updateMealRepository ?? new UpdateMealDetailRepo(_context);   
    }
}
