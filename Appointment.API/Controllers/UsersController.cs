using Appointment.API.Data;
using Appointment.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Appointment.API.Controllers
{
    
    [ApiController]
    [Route("/api/users")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;


        public UsersController(DataContext context)
        {
            _context = context;
        }


        //Método GET LIST

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Users.ToListAsync());

        }

        //´Método GET con parámetro

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var user = await _context.Users.FirstOrDefaultAsync(x => x.user_id == id);
            if (user is null)
            {
                return NotFound(); //404
            }

            return Ok(user);

        }




        // Método POST -- CREAR
        [HttpPost]
        public async Task<ActionResult> Post(User user)
        {
            _context.Add(user);
            try
            {

                await _context.SaveChangesAsync();
                return Ok(user);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un usuario con el mismo nombre.");
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
        public async Task<ActionResult> Put(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }



        // Método DELETE-- Eliminar
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.Users
                .Where(x => x.user_id == id)
                .ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound(); //404
            }

            return NoContent(); //204
        }


    }
}
