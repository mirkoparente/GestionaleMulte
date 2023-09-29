using GestionaleMulte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionaleMulte.Controllers
{
        [Authorize(Users = "admin")]
    public class ViolazioniController : Controller
    {

        // GET: Violazioni
        public ActionResult ListaViolazioni()
        {
            List<Violazioni> list = new List<Violazioni>();
            list = Violazioni.AllVio();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Violazioni v)
        {
            Violazioni.AddVio(v);
            return RedirectToAction("ListaViolazioni", "Violazioni");
        }

        public ActionResult Edit(int id)
        {
            Violazioni vi= new Violazioni();
            vi = Violazioni.DettaglioP(id);
            return View(vi);
        }

        [HttpPost]
        public ActionResult Edit(Violazioni v)
        {
            Violazioni.ModificaVio(v);
            return RedirectToAction("ListaViolazioni","Violazioni");
        }

        public ActionResult Delete(int id)
        {
            Violazioni.Delete(id);
            return RedirectToAction("ListaViolazioni","Violazioni");
        }
    }
}