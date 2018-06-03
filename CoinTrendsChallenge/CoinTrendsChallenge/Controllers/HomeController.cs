using CoinTrendsChallenge.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CoinTrendsChallenge.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<DataPoint> dataPoints = new List<DataPoint>{
                new DataPoint(1528142995000, 422.12),
                new DataPoint(1528229395000, 402.12)

               // new DataPoint("2016-03-26 13:40:00", 402.12),
             //   new DataPoint(DateTime.ParseExact("2016-03-25","yyyy-MM-dd", CultureInfo.InvariantCulture), 418.81),
            };
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);


            List<DataPoint> dataPoints2 = new List<DataPoint>{
                new DataPoint(1528142995000, 134.12),
                new DataPoint(1528229395000, 123.12)
            };
            ViewBag.DataPoints2 = JsonConvert.SerializeObject(dataPoints2);


            List<DataPoint> dataPoints3 = new List<DataPoint>{
                new DataPoint(1528142995000, 678.12),
                new DataPoint(1528229395000, 900.12)
            };
            ViewBag.DataPoints3 = JsonConvert.SerializeObject(dataPoints3);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "My application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My contact page.";
            return View();
        }
        
        public ActionResult MyChart()
        {
            String[] xValueDays = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            double[] yValueDays = { 418.81, 420.01, 428.81, 435.61, 500.00, 523.43, 499.90 };

            getDataFromBitcoinAverage();

            new Chart(width: 800, height: 200)
                .AddSeries(
                    chartType: "line",
                    xValue: xValueDays,
                    yValues: yValueDays)
                .Write("png");
            return null;
        }

        public void getDataFromBitcoinAverage()
        {
            string url = "https://apiv2.bitcoinaverage.com/indices/tokens/history/BTCUSD?period=daily&format=json"; //since=1528038030
           // string data = "{\"service\":\"absence.list\", \"company_id\":3}";

            WebRequest myReq = WebRequest.Create(url);
            myReq.Method = "POST";
           // myReq.ContentLength = data.Length;
            myReq.ContentType = "application/json; charset=UTF-8";

            string usernamePassword = "CoinTrendsChallenge" + ":" + "Y2IzM2Y5MjI5ODMzNDI0Zjk2MWE0YTY2MGJiNjQ0M2Q";

            UTF8Encoding enc = new UTF8Encoding();

            myReq.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(enc.GetBytes(usernamePassword)));

    /*
            using (Stream ds = myReq.GetRequestStream())
            {
                ds.Write(enc.GetBytes(data), 0, data.Length);
            }
            */

          //  WebResponse wr = myReq.GetResponse();
          //  Stream receiveStream = wr.GetResponseStream();
          //  StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
         //   string content = reader.ReadToEnd();
          //  Response.Write(content);
        }
    }
}