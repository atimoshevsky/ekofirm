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
            get { return @"Data Source=(LocalDb)\v11.0;AttachDbFilename=F:\EcoFirm\MyOpportunity\App_Data\OdeToFoodDb.mdf;Initial Catalog=OdeToFoodDb;Integrated Security=True"; }
        }
    }
}
