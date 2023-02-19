﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using QueenFisher.Data.Context;
using QueenFisher.Data.Domains;
using QueenFisher.Data.Repositories;


namespace QueenFisher.Data.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly QueenFisherDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private IUserRepository _userRepository;
   

        
        public UnitOfWork(QueenFisherDbContext context, UserManager<AppUser>  userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }
        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context, _userManager,_mapper);
       
    }
}
