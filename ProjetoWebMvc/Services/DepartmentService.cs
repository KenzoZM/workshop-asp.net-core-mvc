using Microsoft.EntityFrameworkCore;
using ProjetoWebMvc.Models;
using System.Text.RegularExpressions;

namespace ProjetoWebMvc.Services
{
    public class DepartmentService
    {
        private readonly ProjetoWebMvcContext _context;

        public DepartmentService(ProjetoWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
