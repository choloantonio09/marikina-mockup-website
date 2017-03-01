using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

using Microsoft.AspNet.Membership.OpenAuth;
using System.Data.EntityClient;

namespace Marikina.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        static string ef = ConfigurationManager.ConnectionStrings["marikinaDBEntities"].ConnectionString;
        static EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder(ef);

        string cs = builder.ProviderConnectionString;


        protected string SuccessMessage
        {
            get;
            private set;
        }

        protected bool CanRemoveExternalLogins
        {
            get;
            private set;
        }

        protected void Page_Load()
        {
            if (!IsPostBack)
            {
                // Determine the sections to render
                var hasLocalPassword = OpenAuth.HasLocalPassword(User.Identity.Name);
                setPassword.Visible = !hasLocalPassword;
                changePassword.Visible = hasLocalPassword;

                CanRemoveExternalLogins = hasLocalPassword;

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage.aspx");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The external login was removed."
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }

                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd2 = new SqlCommand("SELECT TOP 1 logo_image FROM logo ORDER BY logo_id DESC;", con);
                con.Open();

                byte[] bytes2 = cmd2.ExecuteScalar() as byte[];

                string strBase64 = Convert.ToBase64String(bytes2);

                ImageLogo.ImageUrl = "data:Image/png;base64," + strBase64;

                con.Close();


                SqlCommand cmd3 = new SqlCommand("SELECT TOP 1 banner_image FROM banner ORDER BY banner_id DESC;", con);
                con.Open();

                byte[] bytes3 = cmd3.ExecuteScalar() as byte[];

                string strBase642 = Convert.ToBase64String(bytes3);

                ImageBanner.ImageUrl = "data:Image/png;base64," + strBase642;

                con.Close();

            }


        }

        protected void setPassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var result = OpenAuth.AddLocalPassword(User.Identity.Name, password.Text);
                if (result.IsSuccessful)
                {
                    Response.Redirect("~/Account/Manage.aspx?m=SetPwdSuccess");
                }
                else
                {

                    ModelState.AddModelError("NewPassword", result.ErrorMessage);

                }
            }
        }

        protected static string ConvertToDisplayDateTime(DateTime? utcDateTime)
        {
            // You can change this method to convert the UTC date time into the desired display
            // offset and format. Here we're converting it to the server timezone and formatting
            // as a short date and a long time string, using the current thread culture.
            return utcDateTime.HasValue ? utcDateTime.Value.ToLocalTime().ToString("G") : "[never]";
        }

        protected void UploadLogo(object sender, EventArgs e)
        {

            if (FileUploadLogo.HasFile)
            {
                HttpPostedFile image = FileUploadLogo.PostedFile;
                string extension = Path.GetExtension(FileUploadLogo.PostedFile.FileName);
                string fileName = Path.GetFileName(FileUploadLogo.PostedFile.FileName);
                int fileSize = FileUploadLogo.PostedFile.ContentLength;

                if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || extension.ToLower() == ".gif")
                {


                    Stream stream = FileUploadLogo.PostedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    SqlConnection con = new SqlConnection(cs);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO logo (logo_image_name,logo_image,logo_image_size) VALUES (@logoname, @logo, @logosize);", con);
                    SqlCommand cmd = new SqlCommand("UPDATE logo SET logo_image_name = @logoname, logo_image = @logo, logo_image_size = @logosize WHERE logo_id = 1;", con);
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

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Website logo successfully changed!')", true);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    LabelLogo.Text = "Upload Successful!";
                    LabelLogo.ForeColor = System.Drawing.Color.Green;

                    SqlCommand cmd2 = new SqlCommand("SELECT TOP 1 logo_image FROM logo ORDER BY logo_id DESC;", con);
                    con.Open();

                    byte[] bytes2 = cmd2.ExecuteScalar() as byte[];

                    string strBase64 = Convert.ToBase64String(bytes2);

                    ImageLogo.ImageUrl = "data:Image/png;base64," + strBase64;

                    con.Close();
                    Response.Redirect(Request.RawUrl);


                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);

                }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You did not select an image.')", true);
            }




        }

        protected void UploadBanner(object sender, EventArgs e)
        {

            if (FileUploadBanner.HasFile)
            {
                HttpPostedFile image = FileUploadBanner.PostedFile;
                string extension = Path.GetExtension(FileUploadBanner.PostedFile.FileName);
                string fileName = Path.GetFileName(FileUploadBanner.PostedFile.FileName);
                int fileSize = FileUploadBanner.PostedFile.ContentLength;

                if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || extension.ToLower() == ".gif")
                {

                    Stream stream = FileUploadBanner.PostedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    SqlConnection con = new SqlConnection(cs);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO banner (banner_image_name,banner_image,banner_image_size) VALUES (@bannername, @banner, @bannersize);", con);
                    SqlCommand cmd = new SqlCommand("UPDATE banner SET banner_image_name = @bannername, banner_image = @banner, banner_image_size = @bannersize WHERE banner_id = 1;", con);
                    SqlParameter bannernameparam = new SqlParameter()
                    {
                        ParameterName = "@bannername",
                        Value = fileName
                    };
                    cmd.Parameters.Add(bannernameparam);

                    SqlParameter bannersizeparam = new SqlParameter()
                    {
                        ParameterName = "@bannersize",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(bannersizeparam);

                    SqlParameter bannerparam = new SqlParameter()
                    {
                        ParameterName = "@banner",
                        Value = bytes
                    };
                    cmd.Parameters.Add(bannerparam);

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Website banner successfully changed!')", true);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    LabelBanner.Text = "Upload Successful!";
                    LabelBanner.ForeColor = System.Drawing.Color.Green;

                    SqlCommand cmd2 = new SqlCommand("SELECT TOP 1 banner_image FROM banner ORDER BY banner_id DESC;", con);
                    con.Open();

                    byte[] bytes2 = cmd2.ExecuteScalar() as byte[];

                    string strBase64 = Convert.ToBase64String(bytes2);

                    ImageBanner.ImageUrl = "data:Image/png;base64," + strBase64;

                    con.Close();

                    Response.Redirect(Request.RawUrl);

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You did not select an image.')", true);
            }


        }
    }
}