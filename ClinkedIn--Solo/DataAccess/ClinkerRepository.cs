using ClinkedIn.Models;
using ClinkedIn__Solo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ClinkedIn__Solo.Commands;

namespace ClinkedIn__Solo.DataAccess
{
    public class ClinkerRepository
    {
        string ConnectionString;
        public ClinkerRepository(IConfiguration config)
        {
            ConnectionString = config.GetConnectionString("ClinkenIn--2");

        }

        public Clinker AddNewClinker(AddNewClinkerCommand newClinker)
        {
            var sql = @"INSERT INTO CLINKER (FirstName, LastName, PrisonTermEndDate)
                       output inserted.*
                       VALUES (@FirstName, @LastName, @PrisonTermEndDate)";

            using (var db = new SqlConnection(ConnectionString))
            {
                var parameters = new
                {
                    FirstName = newClinker.FirstName,
                    LastName = newClinker.LastName,
                    PrisonTermEndDate = newClinker.PrisonTermEndDate
                };

                var result = db.QueryFirstOrDefault<Clinker>(sql, parameters);
                return result;
            }

        }


        public int? GetIdByClinkerName(string firstName, string lastName, DateTime prisonTermEndDate)
        {
            var sql = @"SELECT Id From clinker 
                        where FirstName = @FirstName
                        AND LastName = @LastName
                        AND PrisonTermEndDate = @PrisonTermEndDate;";

            using (var db = new SqlConnection(ConnectionString))
            {
                var parameters = new
                {
                    FirstName = firstName,
                    LastName = lastName,
                    PrisonTermEndDate = prisonTermEndDate
                };

                var result = db.QueryFirstOrDefault<int>(sql, parameters);

                if (result != 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        

        public IEnumerable<Services> GetAllServicesByClinkerId(int clinkerId)
        {
            var sql = @"select services.*, Clinker.Id
		                from Services
		                join Clinker 
		                On Clinker.Id = Services.ClinkerId
                        where services.clinkerId = @clinkerId;";

            var parameters = new { ClinkerId = clinkerId };
            var servicesQuery = @"select id from services";

            using (var db = new SqlConnection(ConnectionString))
            {
                var result = db.Query<Clinker>(sql, parameters);
                var serviceList = db.Query<Services>(servicesQuery);
                foreach (var info in result)
                {
                    info.ClinkerServices = serviceList.Where(x => x.Id == info.Id).Select(x => x.Id);
                   
                }

                return result;
            }
        }


        

    }
}
