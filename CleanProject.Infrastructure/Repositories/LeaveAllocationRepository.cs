using CleanProject.Application.Contracts.Persistence;
using CleanProject.Domain;
using CleanProject.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CleanProject.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveType>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task AddAllocations(List<LeaveAllocation> allocations)
        {
            await _context.AddRangeAsync(allocations);
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(q=> q.EmployeeId == userId && q.LeaveTypeId == leaveTypeId && q.Period == period);
        }

        public Task CreateAsync(LeaveAllocation entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(LeaveAllocation entity)
        {
            throw new NotImplementedException();
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocations = await _context.LeaveAllocations.Include(q => q.LeaveType).FirstOrDefaultAsync( q=> q.Id ==id);
            return leaveAllocations;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            var leaveAllocations= await _context.LeaveAllocations.Include(q=> q.LeaveType).ToListAsync();
            return leaveAllocations;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
        {
            var leaveAllocations = await _context.LeaveAllocations.Where(q => q.EmployeeId == userId).Include(q=> q.LeaveType).ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
            var leaveAllocations = await _context.LeaveAllocations.FirstOrDefaultAsync(q=> q.EmployeeId == userId && q.LeaveTypeId==leaveTypeId);
            return leaveAllocations;
        }

        public Task UpdateAsync(LeaveAllocation entity)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<LeaveAllocation>> IGenericRepository<LeaveAllocation>.GetAsync()
        {
            throw new NotImplementedException();
        }

        Task<LeaveAllocation> IGenericRepository<LeaveAllocation>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
