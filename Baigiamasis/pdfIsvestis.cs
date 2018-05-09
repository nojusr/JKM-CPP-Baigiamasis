using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using MySql.Data.Types;

using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Baigiamasis {
    class pdfIsvestis {

        private string connStr = "server=localhost;user id=root;database=jkm_baig;charset=utf8";

        public string filename { get; set; }
        public int obid { get; set; }

        public double elek { get; set; }
        public double duj { get; set; }
        public double vand { get; set; }
        public double inter { get; set; }

        public List<string> bendrpav = new List<string>();
        public List<double> bendrkain = new List<double>();

        public pdfIsvestis() {

        }

        //isvalo visa klase (isskyrus pasirinkta failo vieta)
        public void Clear() {
            obid = 0;
            elek = 0;
            duj = 0;
            vand = 0;
            inter = 0;
            bendrpav.Clear();
            bendrkain.Clear();
            
        }

        //gauna nuomos kaina
        private double getNuom() {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            string sql = "SELECT Nuoma FROM objektai WHERE obid="+obid+";";
            double output = 0;

            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader data = comm.ExecuteReader();
            while (data.Read()) {
                output = Double.Parse(data["Nuoma"].ToString());
            }
            return output;
        }

        //gauna operatoriu kaina vienetui
        private double getOperatorRate(string type) {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            string sql;
            double output = 0;
            string oid = "";

            MySqlCommand comm;
            MySqlDataReader data;

            if (type == "e") {
                sql = "SELECT ce_oid FROM objektai WHERE obid="+obid+";";
                comm = new MySqlCommand(sql, conn);
                data = comm.ExecuteReader();
                while (data.Read()) {
                    oid = data["ce_oid"].ToString();
                }
                data.Dispose();

            } else if (type == "d") {
                sql = "SELECT cd_oid FROM objektai WHERE obid=" + obid + ";";
                comm = new MySqlCommand(sql, conn);
                data = comm.ExecuteReader();
                while (data.Read()) {
                    oid = data["cd_oid"].ToString();
                }
                data.Dispose();

            } else if (type == "v") {
                sql = "SELECT cv_oid FROM objektai WHERE obid=" + obid + ";";
                comm = new MySqlCommand(sql, conn);
                data = comm.ExecuteReader();
                while (data.Read()) {
                    oid = data["cv_oid"].ToString();
                }
                data.Dispose();

            } else if (type == "i") {
                sql = "SELECT ci_oid FROM objektai WHERE obid=" + obid + ";";
                comm = new MySqlCommand(sql, conn);
                data = comm.ExecuteReader();
                while (data.Read()) {
                    oid = data["ci_oid"].ToString();
                }
                data.Dispose();
            }

            sql = "SELECT op_rate FROM operatoriai WHERE oid="+oid+";";
            comm = new MySqlCommand(sql, conn);
            data = comm.ExecuteReader();
            while (data.Read()) {
                output = Double.Parse(data["op_rate"].ToString());
            }

            conn.Close();
            return output;
        }

        //pagrindine pdf piesimo funkcija
        public void Generate(MySqlConnection conn) {




            conn.Open();

            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
            //spalvos
            XBrush lblue = new XSolidBrush(XColor.FromArgb(158, 217, 252 ));
            XBrush pblue = new XSolidBrush(XColor.FromArgb(21, 112, 247 ));

            //fonts
            XFont header = new XFont("Arial", 13, XFontStyle.BoldItalic, options);
            XFont small = new XFont("Arial", 8, XFontStyle.Regular, options);
            XFont normal = new XFont("Arial", 10, XFontStyle.Regular, options);
            XFont normalBold = new XFont("Arial", 10, XFontStyle.Bold, options);
            XFont normalItalic = new XFont("Arial", 10, XFontStyle.Italic, options);
            XFont normalBoldItalic = new XFont("Arial", 10, XFontStyle.BoldItalic, options);

            //'piestukai'
            XPen black = new XPen(XColors.Black, 1);
            XPen gray = new XPen(XColors.Gray, 1);
            XPen neutralRect = new XPen(XColors.Gray, 1);
            XPen goodRect = new XPen(XColors.Aqua, 1);

            
            string sql = "SELECT ob_addr FROM objektai WHERE obid="+this.obid+";";
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader data = comm.ExecuteReader();

            string buf;


            //HEADER
            string addr = "";

            while (data.Read()) {
                addr = data["ob_addr"].ToString();
            }
            buf = addr + " mokesčiai";
            gfx.DrawString(buf, header, XBrushes.Black,new XRect(0, 0, page.Width, 100),XStringFormats.Center);
            gfx.DrawLine(black, 40, 90, page.Width - 40, 90);

            //DATA

            buf = "Data: " + DateTime.Now.ToString("MM-yyyy");
            gfx.DrawRectangle(black ,XBrushes.Beige, 40 , 95, 100, 20);
            gfx.DrawString(buf, normalBold, XBrushes.Black, new XRect(45, 100, page.Width-80, 19), XStringFormats.TopLeft);

            //BENDRIJA
                
                //title
            buf = "Bendrijos mokesčiai";
            gfx.DrawRectangle(neutralRect, XBrushes.Beige, 40, 130, page.Width - 80, 18);
            gfx.DrawString(buf, normalBoldItalic, XBrushes.Black, new XRect(40, 130, page.Width - 80, 18), XStringFormats.Center);

                //tableheader
            buf = "Mokestis";
            gfx.DrawString(buf, normalBold, XBrushes.Black, new XRect(40, 155, 455, 18), XStringFormats.Center);
            buf = "Kaina";
            gfx.DrawString(buf, normalBold, XBrushes.Black, new XRect(495, 155, 60, 18), XStringFormats.Center);
               
                //table
            int lineheight = 16;

            double ypoint = 155 + 16*(bendrpav.Count+1);

            for (int i = 0; i < bendrpav.Count; i++){
                int ycoords = lineheight*(i+1);
                gfx.DrawRectangle(gray, 40, 155 + ycoords, 455, lineheight);
                gfx.DrawRectangle(gray, 495, 155 + ycoords, 60, lineheight);
                gfx.DrawString(bendrpav[i], small, XBrushes.Black, new XRect(45, 155 + ycoords+3.5, 455, lineheight), XStringFormats.TopLeft);
                gfx.DrawString(bendrkain[i].ToString(), small, XBrushes.Black, new XRect(500, 155 + ycoords + 3.5, 60, lineheight), XStringFormats.TopLeft);
            }

                //sum
            buf = "Bendrijos mokesčių suma:";

            ypoint += lineheight;

            gfx.DrawRectangle(black, lblue, 40, ypoint, 150, 18);
            gfx.DrawString(buf, normalBold, pblue, new XRect(45, ypoint+3, 150, 18), XStringFormats.TopLeft);
            gfx.DrawRectangle(black, lblue, 190, ypoint, 60, 18);
            gfx.DrawString(bendrkain.Sum().ToString(), normalBold, XBrushes.Black, new XRect(195, ypoint + 3, 60, 18), XStringFormats.TopLeft);

            
            

            ypoint += 28;

            gfx.DrawLine(black, 40, ypoint, page.Width - 40, ypoint);

            ypoint += 10;

            //KOMUNALINIAI

                //header
            buf = "Komunaliniai patarnavimai (vanduo, šiluma, internetas bei pan.)";
            gfx.DrawRectangle(neutralRect, XBrushes.Beige, 40, ypoint, page.Width - 80, 18);
            gfx.DrawString(buf, normalBoldItalic, XBrushes.Black, new XRect(40, ypoint, page.Width - 80, 18), XStringFormats.Center);

            ypoint += 23;

                //table
            gfx.DrawRectangle(black, XBrushes.LightGray, 170, ypoint, 128, lineheight);
            gfx.DrawString("Išnaudota", small, XBrushes.Black, new XRect(170, ypoint, 129, lineheight), XStringFormats.Center);
            gfx.DrawRectangle(black, XBrushes.LightGray, 298, ypoint, 128, lineheight);
            gfx.DrawString("Kaina/Vnt.", small, XBrushes.Black, new XRect(298, ypoint, 129, lineheight), XStringFormats.Center);
            gfx.DrawRectangle(black, XBrushes.LightGray, 426, ypoint, 129, lineheight);
            gfx.DrawString("Suma", small, XBrushes.Black, new XRect(426, ypoint, 129, lineheight), XStringFormats.Center);

            ypoint += lineheight;
            double rate = 0;
            double komsum = 0;

            for (int i = 0; i < 4; i++) {
                gfx.DrawRectangle(black, XBrushes.LightGray, 40, ypoint, 130, lineheight);
                gfx.DrawRectangle(black, 170, ypoint, 128, lineheight);    
                gfx.DrawRectangle(black, 298, ypoint, 128, lineheight);
                gfx.DrawRectangle(black, 426, ypoint, 129, lineheight);

                if (i == 0) {
                    gfx.DrawString("Elektra (kW/h)", small, XBrushes.Black, new XRect(40, ypoint, 130, lineheight), XStringFormats.Center);
                    rate = getOperatorRate("e");
                    gfx.DrawString(elek.ToString(), small, XBrushes.Black, new XRect(170, ypoint, 129, lineheight), XStringFormats.Center);
                    gfx.DrawString(rate.ToString(), small, XBrushes.Black, new XRect(298, ypoint, 129, lineheight), XStringFormats.Center);
                    gfx.DrawString((elek*rate).ToString(), small, XBrushes.Black, new XRect(426, ypoint, 129, lineheight), XStringFormats.Center);
                    komsum += elek * rate;
                }
                if (i == 1) {
                    gfx.DrawString("Dujos (MW/h)", small, XBrushes.Black, new XRect(40, ypoint, 130, lineheight), XStringFormats.Center);
                    rate = getOperatorRate("d");
                    gfx.DrawString(duj.ToString(), small, XBrushes.Black, new XRect(170, ypoint, 129, lineheight), XStringFormats.Center);
                    gfx.DrawString(rate.ToString(), small, XBrushes.Black, new XRect(298, ypoint, 129, lineheight), XStringFormats.Center);
                    gfx.DrawString((duj*rate).ToString(), small, XBrushes.Black, new XRect(426, ypoint, 129, lineheight), XStringFormats.Center);
                    komsum += duj * rate;
                }
                if (i == 2) {
                    gfx.DrawString("Vanduo (m^3)", small, XBrushes.Black, new XRect(40, ypoint, 130, lineheight), XStringFormats.Center);
                    rate = getOperatorRate("v");
                    gfx.DrawString(vand.ToString(), small, XBrushes.Black, new XRect(170, ypoint, 129, lineheight), XStringFormats.Center);
                    gfx.DrawString(rate.ToString(), small, XBrushes.Black, new XRect(298, ypoint, 129, lineheight), XStringFormats.Center);
                    gfx.DrawString((vand*rate).ToString(), small, XBrushes.Black, new XRect(426, ypoint, 129, lineheight), XStringFormats.Center);
                    komsum += vand * rate;
                }
                if (i == 3) {
                    gfx.DrawString("Internetas (Eur/mėn)", small, XBrushes.Black, new XRect(40, ypoint, 130, lineheight), XStringFormats.Center);
                    rate = getOperatorRate("i");
                    gfx.DrawString("---", small, XBrushes.Black, new XRect(170, ypoint, 129, lineheight), XStringFormats.Center);
                    gfx.DrawString(rate.ToString(), small, XBrushes.Black, new XRect(298, ypoint, 129, lineheight), XStringFormats.Center);
                    gfx.DrawString("---", small, XBrushes.Black, new XRect(426, ypoint, 129, lineheight), XStringFormats.Center);
                    komsum += rate;
                }

                ypoint += lineheight;
            }


            buf = "Komunalinių mokesčių suma:";

            ypoint += lineheight;

            gfx.DrawRectangle(black, lblue, 40, ypoint, 150, 18);
            gfx.DrawString(buf, normalBold, pblue, new XRect(45, ypoint + 3, 150, 18), XStringFormats.TopLeft);
            gfx.DrawRectangle(black, lblue, 190, ypoint, 60, 18);
            gfx.DrawString(komsum.ToString(), normalBold, XBrushes.Black, new XRect(195, ypoint + 3, 60, 18), XStringFormats.TopLeft);
            
            ypoint += 18;

            buf = "Visų mokesčių suma:";
            gfx.DrawRectangle(black, lblue, 40, ypoint, 150, 18);
            gfx.DrawString(buf, normalBold, pblue, new XRect(45, ypoint + 3, 150, 18), XStringFormats.TopLeft);
            gfx.DrawRectangle(black, lblue, 190, ypoint, 60, 18);
            gfx.DrawString((komsum + bendrkain.Sum()).ToString(), normalBold, XBrushes.Black, new XRect(195, ypoint + 3, 60, 18), XStringFormats.TopLeft);

            //GALAS

            gfx.DrawRectangle(black, XBrushes.Beige, 306, 95, 50, 20);
            gfx.DrawRectangle(black,lblue, 356, 95, 50, 20);
            gfx.DrawRectangle(black, lblue, 405, 95, 150, 20);



            double nuom = getNuom();

            gfx.DrawString("Nuoma:", normalBoldItalic, XBrushes.Black, new XRect(306, 95, 50, 20), XStringFormats.Center);
            gfx.DrawString(nuom.ToString(), normalBold, XBrushes.Black, new XRect(356, 95, 50, 20), XStringFormats.Center);
            gfx.DrawString("Nuoma + Mokesčiai:" + (nuom+komsum+bendrkain.Sum()).ToString() , normalBold, XBrushes.Black, new XRect(405, 95, 150, 20), XStringFormats.Center);
            conn.Close();



            document.Save(filename);
            Process.Start(filename);
        
        }
    }
}
