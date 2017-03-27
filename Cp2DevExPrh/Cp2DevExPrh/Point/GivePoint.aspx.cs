using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using QC = System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Configuration;
using System.Data.OleDb;
using Microsoft.Office;
using ClosedXML.Excel;

namespace Cp2DevExPrh.Point
{
    public partial class GivePoint : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();

            }

        }

        protected void Button_Download(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("Puanlama");
            foreach (TableCell cell in GridView1.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                dt.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
                }
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Puanlama.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /*Tell the compiler that the control is rendered
             * explicitly by overriding the VerifyRenderingInServerForm event.*/
        }

        protected void LoadGrid()
        {
            SqlConnection dbConnection = new SqlConnection(@"Data Source=babalarserver.database.windows.net;Database=hasbabalarDB;Integrated Security=False;User ID=babalar;Password=Gelburayi123;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            dbConnection.Open();

            SqlDataAdapter da = new SqlDataAdapter("Select Kullanici.KullaniciAdi,Kullanici.KullaniciMaili,Restoran.Ad,Puanlama.Puan from Puanlama INNER JOIN  Kullanici ON Kullanici.KullaniciID = Puanlama.KullaniciID INNER JOIN  Restoran ON Restoran.RestoranID = Puanlama.RestoranID", dbConnection);

            DataTable ds = new DataTable();

            da.Fill(ds);

            GridView1.DataSource = ds;

            GridView1.DataBind();
            dbConnection.Close();
        }


        protected void Button_Import(object sender, EventArgs e)
        {
            if (FileUpload2.HasFile)
            {
                string path = string.Concat(Server.MapPath("~/File/" + FileUpload2.FileName));
                FileUpload2.SaveAs(path);

                OleDbConnection OleDbcon;
                OleDbCommand cmd = new OleDbCommand(); ;
                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
                DataSet ds = new DataSet();
                DataTable dtExcelData = new DataTable();

                if (Path.GetExtension(path) == ".xls")
                {
                    OleDbcon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "; Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"");
                    OleDbcon.Open();
                    cmd.Connection = OleDbcon;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM [Puanlama$]";
                    objAdapter1 = new OleDbDataAdapter(cmd);
                    objAdapter1.Fill(ds);
                    dtExcelData = ds.Tables[0];
                    GridView2.DataSource = dtExcelData;
                    GridView2.DataBind();
                    OleDbcon.Close();
                }
                else if (Path.GetExtension(path) == ".xlsx")
                {
                    OleDbcon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + "; Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");
                    OleDbcon.Open();
                    cmd.Connection = OleDbcon;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM [Puanlama$]";
                    objAdapter1 = new OleDbDataAdapter(cmd);
                    objAdapter1.Fill(ds);
                    dtExcelData = ds.Tables[0];
                    GridView2.DataSource = dtExcelData;

                    GridView2.DataBind();
                    OleDbcon.Close();
                }



            }




            SqlConnection dbConnection = new SqlConnection(@"Data Source=babalarserver.database.windows.net;Database=hasbabalarDB;Integrated Security=False;User ID=babalar;Password=Gelburayi123;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            dbConnection.Open();
            foreach (GridViewRow row in GridView2.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    String KullaniciAdi = row.Cells[0].Text;
                    String KullaniciMaili = row.Cells[1].Text;
                    String RestoranAdi = row.Cells[2].Text;
                    int Puan = Int32.Parse(row.Cells[3].Text);

                    SqlCommand cmdd = new SqlCommand(" Update Puanlama SET Puan ='" + Puan + "' WHERE  KullaniciID IN (SELECT KullaniciID  FROM Kullanici WHERE KullaniciAdi = '" + KullaniciAdi + "'  AND  KullaniciMaili ='" + KullaniciMaili + "' ) AND RestoranID IN (SELECT RestoranID  FROM Restoran WHERE  Ad = '" + RestoranAdi + "')", dbConnection);
                    cmdd.ExecuteNonQuery();


                }
            }

            SqlDataAdapter da2 = new SqlDataAdapter("Select RestoranID,avg(Puan) as Puan from Puanlama  As Average group by RestoranID", dbConnection);

            DataTable ds2 = new DataTable();

            da2.Fill(ds2);

            GridView3.DataSource = ds2;

            GridView3.DataBind();
            

            String Restoranid;
            String RestoranOrtalamaPuan;

            foreach (GridViewRow row in GridView3.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Restoranid = row.Cells[0].Text;
                    RestoranOrtalamaPuan = row.Cells[1].Text;


                    SqlCommand cmdd2 = new SqlCommand(" Update Restoran SET Puan ='" + RestoranOrtalamaPuan + "' WHERE   RestoranID ='" + Restoranid + "'", dbConnection);
                    cmdd2.ExecuteNonQuery();


                }
            }



            dbConnection.Close();
            LoadGrid();
        }


    }
}