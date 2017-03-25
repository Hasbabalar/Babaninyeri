using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Cp2DevExPrh.RestaurantOperations
{
    public partial class DeleteRestaurant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnDeleteRestaurant_Click(object sender, EventArgs e)
        {
            String RestaurantName = tbRestaurantName.Text;

            bool checkIfExists = false;

            if (!string.IsNullOrEmpty(RestaurantName))
            {
                SqlConnection con = new SqlConnection(@"Data Source=babalarserver.database.windows.net;Database=hasbabalarDB;Integrated Security=False;User ID=babalar;Password=Gelburayi123;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                con.Open();

                string checkRestaurantNameIsExists = "SELECT Ad FROM dbo.Restoran";

                SqlCommand cmdForNameCheck = new SqlCommand(checkRestaurantNameIsExists, con);

                SqlDataReader readerName = cmdForNameCheck.ExecuteReader();

                while (readerName.Read())
                {

                    var readStringName = readerName.GetString(0);

                    if (readStringName == RestaurantName)
                    {
                        checkIfExists = true;
                        break;
                    }
                }
                con.Close();

                if (checkIfExists == true)
                {
                    con.Open();

                    string deleteRestaurantrWithGivenName = "DELETE FROM dbo.Restoran WHERE Ad = '" + RestaurantName + "'";

                    SqlCommand insertCmd = new SqlCommand(deleteRestaurantrWithGivenName, con);

                    insertCmd.ExecuteNonQuery();

                    con.Close();

                    Response.Redirect("~/");
                }
                else
                {
                    tbRestaurantName.ErrorText = "Böyle bir restoran bulunmamaktadır.";
                    tbRestaurantName.IsValid = false;

                }

            }

        }
    }
}