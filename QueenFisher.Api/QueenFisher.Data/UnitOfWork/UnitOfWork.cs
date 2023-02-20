using AutoMapper;
using Microsoft.AspNetCore.Identity;
using QueenFisher.Data.Context;
using QueenFisher.Data.Domains;
using QueenFisher.Data.IRepositories;
using QueenFisher.Data.Repositories;


namespace QueenFisher.Data.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly QueenFisherDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        
        private readonly IMapper _mapper;
        private readonly UserManager<Meal> _mealmanager;
        private IUserRepository _userRepository;
        private IMealRepository _mealRepository;
   

        
        public UnitOfWork(QueenFisherDbContext context, UserManager<AppUser>  userManager,IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
           
            _mapper = mapper;
            
        }

        
        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context, _userManager,_mapper);
        public IMealRepository MealRepository => _mealRepository ?? new MealRepository(_context, _mapper);
    }
}
