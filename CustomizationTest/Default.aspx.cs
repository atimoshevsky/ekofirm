using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decorator.Generic;

namespace CustomizationTest
{
    public class CurrencyInfoDO
    {
        public string CurrencyCode { get; set; }
    }

    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrencyInfoDO infoDO = new CurrencyInfoDO();
            infoDO.CurrencyCode = "USD";

            Control objCurrencyControl = Page.LoadControl("~/UserControls/ucCurrencyControl.ascx");
            objCurrencyControl.ID = "objCurrencyControl";
            (objCurrencyControl as ICustomizationControlInterface<CurrencyInfoDO>).SetData(infoDO);

            phCurrency.Controls.Add(objCurrencyControl);


        }

        protected void btnSubmitForm_Click(object sender, EventArgs e)
        {
            Control objCurrencyControl  = phCurrency.FindControl("objCurrencyControl");
            if (objCurrencyControl != null)
            {
                CurrencyInfoDO objCurrencyInfoDO = (objCurrencyControl as ICustomizationControlInterface<CurrencyInfoDO>).GetData();
                lblCurrentCurrency.Text = objCurrencyInfoDO.CurrencyCode;
            }

        }
    }
}