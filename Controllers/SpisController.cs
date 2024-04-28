using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rkprodAPIx.Data;
using rkprodAPIx.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rkprodAPIx.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpisController : ControllerBase
    {
        private readonly DataContext _context; // YourDbContext je vaša trieda pre pripojenie k databáze

        public SpisController(DataContext context)
        {
            _context = context;
        }

        //Ziskanie zoznamu spisov
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spis>>> GetSpisy()
        {
            return await _context.Spisy.ToListAsync();
        }

        // Ziskanie Spisu podla id
        [HttpGet("{id}")]
        public async Task<ActionResult<Spis>> GetSpis(int id)
        {
            var spis = await _context.Spisy.FindAsync(id);

            if (spis == null)
            {
                return NotFound();
            }

            return spis;
        }
        //Ziskanie spisu podla nazvu
        [HttpGet("{nazovSpisu}")]
        public async Task<ActionResult<Spis>> GetSpisNazov(string nazovSpisu)
        {
            var spis = await _context.Spisy.FindAsync(nazovSpisu);

            if (spis == null)
            {
                return NotFound();
            }

            return spis;
        }

        // Metoda na vytvorenie spisu
        [HttpPost]
        public async Task<ActionResult<Spis>> PostSpis(Spis spis)
        {
            _context.Spisy.Add(spis);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSpis), new { id = spis.Id }, spis);
        }

        // Metoda pre editaciu uz vytvoreneho spisu
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpis(int id, Spis spis)
        {
            if (id != spis.Id)
            {
                return BadRequest();
            }

            _context.Entry(spis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpisExists(id))
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

        // Metoda pre odstranenie spisu
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpis(int id)
        {
            var spis = await _context.Spisy.FindAsync(id);
            if (spis == null)
            {
                return NotFound();
            }

            _context.Spisy.Remove(spis);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        //Metoda pre overenie existencie spisu
        private bool SpisExists(int id)
        {
            return _context.Spisy.Any(e => e.Id == id);
        }
        //metoda pre identifikovanie konkretnych zaznamov zahrnutych do daneho spisu - na zaklade primarneho a cudzieho kluca v jednotlivych modelovych triedach
        [HttpGet("{id}/zaznamy")]
        public async Task<ActionResult<IEnumerable<Zaznam>>> GetSpisZaznamy(int id)
        {
            var zaznamy = await _context.Zaznamy.Where(f => f.SpisId == id).ToListAsync();
            return zaznamy;
        }
    }

}
