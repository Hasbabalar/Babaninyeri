using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cp2DevExPrh.UserOperations
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            String userName = tbUserName.Text;
            string readStringName = "";
            string readStringMail = "";
            bool checkIfExists = false;

            if (!string.IsNullOrEmpty(userName))
            {
                SqlConnection con = new SqlConnection(@"Data Source=babalarserver.database.windows.net;Database=hasbabalarDB;Integrated Security=False;User ID=babalar;Password=Gelburayi123;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                con.Open();

                string checkUserNameIsExists = "SELECT KullaniciAdi FROM dbo.Kullanici";

                SqlCommand cmdForNameCheck = new SqlCommand(checkUserNameIsExists, con);

                SqlDataReader readerName = cmdForNameCheck.ExecuteReader();

                while (readerName.Read())
                {

                    readStringName = readerName.GetString(0);

                    if (readStringName == userName)
                    {
                        checkIfExists = true;
                        break;
                    }
                }
                con.Close();
                con.Open();

                string checkUserMailIsExists = "SELECT KullaniciMaili FROM dbo.Kullanici WHERE KullaniciAdi = '" + userName + "'";

                SqlCommand cmdForMailCheck = new SqlCommand(checkUserMailIsExists, con);

                SqlDataReader readerMail = cmdForMailCheck.ExecuteReader();

                while (readerMail.Read())
                {
                    readStringMail = readerMail.GetString(0);
                }
                con.Close();

                if (checkIfExists == true)
                {
                    tbEditUserName.Text = readStringName;
                    tbEditUserMail.Text = readStringMail;
                }
                else
                {
                    tbUserName.ErrorText = "Böyle bir kullanıcı adı bulunmamaktadır.";
                    tbUserName.IsValid = false;

                }

            }
        }

        protected void btnEnableEditing_Click(object sender, EventArgs e)
        {
            String userName = tbUserName.Text;
            String editedUserName = tbEditUserName.Text;
            String editedUserMail = tbEditUserMail.Text;

            bool isValidUserName = true;

            if (!string.IsNullOrEmpty(editedUserName) && !string.IsNullOrEmpty(editedUserMail))
            {
                SqlConnection con = new SqlConnection(@"Data Source=babalarserver.database.windows.net;Database=hasbabalarDB;Integrated Security=False;User ID=babalar;Password=Gelburayi123;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                con.Open();

                string checkUserNameIsExists = "SELECT KullaniciAdi FROM dbo.Kullanici";

                SqlCommand cmdForNameCheck = new SqlCommand(checkUserNameIsExists, con);

                SqlDataReader readerName = cmdForNameCheck.ExecuteReader();

                while (readerName.Read())
                {

                    var readStringName = readerName.GetString(0);

                    if (readStringName == editedUserName && readStringName != userName)
                    {
                        isValidUserName = false;
                        tbEditUserName.ErrorText = "Bu kullanıcı adı sistemde mevcut. Lütfen başka bir kullanıcı adı seçiniz.";
                        tbEditUserName.IsValid = false;
                        break;
                    }
                }

                con.Close();

                con.Open();

                if (isValidUserName == true)
                {

                    String insertQuery = "UPDATE dbo.Kullanici SET KullaniciAdi = '" + editedUserName + "' ,KullaniciMaili = '" + editedUserMail + "' WHERE KullaniciAdi = '" + userName + "'";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, con);

                    insertCmd.ExecuteNonQuery();

                    Response.Redirect("~/");

                }

                con.Close();
            }

        }
    }

}