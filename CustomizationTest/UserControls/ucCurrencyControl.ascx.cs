using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decorator.Generic;

namespace CustomizationTest.UserControls
{
    public partial class ucCurrencyControl : UserControl,
        ICustomizationControlInterface<CurrencyInfoDO>
    {


        public CurrencyInfoDO GetData()
        {
            CurrencyInfoDO pInfoDO = new CurrencyInfoDO();
            pInfoDO.CurrencyCode = txtCurrency.Text;

            return pInfoDO;
        }

        public void SetData(CurrencyInfoDO pInfoDO)
        {
            txtCurrency.Text = pInfoDO.CurrencyCode;
        }
    }
}