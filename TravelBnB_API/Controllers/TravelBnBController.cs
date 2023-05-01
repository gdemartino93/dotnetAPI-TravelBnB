using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Console;
using TravelBnB_API.Data;
using TravelBnB_API.Models;
using TravelBnB_API.Models.Dto;
using TravelBnB_API.Repository.IRepository;

namespace TravelBnB_API.Controllers
{
    [Route("/api/travelBnB")]
    [ApiController]
    public class TravelBnBController : Controller
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        public TravelBnBController(IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
        } 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task< ActionResult<IEnumerable<ApartmentDTO>>> GetApartments()
        {
            IEnumerable<Apartment> apartments = await _apartmentRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ApartmentDTO>>(apartments));
        }
        [HttpGet("id",Name ="GetApartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApartmentDTO>> GetApartment(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var apartment = await _apartmentRepository.GetAsync(a => a.Id == id);
            if(apartment == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ApartmentDTO>(apartment));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApartmentDTO>> CreateApartment([FromBody]ApartmentCreateDTO createApt)
        {
            if(createApt == null)
            {
                return BadRequest(createApt);
            }
            if(createApt.Name == "prova")
            {
                ModelState.AddModelError("NOMEERRORE", "Il nome non può essere prova ");
                return BadRequest(ModelState);
            }
            Apartment newApt = _mapper.Map<Apartment>(createApt);
            await _apartmentRepository.CreateAsync(newApt);
            await _apartmentRepository.SaveAsync();
       
            return CreatedAtRoute("GetApartment",new { id = newApt.Id }, newApt);
        }
        [HttpDelete("id",Name = "DeleteApartment")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteApartment(int id)
        {
            var apartment = await _apartmentRepository.GetAsync(a => a.Id == id);
            await _apartmentRepository.RemoveAsync(apartment);

            return Ok("Appartamento eliminato");
        }
        [HttpPut("id",Name = "UpdateApartment")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateApartment(int id, [FromBody]ApartmentUpdateDTO apartmentDTO)
        {
            if( apartmentDTO == null || apartmentDTO.Id != id)
            {
                ModelState.AddModelError("error","Impossibile aggiornare l'appartemento selezionato");
                return BadRequest(ModelState);
            }
            if (String.IsNullOrWhiteSpace(apartmentDTO.Name))
            {
                ModelState.AddModelError("name", "Il nome non può essere vuoto");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Apartment editApt = _mapper.Map<Apartment>(apartmentDTO);
            await _apartmentRepository.UpdateAsync(editApt );
            await _apartmentRepository.SaveAsync();
            return Ok("Appartamento aggiornato");
        }


    }
}
