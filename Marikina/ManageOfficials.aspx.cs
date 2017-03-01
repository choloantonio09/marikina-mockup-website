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
    public partial class ManageOfficials : System.Web.UI.Page
    {
        //List<Image> CouncilorImage = new List<Image>();
        //List<Label> CouncilorLabel = new List<Label>();
        //List<TextBox> CouncilorTextBox = new List<TextBox>();
        //List<FileUpload> CouncilorUpload = new List<FileUpload>();
        //List<TableRow> row = new List<TableRow>();
        //List<TableCell> cell = new List<TableCell>();

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
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //Redirect to Default page
                Response.Redirect("~/Account/Login.aspx");
            }


            
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
        

        public void UploadMayor(object sender, EventArgs e)
        {
            if (FileUploadMayor.HasFile)
            {
                HttpPostedFile image = FileUploadMayor.PostedFile;
                string extension = Path.GetExtension(FileUploadMayor.PostedFile.FileName);
                string fileName = Path.GetFileName(FileUploadMayor.PostedFile.FileName);
                int fileSize = FileUploadMayor.PostedFile.ContentLength;

                if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || extension.ToLower() == ".gif")
                {

                    Stream stream = FileUploadMayor.PostedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    SqlConnection con = new SqlConnection(cs);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO banner (banner_image_name,banner_image,banner_image_size) VALUES (@bannername, @banner, @bannersize);", con);
                    SqlCommand cmd = new SqlCommand("UPDATE officials SET official_image_name = @name, official_image = @image, official_image_size = @size WHERE official_id = 1;", con);
                    SqlParameter nameparam = new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = fileName
                    };
                    cmd.Parameters.Add(nameparam);

                    SqlParameter sizeparam = new SqlParameter()
                    {
                        ParameterName = "@size",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(sizeparam);

                    SqlParameter imageparam = new SqlParameter()
                    {
                        ParameterName = "@image",
                        Value = bytes
                    };
                    cmd.Parameters.Add(imageparam);

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Mayor photo successfully changed!')", true);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    

                    SqlCommand cmd2 = new SqlCommand("SELECT official_image FROM officials WHERE official_id = 1;", con);
                    con.Open();

                    byte[] bytes2 = cmd2.ExecuteScalar() as byte[];

                    string strBase64 = Convert.ToBase64String(bytes2);

                    MayorImage.ImageUrl = "data:Image/png;base64," + strBase64;

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

        public void UploadViceMayor(object sender, EventArgs e)
        {
            if (FileUploadViceMayor.HasFile)
            {
                HttpPostedFile image = FileUploadViceMayor.PostedFile;
                string extension = Path.GetExtension(FileUploadViceMayor.PostedFile.FileName);
                string fileName = Path.GetFileName(FileUploadViceMayor.PostedFile.FileName);
                int fileSize = FileUploadViceMayor.PostedFile.ContentLength;

                if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || extension.ToLower() == ".gif")
                {

                    Stream stream = FileUploadViceMayor.PostedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    SqlConnection con = new SqlConnection(cs);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO banner (banner_image_name,banner_image,banner_image_size) VALUES (@bannername, @banner, @bannersize);", con);
                    SqlCommand cmd = new SqlCommand("UPDATE officials SET official_image_name = @name, official_image = @image, official_image_size = @size WHERE official_id = 2;", con);
                    SqlParameter nameparam = new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = fileName
                    };
                    cmd.Parameters.Add(nameparam);

                    SqlParameter sizeparam = new SqlParameter()
                    {
                        ParameterName = "@size",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(sizeparam);

                    SqlParameter imageparam = new SqlParameter()
                    {
                        ParameterName = "@image",
                        Value = bytes
                    };
                    cmd.Parameters.Add(imageparam);

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vice Mayor photo successfully changed!')", true);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();



                    SqlCommand cmd2 = new SqlCommand("SELECT official_image FROM officials WHERE official_id = 2;", con);
                    con.Open();

                    byte[] bytes2 = cmd2.ExecuteScalar() as byte[];

                    string strBase64 = Convert.ToBase64String(bytes2);

                    ViceMayorImage.ImageUrl = "data:Image/png;base64," + strBase64;

                    con.Close();


                    ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#viceMayorDiv';", true);

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

        public void CouncilorGetData()
        {
            var strBase64 = new List<string>();
            //var image = new List<Byte>();
            var councilorName = new List<string>();
            int i = 0;

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SELECT official_name, official_image FROM officials WHERE official_role = 'District 1: Councilor' OR official_role = 'District 2: Councilor';",con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                byte[] bytesCouncilor = reader["official_image"] as byte[];
                strBase64.Add(Convert.ToBase64String(bytesCouncilor));
                councilorName.Add(reader["official_name"].ToString());
            }

            

            for (i = 0; i<8; i++)
            {
                CouncilorImage[i] = new Image();
                CouncilorLabel[i] = new Label();
                CouncilorTextBox[i] = new TextBox();
                CouncilorUpload[i] = new FileUpload();
                row[i] = new TableRow();


                CouncilorImage[i].ImageUrl = "data:Image/png;base64," + strBase64[i];
                CouncilorImage[i].Height = 200;
                CouncilorImage[i].Width = 160;
                CouncilorImage[i].ID = "CouncilorImage" + i+1;

                CouncilorLabel[i].Text = councilorName[i];
                CouncilorLabel[i].ID = "CouncilorLabel" + i + 1;

                CouncilorTextBox[i].Text = councilorName[i];
                CouncilorTextBox[i].Columns = 50;
                CouncilorTextBox[i].ID = "CouncilorTextBox" + i + 1;

                CouncilorUpload[i].ID = "CouncilorUpload" + i + 1;

                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();

                cell1.Controls.Add(CouncilorImage[i]);
                cell1.Controls.Add(new LiteralControl("<br />"));
                cell1.Controls.Add(CouncilorLabel[i]);

                cell2.Controls.Add(CouncilorTextBox[i]);
                cell2.Controls.Add(new LiteralControl("<br />"));
                cell2.Controls.Add(CouncilorUpload[i]);


                row[i].Cells.Add(cell1);
                row[i].Cells.Add(cell2);

                District1Table.Rows.Add(row[i]);

            }

            for (i = 8; i < 16; i++)
            {
                CouncilorImage[i] = new Image();
                CouncilorLabel[i] = new Label();
                CouncilorTextBox[i] = new TextBox();
                CouncilorUpload[i] = new FileUpload();
                row[i] = new TableRow();

                CouncilorImage[i].ImageUrl = "data:Image/png;base64," + strBase64[i];
                CouncilorImage[i].Height = 200;
                CouncilorImage[i].Width = 160;
                CouncilorImage[i].ID = "CouncilorImage" + i + 1;

                CouncilorLabel[i].Text = councilorName[i];
                CouncilorLabel[i].ID = "CouncilorLabel" + i + 1;

                CouncilorTextBox[i].Text = councilorName[i];
                CouncilorTextBox[i].Columns = 50;
                CouncilorTextBox[i].ID = "CouncilorTextBox" + i + 1;

                CouncilorUpload[i].ID = "CouncilorUpload" + i + 1;



                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();

                cell1.Controls.Add(CouncilorImage[i]);
                cell1.Controls.Add(new LiteralControl("<br />"));
                cell1.Controls.Add(CouncilorLabel[i]);

                cell2.Controls.Add(CouncilorTextBox[i]);
                cell2.Controls.Add(new LiteralControl("<br />"));
                cell2.Controls.Add(CouncilorUpload[i]);

                row[i].Cells.Add(cell1);
                row[i].Cells.Add(cell2);

                District2Table.Rows.Add(row[i]);

            }

            con.Close();

        }

        public void CouncilorSetData(object sender, EventArgs e)
        {
            Boolean upload = true;
            Boolean emptyTextBox;
            Boolean imgTypeValidation=true;

            //UPLOAD MUNAAAA ----------------------------------------------------------------------------------------------------------------------

            if (CouncilorUpload[0].HasFile) // ----------------------------------------------------------------------------------- BEGIN IMAGE [0]
            {
                HttpPostedFile image = CouncilorUpload[0].PostedFile;
                string extension = Path.GetExtension(CouncilorUpload[0].PostedFile.FileName);
                string fileName = Path.GetFileName(CouncilorUpload[0].PostedFile.FileName);
                int fileSize = CouncilorUpload[0].PostedFile.ContentLength;

                if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || extension.ToLower() == ".gif")
                {

                    Stream stream = CouncilorUpload[0].PostedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    SqlConnection con = new SqlConnection(cs);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO banner (banner_image_name,banner_image,banner_image_size) VALUES (@bannername, @banner, @bannersize);", con);
                    SqlCommand cmd = new SqlCommand("UPDATE officials SET official_image_name = @name, official_image = @image, official_image_size = @size WHERE official_id = 3;", con);
                    SqlParameter nameparam = new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = fileName
                    };
                    cmd.Parameters.Add(nameparam);

                    SqlParameter sizeparam = new SqlParameter()
                    {
                        ParameterName = "@size",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(sizeparam);

                    SqlParameter imageparam = new SqlParameter()
                    {
                        ParameterName = "@image",
                        Value = bytes
                    };
                    cmd.Parameters.Add(imageparam);

                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vice Mayor photo successfully changed!')", true);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    imgTypeValidation = true;
                    upload = true;

                    //ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#viceMayorDiv';", true);

                }
                else
                {
                    imgTypeValidation = false;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);
                }
            } // --------------------------------------------------------------------------------------------------------------- END IMAGE [1]


            if (CouncilorUpload[1].HasFile) // ----------------------------------------------------------------------------------- BEGIN IMAGE [1]
            {
                HttpPostedFile image = CouncilorUpload[1].PostedFile;
                string extension = Path.GetExtension(CouncilorUpload[1].PostedFile.FileName);
                string fileName = Path.GetFileName(CouncilorUpload[1].PostedFile.FileName);
                int fileSize = CouncilorUpload[1].PostedFile.ContentLength;

                if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || extension.ToLower() == ".gif")
                {

                    Stream stream = CouncilorUpload[1].PostedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    SqlConnection con = new SqlConnection(cs);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO banner (banner_image_name,banner_image,banner_image_size) VALUES (@bannername, @banner, @bannersize);", con);
                    SqlCommand cmd = new SqlCommand("UPDATE officials SET official_image_name = @name, official_image = @image, official_image_size = @size WHERE official_id = 4;", con);
                    SqlParameter nameparam = new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = fileName
                    };
                    cmd.Parameters.Add(nameparam);

                    SqlParameter sizeparam = new SqlParameter()
                    {
                        ParameterName = "@size",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(sizeparam);

                    SqlParameter imageparam = new SqlParameter()
                    {
                        ParameterName = "@image",
                        Value = bytes
                    };
                    cmd.Parameters.Add(imageparam);

                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vice Mayor photo successfully changed!')", true);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    imgTypeValidation = true;
                    upload = true;

                    //ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#viceMayorDiv';", true);

                }
                else
                {
                    imgTypeValidation = false;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);
                }
            } // --------------------------------------------------------------------------------------------------------------- END IMAGE [2]


            if (CouncilorUpload[2].HasFile) // ----------------------------------------------------------------------------------- BEGIN IMAGE [2]
            {
                HttpPostedFile image = CouncilorUpload[2].PostedFile;
                string extension = Path.GetExtension(CouncilorUpload[2].PostedFile.FileName);
                string fileName = Path.GetFileName(CouncilorUpload[2].PostedFile.FileName);
                int fileSize = CouncilorUpload[2].PostedFile.ContentLength;

                if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || extension.ToLower() == ".gif")
                {

                    Stream stream = CouncilorUpload[2].PostedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    SqlConnection con = new SqlConnection(cs);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO banner (banner_image_name,banner_image,banner_image_size) VALUES (@bannername, @banner, @bannersize);", con);
                    SqlCommand cmd = new SqlCommand("UPDATE officials SET official_image_name = @name, official_image = @image, official_image_size = @size WHERE official_id = 5;", con);
                    SqlParameter nameparam = new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = fileName
                    };
                    cmd.Parameters.Add(nameparam);

                    SqlParameter sizeparam = new SqlParameter()
                    {
                        ParameterName = "@size",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(sizeparam);

                    SqlParameter imageparam = new SqlParameter()
                    {
                        ParameterName = "@image",
                        Value = bytes
                    };
                    cmd.Parameters.Add(imageparam);

                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vice Mayor photo successfully changed!')", true);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    imgTypeValidation = true;
                    upload = true;

                    //ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#viceMayorDiv';", true);

                }
                else
                {
                    imgTypeValidation = false;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);
                }
            } // --------------------------------------------------------------------------------------------------------------- END IMAGE [3]

            if (CouncilorUpload[3].HasFile) // ----------------------------------------------------------------------------------- BEGIN IMAGE [3]
            {
                HttpPostedFile image = CouncilorUpload[3].PostedFile;
                string extension = Path.GetExtension(CouncilorUpload[3].PostedFile.FileName);
                string fileName = Path.GetFileName(CouncilorUpload[3].PostedFile.FileName);
                int fileSize = CouncilorUpload[3].PostedFile.ContentLength;

                if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || extension.ToLower() == ".gif")
                {

                    Stream stream = CouncilorUpload[3].PostedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    SqlConnection con = new SqlConnection(cs);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO banner (banner_image_name,banner_image,banner_image_size) VALUES (@bannername, @banner, @bannersize);", con);
                    SqlCommand cmd = new SqlCommand("UPDATE officials SET official_image_name = @name, official_image = @image, official_image_size = @size WHERE official_id = 6;", con);
                    SqlParameter nameparam = new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = fileName
                    };
                    cmd.Parameters.Add(nameparam);

                    SqlParameter sizeparam = new SqlParameter()
                    {
                        ParameterName = "@size",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(sizeparam);

                    SqlParameter imageparam = new SqlParameter()
                    {
                        ParameterName = "@image",
                        Value = bytes
                    };
                    cmd.Parameters.Add(imageparam);

                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vice Mayor photo successfully changed!')", true);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    imgTypeValidation = true;
                    upload = true;

                    //ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#viceMayorDiv';", true);

                }
                else
                {
                    imgTypeValidation = false;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);
                }
            } // --------------------------------------------------------------------------------------------------------------- END IMAGE [4]


            if (CouncilorUpload[4].HasFile) // ----------------------------------------------------------------------------------- BEGIN IMAGE [4]
            {
                HttpPostedFile image = CouncilorUpload[4].PostedFile;
                string extension = Path.GetExtension(CouncilorUpload[4].PostedFile.FileName);
                string fileName = Path.GetFileName(CouncilorUpload[4].PostedFile.FileName);
                int fileSize = CouncilorUpload[4].PostedFile.ContentLength;

                if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || extension.ToLower() == ".gif")
                {

                    Stream stream = CouncilorUpload[4].PostedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    SqlConnection con = new SqlConnection(cs);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO banner (banner_image_name,banner_image,banner_image_size) VALUES (@bannername, @banner, @bannersize);", con);
                    SqlCommand cmd = new SqlCommand("UPDATE officials SET official_image_name = @name, official_image = @image, official_image_size = @size WHERE official_id = 7;", con);
                    SqlParameter nameparam = new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = fileName
                    };
                    cmd.Parameters.Add(nameparam);

                    SqlParameter sizeparam = new SqlParameter()
                    {
                        ParameterName = "@size",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(sizeparam);

                    SqlParameter imageparam = new SqlParameter()
                    {
                        ParameterName = "@image",
                        Value = bytes
                    };
                    cmd.Parameters.Add(imageparam);

                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vice Mayor photo successfully changed!')", true);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    imgTypeValidation = true;
                    upload = true;

                    //ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#viceMayorDiv';", true);

                }
                else
                {
                    imgTypeValidation = false;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);
                }
            } // --------------------------------------------------------------------------------------------------------------- END IMAGE [5]


            if (CouncilorUpload[5].HasFile) // ----------------------------------------------------------------------------------- BEGIN IMAGE [5]
            {
                HttpPostedFile image = CouncilorUpload[5].PostedFile;
                string extension = Path.GetExtension(CouncilorUpload[5].PostedFile.FileName);
                string fileName = Path.GetFileName(CouncilorUpload[5].PostedFile.FileName);
                int fileSize = CouncilorUpload[5].PostedFile.ContentLength;

                if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || extension.ToLower() == ".gif")
                {

                    Stream stream = CouncilorUpload[5].PostedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    SqlConnection con = new SqlConnection(cs);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO banner (banner_image_name,banner_image,banner_image_size) VALUES (@bannername, @banner, @bannersize);", con);
                    SqlCommand cmd = new SqlCommand("UPDATE officials SET official_image_name = @name, official_image = @image, official_image_size = @size WHERE official_id = 8;", con);
                    SqlParameter nameparam = new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = fileName
                    };
                    cmd.Parameters.Add(nameparam);

                    SqlParameter sizeparam = new SqlParameter()
                    {
                        ParameterName = "@size",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(sizeparam);

                    SqlParameter imageparam = new SqlParameter()
                    {
                        ParameterName = "@image",
                        Value = bytes
                    };
                    cmd.Parameters.Add(imageparam);

                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vice Mayor photo successfully changed!')", true);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    imgTypeValidation = true;
                    upload = true;

                    //ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#viceMayorDiv';", true);

                }
                else
                {
                    imgTypeValidation = false;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);
                }
            } // --------------------------------------------------------------------------------------------------------------- END IMAGE [6]

            if (CouncilorUpload[6].HasFile) // ----------------------------------------------------------------------------------- BEGIN IMAGE [6]
            {
                HttpPostedFile image = CouncilorUpload[6].PostedFile;
                string extension = Path.GetExtension(CouncilorUpload[6].PostedFile.FileName);
                string fileName = Path.GetFileName(CouncilorUpload[6].PostedFile.FileName);
                int fileSize = CouncilorUpload[6].PostedFile.ContentLength;

                if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || extension.ToLower() == ".gif")
                {

                    Stream stream = CouncilorUpload[6].PostedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    SqlConnection con = new SqlConnection(cs);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO banner (banner_image_name,banner_image,banner_image_size) VALUES (@bannername, @banner, @bannersize);", con);
                    SqlCommand cmd = new SqlCommand("UPDATE officials SET official_image_name = @name, official_image = @image, official_image_size = @size WHERE official_id = 9;", con);
                    SqlParameter nameparam = new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = fileName
                    };
                    cmd.Parameters.Add(nameparam);

                    SqlParameter sizeparam = new SqlParameter()
                    {
                        ParameterName = "@size",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(sizeparam);

                    SqlParameter imageparam = new SqlParameter()
                    {
                        ParameterName = "@image",
                        Value = bytes
                    };
                    cmd.Parameters.Add(imageparam);

                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vice Mayor photo successfully changed!')", true);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    imgTypeValidation = true;
                    upload = true;

                    //ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#viceMayorDiv';", true);

                }
                else
                {
                    imgTypeValidation = false;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);
                }
            } // --------------------------------------------------------------------------------------------------------------- END IMAGE [7]


            if (CouncilorUpload[7].HasFile) // ----------------------------------------------------------------------------------- BEGIN IMAGE [7]
            {
                HttpPostedFile image = CouncilorUpload[7].PostedFile;
                string extension = Path.GetExtension(CouncilorUpload[7].PostedFile.FileName);
                string fileName = Path.GetFileName(CouncilorUpload[7].PostedFile.FileName);
                int fileSize = CouncilorUpload[7].PostedFile.ContentLength;

                if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || extension.ToLower() == ".gif")
                {

                    Stream stream = CouncilorUpload[7].PostedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    SqlConnection con = new SqlConnection(cs);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO banner (banner_image_name,banner_image,banner_image_size) VALUES (@bannername, @banner, @bannersize);", con);
                    SqlCommand cmd = new SqlCommand("UPDATE officials SET official_image_name = @name, official_image = @image, official_image_size = @size WHERE official_id = 10;", con);
                    SqlParameter nameparam = new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = fileName
                    };
                    cmd.Parameters.Add(nameparam);

                    SqlParameter sizeparam = new SqlParameter()
                    {
                        ParameterName = "@size",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(sizeparam);

                    SqlParameter imageparam = new SqlParameter()
                    {
                        ParameterName = "@image",
                        Value = bytes
                    };
                    cmd.Parameters.Add(imageparam);

                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vice Mayor photo successfully changed!')", true);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    imgTypeValidation = true;
                    upload = true;

                    //ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#viceMayorDiv';", true);

                }
                else
                {
                    imgTypeValidation = false;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);
                }
            } // --------------------------------------------------------------------------------------------------------------- END IMAGE [8]


            if (CouncilorUpload[8].HasFile) // ----------------------------------------------------------------------------------- BEGIN IMAGE [8]
            {
                HttpPostedFile image = CouncilorUpload[8].PostedFile;
                string extension = Path.GetExtension(CouncilorUpload[8].PostedFile.FileName);
                string fileName = Path.GetFileName(CouncilorUpload[8].PostedFile.FileName);
                int fileSize = CouncilorUpload[8].PostedFile.ContentLength;

                if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || extension.ToLower() == ".gif")
                {

                    Stream stream = CouncilorUpload[8].PostedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    SqlConnection con = new SqlConnection(cs);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO banner (banner_image_name,banner_image,banner_image_size) VALUES (@bannername, @banner, @bannersize);", con);
                    SqlCommand cmd = new SqlCommand("UPDATE officials SET official_image_name = @name, official_image = @image, official_image_size = @size WHERE official_id = 11;", con);
                    SqlParameter nameparam = new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = fileName
                    };
                    cmd.Parameters.Add(nameparam);

                    SqlParameter sizeparam = new SqlParameter()
                    {
                        ParameterName = "@size",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(sizeparam);

                    SqlParameter imageparam = new SqlParameter()
                    {
                        ParameterName = "@image",
                        Value = bytes
                    };
                    cmd.Parameters.Add(imageparam);

                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vice Mayor photo successfully changed!')", true);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    imgTypeValidation = true;
                    upload = true;

                    //ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#viceMayorDiv';", true);

                }
                else
                {
                    imgTypeValidation = false;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);
                }
            } // --------------------------------------------------------------------------------------------------------------- END IMAGE [9]

            if (CouncilorUpload[9].HasFile) // ----------------------------------------------------------------------------------- BEGIN IMAGE [1]0
            {
                HttpPostedFile image = CouncilorUpload[9].PostedFile;
                string extension = Path.GetExtension(CouncilorUpload[9].PostedFile.FileName);
                string fileName = Path.GetFileName(CouncilorUpload[9].PostedFile.FileName);
                int fileSize = CouncilorUpload[9].PostedFile.ContentLength;

                if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || extension.ToLower() == ".gif")
                {

                    Stream stream = CouncilorUpload[9].PostedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    SqlConnection con = new SqlConnection(cs);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO banner (banner_image_name,banner_image,banner_image_size) VALUES (@bannername, @banner, @bannersize);", con);
                    SqlCommand cmd = new SqlCommand("UPDATE officials SET official_image_name = @name, official_image = @image, official_image_size = @size WHERE official_id = 12;", con);
                    SqlParameter nameparam = new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = fileName
                    };
                    cmd.Parameters.Add(nameparam);

                    SqlParameter sizeparam = new SqlParameter()
                    {
                        ParameterName = "@size",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(sizeparam);

                    SqlParameter imageparam = new SqlParameter()
                    {
                        ParameterName = "@image",
                        Value = bytes
                    };
                    cmd.Parameters.Add(imageparam);

                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vice Mayor photo successfully changed!')", true);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    imgTypeValidation = true;
                    upload = true;

                    //ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#viceMayorDiv';", true);

                }
                else
                {
                    imgTypeValidation = false;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);
                }
            } // --------------------------------------------------------------------------------------------------------------- END IMAGE [1]0


            if (CouncilorUpload[10].HasFile) // ----------------------------------------------------------------------------------- BEGIN IMAGE [1][1]
            {
                HttpPostedFile image = CouncilorUpload[10].PostedFile;
                string extension = Path.GetExtension(CouncilorUpload[10].PostedFile.FileName);
                string fileName = Path.GetFileName(CouncilorUpload[10].PostedFile.FileName);
                int fileSize = CouncilorUpload[10].PostedFile.ContentLength;

                if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || extension.ToLower() == ".gif")
                {

                    Stream stream = CouncilorUpload[10].PostedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    SqlConnection con = new SqlConnection(cs);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO banner (banner_image_name,banner_image,banner_image_size) VALUES (@bannername, @banner, @bannersize);", con);
                    SqlCommand cmd = new SqlCommand("UPDATE officials SET official_image_name = @name, official_image = @image, official_image_size = @size WHERE official_id = 13;", con);
                    SqlParameter nameparam = new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = fileName
                    };
                    cmd.Parameters.Add(nameparam);

                    SqlParameter sizeparam = new SqlParameter()
                    {
                        ParameterName = "@size",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(sizeparam);

                    SqlParameter imageparam = new SqlParameter()
                    {
                        ParameterName = "@image",
                        Value = bytes
                    };
                    cmd.Parameters.Add(imageparam);

                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vice Mayor photo successfully changed!')", true);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    imgTypeValidation = true;
                    upload = true;

                    //ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#viceMayorDiv';", true);

                }
                else
                {
                    imgTypeValidation = false;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);
                }
            } // --------------------------------------------------------------------------------------------------------------- END IMAGE [1][1]

            if (CouncilorUpload[11].HasFile) // ----------------------------------------------------------------------------------- BEGIN IMAGE [1][2]
            {
                HttpPostedFile image = CouncilorUpload[11].PostedFile;
                string extension = Path.GetExtension(CouncilorUpload[11].PostedFile.FileName);
                string fileName = Path.GetFileName(CouncilorUpload[11].PostedFile.FileName);
                int fileSize = CouncilorUpload[11].PostedFile.ContentLength;

                if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || extension.ToLower() == ".gif")
                {

                    Stream stream = CouncilorUpload[11].PostedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    SqlConnection con = new SqlConnection(cs);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO banner (banner_image_name,banner_image,banner_image_size) VALUES (@bannername, @banner, @bannersize);", con);
                    SqlCommand cmd = new SqlCommand("UPDATE officials SET official_image_name = @name, official_image = @image, official_image_size = @size WHERE official_id = 14;", con);
                    SqlParameter nameparam = new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = fileName
                    };
                    cmd.Parameters.Add(nameparam);

                    SqlParameter sizeparam = new SqlParameter()
                    {
                        ParameterName = "@size",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(sizeparam);

                    SqlParameter imageparam = new SqlParameter()
                    {
                        ParameterName = "@image",
                        Value = bytes
                    };
                    cmd.Parameters.Add(imageparam);

                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vice Mayor photo successfully changed!')", true);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    imgTypeValidation = true;
                    upload = true;

                    //ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#viceMayorDiv';", true);

                }
                else
                {
                    imgTypeValidation = false;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);
                }
            } // --------------------------------------------------------------------------------------------------------------- END IMAGE [1][2]


            if (CouncilorUpload[12].HasFile) // ----------------------------------------------------------------------------------- BEGIN IMAGE [1][3]
            {
                HttpPostedFile image = CouncilorUpload[12].PostedFile;
                string extension = Path.GetExtension(CouncilorUpload[12].PostedFile.FileName);
                string fileName = Path.GetFileName(CouncilorUpload[12].PostedFile.FileName);
                int fileSize = CouncilorUpload[12].PostedFile.ContentLength;

                if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || extension.ToLower() == ".gif")
                {

                    Stream stream = CouncilorUpload[12].PostedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    SqlConnection con = new SqlConnection(cs);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO banner (banner_image_name,banner_image,banner_image_size) VALUES (@bannername, @banner, @bannersize);", con);
                    SqlCommand cmd = new SqlCommand("UPDATE officials SET official_image_name = @name, official_image = @image, official_image_size = @size WHERE official_id = 15;", con);
                    SqlParameter nameparam = new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = fileName
                    };
                    cmd.Parameters.Add(nameparam);

                    SqlParameter sizeparam = new SqlParameter()
                    {
                        ParameterName = "@size",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(sizeparam);

                    SqlParameter imageparam = new SqlParameter()
                    {
                        ParameterName = "@image",
                        Value = bytes
                    };
                    cmd.Parameters.Add(imageparam);

                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vice Mayor photo successfully changed!')", true);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    imgTypeValidation = true;
                    upload = true;

                    //ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#viceMayorDiv';", true);

                }
                else
                {
                    imgTypeValidation = false;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);
                }
            } // --------------------------------------------------------------------------------------------------------------- END IMAGE [1][3]

            if (CouncilorUpload[13].HasFile) // ----------------------------------------------------------------------------------- BEGIN IMAGE [1][4]
            {
                HttpPostedFile image = CouncilorUpload[13].PostedFile;
                string extension = Path.GetExtension(CouncilorUpload[13].PostedFile.FileName);
                string fileName = Path.GetFileName(CouncilorUpload[13].PostedFile.FileName);
                int fileSize = CouncilorUpload[13].PostedFile.ContentLength;

                if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || extension.ToLower() == ".gif")
                {

                    Stream stream = CouncilorUpload[13].PostedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    SqlConnection con = new SqlConnection(cs);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO banner (banner_image_name,banner_image,banner_image_size) VALUES (@bannername, @banner, @bannersize);", con);
                    SqlCommand cmd = new SqlCommand("UPDATE officials SET official_image_name = @name, official_image = @image, official_image_size = @size WHERE official_id = 16;", con);
                    SqlParameter nameparam = new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = fileName
                    };
                    cmd.Parameters.Add(nameparam);

                    SqlParameter sizeparam = new SqlParameter()
                    {
                        ParameterName = "@size",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(sizeparam);

                    SqlParameter imageparam = new SqlParameter()
                    {
                        ParameterName = "@image",
                        Value = bytes
                    };
                    cmd.Parameters.Add(imageparam);

                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vice Mayor photo successfully changed!')", true);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    imgTypeValidation = true;
                    upload = true;

                    //ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#viceMayorDiv';", true);

                }
                else
                {
                    imgTypeValidation = false;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);
                }
            } // --------------------------------------------------------------------------------------------------------------- END IMAGE [1][4]


            if (CouncilorUpload[14].HasFile) // ----------------------------------------------------------------------------------- BEGIN IMAGE [1][5]
            {
                HttpPostedFile image = CouncilorUpload[14].PostedFile;
                string extension = Path.GetExtension(CouncilorUpload[14].PostedFile.FileName);
                string fileName = Path.GetFileName(CouncilorUpload[14].PostedFile.FileName);
                int fileSize = CouncilorUpload[14].PostedFile.ContentLength;

                if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || extension.ToLower() == ".gif")
                {

                    Stream stream = CouncilorUpload[14].PostedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    SqlConnection con = new SqlConnection(cs);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO banner (banner_image_name,banner_image,banner_image_size) VALUES (@bannername, @banner, @bannersize);", con);
                    SqlCommand cmd = new SqlCommand("UPDATE officials SET official_image_name = @name, official_image = @image, official_image_size = @size WHERE official_id = 17;", con);
                    SqlParameter nameparam = new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = fileName
                    };
                    cmd.Parameters.Add(nameparam);

                    SqlParameter sizeparam = new SqlParameter()
                    {
                        ParameterName = "@size",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(sizeparam);

                    SqlParameter imageparam = new SqlParameter()
                    {
                        ParameterName = "@image",
                        Value = bytes
                    };
                    cmd.Parameters.Add(imageparam);

                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vice Mayor photo successfully changed!')", true);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    imgTypeValidation = true;
                    upload = true;

                    //ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#viceMayorDiv';", true);

                }
                else
                {
                    imgTypeValidation = false;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);
                }
            } // --------------------------------------------------------------------------------------------------------------- END IMAGE [1][5]

            if (CouncilorUpload[15].HasFile) // ----------------------------------------------------------------------------------- BEGIN IMAGE [1][6]
            {
                HttpPostedFile image = CouncilorUpload[15].PostedFile;
                string extension = Path.GetExtension(CouncilorUpload[15].PostedFile.FileName);
                string fileName = Path.GetFileName(CouncilorUpload[15].PostedFile.FileName);
                int fileSize = CouncilorUpload[15].PostedFile.ContentLength;

                if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || extension.ToLower() == ".gif")
                {

                    Stream stream = CouncilorUpload[15].PostedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    SqlConnection con = new SqlConnection(cs);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO banner (banner_image_name,banner_image,banner_image_size) VALUES (@bannername, @banner, @bannersize);", con);
                    SqlCommand cmd = new SqlCommand("UPDATE officials SET official_image_name = @name, official_image = @image, official_image_size = @size WHERE official_id = 18;", con);
                    SqlParameter nameparam = new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = fileName
                    };
                    cmd.Parameters.Add(nameparam);

                    SqlParameter sizeparam = new SqlParameter()
                    {
                        ParameterName = "@size",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(sizeparam);

                    SqlParameter imageparam = new SqlParameter()
                    {
                        ParameterName = "@image",
                        Value = bytes
                    };
                    cmd.Parameters.Add(imageparam);

                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vice Mayor photo successfully changed!')", true);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    imgTypeValidation = true;
                    upload = true;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vice Mayor photo successfully changed!')", true);
                    //ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#viceMayorDiv';", true);

                }
                else
                {
                    imgTypeValidation = false;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);
                }
            } // --------------------------------------------------------------------------------------------------------------- END IMAGE [1][6]

            //END OF UPLOOOOOOOOOOOOOOOOAD --------------------------------------------------------------------------------------------------------!!!!!!!!

            //BEGIN OF CHANGE NAME ------------------!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

            if (CouncilorTextBox[0].Text != "" || CouncilorTextBox[1].Text != "" || CouncilorTextBox[2].Text != "" || CouncilorTextBox[3].Text != "" ||
                CouncilorTextBox[4].Text != "" || CouncilorTextBox[5].Text != "" || CouncilorTextBox[6].Text != "" || CouncilorTextBox[7].Text != "" ||
                CouncilorTextBox[8].Text != "" || CouncilorTextBox[9].Text != "" || CouncilorTextBox[10].Text != "" || CouncilorTextBox[11].Text != "" ||
                CouncilorTextBox[12].Text != "" || CouncilorTextBox[13].Text != "" || CouncilorTextBox[14].Text != "" || CouncilorTextBox[15].Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                //-----------------text box [2] @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@###############################
                SqlCommand cmdChangeName = new SqlCommand("UPDATE officials SET official_name = @name WHERE official_id = 3 ;",con);

                SqlParameter changeNameParam = new SqlParameter()
                {
                    ParameterName = "@name",
                    Value = CouncilorTextBox[0].Text
                };
                cmdChangeName.Parameters.Add(changeNameParam);

                con.Open();
                cmdChangeName.ExecuteNonQuery();
                con.Close();

                //-----------------text box [2] @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@###############################
                SqlCommand cmdChangeName2 = new SqlCommand("UPDATE officials SET official_name = @name WHERE official_id = 4 ;", con);

                SqlParameter changeNameParam2 = new SqlParameter()
                {
                    ParameterName = "@name",
                    Value = CouncilorTextBox[1].Text
                };
                cmdChangeName2.Parameters.Add(changeNameParam2);

                con.Open();
                cmdChangeName2.ExecuteNonQuery();
                con.Close();

                //-----------------text box [3] @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@###############################
                SqlCommand cmdChangeName3 = new SqlCommand("UPDATE officials SET official_name = @name WHERE official_id = 5 ;", con);

                SqlParameter changeNameParam3 = new SqlParameter()
                {
                    ParameterName = "@name",
                    Value = CouncilorTextBox[2].Text
                };
                cmdChangeName3.Parameters.Add(changeNameParam3);

                con.Open();
                cmdChangeName3.ExecuteNonQuery();
                con.Close();


                //-----------------text box [4] @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@###############################
                SqlCommand cmdChangeName4 = new SqlCommand("UPDATE officials SET official_name = @name WHERE official_id = 6 ;", con);

                SqlParameter changeNameParam4 = new SqlParameter()
                {
                    ParameterName = "@name",
                    Value = CouncilorTextBox[3].Text
                };
                cmdChangeName4.Parameters.Add(changeNameParam4);

                con.Open();
                cmdChangeName4.ExecuteNonQuery();
                con.Close();

                //-----------------text box [5] @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@###############################
                SqlCommand cmdChangeName5 = new SqlCommand("UPDATE officials SET official_name = @name WHERE official_id = 7;", con);

                SqlParameter changeNameParam5= new SqlParameter()
                {
                    ParameterName = "@name",
                    Value = CouncilorTextBox[4].Text
                };
                cmdChangeName5.Parameters.Add(changeNameParam5);

                con.Open();
                cmdChangeName5.ExecuteNonQuery();
                con.Close();

                //-----------------text box [6] @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@###############################
                SqlCommand cmdChangeName6 = new SqlCommand("UPDATE officials SET official_name = @name WHERE official_id = 8 ;", con);

                SqlParameter changeNameParam6 = new SqlParameter()
                {
                    ParameterName = "@name",
                    Value = CouncilorTextBox[5].Text
                };
                cmdChangeName6.Parameters.Add(changeNameParam6);

                con.Open();
                cmdChangeName6.ExecuteNonQuery();
                con.Close();

                //-----------------text box [7] @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@###############################
                SqlCommand cmdChangeName7 = new SqlCommand("UPDATE officials SET official_name = @name WHERE official_id = 9 ;", con);

                SqlParameter changeNameParam7 = new SqlParameter()
                {
                    ParameterName = "@name",
                    Value = CouncilorTextBox[6].Text
                };
                cmdChangeName7.Parameters.Add(changeNameParam7);

                con.Open();
                cmdChangeName7.ExecuteNonQuery();
                con.Close();

                //-----------------text box [8] @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@###############################
                SqlCommand cmdChangeName8 = new SqlCommand("UPDATE officials SET official_name = @name WHERE official_id = 10 ;", con);

                SqlParameter changeNameParam8 = new SqlParameter()
                {
                    ParameterName = "@name",
                    Value = CouncilorTextBox[7].Text
                };
                cmdChangeName8.Parameters.Add(changeNameParam8);

                con.Open();
                cmdChangeName8.ExecuteNonQuery();
                con.Close();

                //-----------------text box [9] @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@###############################
                SqlCommand cmdChangeName9 = new SqlCommand("UPDATE officials SET official_name = @name WHERE official_id = 11 ;", con);

                SqlParameter changeNameParam9 = new SqlParameter()
                {
                    ParameterName = "@name",
                    Value = CouncilorTextBox[8].Text
                };
                cmdChangeName9.Parameters.Add(changeNameParam9);

                con.Open();
                cmdChangeName9.ExecuteNonQuery();
                con.Close();

                //-----------------text box [1]0 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@###############################
                SqlCommand cmdChangeName10 = new SqlCommand("UPDATE officials SET official_name = @name WHERE official_id = 12 ;", con);

                SqlParameter changeNameParam10 = new SqlParameter()
                {
                    ParameterName = "@name",
                    Value = CouncilorTextBox[9].Text
                };
                cmdChangeName10.Parameters.Add(changeNameParam10);

                con.Open();
                cmdChangeName10.ExecuteNonQuery();
                con.Close();

                //-----------------text box [1][1] @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@###############################
                SqlCommand cmdChangeName11 = new SqlCommand("UPDATE officials SET official_name = @name WHERE official_id = 13 ;", con);

                SqlParameter changeNameParam11 = new SqlParameter()
                {
                    ParameterName = "@name",
                    Value = CouncilorTextBox[10].Text
                };
                cmdChangeName11.Parameters.Add(changeNameParam11);

                con.Open();
                cmdChangeName11.ExecuteNonQuery();
                con.Close();

                //-----------------text box [1][2] @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@###############################
                SqlCommand cmdChangeName12 = new SqlCommand("UPDATE officials SET official_name = @name WHERE official_id = 14 ;", con);

                SqlParameter changeNameParam12 = new SqlParameter()
                {
                    ParameterName = "@name",
                    Value = CouncilorTextBox[11].Text
                };
                cmdChangeName12.Parameters.Add(changeNameParam12);

                con.Open();
                cmdChangeName12.ExecuteNonQuery();
                con.Close();

                //-----------------text box [1][3] @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@###############################
                SqlCommand cmdChangeName13 = new SqlCommand("UPDATE officials SET official_name = @name WHERE official_id = 15;", con);

                SqlParameter changeNameParam13 = new SqlParameter()
                {
                    ParameterName = "@name",
                    Value = CouncilorTextBox[12].Text
                };
                cmdChangeName13.Parameters.Add(changeNameParam13);

                con.Open();
                cmdChangeName13.ExecuteNonQuery();
                con.Close();


                //-----------------text box [1][4] @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@###############################
                SqlCommand cmdChangeName14 = new SqlCommand("UPDATE officials SET official_name = @name WHERE official_id = 16 ;", con);

                SqlParameter changeNameParam14 = new SqlParameter()
                {
                    ParameterName = "@name",
                    Value = CouncilorTextBox[13].Text
                };
                cmdChangeName14.Parameters.Add(changeNameParam14);

                con.Open();
                cmdChangeName14.ExecuteNonQuery();
                con.Close();

                //-----------------text box [1][5] @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@###############################
                SqlCommand cmdChangeName15 = new SqlCommand("UPDATE officials SET official_name = @name WHERE official_id = 17 ;", con);

                SqlParameter changeNameParam15 = new SqlParameter()
                {
                    ParameterName = "@name",
                    Value = CouncilorTextBox[14].Text
                };
                cmdChangeName15.Parameters.Add(changeNameParam15);

                con.Open();
                cmdChangeName15.ExecuteNonQuery();
                con.Close();

                //-----------------text box [1][6] @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@###############################
                SqlCommand cmdChangeName16 = new SqlCommand("UPDATE officials SET official_name = @name WHERE official_id = 18 ;", con);

                SqlParameter changeNameParam16 = new SqlParameter()
                {
                    ParameterName = "@name",
                    Value = CouncilorTextBox[15].Text
                };
                cmdChangeName16.Parameters.Add(changeNameParam16);

                con.Open();
                cmdChangeName16.ExecuteNonQuery();
                con.Close();


                emptyTextBox = true;

            }
            else
            {
                emptyTextBox = false;
            }

            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vice Mayor photo successfully changed!')", true);
            //ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#viceMayorDiv';", true);
            if (emptyTextBox == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Names cannot be empty!')", true);
            }
            else if (imgTypeValidation == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Images (.jpg, .png, .bmp, .gif) can be uploaded!')", true);
            }
            else if (upload == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Image UPLOAD Failed.')", true);
            }
            else
            {
                //CouncilorGetData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Records successfully updated!')", true);
                Page.Response.Redirect(Page.Request.Url.ToString(), true);

            }

            //END OF CHANGE NAME ------------------!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        }

        public void listItemClick(object sender, EventArgs e)
        {
            //selectedItem.Text = DropDownList1.SelectedValue;
            if(DropDownList1.SelectedValue == "Mayor")
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