using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Generic
{
    public interface IConnectionFactory
    {
        string ConnectionString { get; }
    }
}
