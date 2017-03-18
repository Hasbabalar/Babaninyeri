using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cp2DevExPrh.UserOperations
{
    public partial class DeleteUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            String userName = tbUserName.Text;

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

                    var readStringName = readerName.GetString(0);

                    if (readStringName == userName)
                    {
                        checkIfExists = true;
                        break;
                    }
                }
                con.Close();

                if (checkIfExists == true)
                {
                    con.Open();

                    string deleteUserWithGivenName = "DELETE FROM dbo.Kullanici WHERE KullaniciAdi = '" + userName + "'";

                    SqlCommand insertCmd = new SqlCommand(deleteUserWithGivenName, con);

                    insertCmd.ExecuteNonQuery();

                    con.Close();

                    Response.Redirect("~/");
                }
                else
                {
                    tbUserName.ErrorText = "Böyle bir kullanıcı adı bulunmamaktadır.";
                    tbUserName.IsValid = false;

                }

            }
            
        }

    }

}