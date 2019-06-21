using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace attentiTest
{
    class log
    {
        private static log L;
        public static string htmlStr;
        public static string table;
        private log()
        {
        }

        public static log getL()
        {
            if (L == null)
            {
                L = new log();
                htmlStr = @"<html>
                      <body>
                        <style type=""text/css"">
                        .tg  {border-collapse:collapse;border-spacing:0;border-color:#93a1a1;}
                        .tg td{font-family:Arial, sans-serif;font-size:14px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#93a1a1;color:#002b36;background-color:#fdf6e3;}
                        .tg th{font-family:Arial, sans-serif;font-size:14px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#93a1a1;color:#fdf6e3;background-color:#657b83;}
                        .tg .tg-0lax{text-align:left;vertical-align:top}
                        </style>
                        <table class=""tg"">
                          <tr>
                            <th class=""tg-0lax"">Test Name</th>
                            <th class=""tg-0lax"">Value</th> 
                            <th ""tg-0lax"">expected Result</th>
                            <th ""tg-0lax"">Result</th>
                            <th ""tg-0lax"">Comments</th>
                          </tr>
                          insert table here
                        </table>
                      </body>
                      </html>
                     ";
            }

            return L;
        }



        public static void addToHtml(string test, string value, string expected, string res, string comments)
        {
            table += @"<tr>
            <td>" + test + @"</td>
            <td>" + value + @"</td>
            <td>" + expected + @"</td>
            <td>" + res + @"</td>";

            if(comments == "pass")
                table += @"<td><font color=""GREEN"">" + comments + @"</td></tr>";
            else
                table += @"<td><font color=""RED"">" + comments + @"</td></tr>";
        }


        public static void SaveLogToFile()
{
            string path = Directory.GetCurrentDirectory();
            path = path+"\\attentiTestResult.html";
           htmlStr =  htmlStr.Replace("insert table here", table);
            System.IO.File.WriteAllText(path, htmlStr);
            path = AddQuotesIfRequired(path);
            System.Diagnostics.Process.Start("chrome",path);
            
        }

        public static string AddQuotesIfRequired(string path)
        {
            return !string.IsNullOrWhiteSpace(path) ?
                path.Contains(" ") && (!path.StartsWith("\"") && !path.EndsWith("\"")) ?
                    "\"" + path + "\"" : path :
                    string.Empty;
        }
    }
}
        