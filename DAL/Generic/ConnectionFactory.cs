using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Generic
{
    public class ConnectionFactory : IConnectionFactory
    {
        public string ConnectionString
        {
            get { return @"Data Source=(localdb)\Projects;Initial Catalog=Ekofirm;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"; }
        }
    }
}
