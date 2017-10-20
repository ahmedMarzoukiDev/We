using Domain.entities;
using Services.trainingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class TrainingController : Controller
    {
        TrainingService ts = null;
        LessonService ls = null;
        public TrainingController()
        {
             ts = new TrainingService();
            ls = new LessonService();
        }

        // GET: Training/Training
        public ActionResult Training()
        {
            return View();
        }

        // GET: Training/CreateTraining
        public ActionResult CreateTraining()
        {
            return View();
        }
        // POST: Training/CreateTraining
        [HttpPost]
        public ActionResult CreateTraining(TrainingModel t,LessonModel[] l)
        {
            //Json(t, JsonRequestBehavior.AllowGet);
           
                Training tr = new Training();
                tr.title = t.title;
                tr.description = t.description;
                tr.estimatedTime = t.estimatedTime;
                tr.dateAdded = DateTime.Now;
                tr.editorId = 1;
                //tr.categoryId = 1;
                tr.difficultyValue = t.difficultyValue;
                tr.difficultyDescription = t.difficultyDescription;

            Training lastTraining = new Training();
            lastTraining = ts.GetLastAdded();
            foreach (var item in l)
            {
                Lesson le = new Lesson();
                le.trainingId = lastTraining.trainingId+1;
                le.title = item.title;
                le.description = item.description;
                le.estimatedTime = item.estimatedTime;
                le.dateAdded = DateTime.Now;
                le.editorId = 1;
                ls.Add(le);
               
            }
                ts.Add(tr);
                ts.Commit();
                ls.Commit();
                RedirectToAction("Training");
           

            return View();
            
        }

        // GET: Training/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Training/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Training/Create
        [HttpPost]
        public ActionResult Create(TrainingModel t)
        {
                return View();
                
        }

        // GET: Training/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Training/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Training/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Training/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
