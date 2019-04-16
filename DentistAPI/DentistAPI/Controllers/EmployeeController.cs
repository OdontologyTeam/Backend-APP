using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DentistAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DentistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly dentistdbContext _dentistdbContext;
        public EmployeeController(dentistdbContext dentistdbContext)
        {
            _dentistdbContext = dentistdbContext;
            if (_dentistdbContext.Usuario.Count() == 0)
            {
                _dentistdbContext.Usuario.Add(new Usuario { Cedula = "123456",Email="email@email.com",Nombre="Demo User",Password="1234",Telefono="6666666" });
                _dentistdbContext.SaveChanges();
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetEmployees()
        {
            return await _dentistdbContext.Usuario.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetEmployee(string id)
        {
            var usuario = await _dentistdbContext.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }
    }
}