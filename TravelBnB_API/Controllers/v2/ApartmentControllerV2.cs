using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
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
        public async Task<ActionResult<APIResponse>> GetApartments([FromQuery] int? maxPrice, [FromQuery] string? term, int pageSize = 0, int currentPage = 0)
        {
            try
            {
                IEnumerable<Apartment> apartments;
                if(maxPrice is not null )
                {
                    //se è settato il filtro ci torna gli apt con il prezzo massimo il valore settato
                    apartments = await _apartmentRepository.GetAllAsync(a=> a.Rate <=  maxPrice, pageSize:pageSize, currentPage: currentPage );
                }
                else
                {
                    //altrimenti ci torna tutti gli appartamenti
                    apartments = await _apartmentRepository.GetAllAsync(pageSize: pageSize, currentPage: currentPage);
                }
                if (!string.IsNullOrEmpty(term))
                {
                    apartments = apartments.Where(a => a.Name.ToLower().Contains(term.ToLower()));
                }
                Pagination pagination = new Pagination() { PageSize = pageSize , CurrentPage = currentPage};

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination)); //serializziamo l'oggetto pagination e l'aggiungiamo all'header della risposta dell api
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
