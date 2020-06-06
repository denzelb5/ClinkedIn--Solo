using ClinkedIn__Solo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ClinkedIn.Models
{
    public class Clinker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime PrisonTermEndDate { get; set; }
        public List<Services> ClinkerServices { get; set; }

    }

}
