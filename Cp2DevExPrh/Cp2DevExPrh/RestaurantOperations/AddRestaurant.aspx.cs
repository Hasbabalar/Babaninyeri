using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Cp2DevExPrh.RestaurantOperations
{
    public partial class AddRestaurant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    protected void btnAddRestaurant_Click(object sender, EventArgs e)
        {
            String RestaurantName = tbRestaurantName.Text;
            String RestaurantTransportationType = tbRestaurantTransportationType.Text;
            String RestaurantWeatherType = tbRestaurantWeatherType.Text;


            bool isValidRestaurantName = true;
            bool isValidRestaurantTransportationType = true;
            bool isValidRestaurantWeatherType = true;


            if (!string.IsNullOrEmpty(RestaurantName) && !string.IsNullOrEmpty(RestaurantTransportationType) && !string.IsNullOrEmpty(RestaurantWeatherType))
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
                        isValidRestaurantName = false;
                        tbRestaurantName.ErrorText = "Bu restoran sistemde mevcut. Lütfen başka bir restoran giriniz.";
                        tbRestaurantName.IsValid = false;
                        break;
                    }
                }

                con.Close();


                con.Open();

                if (isValidRestaurantName == true )
                {
                    int weather;
                    if (RestaurantWeatherType == "Duyarlı")
                        weather = 1;
                    else
                        weather = 0;


                    /// Burası daha bi düzenlenecek. şimdilik idare etsin.
                    String insertQuery = "INSERT INTO dbo.Restoran (Ad,Ulasim,HavaDurumu) VALUES ('" + RestaurantName + "','" + RestaurantTransportationType + "','" + weather + "' );";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, con);

                    insertCmd.ExecuteNonQuery();

                    Response.Redirect("~/");

                }

                con.Close();
            }


        
        }



    }
}