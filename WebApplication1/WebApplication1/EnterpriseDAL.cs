using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Threading.Tasks;
namespace WebApplication1
{
    //https://www.c-sharpcorner.com/UploadFile/0d5b44/enterprise-library-data-access-application-block-in-C-Sharp-net/#targetText=Enterprise%20Library%20is%20a%20framework,%2C%20Data%20Transfer%20objects%2C%20etc.
    public class EnterpriseDAL
    {
        private static readonly Database operationalDataBase;

        static EnterpriseDAL()
        {
            operationalDataBase = new SqlDatabase(System.Configuration.ConfigurationManager
                                                    .ConnectionStrings["TestConnectionString"]
                                                    .ConnectionString);
        }

        public void selectOp()
        {   
            try
            {
                var allSampleData = operationalDataBase.ExecuteSprocAccessor<CollectData>("[dbo].[GetAllSample]");
            }

            catch(Exception ex)
            {

            }
        }

        class CollectData
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
        }
    }
}