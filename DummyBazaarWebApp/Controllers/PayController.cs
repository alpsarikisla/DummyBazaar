using DummyBazaarWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;


namespace DummyBazaarWebApp.Controllers
{
    public class PayModel
    {
        public string cartNumber { get; set; }
        public string ReqMon { get; set; }
        public string ReqYear { get; set; }
        public string cvc { get; set; }
        public decimal Price { get; set; }
        public string SaticiKodu { get; set; }
        public string SaticiSifre { get; set; }
    }
    public class PayController : Controller
    {
        DummyBazaarModel db = new DummyBazaarModel();
        // GET: Pay
        [HttpGet]
        public ActionResult Index(int? id)
        {
            Product p = db.Products.Find(id);
            return View(p);
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DoPay(string Surname, string Name, string ReqMon, string ReqYear, string cvc, string cartNumber)
        {
            Product p = db.Products.Find(5);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44348/API/Pay");
                PayModel pm = new PayModel();
                pm.cartNumber = cartNumber;
                pm.Price = p.Price;
                pm.cvc = cvc;
                pm.ReqMon = ReqMon;
                pm.ReqYear = ReqYear;
                pm.SaticiKodu = "258964";
                pm.SaticiSifre = "a?lg52";
                //Install Package Microsoft.AspNet.WebApi.Client
                var postTask = client.PostAsJsonAsync<PayModel>("Pay", pm);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var stringResp = result.Content.ReadAsStringAsync();
                    string resultCode = stringResp.Result;
                    if (resultCode == "\"101\"")
                    {
                        TempData["success"] = "Ödeme Başarı ile gerçekleşmiştir";
                    }
                    else if(resultCode == "\"701\"")
                    {
                        TempData["mesaj"] = "Kart Numarası Hatalı";
                    }
                }
            }
            return RedirectToAction("Index","Pay", new { id = p.ID});
        }
        //public async Task<ActionResult> DoPay(string Surname,string Name, string ReqMon, string ReqYear, string cvc, string cartNumber)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        Product p = db.Products.Find(5);
        //        //client.BaseAddress = new Uri("https://localhost:44348/API/Pay");

        //        var values = new Dictionary<string, string>
        //        {
        //            {"SaticiKodu","258964"},
        //            {"SaticiSifre", "a?lg52" },
        //            {"KartNo",cartNumber },
        //            {"SonkullanmaAy",ReqMon },
        //            {"SonKullamaYil",ReqYear },
        //            {"CVCKodu",cvc },
        //            {"Bakiye",p.Price.ToString() }
        //        };
        //        var content = new FormUrlEncodedContent(values);
        //        var response = await client.PostAsync("https://localhost:44348/API/Pay", content);
        //        var responseString = await response.Content.ReadAsStringAsync();
        //    }
        //    return RedirectToAction("");
        //}
    }
}