using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Console;
using TravelBnB_API.Data;
using TravelBnB_API.Models;
using TravelBnB_API.Models.Dto;
using TravelBnB_API.Repository.IRepository;

namespace TravelBnB_API.Controllers.v1
{
    [Route("/api/v{version:apiVersion}/apartment")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ApartmentController : Controller
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public ApartmentController(IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
            _response = new APIResponse();
        }

        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30s")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetApartments()
        {
            try
            {
                IEnumerable<Apartment> apartments = await _apartmentRepository.GetAllAsync();
                _response.Result = _mapper.Map<IEnumerable<ApartmentDTO>>(apartments);
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }
        [HttpGet("{id}", Name = "GetApartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetApartment(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;

                    return BadRequest(_response);
                }
                var apartment = await _apartmentRepository.GetAsync(a => a.Id == id);
                if (apartment == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<ApartmentDTO>(apartment);
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }
        [Authorize(Roles = "admin")]

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> CreateApartment([FromBody] ApartmentCreateDTO createApt)
        {
            try
            {
                if (createApt == null)
                {
                    return BadRequest(createApt);
                }
                Apartment newApt = _mapper.Map<Apartment>(createApt);
                await _apartmentRepository.CreateAsync(newApt);

                _response.Result = _mapper.Map<ApartmentDTO>(newApt);
                _response.StatusCode = System.Net.HttpStatusCode.Created;
                return CreatedAtRoute("GetApartment", new { id = newApt.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpDelete("{id}", Name = "DeleteApartment")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "admin")]

        public async Task<ActionResult<APIResponse>> DeleteApartment(int id)
        {
            try
            {
                var apartment = await _apartmentRepository.GetAsync(a => a.Id == id);
                await _apartmentRepository.RemoveAsync(apartment);
                _response.StatusCode = System.Net.HttpStatusCode.Created;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }
        [HttpPut("{id}", Name = "UpdateApartment")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateApartment(int id, [FromBody] ApartmentUpdateDTO apartmentDTO)
        {
            try
            {
                if (apartmentDTO == null || apartmentDTO.Id != id)
                {
                    ModelState.AddModelError("Error", "Impossibile aggiornare l'appartemento selezionato");
                    return BadRequest(ModelState);
                }
                if (string.IsNullOrWhiteSpace(apartmentDTO.Name))
                {
                    ModelState.AddModelError("Error", "Il nome non può essere vuoto");
                }
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return BadRequest(_response);
                }
                Apartment editApt = _mapper.Map<Apartment>(apartmentDTO);
                await _apartmentRepository.UpdateAsync(editApt);
                await _apartmentRepository.SaveAsync();
                _response.StatusCode = System.Net.HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };

            }
            return _response;
        }


    }
}
