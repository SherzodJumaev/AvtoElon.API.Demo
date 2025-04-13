using AvtoElon.API.Demo.DTOs.CarDtos;
using AvtoElon.API.Demo.Extensions;
using AvtoElon.API.Demo.Helpers;
using AvtoElon.API.Demo.Interfaces;
using AvtoElon.API.Demo.Mappers.CarMaps;
using AvtoElon.API.Demo.Models;
using AvtoElon.API.Demo.Repos;
using AvtoElon.API.Demo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AvtoElon.API.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PortfolioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IFileUploadService _fileUploadService;
        private readonly IDeleteCarPictures _deleteCarPictures;

        public PortfolioController(
            UserManager<AppUser> userManager, 
            IPortfolioRepository portfolioRepository, 
            IFileUploadService fileUploadService,
            IDeleteCarPictures deleteCarPictures)
        {
            _userManager = userManager;
            _portfolioRepository = portfolioRepository;
            _fileUploadService = fileUploadService;
            _deleteCarPictures = deleteCarPictures;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        { 
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var userPortfolio = await _portfolioRepository.GetPortfolioAsync(appUser, cancellationToken);
            
            //return Ok(userPortfolio.Select(up => up.FromCarToCarDto()));
            return Ok(userPortfolio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] UpdateCarDto carDto, [FromQuery] EnumQueryObject queryObject, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            if (carDto.CarPictures == null)
            {
                var carModel = carDto.FromUpdateCarDtoToCarWithoutImage(queryObject);

                var updatedCar = await _portfolioRepository.UpdatePortfolioAsync(appUser, id, carModel, cancellationToken);

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

                var updatedCar = await _portfolioRepository.UpdatePortfolioAsync(appUser, id, carModel, cancellationToken);

                if (updatedCar == null)
                {
                    return NotFound($"The car with the given id:{id} not found.");
                }

                return Ok(updatedCar.FromCarToCarDto());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var isDeleted = await _portfolioRepository.DeletePortfolioAsync(appUser, id);

            if (!isDeleted)
            {
                return NotFound($"The car with the given id:{id} not found.");
            }

            return NoContent();
        }
    }
}
