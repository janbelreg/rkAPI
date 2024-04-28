using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rkprodAPIx.Data;
using rkprodAPIx.Model;

namespace rkprodAPIx.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZaznamController : ControllerBase
    {
        private readonly DataContext _context; //  trieda pre pripojenie k databáze

        public ZaznamController(DataContext context)
        {
            _context = context;
        }

        // metoda pre ziskanie zoznamu zaznamov
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zaznam>>> GetZaznamy()
        {
            return await _context.Zaznamy.ToListAsync();
        }

        // metoda pre ziskanie konkretneho zaznamu na zaklade id
        [HttpGet("{id}")]
        public async Task<ActionResult<Zaznam>> GetZaznam(int id)
        {
            var zaznam = await _context.Zaznamy.FindAsync(id);

            if (zaznam == null)
            {
                return NotFound();
            }

            return zaznam;
        }

        // Metoda pre ziskanie zaznamu na zaklade adresata
        [HttpGet("{adresat}")]
        public async Task<ActionResult<Zaznam>> GetZaznamNazov(string adresat)
        {
            var zaznam = await _context.Zaznamy.FindAsync(adresat);

            if (zaznam == null)
            {
                return NotFound();
            }

            return zaznam;
        }

        // Metoda pre vytvorenie noveho zaznamu
        [HttpPost]
        public async Task<ActionResult<Zaznam>> PostZaznam(Zaznam zaznam)
        {
            _context.Zaznamy.Add(zaznam);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetZaznam), new { id = zaznam.Id }, zaznam);
        }

        // Metoda pre editovanie uz existujuceho zaznamu
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZaznam(int id, Zaznam zaznam)
        {
            if (id != zaznam.Id)
            {
                return BadRequest();
            }

            _context.Entry(zaznam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZaznamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // Metoda pre odstranenie zaznamu
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZaznam(int id)
        {
            var film = await _context.Zaznamy.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }

            _context.Zaznamy.Remove(film);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        //Metoda na overenie existencie zaznamu podla id
        private bool ZaznamExists(int id)
        {
            return _context.Zaznamy.Any(e => e.Id == id);
        }
    }
}
