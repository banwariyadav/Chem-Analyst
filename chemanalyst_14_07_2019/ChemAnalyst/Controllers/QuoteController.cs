using ChemAnalyst.DAL;
using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemAnalyst.Controllers
{
    public class QuoteController : Controller
    {
        // GET: Quote
            QuoteDataStore Obj = new QuoteDataStore();
            // GET: AdvisorySolutions
            public ActionResult Quote()
            {
              
                return View("Quote");
            }

            // GET: NewsAndDeals
            public ActionResult GetQuoteList()
            {
                return View("Quote");
            }
            public JsonResult QuoteList()
            {

                List<SA_Quote> NewsList = Obj.GetQuoteList();

                return Json(new { data = NewsList }, JsonRequestBehavior.AllowGet);

            }
            public ActionResult AddQuote()
            {
                var Model = new SA_Quote();
                return View(Model);

            }
            public ActionResult SaveQuote(SA_Quote UserNews)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);

                        var path = Path.Combine(Server.MapPath("~/ProductImages"), fileName);
                        file.SaveAs(path);
                        UserNews.QuoteImg = fileName;
                    }
                }
                UserNews.CreatedTime = DateTime.Now;
                //AdvisoryDataStore Obj = new AdvisoryDataStore();
                if (UserNews.id == 0)
                {
                    Obj.AddQuote(UserNews);
                }
                else
                {
                    Obj.EditQuote(UserNews);
                }
                return RedirectToAction("Quote");
            }


            public ActionResult EditQuote(int id)
            {
                SA_Quote obj = Obj.GetQuoteByid(id);
                return View("AddQuote", obj);
            }
            public ActionResult DeleteQuote(int id)
            {
                if (Obj.DeleteQuote(id) == true)
                {
                return RedirectToAction("Quote");
            }
                else
                {
                    return View("ErrorEventArgs");
                }
            }
        }
    }

