using CleanProject.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProject.Application.Features.UserType.Queries.GetUser
{
    public record GetUserQuery(int Id) : IRequest<UserTypeDto>
    {

    }
}
