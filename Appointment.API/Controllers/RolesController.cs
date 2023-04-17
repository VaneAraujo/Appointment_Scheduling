using Appointment.API.Data;
using Appointment.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("/api/roles")]
    public class RolesController : ControllerBase
    {
        private readonly DataContext _context;


        public RolesController(DataContext context)
        {
            _context = context;
        }


        //Método GET LIST

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Roles.ToListAsync());

        }

        //´Método GET con parámetro

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var role = await _context.Roles.FirstOrDefaultAsync(x => x.role_id == id);
            if (role is null)
            {
                return NotFound(); //404
            }

            return Ok(role);

        }




        // Método POST -- CREAR
        [HttpPost]
        public async Task<ActionResult> Post(Role role)
        {
            _context.Add(role);
            try
            {

                await _context.SaveChangesAsync();
                return Ok(role);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un rol con el mismo nombre.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }





        //Método PUT --- UPDATE

        [HttpPut]
        public async Task<ActionResult> Put(Role role)
        {
            _context.Update(role);
            await _context.SaveChangesAsync();
            return Ok(role);
        }



        // Método DELETE-- Eliminar
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.Roles
                .Where(x => x.role_id == id)
                .ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound(); //404
            }

            return NoContent(); //204
        }


    }
}
