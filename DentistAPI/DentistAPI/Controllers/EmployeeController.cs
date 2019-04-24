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
    //Controlador para los llamados relacionados a los empleados o usuarios
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly dentistdbContext _dentistdbContext;
        //Constructor que crea un usuario si no hay registros en la tabla
        public EmployeeController(dentistdbContext dentistdbContext)
        {
            _dentistdbContext = dentistdbContext;
            if (_dentistdbContext.Usuario.Count() == 0)
            {
                _dentistdbContext.Usuario.Add(new Usuario { Cedula = "123456",Email="email@email.com",Nombre="Demo User",Password="1234",Telefono="6666666" });
                _dentistdbContext.SaveChanges();
            }
        }
        //Listado de todos los usuarios llamado get https://localhost:44358/api/employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetEmployees()
        {
            return await _dentistdbContext.Usuario.ToListAsync();
        }
        //consulta de un usuario llamado get https://localhost:44358/api/employee/cedula
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
        //insercion de un usuario llamado post https://localhost:44358/api/employee en el body del request se envia el json
        [HttpPost]
        public async Task<ActionResult<Usuario>> AddEmployee(Usuario usuario)
        {
            _dentistdbContext.Usuario.Add(usuario);
            await _dentistdbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployee), new { id = usuario.Cedula }, usuario);
        }
        //actualizacion de un usuario llamado put https://localhost:44358/api/employee/cedula en el body del request se envia el json
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(string id, Usuario usuario)
        {
            if (!id.Equals(usuario.Cedula))
            {
                return BadRequest();
            }

            _dentistdbContext.Entry(usuario).State = EntityState.Modified;
            await _dentistdbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}