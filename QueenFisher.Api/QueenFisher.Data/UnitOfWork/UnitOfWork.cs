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

        private readonly IUpdateMealDetailRepo _updateMealRepository;

        private readonly UserManager<AppUser> _userManager;
        
        private readonly IMapper _mapper;
        private readonly UserManager<Meal> _mealmanager;

        private IUserRepository _userRepository;

        private IGetMealRepository _mealRepository;
   

        
        //public UnitOfWork(QueenFisherDbContext context, UserManager<AppUser>  userManager,IMapper mapper)

        private IMealRepository _mealRepository1;



        public UnitOfWork(QueenFisherDbContext context, UserManager<AppUser>  userManager, IMapper mapper)

        {
            _context = context;
            _userManager = userManager;
           
            _mapper = mapper;
            
        }

        //public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);

        public IUpdateMealDetailRepo UpdateMealDetailRepo => _updateMealRepository ?? new UpdateMealDetailRepo(_context);   


        
        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context, _userManager,_mapper);


        public IGetMealRepository MealRepository => _mealRepository ?? new GetMealRepository(_context, _mapper);

       
        public IMealRepository MealRepository1 => _mealRepository1 ?? new MealRepository(_context);

        public async Task<int> Save()
        {
            return _context.SaveChanges();
        }


    }
}
