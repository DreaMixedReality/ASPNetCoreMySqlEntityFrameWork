using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPNetCoreMySqlEntityFrameWork.Models;

namespace ASPNetCoreMySqlEntityFrameWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : Controller
    {
        private MusicStoreContext _context;

        public AlbumsController(MusicStoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Albums.ToListAsync());
        }

        // GET: api/Albums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            return await _context.Albums.ToListAsync();
        }

        // GET: api/Albums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            var album = await _context.Albums.FindAsync(id);

            if (album == null)
            {
                return NotFound();
            }

            return album;
        }

        // PUT: api/Albums/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        //id and album.id must be the same

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbum(int id, Album album)
        {
            if (id != album.Id)
            {
                return BadRequest();
            }

            _context.Entry(album).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id))
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

        //Check if the album with id already exists, if so, it is replaced, else it is added
        //id and album.id must be the same

        [HttpPost("{id}")]
        public async Task<ActionResult<Album>> Upsert(int id, Album album)
        {
            if (AlbumExists(id))
            {
               await this.PutAlbum(id, album);
            }
            else
            {
                _context.Albums.Add(album);
            }
            await _context.SaveChangesAsync();

            return album;
        }

        // DELETE: api/Albums/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Album>> DeleteAlbum(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();

            return album;
        }

  


        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.Id == id);
        }
    }
}
