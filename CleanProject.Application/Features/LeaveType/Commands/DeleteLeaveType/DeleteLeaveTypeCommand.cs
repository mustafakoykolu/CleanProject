﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProject.Application.Features.LeaveType.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommand: IRequest<Unit>
{
    public int Id { get; set; }
}
