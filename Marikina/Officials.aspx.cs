using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using System.IO;

namespace Marikina
{
    public partial class Officials : System.Web.UI.Page
    {
        TableRow[] row = new TableRow[16];
        //TableCell[] cell = new TableCell[32];
        Image[] CouncilorImage = new Image[16];
        Label[] CouncilorLabel = new Label[16];
        TextBox[] CouncilorTextBox = new TextBox[16];
        FileUpload[] CouncilorUpload = new FileUpload[16];
        Button[] CouncilorUploadBtn = new Button[16];


        static string ef = ConfigurationManager.ConnectionStrings["marikinaDBEntities"].ConnectionString;
        static EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder(ef);

        string cs = builder.ProviderConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (IsPostBack)
            {
                CouncilorGetData();
            }
            else
            {
                CouncilorGetData();
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmdMayor = new SqlCommand("SELECT official_image FROM officials WHERE official_role = 'Mayor';", con);
                con.Open();

                byte[] bytesMayor = cmdMayor.ExecuteScalar() as byte[];

                string strBase642 = Convert.ToBase64String(bytesMayor);

                MayorImage.ImageUrl = "data:Image/png;base64," + strBase642;

                con.Close();

                SqlCommand cmd2 = new SqlCommand("SELECT official_image FROM officials WHERE official_id = 2;", con);
                con.Open();

                byte[] bytes2 = cmd2.ExecuteScalar() as byte[];

                string strBase64 = Convert.ToBase64String(bytes2);

                ViceMayorImage.ImageUrl = "data:Image/png;base64," + strBase64;

                con.Close();
            }




        }

        public void CouncilorGetData()
        {
            var strBase64 = new List<string>();
            //var image = new List<Byte>();
            var councilorName = new List<string>();
            int i = 0;

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SELECT official_name, official_image FROM officials WHERE official_role = 'District 1: Councilor' OR official_role = 'District 2: Councilor';", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                byte[] bytesCouncilor = reader["official_image"] as byte[];
                strBase64.Add(Convert.ToBase64String(bytesCouncilor));
                councilorName.Add(reader["official_name"].ToString());
            }

            TableRow row1 = new TableRow();
            TableRow row2 = new TableRow();
            TableRow row3 = new TableRow();
            TableRow row4 = new TableRow();


            for (i = 0; i < 8; i++)
            {
                CouncilorImage[i] = new Image();
                CouncilorLabel[i] = new Label();

                CouncilorImage[i].ImageUrl = "data:Image/png;base64," + strBase64[i];
                CouncilorImage[i].Height = 200;
                CouncilorImage[i].Width = 160;
                CouncilorImage[i].ID = "CouncilorImage" + i + 1;

                CouncilorLabel[i].Text = councilorName[i];
                CouncilorLabel[i].ID = "CouncilorLabel" + i + 1;

                TableCell cell1 = new TableCell();

                cell1.Controls.Add(CouncilorImage[i]);
                cell1.Controls.Add(new LiteralControl("<br />"));
                cell1.Controls.Add(CouncilorLabel[i]);

                
                if(i<4)
                {
                    row1.Cells.Add(cell1);
                }

                if(i>3)
                {
                    row2.Cells.Add(cell1);
                }

                if(i == 3)
                {
                    District1Table.Rows.Add(row1);
                }

                if(i == 7)
                {
                    District1Table.Rows.Add(row2);
                }


            }

            

            for (i = 8; i < 16; i++)
            {
                CouncilorImage[i] = new Image();
                CouncilorLabel[i] = new Label();
             
                CouncilorImage[i].ImageUrl = "data:Image/png;base64," + strBase64[i];
                CouncilorImage[i].Height = 200;
                CouncilorImage[i].Width = 160;
                CouncilorImage[i].ID = "CouncilorImage" + i + 1;

                CouncilorLabel[i].Text = councilorName[i];
                CouncilorLabel[i].ID = "CouncilorLabel" + i + 1;

                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();

                cell1.Controls.Add(CouncilorImage[i]);
                cell1.Controls.Add(new LiteralControl("<br />"));
                cell1.Controls.Add(CouncilorLabel[i]);

                if (i < 12)
                {
                    row3.Cells.Add(cell1);
                }

                if (i > 11)
                {
                    row4.Cells.Add(cell1);
                }

                if (i == 11)
                {
                    District2Table.Rows.Add(row3);
                }

                if (i == 15)
                {
                    District2Table.Rows.Add(row4);
                }




            }

            con.Close();

        }

        public void listItemClick(object sender, EventArgs e)
        {
            //selectedItem.Text = DropDownList1.SelectedValue;
            if (DropDownList1.SelectedValue == "Mayor")
            {
                //Response.Redirect("ManageOfficials.aspx" + "#mayorDiv", false);
                mayorDiv.Visible = true;
                viceMayorDiv.Visible = false;
                councilorDiv.Visible = false;
                barangayDiv.Visible = false;
            }
            else if (DropDownList1.SelectedValue == "Vice Mayor")
            {
                //Response.Redirect("ManageOfficials.aspx" + "#viceMayorDiv", false);
                mayorDiv.Visible = false;
                viceMayorDiv.Visible = true;
                councilorDiv.Visible = false;
                barangayDiv.Visible = false;
            }
            else if (DropDownList1.SelectedValue == "Councilors")
            {
                mayorDiv.Visible = false;
                viceMayorDiv.Visible = false;
                councilorDiv.Visible = true;
                barangayDiv.Visible = false;
            }
            else if (DropDownList1.SelectedValue == "Barangay Captains")
            {
                mayorDiv.Visible = false;
                viceMayorDiv.Visible = false;
                councilorDiv.Visible = false;
                barangayDiv.Visible = true;
            }

        }
    }
}