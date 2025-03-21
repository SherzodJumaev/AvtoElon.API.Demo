using AvtoElon.API.Demo.DTOs;
using AvtoElon.API.Demo.Helpers;
using AvtoElon.API.Demo.Interfaces;
using AvtoElon.API.Demo.Mappers.CarMaps;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AvtoElon.API.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        // GET: api/<CarController>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cars = await _carRepository.GetAllAsync(query);

            return Ok(cars.Select(c => c.FromCarToCarDtoWithId()));
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var car = await _carRepository.GetAsync(id);

            if(car == null)
            {
                return NotFound($"The car with the given id:{id} not found.");
            }

            return Ok(car.FromCarToCarDto());
        }

        // POST api/<CarController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCarDto createCarDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var carModel = createCarDto.FromCreateCarDtoToCar();

            var createdCar = await _carRepository.CreateAsync(carModel);

            return CreatedAtAction(nameof(GetById), new { id = createdCar.Id }, createdCar);
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCarDto carDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var carModel = carDto.FromUpdateCarDtoToCar();

            var updatedCar = await _carRepository.UpdateAsync(id, carModel);

            if(updatedCar == null)
            {
                return NotFound($"The car with the given id:{id} not found.");
            }

            return Ok(updatedCar.FromCarToCarDto());
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete ([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isDeleted = await _carRepository.SoftDeleteAsync(id);

            if(!isDeleted)
            {
                return NotFound($"The car with the given id:{id} not found.");
            }

            return NoContent();
        }
    }
}
