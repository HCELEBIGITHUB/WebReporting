using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Web.Mvc;

namespace Reporting.MvcWebUI.Controllers
{
    public class SaticiMarkaController : Controller
    {
        // GET: SatisAdet2



        string[] Aylar = { "OCAK", "SUBAT", "MART", "NiSAN", "MAYIS", "HAZiRAN", "TEMMUZ", "AGUSTOS", "EYLUL", "EKiM", "KASIM", "ARALIK" };
        public string KartOlustur(string markaAdetTutar, int ay)
        {
            //string jsontext = "{\"People\":[{\"FirstName\":\"Hans\",\"LastName\":\"Olo\"},{\"FirstName\":\"Jimmy\",\"LastName\":\"Crackedcorn\"}]}";
            //string jsontext = "[{\"FirstName\":\"Hans\",\"LastName\":\"Olo\"},{\"FirstName\":\"Jimmy\",\"LastName\":\"Crackedcorn\"}]";

            NumberFormatInfo myNumberFormatInfo = new CultureInfo("tr-TR", false).NumberFormat;
            string listUl = "";
            if (!string.IsNullOrEmpty(markaAdetTutar))
            {
                string jsontext = "[{" + markaAdetTutar + "]";
                jsontext = jsontext.Replace(",]", "]");
                dynamic array = JsonConvert.DeserializeObject(jsontext);

                listUl += "<table align='top'    cellpadding='4' style='vertical-align:top;width:100%;' >";

                //listUl += "<tr  class='row'>";
                //listUl += "<td  class='cell' colspan='0' style='padding-left:3px; padding-right:3px; font-size:8px  !important; background-color:blue; color: white; border: solid black 0px; text-align:center; -moz-border-radius: 0px; -webkit-border-radius: 0px; border-radius:0px; text-indent:4px; text-shadow:1px 1px 2px black;' > MARKA </td>";
                //listUl += "<td  class='cell' colspan='0' style='padding-left:3px; padding-right:3px; font-size:8px  !important; background-color:blue; color: white; border: solid black 0px; text-align:center; -moz-border-radius: 0px; -webkit-border-radius: 0px; border-radius:0px; text-indent:4px; text-shadow:1px 1px 2px black;' > ADET </td>";
                //listUl += "<td  class='cell' colspan='0' style='padding-left:3px; padding-right:3px; font-size:8px  !important; background-color:blue; color: white; border: solid black 0px; text-align:center; -moz-border-radius: 0px; -webkit-border-radius: 0px; border-radius:0px; text-indent:4px; text-shadow:1px 1px 2px black;' > TUTAR </td>";

                //listUl += "</tr>";


                foreach (var item in array)
                {

                    if (!string.IsNullOrEmpty(item.ToString()))
                    {



                        listUl += "<tr  class='row' style='vertical-align:top;'>";
                        listUl += "<td  class='cell' style='width:40%;-moz-border-radius:5px; -webkit-border-radius: 5px; border-radius:5px;color:#6C3483;text-decoration:none;font-style:italic;font-weight:bold;font-size:18px;border:solid 0px black; ' >" + item.marka + "</td>";


                        listUl += "<td  class='cell'   style='width:20%;-moz-border-radius:5px; -webkit-border-radius: 5px; border-radius:5px;color:brown;text-decoration:none;font-style:italic;font-weight:bold;font-size:18px;border:solid 0px black;text-align:right;'>" + Convert.ToInt32(item.toplam).ToString("#,##0.###") + "</td>";
                        listUl += "<td  class='cell' style='width:40%;-moz-border-radius:5px; -webkit-border-radius: 5px; border-radius:5px;color:black;text-decoration:none;font-style:italic;font-weight:bold;font-size:18px;border:solid 0px black;text-align:right;'>" + Convert.ToDouble(item.tutar).ToString("N", myNumberFormatInfo) + "</td>";
                        listUl += "</tr>";

                    }
                }
                listUl += "</table>";
            }

            return listUl;
        }

        public ActionResult SaticiMarka()
        {
            Reporting.BLL.Repository _repo = new Reporting.BLL.Repository();
            ViewData["SatisAdetMarka"] = _repo.RaporTabloViewDinamikSorgulaSatis("[workcube_boer_1].[dbo].[SATICI_ADET_MARKA_VIEW_HIDIR2]");

            StringBuilder buildHtml = new StringBuilder();
            // buildHtml.Append("<table><tr  class='row'><td  class='cell'>deneme tablo</td></ tr > </table >");
            //buildHtml.AppendLine(body);

            //string renk1 = "E9AE63";
            //string renk2 = "BD936C";




            string kolonRenk = "#003366";
            string renk1 = "#2a6ebc";
            string renk2 = "#5995da";
            string renk3 = "#7ad9ff";
            string renk4 = "#7df3ff";
            string gecerliRenk = renk1;


            #region




            buildHtml.Append("<div id='HtmlResult' class='table-responsive-sm' style='padding-top:5%; height:50%; width: 99%;'>");


            buildHtml.Append("<table id='tableSatis' class='table' style='border:none !important;height:50%;width:99%; font-size:18px; border-top-left-radius: 15px; border-top-right-radius: 15px; font-weight:bold; background-color:" + kolonRenk + ";'>");
            buildHtml.Append("<tr >");
            buildHtml.Append("<td    colspan='13' align='center' style='color:white;'");
            buildHtml.Append("<b>SATIŞ  ADET-MARKA RAPORU </b></td>");
            buildHtml.Append("</tr>");
            buildHtml.Append("<tr   class='row' style='border-bottom:none !important;border-top:none !important;'  > ");
            buildHtml.Append("<td  class='cell'></td>");

            buildHtml.Append("<td  class='cell'></td>");

            for (int i = 0; i < 12; i++)
            {
                buildHtml.Append("<td  class='cell' colspan='1'   style='background-color:" + kolonRenk + "; color: white; border: solid white 0px; text-align:center; -moz-border-radius: 0px; -webkit-border-radius: 0px; border-radius: 0px; border-top-left-radius: 15px; border-top-right-radius: 15px; text-indent:4px; text-shadow: 1px 1px 2px black; '>" + Aylar[i] + "</td>");

            }




            buildHtml.Append("</tr>");
            buildHtml.Append(" <tr  class='row' >");
            buildHtml.Append(" <td  class='cell' colspan = '1' style = ' font-size:12px; background-color:" + kolonRenk + "; color: white; border: solid white 0px;  ; text-shadow: 1px 1px 2px black; text-align:center;vertical-align:middle ; border-top-left-radius: 15px;  ' > SATICI KODU </td>");


            buildHtml.Append("  <td  class='cell' colspan = '1' style = ' font-size:12px; background-color:" + kolonRenk + "; color: white; border: solid white 0px ;  text-shadow: 1px 1px 2px black; border-right:solid 0px white; text-align:center;vertical-align:middle ; ' > SATICI ADI </td>");

            for (int i = 0; i < 12; i++)
            {
                buildHtml.Append("<td  class='cell' colspan='1' style='background-color:" + kolonRenk + ";padding-left:3px; padding-right:3px; font-size:8px  !important; color: white; border: solid black 0px   ; -moz-border-radius: 0px; -webkit-border-radius: 0px; border-radius:0px; text-indent:4px; text-shadow:1px 1px 2px black;vertical-align:middle;text-align:center; border-right:solid white 0px; '>MARKA-ADET-TUTAR</td>");

            }



            #endregion


            //buildHtml.Append("</tr>");






            //string renk1 = "FF8A80";
            //string renk2 = "F4FF81";
            //string gecerliRenk = renk1;






            int p = 0;

            string onceki_saticiKodu = "-1";
            string simdiki_saticiKodu = "-1";
            int kolonAdet = 38;
            int mergeSatirAdet = 0;
            int markaAdet = 10;
            string aranan = "";
            string ustCizgi = "";
            bool mergeYapildi = false; // ayni satici icin satir birlestirme islemi
            NumberFormatInfo myNumberFormatInfo = new CultureInfo("tr-TR", false).NumberFormat;
            IEnumerable<SATICI_ADET_MARKA_VIEW_HIDIR2> satisAdetMarka = ViewData["SatisAdetMarka"] as IEnumerable<SATICI_ADET_MARKA_VIEW_HIDIR2>;





            string satisAdetTutarHtml = "";
            string kalip = "";
            foreach (var item in satisAdetMarka)
            {
                p++;
                gecerliRenk = renk1;
                if (p % 2 == 0)
                {

                    gecerliRenk = renk2;

                }

                simdiki_saticiKodu = item.SATICIKODU.ToString();

                if ((item.SATICIKODU.ToString().Trim() != onceki_saticiKodu.ToString().Trim()) || onceki_saticiKodu.ToString().Trim() == "-1")
                {
                    buildHtml.Append("<tr style='height:6px;' ></tr>");

                }

                kalip = "";
                kalip = "<tr  class='row' style='font-size:16px;font-weight:bold;background-color:" + gecerliRenk + ";border-right:solid 0px white;border-bottom:solid 0px gray;'>";
                kalip += "<td  class='cell' style='" + gecerliRenk + ";border-top-left-radius: 15px;border-bottom-left-radius: 15px; text-align:center;vertical-align:middle;'> #satici_kodu </td>";
                kalip += "<td  class='cell' style='" + gecerliRenk + ";font-size:16px;font-weight:bold;background-color:#renk;border-right:solid 4px white; text-align:center;vertical-align:middle ;'> #satici_adi</td>";
                for (int i = 1; i <= 12; i++)
                {



                    kalip += "<td align='top'  title='" + item.SATICIADI + "  " + Aylar[i - 1].ToString() + "' class='cell' align='top' style='" + gecerliRenk + ";vertical-align:top;border-right:solid 0px white;width:10%;border-bottom:solid 0px gray;'>#" + item.SATICIKODU + "#marka_" + i.ToString("00") + "#</td>";
                    // kalip += "<td  class='cell'>#" + item.SATICIKODU +"#adet_" + i.ToString("00") + "#</td>";

                    // kalip += "<td  class='cell'>#" + item.SATICIKODU +"#tutar_" + i.ToString("00") + "#</td>";

                }
                kalip += "</tr>";
                buildHtml.Append(kalip);







                //buildHtml.Replace("#renk", "#" + gecerliRenk);
                buildHtml.Replace("#satici_kodu", item.SATICIKODU.ToString());
                buildHtml.Replace("#satici_adi", item.SATICIADI);



                satisAdetTutarHtml = this.KartOlustur(item.AY_01, 1);
                aranan = "#" + item.SATICIKODU + "#marka_01" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);


                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }


                satisAdetTutarHtml = this.KartOlustur(item.AY_02, 1);
                aranan = "#" + item.SATICIKODU + "#marka_02" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {

                    buildHtml.Replace(aranan, "");

                }


                satisAdetTutarHtml = this.KartOlustur(item.AY_03, 1);
                aranan = "#" + item.SATICIKODU + "#marka_03" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }


                satisAdetTutarHtml = this.KartOlustur(item.AY_04, 1);
                aranan = "#" + item.SATICIKODU + "#marka_04" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }


                satisAdetTutarHtml = this.KartOlustur(item.AY_05, 1);
                aranan = "#" + item.SATICIKODU + "#marka_05" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }


                satisAdetTutarHtml = this.KartOlustur(item.AY_06, 1);
                aranan = "#" + item.SATICIKODU + "#marka_06" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }


                satisAdetTutarHtml = this.KartOlustur(item.AY_07, 1);
                aranan = "#" + item.SATICIKODU + "#marka_07" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }

                satisAdetTutarHtml = this.KartOlustur(item.AY_08, 1);
                aranan = "#" + item.SATICIKODU + "#marka_08" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }

                satisAdetTutarHtml = this.KartOlustur(item.AY_09, 1);
                aranan = "#" + item.SATICIKODU + "#marka_09" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }


                satisAdetTutarHtml = this.KartOlustur(item.AY_10, 1);
                aranan = "#" + item.SATICIKODU + "#marka_10" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }

                satisAdetTutarHtml = this.KartOlustur(item.AY_11, 1);
                aranan = "#" + item.SATICIKODU + "#marka_11" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }

                satisAdetTutarHtml = this.KartOlustur(item.AY_12, 1);
                aranan = "#" + item.SATICIKODU + "#marka_12" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }

                onceki_saticiKodu = item.SATICIKODU.ToString();


            }


            buildHtml.Append("</table>");
            buildHtml.Append("</div>");





            //ViewData["tumHtml"] = buildHtml;
            ViewData["tumHtml"] = buildHtml;

            return View(buildHtml);
            //return View(tum_html);





        }
    }
}