using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClinkedIn__Solo.DataAccess;
using ClinkedIn__Solo.Models;
using ClinkedIn.Models;
using ClinkedIn__Solo.Commands;

namespace ClinkedIn__Solo.Controllers
{
    [Route("api/clinker")]
    [ApiController]
    public class ClinkerController : ControllerBase
    {
        ClinkerRepository _repository;

        public ClinkerController(ClinkerRepository repository)
        {
            _repository = repository;
        }

        

        // api/clinker/addclinker
        [HttpPost("addclinker")]
        public IActionResult AddNewClinker(AddNewClinkerCommand newClinker)
        {
            var existingClinker = _repository.GetIdByClinkerName(newClinker.FirstName, newClinker.LastName, newClinker.PrisonTermEndDate);

            if (existingClinker == null)
            {
                var createdClinker = _repository.AddNewClinker(newClinker);
                return Created("", createdClinker);
            }
            else
            {
                return BadRequest("Clinker already exists.");
            }
        }

       

        //api/clinker/{clinkerId}/services
        [HttpGet("{clinkerId}/services")]
        public IActionResult GetClinkerServices(int clinkerId)
        {
            var services = _repository.GetAllServicesByClinkerId(clinkerId);
            if (!services.Any())
            {
                return NotFound();
            }
            else
            {
                return Ok(services);
            }

        }

        //api/clinker/{clinkerId}/interests
        [HttpGet("{clinkerId}/interests")] 
        public IActionResult GetClinkerInterests(int clinkerId)
        {
            var interests = _repository.GetAllInterestsByClinkerId(clinkerId);
            if (!interests.Any())
            {
                return NotFound();
            }
            else
            {
                return Ok(interests);
            }
        }

        
    }
}
