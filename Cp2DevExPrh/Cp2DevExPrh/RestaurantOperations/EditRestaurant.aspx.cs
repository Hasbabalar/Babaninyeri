using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Cp2DevExPrh.RestaurantOperations
{
    public partial class EditRestaurant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnEditRestaurant_Click(object sender, EventArgs e)
        {
            String RestaurantName = tbEditRestaurantName.Text;
            String RestaurantTransportationType = tbEditRestaurantTransportationType.Text;
            String RestaurantWeatherType = tbEditRestaurantWeatherType.Text;


            bool isValidRestaurantName = true;
            bool isValidRestaurantTransportationType = true;
            bool isValidRestaurantWeatherType = true;


            if (!string.IsNullOrEmpty(RestaurantName) && !string.IsNullOrEmpty(RestaurantTransportationType) && !string.IsNullOrEmpty(RestaurantWeatherType))
            {
                SqlConnection con = new SqlConnection(@"Data Source=babalarserver.database.windows.net;Database=hasbabalarDB;Integrated Security=False;User ID=babalar;Password=Gelburayi123;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                con.Open();

                string checkRestaurantNameIsExists = "SELECT Ad FROM dbo.Restoran WHERE Ad = '" + tbEditRestaurantName + "'";

                SqlCommand cmdForNameCheck = new SqlCommand(checkRestaurantNameIsExists, con);

                SqlDataReader readerName = cmdForNameCheck.ExecuteReader();

                while (readerName.Read())
                {

                    var readStringName = readerName.GetString(0);

                    if (readStringName != RestaurantName)
                    {
                        isValidRestaurantName = false;
                        tbEditRestaurantName.ErrorText = "Bu restoran sistemde mevcut değil. Lütfen başka bir restoran giriniz.";
                        tbEditRestaurantName.IsValid = false;
                        break;
                    }
                }

                con.Close();


                con.Open();

                if (isValidRestaurantName == true)
                {
                    int weather;
                    if (RestaurantWeatherType == "Duyarlı")
                        weather = 1;
                    else
                        weather = 0;



                    String insertQuery = "UPDATE dbo.Restoran SET Ad = '" + RestaurantName + "' ,Ulasim = '" + RestaurantTransportationType + "' ,HavaDurumu = '" + weather + "' WHERE Ad = '" + tbEditRestaurantName + "'";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, con);

                    insertCmd.ExecuteNonQuery();

                    Response.Redirect("~/");

                }

                con.Close();
            }



        }



    }
}