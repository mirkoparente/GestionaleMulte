using GestionaleMulte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace GestionaleMulte.Controllers
{
        [Authorize(Users = "admin")]
    public class VerbaliController : Controller
    {

        // GET: Verbali
        public ActionResult Create()
        {
         List< Violazioni>listavi=Violazioni.AllVio();
            
         List<SelectListItem> list = new List<SelectListItem>();

            foreach(Violazioni v in listavi)
            {
                SelectListItem item = new SelectListItem { Text=v.Descrizione, Value=v.IdViolazioni.ToString()};
                list.Add(item);
            }
            ViewBag.listaViolazioni = list;

            List<Trasgressori> listatra = Trasgressori.ListTrasg();

            List<SelectListItem> list1 = new List<SelectListItem>();
            foreach(Trasgressori tr in listatra)
            {
                SelectListItem item1 = new SelectListItem { Text = $"{tr.Nome} {tr.Cognome}", Value = tr.IdTrasgressori.ToString() };
                list1.Add(item1);
            }
            ViewBag.listaTrasgressori=list1;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Verbali v,int list,int list1) {
            v.IdViolazione=list;
            v.IdAnagrafica=list1;
            Verbali.AddVerbale(v);
            return RedirectToAction("ListaVerbali","Verbali");
        
        }


        public ActionResult ListaVerbali()
        {
            List<Verbali> list = new List<Verbali>();
            list=Verbali.ListVerbali();
            return View(list);
        }


        public ActionResult GetPartial()
        {
            List<Partial> v= new List<Partial>();
            v=Partial.joinTrasg();
            return PartialView("GetPartial",v);
        } 
        
        public ActionResult GetPartial1()
        {
            List<Partial> v= new List<Partial>();
            v=Partial.joinPunti();
            return PartialView("GetPartial1",v);
        }
    }
}