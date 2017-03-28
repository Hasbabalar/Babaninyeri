using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Cp2DevExPrh
{
    public partial class Statistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
           

            SqlConnection dbConnection = new SqlConnection(@"Data Source=babalarserver.database.windows.net;Database=hasbabalarDB;Integrated Security=False;User ID=babalar;Password=Gelburayi123;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            dbConnection.Open();

            SqlDataAdapter da2 = new SqlDataAdapter("Select Restoran.Ad,avg(Puanlama.Puan) as Puan from Puanlama  INNER JOIN  Restoran ON Restoran.RestoranID = Puanlama.RestoranID group by Restoran.Ad", dbConnection);
            DataTable ds2 = new DataTable();

            da2.Fill(ds2);

            GridView1.DataSource = ds2;

            GridView1.DataBind();

            //bölme değiştirildi
            SqlDataAdapter da3 = new SqlDataAdapter(" Select Restoran.Ad,Restoran.KalanPuan as Kalan_Gün_Sayısı from Restoran", dbConnection);
           
            DataTable ds3 = new DataTable();

            da3.Fill(ds3);

            GridView2.DataSource = ds3;

            GridView2.DataBind();





            SqlDataAdapter da4 = new SqlDataAdapter(" Select Gun,Ad from GunlukBilgi inner join Restoran on GunlukBilgi.RestoranID=Restoran.RestoranID", dbConnection);
           
            DataTable ds4 = new DataTable();

            da4.Fill(ds4);

            GridView3.DataSource = ds4;

            GridView3.DataBind();
            dbConnection.Close();


        }

        protected void ButtonShow1(object sender, EventArgs e)
        {
            if (GridView1.Visible == false)
                GridView1.Visible = true;
            else
                GridView1.Visible = false;
        }
        protected void ButtonShow2(object sender, EventArgs e)
        {
            if (GridView2.Visible == false)
                GridView2.Visible = true;
            else
                GridView2.Visible = false;
        }
        protected void ButtonShow3(object sender, EventArgs e)
        {
            if (GridView3.Visible == false)
                GridView3.Visible = true;
            else
                GridView3.Visible = false;
        }
    }
}