using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Script.Serialization;namespace Cp2DevExPrh
{
    public partial class SendEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                /*Today's date is taken.*/
                String sDate = DateTime.Now.ToString();
                DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
                String dy = datevalue.Day.ToString();


                /*Weather conditions are taken from Accuweather web service as Json string*/
                string jsonStrParse = new WebClient().DownloadString("http://apidev.accuweather.com/currentconditions/v1/318251.json?language=en&apikey=hoArfRosT1215");
                bool isRain = jsonStrParse.Contains("Rain");
                bool isSnow = jsonStrParse.Contains("Snow");
                bool isRainAndSnow = jsonStrParse.Contains("Rain and Snow");

                /*Mail and Smtp settings*/
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("hasbabalar@gmail.com");

                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("hasbabalar", "Gelburayi123");
                SmtpServer.EnableSsl = true;

                String returnedStr;

                SqlConnection con = new SqlConnection(@"Data Source=babalarserver.database.windows.net;Database=hasbabalarDB;Integrated Security=False;User ID=babalar;Password=Gelburayi123;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

               
                con.Open();

                int oneDayAgo = Int32.Parse(dy)-1;

                string getOneDayAgo = "SELECT Ulasim FROM dbo.Restoran INNER JOIN dbo.GunlukBilgi ON dbo.Restoran.RestoranID = dbo.GunlukBilgi.RestoranID WHERE Gun = " + oneDayAgo;

                SqlCommand cmdOneDayAgo = new SqlCommand(getOneDayAgo, con);

                string rtnOneDayAgo = (String)cmdOneDayAgo.ExecuteScalar();

                con.Close();


                con.Open();

                int twoDaysAgo = Int32.Parse(dy) - 2;

                string getTwoDaysAgo = "SELECT Ulasim FROM dbo.Restoran INNER JOIN dbo.GunlukBilgi ON dbo.Restoran.RestoranID = dbo.GunlukBilgi.RestoranID WHERE Gun = " + twoDaysAgo;

                SqlCommand cmdTwoDaysAgo = new SqlCommand(getTwoDaysAgo, con);

                string rtnTwoDaysAgo = (String)cmdTwoDaysAgo.ExecuteScalar();

                con.Close();

                if ((rtnOneDayAgo.Contains("Araba") || rtnTwoDaysAgo.Contains("Araba")) && !isRainAndSnow && !isRain && !isSnow)
                {
                    con.Open();

                    string getMaxRestaurantName = "SELECT TOP 1 Ad FROM dbo.Restoran WHERE Puan = (SELECT MAX(Puan) FROM dbo.Restoran WHERE DunGidildiMi = 0 AND Ulasim = 'Yaya')";

                    SqlCommand cmdMaxName = new SqlCommand(getMaxRestaurantName, con);

                    returnedStr = (String)cmdMaxName.ExecuteScalar();

                    Response.Write("Gidilecek restoran adı: " + returnedStr);

                    con.Close();

                    con.Open();

                    string decPuan = "UPDATE dbo.Restoran SET Puan = Puan - 1  WHERE Ad = " +"'" + returnedStr + "'" ;

                    SqlCommand cmdDecPuan = new SqlCommand(decPuan, con);

                    cmdDecPuan.ExecuteNonQuery();

                    con.Close();

                }
                else
                {
                    con.Open();

                    string getMaxRestaurantName = "SELECT TOP 1 Ad FROM dbo.Restoran WHERE Puan = (SELECT MAX(Puan) FROM dbo.Restoran WHERE DunGidildiMi = 0)";

                    SqlCommand cmdMaxName = new SqlCommand(getMaxRestaurantName, con);

                    returnedStr = (String)cmdMaxName.ExecuteScalar();

                    Response.Write("Gidilecek restoran adı: " + returnedStr);

                    con.Close();

                    con.Open();

                    string decPuan = "UPDATE dbo.Restoran SET Puan = Puan - 1  WHERE Ad = " + "'" + returnedStr + "'";

                    SqlCommand cmdDecPuan = new SqlCommand(decPuan, con);

                    cmdDecPuan.ExecuteNonQuery();

                    con.Close();

                }


                con.Open();

                string getMailAddress = "SELECT KullaniciMaili FROM dbo.Kullanici";

                SqlCommand cmdForMailAddress = new SqlCommand(getMailAddress, con);

                SqlDataReader readerName = cmdForMailAddress.ExecuteReader();

                while (readerName.Read())
                {

                    var readStringName = readerName.GetString(0);

                    mail.To.Add(readStringName);

                }

                con.Close();

                con.Open();

                string updateDunGidildiMi = "UPDATE dbo.Restoran SET DunGidildiMi = 0";

                SqlCommand cmdDunGidildiMi = new SqlCommand(updateDunGidildiMi, con);
                
                cmdDunGidildiMi.ExecuteNonQuery();
                
                con.Close();

                con.Open();

                string setGidildi = "UPDATE dbo.Restoran SET DunGidildiMi = 1 WHERE Ad = " + "'"+ returnedStr + "'";
                
                SqlCommand cmdDunGidildi = new SqlCommand(setGidildi, con);
                
                cmdDunGidildi.ExecuteNonQuery();

                con.Close();

                mail.Subject = "Bugün gidilecek restoran";
                
                mail.Body = "Merhaba, Nerede yesek? Uygulamasının size bugün için önerdiği restoran: " + returnedStr;

                con.Open();

                string insertGunlukBilgi = "SET IDENTITY_INSERT dbo.GunlukBilgi ON INSERT INTO dbo.GunlukBilgi(Gun, RestoranID) VALUES(" + dy + ",(SELECT RestoranID FROM dbo.Restoran WHERE Ad = " + "'" + returnedStr + "'" + "))";
                
                SqlCommand cmdInsertGunlukBilgi = new SqlCommand(insertGunlukBilgi, con);
                
                cmdInsertGunlukBilgi.ExecuteNonQuery();
                
                con.Close();

                SmtpServer.Send(mail);
          }
            catch (Exception ex)
            {
                Response.Write("Could not send the e-mail - error: " + ex.Message);
            }
             
        }
    }
}