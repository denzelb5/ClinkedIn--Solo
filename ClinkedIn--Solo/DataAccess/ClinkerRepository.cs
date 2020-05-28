using ClinkedIn__Solo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ClinkedIn__Solo.DataAccess
{
    public class ClinkerRepository
    {
        static List<Clinker> _clinkers = new List<Clinker>()
        {
            new Clinker { Id = 1, FirstName = "John", LastName = "Doe", PrisonTermEndDate = new DateTime(2035, 03, 24), Interests = new List<string>() { "Killin" } },
            new Clinker { Id = 2, FirstName = "Jimmie", LastName = "John", PrisonTermEndDate = new DateTime(2050, 04, 12), Interests = new List<string>() { "Killin" } },
            new Clinker { Id = 3, FirstName = "Sam", LastName = "Smith", PrisonTermEndDate = new DateTime(2025, 06, 19), Interests = new List<string>() { "BeatBoxin" } },
            new Clinker { Id = 4, FirstName = "Samson", LastName = "Smith", PrisonTermEndDate = new DateTime(2029, 01, 31), Interests = new List<string>() { "BeatBoxin" } },
            new Clinker {Id = 5, FirstName = "ButterCup", LastName = "Johnson", PrisonTermEndDate = new DateTime(2024, 02, 15), Interests = new List<string>() {"BasketWeavin", "Origamin" } },
            new Clinker {Id = 6, FirstName = "Slash", LastName = "MacGruber", PrisonTermEndDate = new DateTime(2030, 10, 31), Interests = new List<string>() { "Killin", "BasketWeavin" }},
            new Clinker {Id = 7, FirstName = "Slick", LastName = "Willie", PrisonTermEndDate = new DateTime(2021, 09, 22), Interests = new List<string>() { "Origamin" }},
            new Clinker {Id = 8, FirstName = "LittleShoe", LastName = "Wilomena", PrisonTermEndDate = new DateTime(2031, 12, 18), Interests = new List<string>() { "Killin", "BeatBoxin", "Origamin" } },
        };

        static List<Services> _services = new List<Services>()
        {
            new Services { Id = 1, Name= "Hair Cut", Price = 3.00 },
            new Services { Id = 2, Name= "Legal Advice", Price = 5.00 },
            new Services { Id = 3, Name= "Cuddle Buddy", Price = 2.00 }
        };

        static List<string> _interests = new List<string>()
        {
            "ShowTunesin",
            "Killin",
            "BeatBoxin",
            "BasketWeavin",
            "Origamin"
        };

        public Clinker GetByFullName(Clinker clinkerToAdd)
        {
            var firstNameMatch = _clinkers.FindAll(x => x.FirstName == clinkerToAdd.FirstName);
            return firstNameMatch.FirstOrDefault(j => j.LastName == clinkerToAdd.LastName);
        }
    }
}
