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
        private IUserRepository _userRepository;
        private MealRepository _mealRepository;

        public UnitOfWork(QueenFisherDbContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);
        public IMealRepository MealRepository => _mealRepository ?? new MealRepository(_context);
    }
}
