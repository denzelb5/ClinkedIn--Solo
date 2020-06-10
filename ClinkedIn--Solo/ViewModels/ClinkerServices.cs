using ClinkedIn__Solo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn__Solo.ViewModels
{
    public class ClinkerServices
    {
        public int ClinkerId { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Services { get; set; }
    }
}
