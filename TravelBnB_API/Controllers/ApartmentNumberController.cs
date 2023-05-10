using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using TravelBnB_API.Models;
using TravelBnB_API.Models.Dto;
using TravelBnB_API.Repository.IRepository;

namespace TravelBnB_API.Controllers
{
    [Route("/api/v{version:ApiVersion}/apartmentnumber")]
    [ApiController]
    public class ApartmentNumberController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IApartmentNumberRepository _aptNo;
        private readonly IApartmentRepository _aptRepo;
        protected APIResponse _response;
        public ApartmentNumberController(IMapper mapper, IApartmentNumberRepository repository, IApartmentRepository aptRepo)
        {
            _mapper = mapper;
            _aptNo = repository;
            this._response = new APIResponse();
            _aptRepo = aptRepo;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            try
            {
                List<ApartmentNumber> apartmentNumbersList = await _aptNo.GetAllAsync(includeProperties:"Apartment");
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                _response.Result = apartmentNumbersList;
                return _response;
            }
            catch (Exception ex)
            {
                _response.StatusCode=System.Net.HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }
        [HttpGet("{aptNo}",Name = "GetAptNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> Get(int aptNo )
        {
            try
            {
                if(aptNo == 0)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var apt = await _aptNo.GetAsync(a => a.AptNo == aptNo);
                if(apt is null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                _response.Result = _mapper.Map<ApartmentNumberDTO>(apt);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string> { ex.Message };
                _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return _response;
            }
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> Create([FromBody] ApartmentNumberCreateDTO createDTO)
        {
            try
            {
                if (createDTO is null)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return _response;
                }
                if (await _aptNo.GetAsync(a => a.AptNo == createDTO.AptNo) != null)
                {
                    ModelState.AddModelError("Errore", "Numero di appartamento già esistente");
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _response.ErrorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return _response;
                }

                // Controlliamo se l'appartamento collegato esiste
                if (await _aptRepo.GetAsync(a => a.Id == createDTO.ApartmentId) == null)
                {
                    ModelState.AddModelError("Errore", "Appartamento Collegato non esiste");
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _response.ErrorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return _response;
                }

                ApartmentNumber newApt = _mapper.Map<ApartmentNumber>(createDTO);
                await _aptNo.CreateAsync(newApt);
                _response.StatusCode = System.Net.HttpStatusCode.Created;
                _response.Result = _mapper.Map<ApartmentNumberDTO>(createDTO);

                return CreatedAtRoute("GetAptNo", new { aptNo = newApt.AptNo }, _response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string> { ex.InnerException?.Message ?? ex.Message };
                return _response;
            }
        }

        [HttpDelete("{aptNo}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> Delete(int aptNo)
        {
            try
            {
                if(aptNo == 0)
                {
                    _response.StatusCode =System.Net.HttpStatusCode.NotFound;
                }
                ApartmentNumber apt = await _aptNo.GetAsync(a => a.AptNo == aptNo);
                await _aptNo.RemoveAsync(apt);
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                _response.Result = $"Appartamento n.{aptNo} Eliminato";
                return _response;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
                return _response;
            }
        }
        [HttpPut("{aptNo}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> Update(int aptNo,[FromBody]ApartmentNumberUpdateDTO aptUpdateDto)
        {
;
            try
            {
                if (aptUpdateDto.AptNo != aptNo || aptUpdateDto == null)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    _response.ErrorMessages = new List<string> { "L'appartamento non esiste" };
                    return BadRequest(_response);
                }
                //controlliamo se l'appartmento collegato esiste
                if (await _aptRepo.GetAsync(a => a.Id == aptUpdateDto.ApartmentId) == null)
                {
                    ModelState.AddModelError("Errore", "Appartamento Collegato non esiste");
                    _response.IsSuccess = false;
                    return BadRequest(ModelState);
                }
                ApartmentNumber model = _mapper.Map<ApartmentNumber>(aptUpdateDto);
                await _aptNo.UpdateAsync(model);
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                _response.Result = "Aggiornato Correttamente";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string> { ex.Message };
                return _response;
            }
        }
    }
}
