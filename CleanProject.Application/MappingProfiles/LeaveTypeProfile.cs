using AutoMapper;
using CleanProject.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using CleanProject.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using CleanProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProject.Application.MappingProfiles
{
    public class LeaveTypeProfile:Profile
    {
        public LeaveTypeProfile() { 
            CreateMap<LeaveTypeDto,LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailsDto>();
        }
    }
}
