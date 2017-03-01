using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Marikina
{
    public partial class ManageEvents : System.Web.UI.Page
    {
        static string ef = ConfigurationManager.ConnectionStrings["marikinaDBEntities"].ConnectionString;
        static EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder(ef);

        string cs = builder.ProviderConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //Redirect to Default page
                Response.Redirect("~/Account/Login.aspx");
            }

           /* if (IsPostBack && NewUpload.PostedFile != null)
            {
                if (NewUpload.PostedFile.FileName.Length > 0)
                {
                   NewUpload.SaveAs(Server.MapPath("~/Images/banner") + NewUpload.PostedFile.FileName);
                    NewImage.ImageUrl = "~/Images/banner" + NewUpload.PostedFile.FileName;
               }
            }*/

        }

        

        public void CreateNew(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);

            if (NewUpload.HasFile && NewName.Text != null && NewDesc.Text != null && NewLocation.Text != null && NewDateTime.Value != null)
            {
                HttpPostedFile image = NewUpload.PostedFile;
                string extension = Path.GetExtension(NewUpload.PostedFile.FileName);
                string fileName = Path.GetFileName(NewUpload.PostedFile.FileName);
                int fileSize = NewUpload.PostedFile.ContentLength;

                DateTime datetime = Convert.ToDateTime(NewDateTime.Value);
               

                if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || extension.ToLower() == ".gif")
                {


                    Stream stream = NewUpload.PostedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    SqlCommand cmd = new SqlCommand("INSERT INTO events (event_name,event_desc,event_expiration_datetime,event_status,event_location,event_image_name,event_image,event_image_size) VALUES (@name,@desc,@datetime,@status,@location,@logoname, @logo, @logosize);", con);
                    //SqlCommand cmd = new SqlCommand("UPDATE logo SET logo_image_name = @logoname, logo_image = @logo, logo_image_size = @logosize WHERE logo_id = 1;", con);

                    SqlParameter eventname = new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = NewName.Text
                    };
                    cmd.Parameters.Add(eventname);


                    SqlParameter eventdesc = new SqlParameter()
                    {
                        ParameterName = "@desc",
                        Value = NewDesc.Text

                    };
                    cmd.Parameters.Add(eventdesc);

                    SqlParameter eventdatetime = new SqlParameter()
                    {
                        ParameterName = "@datetime",
                        Value = datetime
                    };
                    cmd.Parameters.Add(eventdatetime);

                    SqlParameter eventstatus = new SqlParameter()
                    {
                        ParameterName = "@status",
                        Value = "Upcoming"
                    };
                    cmd.Parameters.Add(eventstatus);

                    SqlParameter eventlocation = new SqlParameter()
                    {
                        ParameterName = "@location",
                        Value = NewLocation.Text

                    };
                    cmd.Parameters.Add(eventlocation);

                    SqlParameter logonameparam = new SqlParameter()
                    {
                        ParameterName = "@logoname",
                        Value = fileName
                    };
                    cmd.Parameters.Add(logonameparam);

                    SqlParameter logosizeparam = new SqlParameter()
                    {
                        ParameterName = "@logosize",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(logosizeparam);

                    SqlParameter logoparam = new SqlParameter()
                    {
                        ParameterName = "@logo",
                        Value = bytes
                    };
                    cmd.Parameters.Add(logoparam);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    SqlCommand cmd3 = new SqlCommand("SELECT TOP 1 event_image FROM events ORDER BY event_id DESC;", con);
                    con.Open();

                    byte[] bytes3 = cmd3.ExecuteScalar() as byte[];

                    string strBase642 = Convert.ToBase64String(bytes3);

                    NewImage.ImageUrl = "data:Image/png;base64," + strBase642;

                    con.Close();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('NEW EVENT SUCCESSFULLY CREATED!')", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#AddNewDiv';", true);


                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);

                }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Do not leave an empty field!')", true);
            }

            

        }
    }
}