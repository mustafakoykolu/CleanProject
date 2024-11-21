using AutoMapper;
using CleanProject.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProject.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public GetLeaveTypeDetailsHandler(IMapper mapper,ILeaveTypeRepository leaveTypeRepository )
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository; 

    }
    public Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        //Query the database
        var leaveTypeDetail = await _leaveTypeRepository.GetByIdAsync(request.Id);

        // convert data object to dto object
        var data = _mapper.Map<LeaveTypeDetailsDto>( leaveTypeDetail);

        //return Dto object
        return data;
    }
}
