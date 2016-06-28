using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Text;


public partial class CS : System.Web.UI.Page
{
    private SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyCompany"].ConnectionString);
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        string FilePath = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/")) + "Image\\";
        try
        {
            DataTable dtStudentCode= new DataTable();
          
            string SQLCode = " SELECT StudentCode FROM Student";
           
            if (conn.State == 0)
            {
                conn.Open();
            }
            SqlDataAdapter adpt1 = new SqlDataAdapter(SQLCode, conn);
            adpt1.Fill(dtStudentCode);

            foreach (DataRow dtRow in dtStudentCode.Rows)
            {
                var StucentCode = dtRow["StudentCode"].ToString();


              //  string barCode = txtCode.Text;
                string barCode = StucentCode;
                
                System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                using (Bitmap bitMap = new Bitmap(barCode.Length * 40, 80))
                {
                    using (Graphics graphics = Graphics.FromImage(bitMap))
                    {
                        Font oFont = new Font("IDAutomationHC39M", 16);
                        PointF point = new PointF(2f, 2f);
                        SolidBrush blackBrush = new SolidBrush(Color.Black);
                        SolidBrush whiteBrush = new SolidBrush(Color.White);
                        graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                        graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
                    }
                    using (MemoryStream ms = new MemoryStream())
                    {
                        string fileName = StucentCode;

                       // bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    //    bitMap.Save(System.IO.Path.GetTempPath() + StucentCode, System.Drawing.Imaging.ImageFormat.Png);
                        bitMap.Save(FilePath + StucentCode+ ".png", System.Drawing.Imaging.ImageFormat.Png);

                       byte[] byteImage = ms.ToArray();

                        Convert.ToBase64String(byteImage);
                        imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);



                       // Image img = System.Drawing.Image.FromStream(ms);

                       // img.Save(System.IO.Path.GetTempPath() + StucentCode, ImageFormat.Jpeg);

                   ////    Byte[] bytesInStream = null;
                   ////   //  bytesInStream = byteImage;
                   ////     FileStream fileStream = File.Create(FilePath, (int)ms.Length);
                   ////     // Initialize the bytes array with the stream length and then fill it with data
                   //////     byte[] bytesInStream = new byte[ms.Length];
                   ////     ms.Read(byteImage, 0, bytesInStream.Length);
                   ////     // Use write method to write to the file specified above
                   ////     fileStream.Write(bytesInStream, 0, bytesInStream.Length);




                     //   string memString = Convert.ToBase64String(byteImage);//"Memory test string !!";
                     //   // convert string to stream
                     //   byte[] buffer = Encoding.ASCII.GetBytes(memString);
                     //  MemoryStream mss = new MemoryStream(buffer);
                     //   //write to file
                     ////   FileStream file = new FileStream("d:\\file.txt", FileMode.Create, FileAccess.Write);
                     //   FileStream file = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
                     //   mss.WriteTo(file);
                     //   file.Close();
                     //   mss.Close();

                       





                    }

                   


                    //Byte[] bytes = null;


                    //FileStream fs = new FileStream(PDFPath + fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    //byte[] data = new byte[fs.Length];
                    //fs.Write(bytes, 0, bytes.Length);
                    //fs.Close();
                    //PdfLocation = PDFPath + fileName;


                    plBarCode.Controls.Add(imgBarCode);

                   // "AdmitCard" + UserID + DateTime.Now.ToFileTime() + ".pdf";
                    //data:image/gif;base64,
                    //this image is a single pixel (black)
                    //byte[] bytes = Convert.FromBase64String("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw==");

                    //Image image;
                    //using (MemoryStream ms = new MemoryStream(bytes))
                    //{
                    //    image = Image.FromStream(ms);
                    //}

            
            
            }


       
            }
        }
        catch (Exception ex)
        {
            return;

        }
        }
    
}
