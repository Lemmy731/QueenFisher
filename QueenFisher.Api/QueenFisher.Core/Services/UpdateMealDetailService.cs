﻿using AutoMapper;
using QueenFisher.Core.DTO;
using QueenFisher.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QueenFisher.Core.Services
{
    public class UpdateMealDetailService: IUpdateMealDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMealDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;   
            _mapper = mapper;   
        }

        public async Task<Response<string>> UpdateAsync(UpdateMealDetailDTO data)
        {
            var response = await _unitOfWork.UpdateMealDetailRepo.UpdateAsync(data);
            if (response != null) return Response<string>.Success("successful", response);
            return Response<string>.Fail("Failed");

        }
    }
}
