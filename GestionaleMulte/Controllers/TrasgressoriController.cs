using GestionaleMulte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GestionaleMulte.Controllers
{
    [Authorize(Users ="admin")]
    public class TrasgressoriController : Controller
    {
        // GET: Trasgressori
        public ActionResult ListaTrasgressori()
        {
            List<Trasgressori> tra = new List<Trasgressori>();
            tra = Trasgressori.ListTrasg();
            return View(tra);
        }

        public ActionResult Edit(int id)
        {
            Trasgressori tr=new Trasgressori();
            tr=Trasgressori.DettaglioP(id);

            return View(tr);
        }

        [HttpPost]
        public ActionResult Edit(Trasgressori t)
        {

            Trasgressori.ModificaTrasg(t);
            return RedirectToAction("ListaTrasgressori","Trasgressori");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Trasgressori t)
        {
            Trasgressori.AddTrasg(t);
            return RedirectToAction("ListaTrasgressori");
        }


        public ActionResult Delete(int id) { 
        
            Trasgressori.Delete(id); 
            return View("ListaTrasgressori");
        }
    }
}