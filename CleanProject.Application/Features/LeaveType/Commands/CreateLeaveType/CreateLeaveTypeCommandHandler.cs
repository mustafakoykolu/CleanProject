﻿using AutoMapper;
using CleanProject.Application.Contracts.Logging;
using CleanProject.Application.Contracts.Persistence;
using CleanProject.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProject.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<CreateLeaveTypeCommandHandler> _logger;
        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository,IAppLogger<CreateLeaveTypeCommandHandler> logger)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _logger = logger;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation errors in create request for {0} - {1}",request.Name,request.DefaultDays);
                throw new BadRequestException("Invalid LeaveType", validationResult);
            }
            //convert to domain entity object
            var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);
            //add to database
            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);
            //return record id
            return leaveTypeToCreate.Id;
        }
    }
}
