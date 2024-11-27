using AutoMapper;
using CleanProject.Application.Contracts.Logging;
using CleanProject.Application.Contracts.Persistence;
using CleanProject.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProject.Application.Features.UserType.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IAppLogger<GetUserQueryHandler> _logger;
        public GetUserQueryHandler(IMapper mapper, IUserTypeRepository userTypeRepository, IAppLogger<GetUserQueryHandler> logger)
        {
            this._mapper = mapper;
            this._userTypeRepository = userTypeRepository;
            this._logger = logger;
        }
        public async Task<UserTypeDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            //Query Database
            var userType = await _userTypeRepository.GetByIdAsync(12);

            // convert data objects to DTO objects
            var data = _mapper.Map<UserTypeDto>(userType);

            //log
            _logger.LogInformation("User type were retrieved successfully");
            //return list of DTO objects
            return data;
        }
    }
}
