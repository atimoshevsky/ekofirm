using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Generic
{

    public class CurrencyInfoDO
    {
        public string CurrencyCode { get; set; }
    }

    public interface ICustomizationControlInterface<T> where T : class
    {
        T GetData();
        void SetData(T pInfoDO);
    }

}
