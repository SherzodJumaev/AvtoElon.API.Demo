using AvtoElon.API.Demo.DTOs.CarDtos;
using AvtoElon.API.Demo.Extensions;
using AvtoElon.API.Demo.Helpers;
using AvtoElon.API.Demo.Interfaces;
using AvtoElon.API.Demo.Mappers.CarMaps;
using AvtoElon.API.Demo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AvtoElon.API.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileUploadService _fileUploadService;
        private readonly IDeleteCarPictures _deleteCarPictures;
        public CarController(
            ICarRepository carRepository, 
            UserManager<AppUser> userManager, 
            IFileUploadService fileUploadService,
            IDeleteCarPictures deleteCarPictures)
        {
            _carRepository = carRepository;
            _userManager = userManager;
            _fileUploadService = fileUploadService;
            _deleteCarPictures = deleteCarPictures;
        }

        // GET: api/<CarController>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cars = await _carRepository.GetAllAsync(query);

            return Ok(cars.Select(c => c.FromCarToCarDto()));
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var car = await _carRepository.GetAsync(id);

            if (car == null)
            {
                return NotFound($"The car with the given id:{id} not found.");
            }

            return Ok(car.FromCarToCarDto());
        }

        // POST api/<CarController>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCarDto createCarDto, [FromQuery] EnumQueryObject queryObject, [FromServices] IWebHostEnvironment environment)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var carModel = createCarDto.FromCreateCarDtoToCar(queryObject, appUser);

            var createdCar = await _carRepository.CreateAsync(carModel);

            return CreatedAtAction(nameof(GetById), new { id = createdCar.Id }, createdCar);
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] UpdateCarDto carDto, [FromQuery] EnumQueryObject queryObject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (carDto.CarPictures == null)
            {
                var carModel = carDto.FromUpdateCarDtoToCarWithoutImage(queryObject);

                var updatedCar = await _carRepository.UpdateAsync(id, carModel);

                if (updatedCar == null)
                {
                    return NotFound($"The car with the given id:{id} not found.");
                }

                return Ok(updatedCar.FromCarToCarDto());
            }
            else
            {
                await _deleteCarPictures.DeleteCarPicturesAsync(id);

                var carModel = carDto.FromUpdateCarDtoToCar(queryObject);

                foreach (var picture in carDto.CarPictures)
                {
                    await _fileUploadService.UploadFile(picture, id);
                }

                var updatedCar = await _carRepository.UpdateAsync(id, carModel);

                if (updatedCar == null)
                {
                    return NotFound($"The car with the given id:{id} not found.");
                }

                return Ok(updatedCar.FromCarToCarDto());
            }
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isDeleted = await _carRepository.SoftDeleteAsync(id);

            if (!isDeleted)
            {
                return NotFound($"The car with the given id:{id} not found.");
            }

            return NoContent();
        }
    }
}
