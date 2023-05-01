using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TravelBnB_API.Models;
using TravelBnB_API.Models.Dto;
using TravelBnB_API.Repository.IRepository;

namespace TravelBnB_API.Controllers
{
    [Route("/api/apartmentnumber")]
    [ApiController]
    public class ApartmentNumberController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IApartmentNumberRepository _repository;
        protected APIResponse _response;
        public ApartmentNumberController(IMapper mapper, IApartmentNumberRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
            this._response = new APIResponse();
        }
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            try
            {
                List<ApartmentNumber> apartmentNumbersList = await _repository.GetAllAsync();
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
        public async Task<ActionResult<APIResponse>> Get(int aptNo )
        {
            try
            {
                if(aptNo is 0)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return _response;
                }
                ApartmentNumber apt = await _repository.GetAsync(a => a.AptNo == aptNo);
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                _response.Result = apt;
                return _response;
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string> { ex.Message };
                _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return _response;
            }
        }
        [HttpPost]
        public async Task<ActionResult<APIResponse>> Create([FromBody]ApartmentNumberCreateDTO createDTO)
        {
            try
            {
                if(createDTO is null)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return _response;
                }
                if(await _repository.GetAsync(a => a.AptNo == createDTO.AptNo) != null)
                {
                    ModelState.AddModelError("Error","Numero di appartamento già esistente");
                    return BadRequest(ModelState);
                }

                ApartmentNumber newApt = _mapper.Map<ApartmentNumber>(createDTO);
                await _repository.CreateAsync(newApt);
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
        [HttpDelete]
        public async Task<ActionResult<APIResponse>> Delete(int aptNo)
        {
            try
            {
                if(aptNo == 0)
                {
                    _response.StatusCode =System.Net.HttpStatusCode.NotFound;
                }
                ApartmentNumber apt = await _repository.GetAsync(a => a.AptNo == aptNo);
                await _repository.RemoveAsync(apt);
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
        [HttpPut]
        public async Task<ActionResult<APIResponse>> Update(ApartmentNumberUpdateDTO aptUpdateDto)
        {
            try
            {
                if(aptUpdateDto == null)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return _response;
                }
                if(_repository.GetAllAsync(a => a.AptNo == aptUpdateDto.AptNo) != null)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    _response.ErrorMessages = new List<string> { "L'appartamento non esiste" };
                    return _response;
                }
                 ApartmentNumber updateApt = _mapper.Map<ApartmentNumber>(aptUpdateDto);
                await _repository.UpdateAsync(updateApt);
                await _repository.SaveAsync();
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                _response.Result = updateApt.AptNo;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode=System.Net.HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string> { ex.Message };
                return _response;
            }
        }
    }
}
