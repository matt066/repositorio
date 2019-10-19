using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contas.Repositories.FonteDeDados
{
    public class FabricaPersisteContext : IDesignTimeDbContextFactory<PersisteContext>
    {
        private const string CnString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public PersisteContext CreateDbContext( op)
        {
            
        }
    }
}
