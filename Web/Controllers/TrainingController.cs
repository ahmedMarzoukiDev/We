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
        QuestionService qs = null;
        AnswerService ans = null;
        public TrainingController()
        {
             ts = new TrainingService();
            ls = new LessonService();
            qs = new QuestionService();
            ans = new AnswerService();
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
        public ActionResult CreateTraining(TrainingModel t,LessonModel[] l,QuestionModel[] q,AnswerModel[] a)
        {
                

            Training lastTraining = new Training();
            lastTraining = ts.GetLastAdded();
            Lesson lastLesson = new Lesson();
            lastLesson = ls.GetLastAdded();
            Question lastQuestion = new Question();
            lastQuestion = qs.GetLastAdded();
            foreach (var itema in a)
            {

                Answer an = new Answer();
                an.questionId = lastQuestion.questionId + itema.questionNumber;
                an.description = itema.description;
                if (itema.isTrue==0)
                {
                    an.isTrue = true;
                }
                else
                {
                    an.isTrue = false;
                }
                
                an.editorId = 1;
                ans.Add(an);
            }
            
            // ADD QUESTIONS

            foreach (var itemq in q)
            {

                Question qu = new Question();
                qu.lessonId = lastLesson.lessonId + itemq.lessonNumber;
                qu.title = itemq.title;
                qu.description = itemq.description;
                qu.editorId = 1;
                qu.dateAdded = DateTime.Now;
                qs.Add(qu);
            }
            foreach (var item in l)
            {
                // ADD A LESSON
                Lesson le = new Lesson();
                le.trainingId = lastTraining.trainingId + 1;
                le.title = item.title;
                le.description = item.description;
                le.estimatedTime = item.estimatedTime;
                le.dateAdded = DateTime.Now;
                le.editorId = 1;
                ls.Add(le);

            }


            //ADD A TRAINING SESSION
            Training tr = new Training();
            tr.title = t.title;
            tr.description = t.description;
            tr.estimatedTime = t.estimatedTime;
            tr.dateAdded = DateTime.Now;
            tr.editorId = 1;
            //tr.categoryId = 1;
            tr.difficultyValue = t.difficultyValue;
            tr.difficultyDescription = t.difficultyDescription;
            ts.Add(tr);
            ts.Commit();
                ls.Commit();
                qs.Commit();
                ans.Commit();
                
           

            return RedirectToAction("Training");

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
