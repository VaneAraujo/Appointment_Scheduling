using Appointment.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Appointment.Shared.Entities;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("/api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly DataContext _context;

        public DoctorsController(DataContext context)
        {
            _context = context;
        }

        //Método GET LIST
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Doctors.ToListAsync());
        }

        //Método GET con parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var doctors = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);

            if (doctors is null)
            {
                return NotFound(); //404
            }
            return Ok(doctors);
        }


        // Método POST -- CREAR
        [HttpPost]
        public async Task<ActionResult> Post(Doctors doctors)
        {
            _context.Add(doctors);
            try
            {

                await _context.SaveChangesAsync();
                return Ok(doctors);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un paciente con el mismo nombre.");
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
        public async Task<ActionResult> Put(Doctors doctors)
        {
            _context.Update(doctors);
            await _context.SaveChangesAsync();
            return Ok(doctors);
        }

        //Método DELETE-- Eliminar
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.Doctors
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound(); //404
            }

            return NoContent(); //204


        }
    }
}