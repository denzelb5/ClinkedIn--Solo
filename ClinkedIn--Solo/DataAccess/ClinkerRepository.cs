using ClinkedIn.Models;
using ClinkedIn__Solo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ClinkedIn__Solo.DataAccess
{
    public class ClinkerRepository
    {
        string ConnectionString;
        public ClinkerRepository(IConfiguration config)
        {
            var ConnectionString = config.GetConnectionString("ClinkedIn--Solo");

        }

        public IEnumerable<Clinker> AddNewClinker(string FirstName, string LastName, DateTime PrisonTermEndDate)
        {
            var sql = @"INSERT INTO CLINKER (FirstName, LastName, PrisonTermEndDate)
                        VALUES (@FirstName, @LastName, @PrisonTermEndDate)";

            var parameters = new
            {
                FirstName = FirstName,
                LastName = LastName,
                PrisonTermEndDate = PrisonTermEndDate
            };

            using (var db = new SqlConnection(ConnectionString))
            {
                var result = db.Query<Clinker>(sql, parameters);
                return result;
            }
        }

        public int GetIdByClinkerName(string FirstName, string LastName, DateTime PrisonTermEndDate)
        {
            var sql = @"SELECT Id From clinker 
                        where FirstName = @FirstName
                        AND LastName = @LastName
                        AND PrisonTermEndDate = @PrisonTermEndDate;";

            var parameters = new
            {
                FirstName = FirstName,
                LastName = LastName,
                PrisonTermEndDate = PrisonTermEndDate
            };

            using (var db = new SqlConnection(ConnectionString))
            {
                var result = db.QueryFirstOrDefault<int>(sql, parameters);
                return result;
            }
        }
    }
}
