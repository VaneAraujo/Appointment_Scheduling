using Appointment.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Appointment.Shared.Entities;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("/api/patients")]
    public class PatientsController: ControllerBase
    {
        private readonly DataContext _context;

        public PatientsController(DataContext context)
        {
            _context = context;
        }

        //Método GET LIST
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Patients.ToListAsync());
        }

        //Método GET con parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
            if (patient is null)
            {
                return NotFound(); //404
            }
            return Ok(patient);
        }


        // Método POST -- CREAR
        [HttpPost]
        public async Task<ActionResult> Post(Patient patient)
        {
            _context.Add(patient);
            try
            {

                await _context.SaveChangesAsync();
                return Ok(patient);
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
        public async Task<ActionResult> Put(Patient patient)
        {
            _context.Update(patient);
            await _context.SaveChangesAsync();
            return Ok(patient);
        }

        //Método DELETE-- Eliminar
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.Patients
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
