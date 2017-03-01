using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Marikina
{
    public partial class _Default : Page
    {
        public string img;
        static string ef = ConfigurationManager.ConnectionStrings["marikinaDBEntities"].ConnectionString;
        static EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder(ef);
        string cs = builder.ProviderConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd3 = new SqlCommand("SELECT TOP 1 banner_image FROM banner ORDER BY banner_id DESC;", con);
            con.Open();

            byte[] bytes3 = cmd3.ExecuteScalar() as byte[];

            string strBase642 = Convert.ToBase64String(bytes3);

            img = "data:Image/png;base64," + strBase642;

            con.Close();


        }
        public string BannerImage { get { return img; } }
    }
}