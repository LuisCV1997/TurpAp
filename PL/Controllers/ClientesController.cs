using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices.CompensatingResourceManager;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;


namespace PL.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/");
                var responseTask = client.GetAsync("Cliente/GetAll");
                responseTask.Wait();
                var result1 = responseTask.Result;

                if (result1.IsSuccessStatusCode)
                {
                    var task = result1.Content.ReadAsAsync<ML.Result>();
                    task.Wait();
                    foreach (var resultitem in task.Result.Objects)
                    {
                        ML.Cliente resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Cliente>(resultitem.ToString());
                        result.Objects.Add(resultItemList);
                    }
                }
            }
            return View(result);
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
            using (var clien = new HttpClient())
            {
                clien.BaseAddress = new Uri("https://localhost:44384/api/");

                var post = clien.PostAsJsonAsync<ML.Cliente>("cliente", cliente);

                var result = post.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View("Index");
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            ML.Cliente cliente = new ML.Cliente();
            var correct = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44384/api/");

                var resp = client.GetAsync("Cliente/GetById/" + id);
                resp.Wait();
                var result = resp.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    resp.Wait();

                    var productoJson = readTask.Result.Object.ToString();
                   ML.Cliente cliente1 = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Cliente>(productoJson);
                    cliente.Id = cliente1.Id;
                    cliente.RFC = cliente1.RFC;
                    cliente.Nombre = cliente1.Nombre;
                    cliente.Numero_Cliente = cliente1.Numero_Cliente;
                    cliente.Fecha_Control = cliente1.Fecha_Control;
                    cliente.Salario = cliente1.Salario;
                    correct = true;
                }
                else
                {
                    correct = false;
                    return View("Index");
                }
                if (correct == true)
                {
                    return View(cliente);
                }
                else
                {
                    return View("Index");
                }
                
            }
            
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(ML.Cliente cliente)
        {
            using (var clien = new HttpClient())
            {
                clien.BaseAddress = new Uri("https://localhost:44384/api/");
                var post = clien.PostAsJsonAsync<ML.Cliente>("Cliente/Update", cliente);
                post.Wait();
                var result = post.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
           using (var clien = new HttpClient())
            {
                clien.BaseAddress = new Uri("https://localhost:44384/api/");
                var post = clien.GetAsync("Cliente/Delete/" + id);
                var result = post.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
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

        public ActionResult TestFile(int id)
        {
            MemoryStream memoryStream = new MemoryStream();
            TextWriter tw = new StreamWriter(memoryStream);
            ML.Cliente cliente = new ML.Cliente();
            ML.Result result = BL.Cliente.GetById(id);
            foreach (var item in result.Objects)
            {
                cliente.RFC = ((ML.Cliente)item).RFC;
                cliente.Nombre = ((ML.Cliente)item).Nombre;
                cliente.Salario = ((ML.Cliente)item).Salario;
                cliente.Fecha_Control = ((ML.Cliente)item).Fecha_Control;
                cliente.Numero_Cliente = ((ML.Cliente)item).Numero_Cliente;
                tw.Write("RFC|" + cliente.RFC+"|");
                tw.Write("Nombre|" + cliente.Nombre + "|");
                tw.Write("Salario|" + cliente.Salario + "|");
                tw.Write("Fecha|" + cliente.Fecha_Control + "|");
                tw.Write("Numero de Cliente|" + cliente.Numero_Cliente + "|");
                tw.Flush();

            }


            var length = memoryStream.Length;
            tw.Close();
            var toWrite = new byte[length];
            Array.Copy(memoryStream.GetBuffer(), 0, toWrite, 0, length);

            return File(toWrite, "text/plain", "file.txt");
        }
        public FileStreamResult XMlFile(int id)
        {
            MemoryStream ms = new MemoryStream();
            XmlWriterSettings setings = new XmlWriterSettings();
            setings.OmitXmlDeclaration = true;
            setings.Indent = true;
            ML.Cliente cliente = new ML.Cliente();
            ML.Result result = BL.Cliente.GetById(id);
            foreach (var item in result.Objects)
            {
                cliente.RFC = ((ML.Cliente)item).RFC;
                cliente.Nombre = ((ML.Cliente)item).Nombre;
                cliente.Salario = ((ML.Cliente)item).Salario;
                cliente.Fecha_Control = ((ML.Cliente)item).Fecha_Control;
                cliente.Numero_Cliente = ((ML.Cliente)item).Numero_Cliente;
            }
            using (XmlWriter xw = XmlWriter.Create(ms,setings))
            {
                XDocument doc = new XDocument(
                    new XElement("Datos",
                    new XElement("RFC" , cliente.RFC),
                    new XElement("Empleado", cliente.Numero_Cliente),
                    new XElement("Nombre", cliente.Nombre),
                    new XElement("Fecha_de_control", cliente.Fecha_Control.ToString()),
                    new XElement("Salario", cliente.Salario.ToString()))
                    );
                doc.WriteTo(xw);
            }
            ms.Position = 0;
            return File(ms, "text/Xml", "Cleinte.xml");


        }



    }


}

