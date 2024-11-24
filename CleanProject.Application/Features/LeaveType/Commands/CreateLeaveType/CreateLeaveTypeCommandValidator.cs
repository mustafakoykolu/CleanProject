using CleanProject.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProject.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandValidator: AbstractValidator<CreateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        RuleFor(p=>p.Name).NotEmpty().WithMessage("{ProperyName} is required").NotNull().MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");
        RuleFor(p => p.DefaultDays).LessThan(100).WithMessage("{ProperyName} cannot exceed 100").GreaterThan(1).WithMessage("{PropertyName} cannot less than 1");
        RuleFor(q => q).MustAsync(LeaveTypeNameUnique).WithMessage("Leave type already exists");
        _leaveTypeRepository = leaveTypeRepository;
    }

    private async Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
    {
        return await _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
    }
}
