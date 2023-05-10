using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelBnB_API.Models;
using TravelBnB_API.Models.Dto;
using TravelBnB_API.Repository.IRepository;

namespace TravelBnB_API.Controllers.v2
{
    [Route("/api/v{version:apiVersion}/apartment")]
    [ApiController]
    [ApiVersion("2.0")]
    public class ApartmentControllerV2 : ControllerBase
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public ApartmentControllerV2(IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
            _response = new APIResponse();
        }
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30s")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetApartments([FromQuery] int? qPrice)
        {
            try
            {

                IEnumerable<Apartment> apartments;
                if(qPrice is not null)
                {
                    apartments = await _apartmentRepository.GetAllAsync(a=> a.Rate <  qPrice);
                }
                else
                {
                    apartments = await _apartmentRepository.GetAllAsync();
                }

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
    }
}
