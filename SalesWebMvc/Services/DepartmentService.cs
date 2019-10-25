using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }
        //OPERAÇÃO ASSINCRONA//
        public async Task<List<Department>> FindAllAsync()
        {
            return  await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
        /*MESMA OPERAÇÃO, POREM SINCRONA
         
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }*/
    }
}
