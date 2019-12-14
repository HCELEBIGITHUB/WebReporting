using Newtonsoft.Json;
using Reporting.Entities.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Web.Mvc;

namespace Reporting.MvcWebUI.Controllers
{
    public class SaticiMusteriTutarController : Controller
    {
        // GET: SaticiMusteriTutar
        //SATC_MUST_VIEW_HIDIR

        string[] Aylar = { "OCAK", "SUBAT", "MART", "NiSAN", "MAYIS", "HAZiRAN", "TEMMUZ", "AGUSTOS", "EYLUL", "EKiM", "KASIM", "ARALIK" };
        string[] renkler;

        public string KartOlustur(string markaAdetTutar, int ay)
        {
            //string jsontext = "{\"People\":[{\"FirstName\":\"Hans\",\"LastName\":\"Olo\"},{\"FirstName\":\"Jimmy\",\"LastName\":\"Crackedcorn\"}]}";
            //string jsontext = "[{\"FirstName\":\"Hans\",\"LastName\":\"Olo\"},{\"FirstName\":\"Jimmy\",\"LastName\":\"Crackedcorn\"}]";

            NumberFormatInfo myNumberFormatInfo = new CultureInfo("tr-TR", false).NumberFormat;
            string listUl = "";
            if (!string.IsNullOrEmpty(markaAdetTutar))
            {
                string jsontext = "[" + markaAdetTutar + "]";
                jsontext = jsontext.Replace(",]", "]");
                dynamic array = JsonConvert.DeserializeObject(jsontext);

                listUl += "<table     cellpadding='4' style='vertical-align:middle;width:100%;' >";

                //listUl += "<tr  class='row'>";
                //listUl += "<td  class='cell' colspan='0' style='padding-left:3px; padding-right:3px; font-size:8px  !important; background-color:blue; color: white; border: solid black 0px; text-align:center; -moz-border-radius: 0px; -webkit-border-radius: 0px; border-radius:0px; text-indent:4px; text-shadow:1px 1px 2px black;' > MARKA </td>";
                //listUl += "<td  class='cell' colspan='0' style='padding-left:3px; padding-right:3px; font-size:8px  !important; background-color:blue; color: white; border: solid black 0px; text-align:center; -moz-border-radius: 0px; -webkit-border-radius: 0px; border-radius:0px; text-indent:4px; text-shadow:1px 1px 2px black;' > ADET </td>";
                //listUl += "<td  class='cell' colspan='0' style='padding-left:3px; padding-right:3px; font-size:8px  !important; background-color:blue; color: white; border: solid black 0px; text-align:center; -moz-border-radius: 0px; -webkit-border-radius: 0px; border-radius:0px; text-indent:4px; text-shadow:1px 1px 2px black;' > TUTAR </td>";

                //listUl += "</tr>";


                foreach (var item in array)
                {

                    if (!string.IsNullOrEmpty(item.ToString()))
                    {



                        listUl += "<tr  class='row'>";
                        //listUl += "<td  class='cell' style='width:40%;-moz-border-radius:5px; -webkit-border-radius: 5px; border-radius:5px;color:green;text-decoration:none;font-style:italic;font-weight:bold;font-size:18px;border:solid 0px black; ' >" + item.marka+ "</td>";


                        listUl += "<td  class='cell'   style='width:20%;-moz-border-radius:5px; -webkit-border-radius: 5px; border-radius:5px;color:#BA4A00 ;text-decoration:none;font-style:italic;font-weight:bold;font-size:20px;border:solid 0px black;text-align:right;'>" + Convert.ToInt32(item.toplam).ToString("#,##0.###") + "</td>";
                        listUl += "<td  class='cell' style='width:40%;-moz-border-radius:5px; -webkit-border-radius: 5px; border-radius:5px;color:black;text-decoration:none;font-style:italic;font-weight:bold;font-size:20px;border:solid 0px black;text-align:right;'>" + Convert.ToDouble(item.tutar).ToString("N", myNumberFormatInfo) + "</td>";
                        listUl += "</tr>";

                    }
                }
                listUl += "</table>";
            }

            return listUl;
        }

        public ActionResult SaticiMusteriTutar()
        {
            Reporting.BLL.Repository _repo = new Reporting.BLL.Repository();
            ViewData["SatisAdetMarka"] = _repo.RaporTabloViewDinamikSorgulaSaticiMusteriTemsil("[workcube_boer_1].[dbo].[SATC_MUST_VIEW_HIDIR]");

            StringBuilder buildHtml = new StringBuilder();
            // buildHtml.Append("<table><tr  class='row'><td  class='cell'>deneme tablo</td></ tr > </table >");
            //buildHtml.AppendLine(body);
            int secilenYil = 2019;
            string kolonRenk = "#0e367c";
            string renk1 = "FF8A80";
            string renk2 = "F4FF81";
            string renk3 = "f44242";
            string renk4 = "#554562";
            string gecerliRenk = renk1;

            //string renk1 = "E9AE63";
            //string renk2 = "BD936C";
            //string gecerliRenk = renk1;


            //string kolonRenk = "#0e367c";
            //string renk1 = "#4874bf";
            //string renk2 = "#fba257";
            //string renk3 = "#f44242";
            //string renk4 = "#ab3434";
            //string gecerliRenk = renk1;


            //kolonRenk = "#fadbe0";
            //renk1 = "#eaadbd";
            //renk2 = "#b88a9f";
            //renk3 = "#876880";
            //renk4 = "#554562";
            //gecerliRenk = renk1;


            //kolonRenk = "#ff9416";
            //renk1 = "#eaadbd";
            //renk2 = "#b88a9f";
            //renk3 = "#876880";
            //renk4 = "#554562";
            //gecerliRenk = renk1;


            kolonRenk = "#003366";
            renk1 = "#2a6ebc";
            renk2 = "#5995da";
            renk3 = "#7ad9ff";
            renk4 = "#7df3ff";
            gecerliRenk = renk1;


            //kolonRenk = "orangered";
            //renk1 = "#FFCA1F";
            //renk2 = "#FF9416";
            //renk3 = "#FF7B65";
            //renk4 = "#554562";
            //gecerliRenk = renk1;


            //kolonRenk = "#0E6251";
            //renk1 = "#1B2631";
            //renk2 = "#626567";
            //renk3 = "#7ad9ff";
            //renk4 = "#7df3ff";
            //gecerliRenk = renk1;





            #region



            buildHtml.Append("<div id='HtmlResult' class='table-responsive-sm' style='padding-top:5%; height:50%; width: 99%;'>");


            buildHtml.Append("<table id='tableSatis' class='table' style='border:none !important;height:50%;width:99%; font-size:18px; border-top-left-radius: 15px; border-top-right-radius: 15px; font-weight:bold; background-color:" + kolonRenk + ";'>");
            buildHtml.Append("<tr >");
            buildHtml.Append("<td  class='cell' ></td>");
            buildHtml.Append("<td  class='cell'></td>");
            buildHtml.Append("<td  class='cell'></td>");
            buildHtml.Append("<td    colspan='12' align='center' style='color:white;text-shadow: 1px 1px 2px black;' >");
            buildHtml.Append("<b>SATICI-MÜSTERİ  RAPORU </b></td>");
            buildHtml.Append("</tr>");
            buildHtml.Append("<tr   class='row' style='border-bottom:none !important;border-top:none !important;'  > ");
            buildHtml.Append("<td  class='cell' ></td>");

            buildHtml.Append("<td  class='cell'></td>");
            buildHtml.Append("<td  class='cell'></td>");
            for (int i = 0; i < 12; i++)
            {
                buildHtml.Append("<td  class='cell' colspan='1'   style='background-color:" + kolonRenk + " !important;color: white; border: solid white 0px; text-align:center; -moz-border-radius: 0px; -webkit-border-radius: 0px; border-radius: 0px; border-top-left-radius: 15px; border-top-right-radius: 15px; text-indent:4px; text-shadow: 1px 1px 2px black; '>" + Aylar[i] + "</td>");

            }
            buildHtml.Append("<td  class='cell' colspan='1'   style='background-color:" + kolonRenk + " !important; color: white; border: solid white 0px; text-align:center; -moz-border-radius: 0px; -webkit-border-radius: 0px; border-radius: 0px; border-top-left-radius: 15px; border-top-right-radius: 15px; text-indent:4px; text-shadow: 1px 1px 2px black; '> TOPLAM " + secilenYil + "</td>");




            buildHtml.Append("</tr>");
            buildHtml.Append(" <tr  class='row' >");
            buildHtml.Append(" <td  class='cell' colspan = '1' style = ' font-size:12px; background-color:" + kolonRenk + "  !important; color: white; border: solid white 0px;  ; text-shadow: 1px 1px 2px black; text-align:center;vertical-align:middle ; border-top-left-radius: 15px;  ' > SATICI KODU </td>");


            buildHtml.Append("  <td  class='cell' colspan = '1' style = ' font-size:12px; background-color:" + kolonRenk + "  !important; color: white; border: solid white 0px ;  text-shadow: 1px 1px 2px black; border-right:solid 0px white; text-align:center;vertical-align:middle ; ' > SATICI ADI </td>");
            buildHtml.Append("  <td  class='cell' colspan = '1' style = ' font-size:12px; background-color:" + kolonRenk + "  !important; color: white; border: solid white 0px ;  text-shadow: 1px 1px 2px black; border-right:solid 0px white; text-align:center;vertical-align:middle ; ' > FIRMA UNVANI </td>");

            for (int i = 0; i < 13; i++)
            {
                buildHtml.Append("<td  class='cell' colspan='1' style='padding-left:3px; padding-right:3px; font-size:8px  !important; background-color:" + kolonRenk + "  !important; color: white; border: solid black 0px   ; -moz-border-radius: 0px; -webkit-border-radius: 0px; border-radius:0px; text-indent:4px; text-shadow:1px 1px 2px black;vertical-align:middle;text-align:center; border-right:solid white 0px; '>ADET-TUTAR</td>");

            }



            #endregion


            //buildHtml.Append("</tr>");














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
            IEnumerable<SATC_MUST_VIEW_HIDIR> satisAdetMarka = ViewData["SatisAdetMarka"] as IEnumerable<SATC_MUST_VIEW_HIDIR>;



            string satisAdetTutarHtml = "";
            string kalip = "";

            foreach (var item in satisAdetMarka)
            {

                simdiki_saticiKodu = item.SATICIKODU.ToString().Trim();
                p++;
                gecerliRenk = renk1;
                if (p % 2 == 0)
                {

                    gecerliRenk = renk2;

                }
                //  genel toplamlar sırası 1
                if (item.SIRA > 0)
                {
                    gecerliRenk = kolonRenk;
                }

                mergeSatirAdet = 0;
                ustCizgi = "";
                kalip = "";

                if ((item.SATICIKODU.ToString().Trim() != onceki_saticiKodu.ToString().Trim()) || onceki_saticiKodu.ToString().Trim() == "-1")
                {
                    buildHtml.Append("<tr style='height:6px;' ></tr>");

                }
                kalip += "<tr  class='row' style='font-size:16px;font-weight:bold;background-color:" + gecerliRenk + "  !important;border-right:solid 0px white;border-bottom:solid 0px gray;'>";

                if ((item.SATICIKODU.ToString().Trim() != onceki_saticiKodu.ToString().Trim()) || onceki_saticiKodu.ToString().Trim() == "-1")
                {
                    mergeSatirAdet = item.MERGE_ADET;
                    kalip += "<td rowspan='" + mergeSatirAdet + "  class='cell' style='border-top-left-radius: 15px;border-bottom-left-radius: 15px; text-align:center;vertical-align:middle;'> #satici_kodu# </td>";
                    kalip += "<td rowspan='" + mergeSatirAdet + "  class='cell' style='font-size:16px;font-weight:bold;background-color:" + gecerliRenk + " !important;border-right:solid 0px white; text-align:center;vertical-align:middle ;'> #satici_adi#</td>";



                }
                kalip += "<td    class='cell' style='font-size:16px;font-weight:bold;background-color:" + gecerliRenk + " !important;border-right:solid 4px " + kolonRenk + "; text-align:center;vertical-align:middle ;'> #firma_unvan#</td>";





                for (int i = 1; i <= 12; i++)
                {



                    kalip += "<td  title='" + item.SATICIADI + "  " + Aylar[i - 1].ToString() + "' class='cell' align='top' style='background-color:" + gecerliRenk + " !important;border-right:solid 0px white;width:10%;border-bottom:solid 0px gray;'>#" + item.SATICIKODU + "#" + item.FirmaUNVAN + "#siraliGosterilecekBilgi_" + i.ToString("00") + "#</td>";

                }
                /// yillik toplam 
                kalip += "<td  title='" + item.SATICIADI + " Yıllık  Toplam " + secilenYil + "' class='cell' align='top' style='background-color:" + gecerliRenk + " !important;border-right:solid 0px white;width:10%;border-bottom:solid 0px gray;border-left:solid 2px " + kolonRenk + " !important;'>#" + item.SATICIKODU + "#" + item.FirmaUNVAN + "#siraliGosterilecekBilgi_13" + "#</td>";

                kalip += "</tr>";
                buildHtml.Append(kalip);







                buildHtml.Replace("#renk# !important", gecerliRenk);




                buildHtml.Replace("#satici_kodu#", item.SATICIKODU.ToString().Replace("-1", ""));
                buildHtml.Replace("#satici_adi#", item.SATICIADI.Replace("GENEL TOPLAM", ""));
                buildHtml.Replace("#firma_unvan#", item.FirmaUNVAN);



                satisAdetTutarHtml = this.KartOlustur(item.AY_01, 1);
                aranan = "#" + item.SATICIKODU + "#" + item.FirmaUNVAN + "#siraliGosterilecekBilgi_01" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);


                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }


                satisAdetTutarHtml = this.KartOlustur(item.AY_02, 1);
                aranan = "#" + item.SATICIKODU + "#" + item.FirmaUNVAN + "#siraliGosterilecekBilgi_02" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {

                    buildHtml.Replace(aranan, "");

                }


                satisAdetTutarHtml = this.KartOlustur(item.AY_03, 1);
                aranan = "#" + item.SATICIKODU + "#" + item.FirmaUNVAN + "#siraliGosterilecekBilgi_03" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }


                satisAdetTutarHtml = this.KartOlustur(item.AY_04, 1);
                aranan = "#" + item.SATICIKODU + "#" + item.FirmaUNVAN + "#siraliGosterilecekBilgi_04" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }


                satisAdetTutarHtml = this.KartOlustur(item.AY_05, 1);
                aranan = "#" + item.SATICIKODU + "#" + item.FirmaUNVAN + "#siraliGosterilecekBilgi_05" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }


                satisAdetTutarHtml = this.KartOlustur(item.AY_06, 1);
                aranan = "#" + item.SATICIKODU + "#" + item.FirmaUNVAN + "#siraliGosterilecekBilgi_06" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }


                satisAdetTutarHtml = this.KartOlustur(item.AY_07, 1);
                aranan = "#" + item.SATICIKODU + "#" + item.FirmaUNVAN + "#siraliGosterilecekBilgi_07" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }

                satisAdetTutarHtml = this.KartOlustur(item.AY_08, 1);
                aranan = "#" + item.SATICIKODU + "#" + item.FirmaUNVAN + "#siraliGosterilecekBilgi_08" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }

                satisAdetTutarHtml = this.KartOlustur(item.AY_09, 1);
                aranan = "#" + item.SATICIKODU + "#" + item.FirmaUNVAN + "#siraliGosterilecekBilgi_09" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }


                satisAdetTutarHtml = this.KartOlustur(item.AY_10, 1);
                aranan = "#" + item.SATICIKODU + "#" + item.FirmaUNVAN + "#siraliGosterilecekBilgi_10" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }

                satisAdetTutarHtml = this.KartOlustur(item.AY_11, 1);
                aranan = "#" + item.SATICIKODU + "#" + item.FirmaUNVAN + "#siraliGosterilecekBilgi_11" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }

                satisAdetTutarHtml = this.KartOlustur(item.AY_12, 1);
                aranan = "#" + item.SATICIKODU + "#" + item.FirmaUNVAN + "#siraliGosterilecekBilgi_12" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }

                satisAdetTutarHtml = this.KartOlustur(item.YIL_TOPLAM.ToString(), 1);
                aranan = "#" + item.SATICIKODU + "#" + item.FirmaUNVAN + "#siraliGosterilecekBilgi_13" + "#";
                if (!string.IsNullOrEmpty(satisAdetTutarHtml))
                {

                    buildHtml.Replace(aranan, satisAdetTutarHtml);
                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }


                onceki_saticiKodu = item.SATICIKODU.ToString().Trim();
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