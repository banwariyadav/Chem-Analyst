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
    public class JobController : Controller
    {
        JobDataStore Obj = new JobDataStore();
        // GET: Job
        public ActionResult Index()
        {
            return View();
        }
            
            // GET: AdvisorySolutions
            public ActionResult Job()
            {
                JobDataStore Obj = new JobDataStore();
                return View("Job");
            }

            // GET: NewsAndDeals
            public ActionResult GetJobList()
            {
                return View("Job");
            }
            public JsonResult JobList()
            {

                List<SA_Job> NewsList = Obj.GetJobList();

                return Json(new { data = NewsList }, JsonRequestBehavior.AllowGet);

            }
            public ActionResult AddJob()
            {
                var Model = new SA_Job();
                return View(Model);

            }
            public ActionResult SaveJob(SA_Job UserNews)
            {
                UserNews.CreatedTime = DateTime.Now;
         
                if (UserNews.id == 0)
                {
                    Obj.AddJob(UserNews);
                }
                else
                {
                    Obj.EditJob(UserNews);
                }
                return RedirectToAction("Job");
            }


            public ActionResult EditJob(int id)
            {
                SA_Job obj = Obj.GetJobByid(id);
                return View("AddJob", obj);
            }
            public ActionResult DeleteJob(int id)
            {
                if (Obj.DeleteJob(id) == true)
                {
                    return View("Job");
                }
                else
                {
                    return View("ErrorEventArgs");
                }
            }
        }
    }

