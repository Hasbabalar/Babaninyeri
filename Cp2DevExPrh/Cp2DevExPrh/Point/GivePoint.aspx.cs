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
using OfficeOpenXml;
using System.Globalization;

namespace Cp2DevExPrh.Point
{

    public static class ExcelPackageExtensions
    {
        public static DataTable ToDataTable(this ExcelPackage package)
        {
           
                ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
            
            DataTable table = new DataTable();
            foreach (var firstRowCell in workSheet.Cells[1, 1, 1, workSheet.Dimension.End.Column])
            {
                table.Columns.Add(firstRowCell.Text);
            }

            for (var rowNumber = 2; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
            {
                var row = workSheet.Cells[rowNumber, 1, rowNumber, workSheet.Dimension.End.Column];
                var newRow = table.NewRow();
                foreach (var cell in row)
                {
                    newRow[cell.Start.Column - 1] = cell.Text;
                }
                table.Rows.Add(newRow);
            }
            return table;
        }
    }

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
                if (row.Cells[0].Text==DropDownList1.Text)
                {
                    dt.Rows.Add();
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
                    }

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
                    
                        wb.SaveAs(MyMemoryStream, false);
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

            SqlCommand cmd = new SqlCommand("Select KullaniciAdi from Kullanici", dbConnection);

            SqlDataAdapter da5 = new SqlDataAdapter(cmd);

            DataSet ds5 = new DataSet();
            da5.Fill(ds5);

            DropDownList1.DataTextField = ds5.Tables[0].Columns["KullaniciAdi"].ToString();
            

            DropDownList1.DataSource = ds5.Tables[0];
            DropDownList1.DataBind();




            SqlDataAdapter da = new SqlDataAdapter("Select Kullanici.KullaniciAdi,Kullanici.KullaniciMaili,Restoran.Ad,Puanlama.Puan from Puanlama INNER JOIN  Kullanici ON Kullanici.KullaniciID = Puanlama.KullaniciID INNER JOIN  Restoran ON Restoran.RestoranID = Puanlama.RestoranID order by Restoran.Ad ASC", dbConnection);

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

                if (FileUpload2.HasFile)
                {
                    if (Path.GetExtension(FileUpload2.FileName) == ".xlsx")
                    {
                        ExcelPackage package = new ExcelPackage(FileUpload2.FileContent);
                        GridView2.DataSource = package.ToDataTable();
                        GridView2.DataBind();
                    }
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
            dbConnection.Close();
            dbConnection.Open();
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

                    float x = float.Parse(RestoranOrtalamaPuan, CultureInfo.InvariantCulture.NumberFormat);

                    SqlCommand cmdd2 = new SqlCommand(" Update Restoran SET Puan ='" + x + "' WHERE   RestoranID ='" + Restoranid + "'", dbConnection);
                    cmdd2.ExecuteNonQuery();


                }
            }



            dbConnection.Close();
            LoadGrid();
        }


    }
}