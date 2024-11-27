using CleanProject.Application.Contracts.Persistence;
using CleanProject.Domain;
using CleanProject.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProject.Persistence.Repositories
{
    public class UserTypeRepository : GenericRepository<UserType>, IUserTypeRepository
    {
        private readonly NutritionDatabaseContext _context;
        public UserTypeRepository(NutritionDatabaseContext context) : base(context)
        {
        }
    }
}
