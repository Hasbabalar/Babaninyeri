using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cp2DevExPrh.UserOperations
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            String userName = tbUserName.Text;
            String userMail = tbUserMail.Text;

            bool isValidUserName = true;
            bool isValidUserMail = true;
            
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(userMail))
            {
                SqlConnection con = new SqlConnection(@"Data Source=babalarserver.database.windows.net;Database=hasbabalarDB;Integrated Security=False;User ID=babalar;Password=Gelburayi123;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                con.Open();

                string checkUserNameIsExists = "SELECT KullaniciAdi FROM dbo.Kullanici";

                SqlCommand cmdForNameCheck = new SqlCommand(checkUserNameIsExists, con);

                SqlDataReader readerName = cmdForNameCheck.ExecuteReader();

                while (readerName.Read())
                {

                    var readStringName = readerName.GetString(0);

                    if (readStringName == userName)
                    {
                        isValidUserName = false;
                        tbUserName.ErrorText = "Bu kullanıcı adı sistemde mevcut. Lütfen başka bir kullanıcı adı seçiniz.";
                        tbUserName.IsValid = false;
                        break;
                    }
                }

                con.Close();

                con.Open();
                string checkUserMailIsExists = "SELECT KullaniciMaili FROM dbo.Kullanici";

                SqlCommand cmdForMailCheck = new SqlCommand(checkUserMailIsExists, con);

                SqlDataReader readerMail = cmdForMailCheck.ExecuteReader();
                while (readerMail.Read())
                {

                    var readStringMail = readerMail.GetString(0);

                    if (readStringMail == userMail)
                    {
                        isValidUserMail = false;
                        tbUserMail.ErrorText = "Bu mail adresi sistemde mevcut. Lütfen başka bir mail giriniz.";
                        tbUserMail.IsValid = false;
                        break;
                    }
                }
                con.Close();

                con.Open();

                if (isValidUserName == true && isValidUserMail == true) { 

                String insertQuery = "INSERT INTO dbo.Kullanici (KullaniciAdi,KullaniciMaili) VALUES ('" + userName + "','" + userMail + "' );";

                SqlCommand insertCmd = new SqlCommand(insertQuery, con);

                insertCmd.ExecuteNonQuery();

                Response.Redirect("~/");

                }

                con.Close();
            }

        }
    }
}