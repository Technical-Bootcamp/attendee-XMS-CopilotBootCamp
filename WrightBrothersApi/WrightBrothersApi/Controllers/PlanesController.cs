using Microsoft.AspNetCore.Mvc;
using WrightBrothersApi.Models;

namespace WrightBrothersApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanesController : ControllerBase
    {
        private readonly ILogger<PlanesController> _logger;

        public PlanesController(ILogger<PlanesController> logger)
        {
            _logger = logger;
        }

        private static readonly List<Plane> Planes = new List<Plane>
        {
            new Plane
            {
                Id = 1,
                Name = "Wright Flyer",
                Year = 1903,
                Description = "The first successful heavier-than-air powered aircraft.",
                RangeInKm = 12
            },
            new Plane
            {
                Id = 2,
                Name = "Wright Flyer II",
                Year = 1904,
                Description = "A refinement of the original Flyer with better performance.",
                RangeInKm = 24
            },
            new Plane
            {
                Id = 3,
                Name = "Wright Model A",
                Year = 1908,
                Description = "The first commercially successful airplane.",
                RangeInKm = 40
            }
        };

        [HttpGet]
        public ActionResult<List<Plane>> GetAll()
        {

            
            return Planes;
        }

        [HttpGet("{id}")]
        public ActionResult<Plane> GetById(int id)
        {
            var plane = Planes.Find(p => p.Id == id);

            if (plane == null)
            {
                return NotFound();
            }

            return Ok(plane);
        }

        [HttpPost]
        public ActionResult<Plane> Post(Plane plane)
        {
            Planes.Add(plane);

            return CreatedAtAction(nameof(GetById), new { id = plane.Id }, plane);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Plane plane)
        {
            if (id != plane.Id)
            {
                return BadRequest();
            }

            var index = Planes.FindIndex(p => p.Id == id);

            if (index == -1)
            {
                return NotFound();
            }

            Planes[index] = plane;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var index = Planes.FindIndex(p => p.Id == id);

            if (index == -1)
            {
                return NotFound();
            }

            Planes.RemoveAt(index);

            return NoContent();
        }


    }
}
