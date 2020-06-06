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
            ConnectionString = config.GetConnectionString("ClinkenIn--2");

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

        public IEnumerable<Clinker> GetAllServicesByClinkerId(int clinkerId)
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
                    info.ClinkerServices = serviceList.Where(x => x.Id == info.Id).Select(x => x.Name);
                }

                return result;
            }
        }


        //public IEnumerable<InvoiceWithCustomerAndTrackInfoPart2> GetInvoicesWithCustomersAndTracksPart2()
        //{
        //    var sql = @"
        //                select i.InvoiceId,c.CustomerId, i.InvoiceDate, i.Total, c.FirstName + ' ' + c.LastName as CustomerName
        //                from Invoice i  
        //                    join customer c
        //                        on i.customerid = c.customerid
        //              ";

        //    var invoiceLineQuery = "select trackid, invoiceid from invoiceline";

        //    using (var db = new SqlConnection(ConnectionString))
        //    {
        //        //var parameters = new { Country = country } << Need to get the sum of the invoice ;
        //        var result = db.Query<InvoiceWithCustomerAndTrackInfoPart2>(sql);
        //        var invoiceLines = db.Query<InvoiceTrack>(invoiceLineQuery);

        //        foreach (var info in result)
        //        {
        //            info.Tracks = invoiceLines.Where(il => il.InvoiceId == info.InvoiceId).Select(il => il.TrackId);
        //        }

        //        return result;
        //    }
        //}


    }
}
