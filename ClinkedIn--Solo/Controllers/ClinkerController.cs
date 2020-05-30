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

        // api/clinker
        [HttpPut("{FirstName}/{LastName}/{PrisonTermEndDate}")]
        public IActionResult AddClinker(string FirstName, string LastName, DateTime PrisonTermEndDate)
        {
            var existingClinker = _repository.GetIdByClinkerName(FirstName, LastName, PrisonTermEndDate);
            if (existingClinker == null)
            {
                var clinkerAdded = _repository.AddNewClinker(FirstName, LastName, PrisonTermEndDate);
                return Created("", clinkerAdded);
            }
            else
            {
                return BadRequest("User already exists.");
            }
        }
    }
}
