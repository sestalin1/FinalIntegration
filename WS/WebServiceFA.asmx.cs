using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WS.Models;

namespace WS
{
    /// <summary>
    /// Descripción breve de WebServiceFA
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceFA : System.Web.Services.WebService
    {
        DBConnect db = new DBConnect();
       
        [WebMethod]
        public string InsertSalesType(SalesType t)
        {

            db.Insert("0_sales_types",t);
            return "Insertado con exito";
        }

        [WebMethod]
        public string InsertDimensionTag(DimensionTag t)
        {
            
            db.Insert("0_tags", t);
            return "Insertado con exito";
        }

        [WebMethod]
        public List<SalesGroups> SalesGroups()
        {
            return db.SelectG();
        }

        [WebMethod]
        public List<SalesAreas> SalesAreas()
        {
            return db.SelectA();
        }
    }
}
