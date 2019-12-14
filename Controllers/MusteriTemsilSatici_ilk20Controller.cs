using Newtonsoft.Json;
using Reporting.Entities.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;

namespace Reporting.MvcWebUI.Controllers
{
    public class MusteriTemsilSatici_ilk20Controller : Controller
    {
        // GET: MusteriTemsilSatici_ilk20

        string[] Aylar = { "OCAK", "SUBAT", "MART", "NiSAN", "MAYIS", "HAZiRAN", "TEMMUZ", "AGUSTOS", "EYLUL", "EKiM", "KASIM", "ARALIK" };
        // string kolonRenk = "#003366";
        string kolonRenk = "red";
        StringBuilder StyleIcerik = new StringBuilder();



        int saticiAdet = 0;
        int secilenYil = 2019;
        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }
        public string KalipOlustur(string markaAdetTutar, Microsoft.Office.Interop.Excel.Worksheet excelSheet, int excelSatirNo, int excelKolonNo)
        {
            //string jsontext = "{\"People\":[{\"FirstName\":\"Hans\",\"LastName\":\"Olo\"},{\"FirstName\":\"Jimmy\",\"LastName\":\"Crackedcorn\"}]}";
            //string jsontext = "[{\"FirstName\":\"Hans\",\"LastName\":\"Olo\"},{\"FirstName\":\"Jimmy\",\"LastName\":\"Crackedcorn\"}]";

            NumberFormatInfo myNumberFormatInfo = new CultureInfo("tr-TR", false).NumberFormat;
            string listUl = "";
            int kolonNo = excelKolonNo;
            int satirNo = excelSatirNo;
            int n = 0;
            if (!string.IsNullOrEmpty(markaAdetTutar))
            {
                string jsontext = "[{" + markaAdetTutar + "]";
                jsontext = jsontext.Replace(",]", "]");
                jsontext = jsontext.Replace("[{{", "[{");

                dynamic array = JsonConvert.DeserializeObject(jsontext);




                foreach (var item in array)
                {

                    if (!string.IsNullOrEmpty(item.ToString()))
                    {


                        n++;

                        //listUl += "<td  class='odd' style='width:5%;-moz-border-radius:0px; -webkit-border-radius: 0px; border-radius:0px;color:brown;text-decoration:none;font-style:normal;font-weight:bold;font-size:10px;border-right:solid 0px gray; border-left:solid 0px gray ;text-align:right;text-indent:10px;'>#" + item.SATICIKODU + "#toplam#</td>";
                        //listUl += "<td  class='odd' style='width:5%;-moz-border-radius:0px; -webkit-border-radius: 0px; border-radius:0px;color:black;text-decoration:none;font-style:normal;font-weight:bold;font-size:10px;border-right:solid 4px "+ kolonRenk + "; border-left:solid 0px gray ;text-align:right;text-indent:10px;'>#" + item.SATICIKODU + "#tutar#</td>";


                        listUl += "<td  class='odd' style='width:5px;'>#" + item.SATICIKODU + "#toplam#</td>";
                        listUl += "<td  class='odd' style='width:5px;'>#" + item.SATICIKODU + "#tutar#</td>";

                        //   ////* excelSheet.Cells[satirNo +1 , kolonNo+1] = "#" + item.SATICIKODU + "#toplam#";
                        //   ////* excelSheet.Cells[satirNo +1, kolonNo+2] = "#" + item.SATICIKODU + "#tutar#";
                        kolonNo += 2; ;



                    }
                }

            }

            //listUl += "<td  class='odd' style='width:5%;-moz-border-radius:0px; -webkit-border-radius: 0px; border-radius:0px;color:brown;text-decoration:none;font-style:normal;font-weight:bold;font-size:10px;border-right:solid 0px gray; border-left:solid 4px "+ kolonRenk + "; text-align:right;text-indent:10px;'>#YIL_TOPLAM#</td>";
            //listUl += "<td  class='odd' style='width:5%;-moz-border-radius:0px; -webkit-border-radius: 0px; border-radius:0px;color:black;text-decoration:none;font-style:normal;font-weight:bold;font-size:10px;border-right:solid 4px " + kolonRenk + "; border-left:solid 0px gray ;text-align:right;text-indent:10px;'>#YIL_TUTAR#</td>";


            listUl += "<td  class='odd' style='width:5px;'>#YIL_TOPLAM#</td>";
            listUl += "<td  class='odd' style='width:5px;'>#YIL_TUTAR#</td>";

            //   ////* excelSheet.Cells[satirNo + 1, kolonNo + 1] = "#YIL_TOPLAM#";
            //   ////* excelSheet.Cells[satirNo + 1, kolonNo + 2] = "#YIL_TUTAR#";

            saticiAdet = n;
            return listUl;
        }
        public string KalipOlustur2(string markaAdetTutar, Microsoft.Office.Interop.Excel.Worksheet excelSheet, int excelSatirNo, int excelKolonNo)
        {
            //string jsontext = "{\"People\":[{\"FirstName\":\"Hans\",\"LastName\":\"Olo\"},{\"FirstName\":\"Jimmy\",\"LastName\":\"Crackedcorn\"}]}";
            //string jsontext = "[{\"FirstName\":\"Hans\",\"LastName\":\"Olo\"},{\"FirstName\":\"Jimmy\",\"LastName\":\"Crackedcorn\"}]";

            NumberFormatInfo myNumberFormatInfo = new CultureInfo("tr-TR", false).NumberFormat;
            string listUl = "";
            int kolonNo = excelKolonNo;
            int satirNo = excelSatirNo;
            if (!string.IsNullOrEmpty(markaAdetTutar))
            {
                string jsontext = "[{" + markaAdetTutar + "]";
                jsontext = jsontext.Replace(",]", "]");
                jsontext = jsontext.Replace("[{{", "[{");

                dynamic array = JsonConvert.DeserializeObject(jsontext);




                foreach (var item in array)
                {

                    if (!string.IsNullOrEmpty(item.ToString()))
                    {


                        kolonNo += 2;

                        //listUl += "<th  class='odd' colspan='2' style='width:80%;-moz-border-radius:5px; -webkit-border-radius: 15px; border-radius:15px;color:white;text-decoration:none;font-weight:bold;font-size:10px;border-top:solid 0px gray;border-left:solid 0px gray;border-right:solid 0px gray;text-align:center; text-shadow: 1px 1px 2px black;background-color:"+ kolonRenk+";' >" + item.SATICIADI + "</th>";
                        listUl += "<th  class='odd' colspan='2' style='width:5px;font-size:10px !important;' >" + item.SATICIADI + "</th>";
                        ////* excelSheet.Cells[satirNo, kolonNo] = item.SATICIADI;
                        ////* excelSheet.Cells[satirNo, kolonNo].Name = "name" + item.SATICIKODU;
                        ////* excelSheet.Cells[satirNo, kolonNo].Interior.Color = System.Drawing.ColorTranslator.FromHtml(kolonRenk);





                        ////* excelSheet.Range[   ////* excelSheet.Cells[satirNo, kolonNo],    ////* excelSheet.Cells[satirNo, kolonNo + 1]].Merge();
                        ////* excelSheet.Range[   ////* excelSheet.Cells[satirNo, kolonNo],    ////* excelSheet.Cells[satirNo, kolonNo + 1]].WrapText = true;
                        ////* excelSheet.Range[   ////* excelSheet.Cells[satirNo, kolonNo],    ////* excelSheet.Cells[satirNo, kolonNo + 1]].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        ////* excelSheet.Range[   ////* excelSheet.Cells[satirNo, kolonNo],    ////* excelSheet.Cells[satirNo, kolonNo + 1]].VerticalAlignment = XlHAlign.xlHAlignCenter;

                        // listUl += "<td  class='odd'   style='width:10%;-moz-border-radius:5px; -webkit-border-radius: 5px; border-radius:5px;color:brown;text-decoration:none;font-style:normal;font-weight:bold;font-size:18px;border:solid 0px black;text-align:right;'>" + Convert.ToInt32(item.toplam).ToString("#,##0.###") + "</td>";
                        //  listUl += "<td  class='odd' style='width:10%;-moz-border-radius:5px; -webkit-border-radius: 5px; border-radius:5px;color:black;text-decoration:none;font-style:normal;font-weight:bold;font-size:18px;border:solid 0px black;text-align:right;'>" + Convert.ToDouble(item.tutar).ToString("N", myNumberFormatInfo) + " $</td>";


                    }
                }

            }


            //listUl += "<td  class='odd' colspan='2' style='width:80%;-moz-border-radius:5px; -webkit-border-radius: 0px; border-radius:0px;color:white;text-decoration:none;font-weight:bold;font-size:10px;border-right:solid 0px gray;border-left:solid 0px gray;text-align:center; text-shadow: 1px 1px 2px black;background-color:" + kolonRenk + ";'>" + " TOPLAM("+ secilenYil.ToString() + ")</td>";
            listUl += "<th  class='odd' colspan='2' style='width:5px;'>" + " TOPLAM(" + secilenYil.ToString() + ")</th>";
            ////* excelSheet.Cells[satirNo, kolonNo+2] = "TOPLAM(" + secilenYil.ToString() + ")";
            ////* excelSheet.Cells[satirNo, kolonNo + 2].Interior.Color = System.Drawing.ColorTranslator.FromHtml(kolonRenk);
            ////* excelSheet.Cells[satirNo, kolonNo + 2].Font.Bold = true;
            ////* excelSheet.Cells[satirNo, kolonNo + 2].HorizontalAlignment = XlHAlign.xlHAlignCenter;
            ////* excelSheet.Cells[satirNo, kolonNo + 2].VerticalAlignment =   ////*xlHAlign.xlHAlignCenter;



            ////* excelSheet.Cells[satirNo, kolonNo + 2].Name = "nameYIL";
            ////* excelSheet.Range[   ////* excelSheet.Cells[satirNo, kolonNo + 2],    ////* excelSheet.Cells[satirNo, kolonNo + 3]].Merge();

            return listUl;
        }
        public StringBuilder KalipTemizle(string saticilar, StringBuilder htmlContent, Microsoft.Office.Interop.Excel.Worksheet excelSheet)
        {
            //string jsontext = "{\"People\":[{\"FirstName\":\"Hans\",\"LastName\":\"Olo\"},{\"FirstName\":\"Jimmy\",\"LastName\":\"Crackedcorn\"}]}";
            //string jsontext = "[{\"FirstName\":\"Hans\",\"LastName\":\"Olo\"},{\"FirstName\":\"Jimmy\",\"LastName\":\"Crackedcorn\"}]";

            NumberFormatInfo myNumberFormatInfo = new CultureInfo("tr-TR", false).NumberFormat;

            if (!string.IsNullOrEmpty(saticilar))
            {
                string jsontext = "[{" + saticilar + "]";
                jsontext = jsontext.Replace(",]", "]");
                jsontext = jsontext.Replace("[{{", "[{");

                dynamic array = JsonConvert.DeserializeObject(jsontext);




                foreach (var item in array)
                {

                    if (!string.IsNullOrEmpty(item.ToString()))
                    {





                        htmlContent.Replace("#" + item.SATICIKODU + "#tutar#", "");
                        htmlContent.Replace("#" + item.SATICIKODU + "#toplam#", "");


                        //   ////* excelSheet.Cells.Replace("#" + item.SATICIKODU + "#tutar#", "");
                        //   ////* excelSheet.Cells.Replace("#" + item.SATICIKODU + "#toplam#", "");



                    }
                }

            }

            return htmlContent;
        }


        public ActionResult MusteriTemsilSatici_ilk20()
        {
            Reporting.BLL.Repository _repo = new Reporting.BLL.Repository();
            ViewData["SatisAdetMarka"] = _repo.RaporTabloViewDinamikSorgulaMusteriTemsilSatici_ilk20("[workcube_boer_1].[dbo].[MUSTERI_TEMS_SATICI_ILK20_VIEW_HIDIR]");
            IEnumerable<MUSTERI_TEMS_SATICI_ILK20_VIEW_HIDIR> satisAdetMarka = ViewData["SatisAdetMarka"] as IEnumerable<MUSTERI_TEMS_SATICI_ILK20_VIEW_HIDIR>;

            StringBuilder buildHtml = new StringBuilder();
            // buildHtml.Append("<table><tr  class='row'><td  class='odd'>deneme tablo</td></ tr > </table >");
            //buildHtml.AppendLine(body);

            //string renk1 = "E9AE63";
            //string renk2 = "BD936C";

            JsonResult _SatisDataJson = Json(satisAdetMarka, JsonRequestBehavior.AllowGet);
            ViewData["SatisAdetMarkaJson"] = _SatisDataJson.Data;


            // devexpes script
            StringBuilder DevExpresHtml = new StringBuilder();

            DevExpresHtml.AppendLine("<meta http-equiv = 'X -UA-Compatible' content = 'IE=edge' />");


            DevExpresHtml.AppendLine("<meta http-equiv = 'Content-Type' content = 'text/html; charset=utf-8' />");


            DevExpresHtml.AppendLine("<meta name = 'viewport' content = 'width=device-width, initial-scale = 1.0, maximum-scale = 1.0' />");


            DevExpresHtml.AppendLine("<script src = 'https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js' ></script >");

            DevExpresHtml.AppendLine("<script> window.jQuery || document.write(decodeURIComponent('%3Cscript src='js/jquery.min.js'%3E%3C/script%3E')) </script >");


            DevExpresHtml.AppendLine("<script src = 'https://cdnjs.cloudflare.com/ajax/libs/cldrjs/0.4.4/cldr.min.js' ></script >");

            DevExpresHtml.AppendLine("<script src = 'https://cdnjs.cloudflare.com/ajax/libs/cldrjs/0.4.4/cldr/event.min.js' ></script >");

            DevExpresHtml.AppendLine("<script src = 'https://cdnjs.cloudflare.com/ajax/libs/cldrjs/0.4.4/cldr/supplemental.min.js' ></script >");

            DevExpresHtml.AppendLine("<script src = 'https://cdnjs.cloudflare.com/ajax/libs/cldrjs/0.4.4/cldr/unresolved.min.js' ></script >");

            DevExpresHtml.AppendLine("<script type = 'text/javascript' src ='https://cdnjs.cloudflare.com/ajax/libs/globalize/1.1.1/globalize.min.js' ></script >");

            DevExpresHtml.AppendLine("<script type = 'text/javascript' src ='https://cdnjs.cloudflare.com/ajax/libs/globalize/1.1.1/globalize/message.min.js' ></script>");



            DevExpresHtml.AppendLine("<script type = 'text/javascript' src ='https://cdnjs.cloudflare.com/ajax/libs/globalize/1.1.1/globalize/number.min.js' ></script>");



            DevExpresHtml.AppendLine("<script type = 'text/javascript' src = 'https://cdnjs.cloudflare.com/ajax/libs/globalize/1.1.1/globalize/currency.min.js' ></script>");

            DevExpresHtml.AppendLine("<script type = 'text/javascript' src = 'https://cdnjs.cloudflare.com/ajax/libs/globalize/1.1.1/globalize/date.min.js' ></script>");

            DevExpresHtml.AppendLine("<link rel = 'stylesheet' type = 'text/css' href = 'https://cdn3.devexpress.com/jslib/19.2.3/css/dx.common.css' />");

            DevExpresHtml.AppendLine("<link rel = 'stylesheet' type = 'text/css' href = 'https://cdn3.devexpress.com/jslib/19.2.3/css/dx.light.css' />");

            DevExpresHtml.AppendLine("<script src = 'https://cdn3.devexpress.com/jslib/19.2.3/js/dx.all.js' ></script >");



            //DevExpresHtml.AppendLine("< !--< script src = 'data.js' ></script > -->");


            DevExpresHtml.AppendLine("<script src = 'PivotJqueryData.js' ></script >");


            DevExpresHtml.AppendLine("<link rel = 'stylesheet' type = 'text/css' href = 'styles.css' />");


            //DevExpresHtml.AppendLine("< !--< script src = 'index.js' ></script > -->");


            //DevExpresHtml.AppendLine("<script src = 'PivotJqueryIndex.js' ></script >");



            DevExpresHtml.AppendLine("<script>");
            DevExpresHtml.AppendLine("    $(function() {");
            //DevExpresHtml.AppendLine("    $(\"#dataGridContainer\").dxDataGrid({");
            DevExpresHtml.AppendLine("    $(\"#dataGrid\").dxDataGrid({");

            // ...
            DevExpresHtml.AppendLine("     filterRow:");
            DevExpresHtml.AppendLine("     {");
            DevExpresHtml.AppendLine("     visible: true,");
            DevExpresHtml.AppendLine("     applyFilter: \"onClick\"");
            DevExpresHtml.AppendLine("     }");
            DevExpresHtml.AppendLine("     });");
            DevExpresHtml.AppendLine("     });");


            DevExpresHtml.AppendLine("	     $(function () {	");

            DevExpresHtml.AppendLine("	        var pivotGridChart = $('#pivotgrid-chart').dxChart({	");
            DevExpresHtml.AppendLine("	            commonSeriesSettings: {	");
            DevExpresHtml.AppendLine("	                type: 'bar'	");
            DevExpresHtml.AppendLine("	            },	");
            DevExpresHtml.AppendLine("	            tooltip: {	");
            DevExpresHtml.AppendLine("	                enabled: true,	");
            DevExpresHtml.AppendLine("	                format: '#,##0',	"); //currency
            DevExpresHtml.AppendLine("	                customizeTooltip: function (args) {	");
            DevExpresHtml.AppendLine("	                    return {	");
            DevExpresHtml.AppendLine("	                        html: args.seriesName + \" | Toplam Tutar<div class='#,##0'>\" + args.valueText + \"</div>\"	");
            DevExpresHtml.AppendLine("	                    };	");
            DevExpresHtml.AppendLine("	                }	");
            DevExpresHtml.AppendLine("	            },	");
            DevExpresHtml.AppendLine("	            size: {	");
            DevExpresHtml.AppendLine("	                height: 200	");
            DevExpresHtml.AppendLine("	            },	");
            DevExpresHtml.AppendLine("	            adaptiveLayout: {	");
            DevExpresHtml.AppendLine("	                width: 450	");
            DevExpresHtml.AppendLine("	            }	");
            DevExpresHtml.AppendLine("	        }).dxChart(\"instance\");	");
            DevExpresHtml.AppendLine("		");
            DevExpresHtml.AppendLine("	        var pivotGrid = $(\"#pivotgrid\").dxPivotGrid({	");
            DevExpresHtml.AppendLine("	            allowSortingBySummary: true,	");
            DevExpresHtml.AppendLine("	            allowFiltering: true,	");
            DevExpresHtml.AppendLine("	            showBorders: true,	");
            DevExpresHtml.AppendLine("	            showColumnGrandTotals: false,	");
            DevExpresHtml.AppendLine("	            showRowGrandTotals: false,	");
            DevExpresHtml.AppendLine("	            showRowTotals: false,	");
            DevExpresHtml.AppendLine("	            showColumnTotals: false,	");
            DevExpresHtml.AppendLine("	            fieldChooser: {	");
            DevExpresHtml.AppendLine("	                enabled: true,	");
            DevExpresHtml.AppendLine("	                height: 400	");
            DevExpresHtml.AppendLine("	            },	");
            DevExpresHtml.AppendLine("	            dataSource: {	");
            DevExpresHtml.AppendLine("	                fields: [{	");
            DevExpresHtml.AppendLine("	                    caption: \"MusteriTemsilcisi\",	");
            DevExpresHtml.AppendLine("	                    width: 120,	");
            DevExpresHtml.AppendLine("	                    dataField: \"MusteriTemsilcisi\",	");
            DevExpresHtml.AppendLine("	                    area: \"row\",	");
            DevExpresHtml.AppendLine("	                    sortBySummaryField: \"TUTAR\"	");


            DevExpresHtml.AppendLine("	                }, {");
            DevExpresHtml.AppendLine("	                    caption: \"FirmaUNVAN\",	");
            DevExpresHtml.AppendLine("	                    dataField: \"FirmaUNVAN\",	");
            DevExpresHtml.AppendLine("	                    width: 150,	");
            DevExpresHtml.AppendLine("	                    area: \"row\"	");
            DevExpresHtml.AppendLine("	                }, {");

            DevExpresHtml.AppendLine("	                }, {");
            DevExpresHtml.AppendLine("	                    caption: \"SATICIADI\",	");
            DevExpresHtml.AppendLine("	                    dataField: \"SATICIADI\",	");
            DevExpresHtml.AppendLine("	                    width: 150,	");
            DevExpresHtml.AppendLine("	                    area: \"column\"	");
            DevExpresHtml.AppendLine("	                }");


            //DevExpresHtml.AppendLine(", {");



            //DevExpresHtml.AppendLine("	                    dataField: \"date\",	");
            //DevExpresHtml.AppendLine("	                    dataType: \"date\",	");
            //DevExpresHtml.AppendLine("	                    area: \"column\"	");
            //DevExpresHtml.AppendLine("}"); 
            //DevExpresHtml.AppendLine(",{");
            //DevExpresHtml.AppendLine("	                    groupName: \"date\",	");
            //DevExpresHtml.AppendLine("	                    groupInterval: \"month\",	");
            //DevExpresHtml.AppendLine("	                    visible: false	");
            //DevExpresHtml.AppendLine("	                },");
            DevExpresHtml.AppendLine(" ,{");
            DevExpresHtml.AppendLine("	                    caption: \"Toplam Tutar\",	");
            DevExpresHtml.AppendLine("	                    dataField: \"TUTAR\",	");
            DevExpresHtml.AppendLine("	                    dataType: \"double\",	");
            DevExpresHtml.AppendLine("	                    summaryType: \"sum\",	");

            DevExpresHtml.AppendLine("	                    format: \"currency\",	");  //currency
            DevExpresHtml.AppendLine("	                    format: \"#,##0\",	");  //


            DevExpresHtml.AppendLine("	                    area: \"data\"	");
            DevExpresHtml.AppendLine("	                }],	");
            DevExpresHtml.AppendLine("	                store: sales	");
            DevExpresHtml.AppendLine("	            }	");
            DevExpresHtml.AppendLine("	        }).dxPivotGrid(\"instance\");	");
            DevExpresHtml.AppendLine("		");
            DevExpresHtml.AppendLine("	        pivotGrid.bindChart(pivotGridChart, {	");
            DevExpresHtml.AppendLine("	            dataFieldsDisplayMode: \"splitPanes\",	");
            DevExpresHtml.AppendLine("	            alternateDataFields: false	");
            DevExpresHtml.AppendLine("	        });	");
            DevExpresHtml.AppendLine("		");
            DevExpresHtml.AppendLine("	        function expand() {	");
            DevExpresHtml.AppendLine("	            var dataSource = pivotGrid.getDataSource();	");
            DevExpresHtml.AppendLine("	            dataSource.expandHeaderItem(\"row\", [\"North America\"]);	");
            DevExpresHtml.AppendLine("	            dataSource.expandHeaderItem(\"column\", [2013]);	");
            DevExpresHtml.AppendLine("	        }	");
            DevExpresHtml.AppendLine("		");
            DevExpresHtml.AppendLine("	        setTimeout(expand, 0);	");
            DevExpresHtml.AppendLine("	    });	");

            //MusteriTemsilcisi 
            //FirmaUNVAN;
            //SATICIADI;
            //TOPLAM;
            // TUTAR;

            string json = JsonConvert.SerializeObject(_SatisDataJson.Data);
            DevExpresHtml.AppendLine("var sales =" + json);
            // DevExpresHtml.Replace("Data:[", "var sales = [");


            ////// data 
            //DevExpresHtml.Append("  var sales = [{");
            //DevExpresHtml.Append("      \"id\": 10248,");
            //DevExpresHtml.Append("      \"region\": \"North America\",");
            //DevExpresHtml.Append("      \"country\": \"United States of America\",");
            //DevExpresHtml.Append("      \"city\": \"New York\",");
            //DevExpresHtml.Append("      \"amount\": 1740,");
            //DevExpresHtml.Append("      \"date\": new Date(\"2013-01-06\")");
            //DevExpresHtml.Append("  }, {");
            //DevExpresHtml.Append("      \"id\": 10249,");
            //DevExpresHtml.Append("      \"region\": \"North America\",");
            //DevExpresHtml.Append("      \"country\": \"United States of America\",");
            //DevExpresHtml.Append("      \"city\": \"Los Angeles\",");
            //DevExpresHtml.Append("      \"amount\": 850,");
            //DevExpresHtml.Append("      \"date\": new Date(\"2013-01-13\")");
            //DevExpresHtml.Append("  }, {");
            //DevExpresHtml.Append("      \"id\": 10250,");
            //DevExpresHtml.Append("      \"region\": \"North America\",");
            //DevExpresHtml.Append("      \"country\": \"United States of America\",");
            //DevExpresHtml.Append("      \"city\": \"Denver\",");
            //DevExpresHtml.Append("      \"amount\": 2235,");
            //DevExpresHtml.Append("      \"date\": new Date(\"2013-01-07\")");
            //DevExpresHtml.Append("  }, {");
            //DevExpresHtml.Append("     \"id\": 10251,");
            //DevExpresHtml.Append("      \"region\": \"North America\",");
            //DevExpresHtml.Append("      \"country\": \"Canada\",");
            //DevExpresHtml.Append("      \"city\": \"Vancouver\",");
            //DevExpresHtml.Append("      \"amount\": 1965,");
            //DevExpresHtml.Append("      \"date\": new Date(\"2013-01-03\")");
            //DevExpresHtml.Append("  }   ");
            //DevExpresHtml.Append("];");
            ////// data 



            DevExpresHtml.AppendLine("</script>");


            // devexpes script sonu





            StyleIcerik.AppendLine("<style>");

            StyleIcerik.AppendLine(".column-options {");
            StyleIcerik.AppendLine("width:80% !important;");
            StyleIcerik.AppendLine("margin-right:8% !important;");

            StyleIcerik.AppendLine("margin-left:2% !important;");
            StyleIcerik.AppendLine("border-collapse: collapse;");
            StyleIcerik.AppendLine("border-bottom: 1px solid #d6d6d6;");
            StyleIcerik.AppendLine("}");

            StyleIcerik.AppendLine(".column-options th, .column-options td {");
            StyleIcerik.AppendLine("font-family: Helvetica, Arial, sans-serif;");
            StyleIcerik.AppendLine("font-weight: bold;");
            StyleIcerik.AppendLine("color: #434343;");
            StyleIcerik.AppendLine("width:80%;");
            StyleIcerik.AppendLine("margin-right:8% !important;");

            StyleIcerik.AppendLine("margin-left:2% !important;");
            StyleIcerik.AppendLine("background-color: #f7f7f7;");
            StyleIcerik.AppendLine("border-left: 1px solid #ffffff;");
            StyleIcerik.AppendLine("border-right: 1px solid #dcdcdc;");
            StyleIcerik.AppendLine("}");

            StyleIcerik.AppendLine(".column-options th {");
            StyleIcerik.AppendLine("font-size:10px;");
            StyleIcerik.AppendLine("font-weight: normal;");
            StyleIcerik.AppendLine("letter-spacing: 0.12em;");
            StyleIcerik.AppendLine("text-shadow: -1px-1px 1px #999;");
            StyleIcerik.AppendLine("color: #fff;");
            kolonRenk = "#0cb08b";
            StyleIcerik.AppendLine("background-color:" + kolonRenk + ";");
            //StyleIcerik.AppendLine("padding: 12px 0px 8px 0px;");
            //StyleIcerik.AppendLine("padding: 12px 0px 2px 0px;");
            StyleIcerik.AppendLine("border-bottom: 1px solid #d6d6d6;");

            StyleIcerik.AppendLine("}");

            StyleIcerik.AppendLine(".column-options td {");
            StyleIcerik.AppendLine("text-shadow: 1px 1px 0 #fff;");
            //StyleIcerik.AppendLine("padding: 12px 20px 12px 20px;");
            StyleIcerik.AppendLine("padding: 2px 2px 2px 2px;");
            StyleIcerik.AppendLine("}");

            StyleIcerik.AppendLine(".column-options.odd td {");
            StyleIcerik.AppendLine("background-color: #ededed;");
            StyleIcerik.AppendLine("}");


            StyleIcerik.AppendLine(".column-options th: first-child {");
            StyleIcerik.AppendLine("border-top-left-radius: 7px;");
            StyleIcerik.AppendLine("- moz-border-radius-topleft: 7px;");
            StyleIcerik.AppendLine("}");

            StyleIcerik.AppendLine(".column-options th: last-child {");
            StyleIcerik.AppendLine("border-top-right-radius: 7px;");
            StyleIcerik.AppendLine("- moz-border-radius-topright: 7px;");
            StyleIcerik.AppendLine("}");

            StyleIcerik.AppendLine(".column-options th: last-child, .column-options td: last-child {");
            StyleIcerik.AppendLine("border-right: 0px;");
            StyleIcerik.AppendLine("}");


            StyleIcerik.AppendLine("</style>");







            //// create excel

            int excelSatirNo = 1;
            int excelKolonNo = 2;
            int excelKolonNoFirma = 3;
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {

                return null;
            }

            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet2;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkBook.Worksheets.Add(); ;
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkBook.ActiveSheet.Name = "Satis";
            xlWorkSheet.Name = "Satis";

            xlApp.ActiveWindow.DisplayGridlines = false;
            xlApp.ActiveWindow.Zoom = 70;

            xlWorkBook.Sheets[2].Name = "data";
            xlWorkBook.Sheets["data"].Cells[1, 1] = "MUSTERi TEMSiLCiSi";
            xlWorkBook.Sheets["data"].Cells[1, 2] = "FiRMA ÜNVANI";
            xlWorkBook.Sheets["data"].Cells[1, 3] = "SATICI ADI";
            xlWorkBook.Sheets["data"].Cells[1, 4] = "ADET";
            xlWorkBook.Sheets["data"].Cells[1, 5] = "TUTAR";





            //xlWorkBook.Worksheets.Add(); ;
            //xlWorkSheet2 = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);
            //xlWorkSheet2.Name = "Data";

            //xlWorkSheet.Select();
            //xlWorkSheet.Activate();



            string altCizgiRengi = "#996633";


            //string renk1 = "#2a6ebc";
            //string renk2 = "#5995da";
            //string renk3 = "#7ad9ff";
            //string renk4 = "#7df3ff";
            //string gecerliRenk = renk1;
            //string kalip = "";
            //string saticilar = "";
            //string musteriTemsilcisiHtml = "";


            string renk1 = "#CCCCFF";
            string renk2 = "white";
            string renk3 = "#7ad9ff";
            string renk4 = "#7df3ff";
            string gecerliRenk = renk1;
            string kalip = "";
            string saticilar = "";
            string musteriTemsilcisiHtml = "";


            #region





            buildHtml.Append("<table id='tableSatis2' width='80%' style='width:80% !important;padding-top:10% !important;margin-top:10% ' class='column-options'>");

            buildHtml.Append("<tr>");
            buildHtml.Append("<th  class = 'odd'   colspan='#saticiAdet#' align='center' style='color:white;padding-top:10px;padding-bottom:10px; text-shadow: 1px 1px 2px black; border-top-left-radius: 15px;; border-top-right-radius: 15px;  '");
            buildHtml.Append("<b> MÜŞTERi TEMSiLCiSi - SATICI İLK 20 RAPORU  (YILLIK) </b></th>");
            buildHtml.Append("</tr>");
            excelSatirNo++;
            ////*xlWorkSheet.Cells[excelSatirNo, excelKolonNo] = "MÜŞTERi TEMSiLCiSi - SATICI İLK 20 RAPORU  (YILLIK) ";
            ////*xlWorkSheet.Cells[excelSatirNo, excelKolonNo].Font.Bold = true;


            buildHtml.Append("<tr>");

            buildHtml.Append("</tr>");
            buildHtml.Append("<tr   class = 'odd' style='border-bottom:none !important;border-top:none !important;'  > ");
            buildHtml.Append("<td  class='odd'></td>");

            buildHtml.Append("<td  class='odd'></td>");
            excelSatirNo++;




            buildHtml.Append("<td  class='odd' colspan='1'   style='color: white; border: solid white 0px; text-align:center; -moz-border-radius: 0px; -webkit-border-radius: 0px; border-radius: 0px; border-top-left-radius: 15px; border-top-right-radius: 15px; text-indent:4px; text-shadow: 1px 1px 2px black; '>" + "" + "</td>");
            excelKolonNo++;



            buildHtml.Append("</tr>");
            buildHtml.Append(" <tr  class='odd'  style='text-shadow: 1px 1px 2px black;' >");



            buildHtml.Append(" <th  class='odd' colspan = '1' style = 'width:4%;font-size:10px !important;' > MUSTERi TEMSiLCiSi </th>");
            buildHtml.Append(" <th  class='odd' colspan = '1' style = 'width:4%;font-size:10px !important;' > FiRMA </th>");


            excelSatirNo = 2;
            ////*xlWorkSheet.Cells[excelSatirNo, excelKolonNoFirma-1] = "MUSTERi TEMSiLCiSi ";
            ////*xlWorkSheet.Cells[excelSatirNo, excelKolonNoFirma-1].Font.Bold = true;
            ////*xlWorkSheet.Cells[excelSatirNo, excelKolonNoFirma - 1].Interior.Color = System.Drawing.ColorTranslator.FromHtml(kolonRenk);





            ////*xlWorkSheet.Cells[excelSatirNo, excelKolonNoFirma] = "FiRMA";
            ////*xlWorkSheet.Cells[excelSatirNo, excelKolonNoFirma].Font.Bold = true;
            ////*xlWorkSheet.Cells[excelSatirNo, excelKolonNoFirma].Interior.Color = System.Drawing.ColorTranslator.FromHtml(kolonRenk);


            int z = 0;
            string saticilar1 = "";
            string saticilar2 = "";
            string saticiListesi = "";
            foreach (var item in satisAdetMarka)
            {


                saticiListesi = item.SATICI_LISTESI;
                saticilar1 = KalipOlustur(item.SATICI_LISTESI, xlWorkSheet, excelSatirNo, excelKolonNoFirma + 1);
                saticilar2 += KalipOlustur2(item.SATICI_LISTESI, xlWorkSheet, excelSatirNo, excelKolonNoFirma);

                break;
            }

            buildHtml.Append(saticilar2);
            buildHtml.Append("</tr>");





            #endregion




            int p = 0;
            int yer = -1;
            string onceki_musteriTemsilcisi = "-1";
            string simdiki_musteriTemsilcisi = "-1";


            string onceki_musteriTemsilcisiFirma = "-1";
            string simdiki_musteriTemsilcisiFirma = "-1";
            string simdiki_FirmaKODU = "-1";
            string onceki_FirmaKODU = "-1";
            int kolonAdet = 38;
            int mergeSatirAdet = 0;
            int markaAdet = 10;
            int firmaAdet = 0;
            string aranan = "";
            string ustCizgi = "";
            bool mergeYapildi = false; // ayni satici icin satir birlestirme islemi
            NumberFormatInfo myNumberFormatInfo = new CultureInfo("tr-TR", false).NumberFormat;





            string satisAdetTutarHtml = "";






            foreach (var item in satisAdetMarka)
            {



                ////*xlWorkSheet.Select();
                ////*xlWorkSheet.Activate();

                p++;

                simdiki_musteriTemsilcisi = "|" + item.MusteriTemsilcisi + "|";
                simdiki_FirmaKODU = "|" + item.FirmaKODU + "|";




                if (!simdiki_FirmaKODU.Equals(onceki_FirmaKODU))
                {
                    firmaAdet++;


                }
                gecerliRenk = renk1;
                if (firmaAdet % 2 == 0)
                {

                    gecerliRenk = renk2;

                }








                if (item.SIRA > 0)
                {
                    gecerliRenk = kolonRenk;
                }







                kalip = "";
                kalip = "<tr  class='odd' style='border-right:solid 0px white;border-bottom:solid 2px gray !important;'>";

                mergeSatirAdet = 0;

                musteriTemsilcisiHtml = "";


                simdiki_musteriTemsilcisiFirma = item.MusteriTemsilcisi + "|" + item.FirmaKODU;
                if ((simdiki_musteriTemsilcisiFirma.ToString().Trim() != onceki_musteriTemsilcisiFirma.ToString().Trim()) || onceki_musteriTemsilcisiFirma.ToString().Trim() == "-1")
                {
                    buildHtml = KalipTemizle(item.SATICI_LISTESI.ToString(), buildHtml, xlWorkSheet);

                }
                excelKolonNo = 2;

                if ((simdiki_musteriTemsilcisi.ToString().Trim() != onceki_musteriTemsilcisi.ToString().Trim()) || onceki_musteriTemsilcisi.ToString().Trim() == "-1")
                {


                    buildHtml.Append("<tr style='height:2px;' ></tr>");
                    musteriTemsilcisiHtml = "<td rowspan='" + item.MERGE_ADET.ToString() + "'  class='odd' style='width:5px; text-align:center;vertical-align:middle;'> #MusteriTemsilcisi#</td>";
                    excelSatirNo++;
                    excelKolonNo = 2;
                    ////*xlWorkSheet.Cells[excelSatirNo, excelKolonNoFirma-1] = "#MusteriTemsilcisi#";
                    ////*xlWorkSheet.Cells[excelSatirNo, excelKolonNoFirma-1].Font.Bold = true;
                    ////*xlWorkSheet.Cells[excelSatirNo, excelKolonNoFirma - 1].Name = "MergeBaslangic";
                    ////*xlWorkSheet.Cells[excelSatirNo, excelKolonNoFirma - 1].Borders.LineStyle=  XlLineStyle.xlContinuous;
                    ////*xlWorkSheet.Cells[excelSatirNo, excelKolonNoFirma - 1].Borders.Weight =  XlBorderWeight.xlThin; 





                    ////*xlWorkSheet.Cells[excelSatirNo, excelKolonNoFirma - 1].VerticalAlignment = XlPhoneticAlignment.xlPhoneticAlignCenter;



                }
                else
                {
                    excelSatirNo++;
                    string rangeName2 = "MergeBaslangic";


                    ////* Range cellAranan2 = xlWorkSheet.Range[rangeName2];
                    ////*xlWorkSheet.Range[xlWorkSheet.Cells[cellAranan2.Row, cellAranan2.Column], xlWorkSheet.Cells[excelSatirNo, cellAranan2.Column ]].Merge();


                }





                kalip += musteriTemsilcisiHtml;
                kalip += "<td   class='odd' style='width:5px;text-align:center;vertical-align:middle ;'> #FirmaUNVAN# </td>";


                kalip += saticilar1 + "</tr>";

                if ((simdiki_musteriTemsilcisiFirma.ToString().Trim() != onceki_musteriTemsilcisiFirma.ToString().Trim()) || onceki_musteriTemsilcisiFirma.ToString().Trim() == "-1")
                {
                    buildHtml.Append(kalip);

                }

                excelKolonNo = 3;
                ////*xlWorkSheet.Cells[excelSatirNo, excelKolonNoFirma] = "#FirmaUnvan#";
                ////*xlWorkSheet.Cells[excelSatirNo, excelKolonNoFirma].Font.Bold = true;

                ////*xlWorkSheet.Cells[excelSatirNo, excelKolonNoFirma  ].Borders.LineStyle = XlLineStyle.xlContinuous;
                ////*xlWorkSheet.Cells[excelSatirNo, excelKolonNoFirma  ].Borders.Weight = XlBorderWeight.xlThin;

                ustCizgi = "";
                if (Convert.ToInt32(item.SIRA).Equals(mergeSatirAdet - 1))
                {
                    ustCizgi = ";border-bottom:solid 2px red;";
                }






                buildHtml.Replace("#MusteriTemsilcisi#", item.MusteriTemsilcisi.ToString());
                buildHtml.Replace("#FirmaUNVAN#", item.FirmaUNVAN);
                buildHtml.Replace("#saticiAdet#", (saticiAdet * 2 + 4).ToString());
                buildHtml.Replace("#YIL_TOPLAM#", Convert.ToInt32(item.YILLIK_ADET_TOPLAM).ToString("#,##0.###"));
                buildHtml.Replace("#YIL_TUTAR#", Convert.ToDouble(item.YILLIK_TUTAR_TOPLAM).ToString("N", myNumberFormatInfo));



                ////*xlWorkSheet.Cells[excelSatirNo, excelKolonNoFirma-1].Replace("#MusteriTemsilcisi#", item.MusteriTemsilcisi.ToString());
                ////*xlWorkSheet.Cells[excelSatirNo, excelKolonNoFirma].Replace("#FirmaUNVAN#", item.FirmaUNVAN.ToString());


                string rangeName = "Name" + item.SATICIKODU;


                ////* Range cellAranan = xlWorkSheet.Range[rangeName];
                ////*xlWorkSheet.Cells[excelSatirNo, cellAranan.Column] = Convert.ToInt32(item.TOPLAM).ToString("#,##0.###");
                ////*xlWorkSheet.Cells[excelSatirNo, cellAranan.Column+1] = Convert.ToInt32(item.TUTAR).ToString("#,##0.###");

                ////*xlWorkSheet.Cells[excelSatirNo, cellAranan.Column + 1].Borders[ XlBordersIndex.xlEdgeRight].Weight = 1d;







                rangeName = "nameYIL";
                ////*  cellAranan = xlWorkSheet.Range[rangeName];
                ////*xlWorkSheet.Cells[excelSatirNo, cellAranan.Column] = Convert.ToInt32(item.YILLIK_ADET_TOPLAM).ToString("#,##0.###");
                ////*xlWorkSheet.Cells[excelSatirNo, cellAranan.Column + 1] = Convert.ToDouble(item.YILLIK_TUTAR_TOPLAM).ToString("N", myNumberFormatInfo);
                ////*xlWorkSheet.Cells[excelSatirNo, cellAranan.Column + 1].Borders[XlBordersIndex.xlEdgeRight].Weight = 1d;


                aranan = "#" + item.SATICIKODU.ToString().Trim() + "#toplam#";
                yer = -1;
                yer = buildHtml.ToString().IndexOf(aranan);
                if (yer > -1)
                {

                    buildHtml.Replace(aranan, Convert.ToInt32(item.TOPLAM).ToString("#,##0.###"));

                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }

                aranan = "#" + item.SATICIKODU.ToString().Trim() + "#tutar#";
                yer = -1;
                yer = buildHtml.ToString().IndexOf(aranan);
                if (yer > -1)
                {

                    buildHtml.Replace(aranan, Convert.ToDouble(item.TUTAR).ToString("N", myNumberFormatInfo));
                    ////*xlWorkSheet.Cells.Replace(aranan, Convert.ToDouble(item.TUTAR).ToString("N", myNumberFormatInfo));


                }
                else
                {
                    buildHtml.Replace(aranan, "");
                }





                onceki_musteriTemsilcisi = "|" + item.MusteriTemsilcisi + "|";
                onceki_musteriTemsilcisiFirma = item.MusteriTemsilcisi + "|" + item.FirmaKODU;
                onceki_FirmaKODU = "|" + item.FirmaKODU + "|";



                ////*xlWorkBook.Sheets["data"].Cells[p + 1, 1] = item.MusteriTemsilcisi;
                ////*xlWorkBook.Sheets["data"].Cells[p + 1, 2] = item.FirmaUNVAN;
                ////*xlWorkBook.Sheets["data"].Cells[p + 1, 3] = item.SATICIADI;
                ////*xlWorkBook.Sheets["data"].Cells[p + 1, 4] = item.TOPLAM;
                ////*xlWorkBook.Sheets["data"].Cells[p + 1, 5] = item.TUTAR;
            }



            buildHtml = KalipTemizle(saticiListesi, buildHtml, xlWorkSheet);
            buildHtml.Append("</table>");

            string rangeCerceve = "";


            for (int i = 0; i < saticiAdet * 2 + 3; i += 2)
            {
                rangeCerceve = GetExcelColumnName(excelKolonNoFirma + i) + "2:" + GetExcelColumnName(excelKolonNoFirma + i + 1) + (p + 2).ToString();
                ////*xlWorkSheet.Range[rangeCerceve].Borders[XlBordersIndex.xlEdgeRight].Weight = 2d;
                ////*xlWorkSheet.Range[rangeCerceve].Borders[XlBordersIndex.xlEdgeBottom].Weight = 2d;
                ////*xlWorkSheet.Range[rangeCerceve].Borders[XlBordersIndex.xlInsideHorizontal].Weight = 2d;
                ////*xlWorkSheet.Columns[excelKolonNoFirma + i].ColumnWidth = 6;
                ////*xlWorkSheet.Columns[excelKolonNoFirma + i+1].ColumnWidth = 6;




            }

            ////*xlWorkSheet.Columns[4].Hidden = true;
            ////*xlWorkSheet.Rows[2].RowHeight = 40;

            ////*xlWorkSheet.Columns[excelKolonNoFirma].AutoFit();
            ////*xlWorkSheet.Columns[excelKolonNoFirma+1].AutoFit();
            ////*xlWorkSheet.Columns[excelKolonNoFirma - 1].AutoFit();
            ////*xlWorkSheet.Columns[excelKolonNoFirma + 2 + (saticiAdet * 2)].AutoFit();
            ////*xlWorkSheet.Columns[excelKolonNoFirma + 3 + (saticiAdet * 2)].AutoFit();
            ////*xlWorkSheet.Columns[excelKolonNoFirma + 4 + (saticiAdet * 2)].AutoFit();
            ////*xlWorkSheet.Columns[excelKolonNoFirma + 3 + (saticiAdet * 2)].Font.Bold = true;



            rangeCerceve = GetExcelColumnName(excelKolonNoFirma + -1) + "2:" + GetExcelColumnName(excelKolonNoFirma + 3 + (saticiAdet * 2)) + (p + 2).ToString();
            ////*xlWorkSheet.Range[rangeCerceve].Borders[XlBordersIndex.xlEdgeBottom].Weight = 2d;
            ////*xlWorkSheet.Range[rangeCerceve].Borders[XlBordersIndex.xlEdgeTop].Weight = 2d;
            ////*xlWorkSheet.Range[rangeCerceve].Borders[XlBordersIndex.xlEdgeLeft].Weight = 2d;
            ////*xlWorkSheet.Range[rangeCerceve].Borders[XlBordersIndex.xlEdgeRight].Weight = 2d;



            ViewData["tumHtml"] = StyleIcerik + buildHtml.ToString();



            string rangeData = "A1:E" + (p + 1).ToString();

            ////*xlWorkBook.Sheets["Data"].Columns[1].AutoFit();
            ////*xlWorkBook.Sheets["Data"].Columns[2].AutoFit();
            ////*xlWorkBook.Sheets["Data"].Columns[3].AutoFit();
            ////*xlWorkBook.Sheets["Data"].Columns[4].AutoFit();
            ////*xlWorkBook.Sheets["Data"].Columns[5].AutoFit();

            ////* Range range = xlWorkBook.Sheets["Data"].Range[rangeData];




            ////*xlWorkBook.Sheets["satis"].Select();
            ////*xlWorkBook.Sheets["satis"].Activate();

            // Add chart.
            ////*  var charts = xlWorkSheet.ChartObjects() as
            ////*Microsoft.Office.Interop.Excel.ChartObjects;
            ////* var chartObject = charts.Add(60, 25*p, saticiAdet*200, 600) as
            ////*Microsoft.Office.Interop.Excel.ChartObject;
            ////* var chart = chartObject.Chart;

            // Set chart range.







            ////*  chart.SetSourceData(range);

            // Set chart properties.
            ////* chart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xl3DColumnClustered;
            //chart.ChartWizard(Source:range, Title:graphTitle,CategoryTitle:xAxis,ValueTitle: yAxis);

            //chart.ChartWizard(Source: range, Title: "Müsteri Tems. Satıcı ilk 20", CategoryTitle: "xAxis", ValueTitle: "yAxis");
            ////*  chart.ChartWizard(Source: range, Title: "Müsteri Tems. Satıcı ilk 20 Grafiği", CategoryTitle: "Müst.Tems.Satıcı", ValueTitle: "Tutar-Adet");

            string dosya_adi = "d:\\MusteriTems_Satici_ilk20_" + DateTime.Now.ToShortDateString().Replace(":", "_").Replace(":", "_") + DateTime.Now.ToLongTimeString().Replace(":", "_").Replace(":", "_");
            string dosya_adiXLSX = dosya_adi + ".xlsx";

            //xlWorkBook.SaveAs(dosya_adiXLSX, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, misValue,
            //misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

            ////*xlWorkBook.SaveAs(dosya_adiXLSX, Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, misValue,
            /////* misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);







            ////*xlWorkBook.Close(true, misValue, misValue);
            ////*xlApp.Quit();

            ////*Marshal.ReleaseComObject(xlWorkSheet);
            //Marshal.ReleaseComObject(xlWorkSheet2);
            ////*Marshal.ReleaseComObject(xlWorkBook);
            ////*Marshal.ReleaseComObject(xlApp);

            // MessageBox.Show("Excel file created , you can find the file d:\\csharp-Excel.xlsx");

            //create html
            //string path = @"c:\temp\MyTest.txt";







            string mailBody = "";
            mailBody += "<!DOCTYPE html>";


            mailBody += "<html>";
            mailBody += "<head>";
            mailBody += "<meta charset = 'UTF-8'>";
            mailBody += "</head>";


            mailBody += StyleIcerik;


            mailBody += "<table id='tableSatisOzet' class='column-options' style='width:98% !important;-moz-border-radius: 0px; -webkit-border-radius: 0px; border-radius: 0px; border-top-left-radius: 15px; border-top-right-radius: 15px; text-indent:4px; text-shadow: 1px 1px 2px black;' >";
            mailBody += " <tr class = 'odd'>";
            mailBody += "<th colspan='2' class = 'odd' style='-moz-border-radius: 0px; -webkit-border-radius: 0px; border-radius: 0px; border-top-left-radius: 15px; border-top-right-radius: 15px; text-indent:4px; text-shadow: 1px 1px 2px black;' >Müşteri Temsilcisi Satıcı ilk 20 Raporu </th>";
            mailBody += " </tr>";
            mailBody += " <tr class = 'odd' style='border-bottom:solid 2px gray !important;' >";
            mailBody += "<td class = 'odd' > Kayıt Adet</td>";
            mailBody += "<td class = 'odd'> " + firmaAdet.ToString() + "</td>";

            mailBody += " </tr>";
            mailBody += "<tr class = 'odd' style='border-bottom:solid 2px gray !important;'><td colspan='10' class = 'odd' >Detaylar için Ekteki Excel veya Html Dosyalarını incelebilirsiniz..</td></tr>";
            mailBody += " <tr class = 'odd' style='border-bottom:solid 2px gray !important;'> <td class = 'odd' colspan='10'  > <a> Tekrar Gönder(Güncel)</a></td>  </tr> ";

            mailBody += "</table>";
            mailBody += "</html>";





            string dosya_adiHTML = dosya_adi + ".HTML";
            using (FileStream fs = new FileStream(dosya_adiHTML, FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {


                    w.WriteLine("<!DOCTYPE html>");


                    w.WriteLine("<html>");
                    w.WriteLine("<head>");
                    w.WriteLine("<meta charset = 'UTF-8'>");




                    w.WriteLine(DevExpresHtml);


                    w.WriteLine(StyleIcerik);
                    w.WriteLine("</head>");

                    //w.WriteLine(StyleIcerik);







                    w.WriteLine("<body class='dx-viewport'>");

                    w.WriteLine(buildHtml);




                    //  DevExpres govde icin

                    w.WriteLine("<div class='demo-container' style='margin-top:10%; margin-top:10%;'>");
                    w.WriteLine("<div id = 'pivotgrid-demo'>");
                    w.WriteLine("<div id='pivotgrid-chart'></div>");
                    w.WriteLine("<div id = 'pivotgrid' ></div>");
                    w.WriteLine("</div>");
                    w.WriteLine("</div>");

                    //  DevExpres govde icin






                    w.WriteLine("</body>");
                    w.WriteLine("</HTML>");

                }
            }

            // create html sonu


            /// create excel sonu
            /// 



            string dosya_adiHTML2 = dosya_adi + "_tum__" + ".HTML";

            //  w.Write(client.DownloadString("http://localhost:12841/MusteriTemsilSatici_ilk20"));



            // Create the file.
            //using (FileStream fs = new FileStream(Server.MapPath("Files\\test.htm"), FileMode.Create))



            SendEmail(mailBody, dosya_adiXLSX, dosya_adiHTML);






            return View(buildHtml);
            //return View(tum_html);





        }

        public static void SendEmail(string Body, string dosya_adiXLSX, string dosya_adiHTML)
        {


            MailMessage message = new MailMessage();
            message.From = new MailAddress("rapor@boer.com.tr");
            message.To.Add("hidir_celebi1981@hotmail.com");
            message.To.Add("hidir.celebi@boer.com.tr");
            message.Subject = "deneme email rapor";
            message.IsBodyHtml = true;

            ///////*** message.Attachments.Add(new Attachment(dosya_adiXLSX));
            message.Attachments.Add(new Attachment(dosya_adiHTML));



            // message.Attachments.Add(new Attachment(HostingEnvironment.MapPath("~/MusteriTemsilSatici_ilk20.cshtml")));

            //  message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(HostingEnvironment.MapPath("~/MusteriTemsilSatici_ilk20.cshtml"), Encoding.UTF8, "text/html"));





            // message.Attachments.Add(ekDosya);
            message.Body = Body;  //"<table>  <th> deneme ee     </th>    </table>";  // Body;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.UseDefaultCredentials = true;

            smtpClient.Host = "mail.boer.com.tr"; // ConfigurationSettings.AppSettings["SMTP"].ToString();
            //smtpClient.Port = 587; // Convert.ToInt32(ConfigurationSettings.AppSettings["PORT"].ToString());
            smtpClient.Port = 25; // Convert.ToInt32(ConfigurationSettings.AppSettings["PORT"].ToString());
            //**smtpClient.EnableSsl = true;
            //smtpClient.Credentials = new System.Net.NetworkCredential(ConfigurationSettings.AppSettings["USERNAME"].ToString(), ConfigurationSettings.AppSettings["PASSWORD"].ToString());
            smtpClient.Credentials = new System.Net.NetworkCredential("rapor@boer.com.tr", "Boer2637#");


            /////**  smtpClient.Send(message);
        }


    }
}