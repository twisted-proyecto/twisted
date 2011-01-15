using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using MvcApplication1.Controllers;

namespace MvcApplication1.Views.Viaje
{
    public partial class VerViajes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void BtnExportClick(object sender, EventArgs e)
        {
            // Get the report document
            CrystalReport1 repDoc = new CrystalReport1();
            // Stop buffering the response
            Response.Buffer = false;
            // Clear the response content and headers
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                // Export the Report to Response stream in PDF format and file name Customers
                repDoc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Customers");
                // There are other format options available such as Word, Excel, CVS, and HTML in the ExportFormatType Enum given by crystal reports
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex = null;
            }
        }


    }
}