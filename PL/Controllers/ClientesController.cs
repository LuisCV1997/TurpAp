using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            ML.Result result = new ML.Result();
            result = BL.Cliente.GetAll();
            return View(result);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ML.Cliente cliente = new ML.Cliente();
            return View(cliente);
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                result = BL.Cliente.Add(cliente);
                if (result.Correct ==true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

                
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            ML.Cliente cliente = new ML.Cliente();
            ML.Result result = BL.Cliente.GetById(id);
            foreach (var item in result.Objects)
            {
                
                cliente.Id = ((ML.Cliente)item).Id;
                cliente.Nombre = ((ML.Cliente)item).Nombre;
                cliente.Salario = ((ML.Cliente)item).Salario;
                cliente.RFC = ((ML.Cliente)item).RFC;
                cliente.Fecha_Control = ((ML.Cliente)item).Fecha_Control;
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(ML.Cliente cliente)
        {
            try
            {
                ML.Result result = BL.Cliente.Update(cliente);
                if (result.Correct == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            ML.Result result = BL.Cliente.Delete(id);
            if (result.Correct == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
        [HttpPost]
        public ActionResult Carga(ML.Result result)
        {

            if (result.file != null)
            {
                ML.Result resultEmpleados = BL.Cliente.Convert(result.file.FileName);
                if (resultEmpleados.Correct == true)
                {
                    return RedirectToAction("Index");
                }
                
            }
            return RedirectToAction("Index");
        }

        
    }
}
