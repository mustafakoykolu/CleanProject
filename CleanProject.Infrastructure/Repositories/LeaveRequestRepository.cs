using CleanProject.Application.Contracts.Persistence;
using CleanProject.Domain;
using CleanProject.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CleanProject.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveType>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HrDatabaseContext context) : base(context)
        {

        }
        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = await _context.LeaveRequests.Include(q=> q.LeaveType).ToListAsync();
            return leaveRequests;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
        {
            var leaveRequests = await _context.LeaveRequests.Where(q => q.RequestingEmployeeId==userId).Include(q=> q.LeaveType).ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequsetWithDetails(int id)
        {
            var leaveRequests = await _context.LeaveRequests.Include(q => q.LeaveType).FirstOrDefaultAsync(q => q.Id ==id);
            return leaveRequests;
        }

        Task IGenericRepository<LeaveRequest>.CreateAsync(LeaveRequest entity)
        {
            throw new NotImplementedException();
        }

        Task IGenericRepository<LeaveRequest>.DeleteAsync(LeaveRequest entity)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<LeaveRequest>> IGenericRepository<LeaveRequest>.GetAsync()
        {
            throw new NotImplementedException();
        }

        Task<LeaveRequest> IGenericRepository<LeaveRequest>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IGenericRepository<LeaveRequest>.UpdateAsync(LeaveRequest entity)
        {
            throw new NotImplementedException();
        }
    }
}
