using Appointment.API.Data;
using Appointment.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Appointment.API.Controllers
{

    [ApiController]
    [Route("/api/schedules")]
    public class SchedulesController : ControllerBase
    {
        private readonly DataContext _context;


        public SchedulesController(DataContext context)
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

            var scheduling = await _context.Schedules.FirstOrDefaultAsync(x => x.order_id == id);
            if (scheduling is null)
            {
                return NotFound(); //404
            }

            return Ok(scheduling);

        }




        // Método POST -- CREAR
        [HttpPost]
        public async Task<ActionResult> Post(Scheduling scheduling)
        {
            _context.Add(scheduling);
            try
            {

                await _context.SaveChangesAsync();
                return Ok(scheduling);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una cita agendada. Realice un nuevo agendamiento.");
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
        public async Task<ActionResult> Put(Scheduling scheduling)
        {
            _context.Update(scheduling);
            await _context.SaveChangesAsync();
            return Ok(scheduling);
        }



        // Método DELETE-- Eliminar
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.Schedules
                .Where(x => x.order_id == id)
                .ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound(); //404
            }

            return NoContent(); //204
        }


    }
}

