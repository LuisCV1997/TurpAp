using LinqKit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Cliente
    {
        public static CommandType CommandType { get; private set; }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            
            try
            {
                using (DL.TurboPacEntities context = new DL.TurboPacEntities())
                {
                    var lista = context.SP_GetAll_Cliente();
                    foreach (var item in lista.ToList())
                    {
                        ML.Cliente cliente = new ML.Cliente();
                        cliente.Id = item.Id;
                        cliente.Nombre = item.Nombre;
                        cliente.RFC = item.RFC;
                        cliente.Salario = item.Salario;
                        cliente.Fecha_Control = item.Fecha_Control;
                        cliente.Numero_Cliente = item.Numero_Cliente;
                        result.Objects.Add(cliente);
                        
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {

                result.ex = ex.InnerException;
                result.Messages = ex.Message;
                result.Correct = false;
            }


            return result;
        }
        public  static ML.Result Add(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TurboPacEntities context = new DL.TurboPacEntities())
                {
                    int? id = (int)context.SP_Add_Cliente(cliente.RFC, cliente.Nombre, cliente.Fecha_Control, cliente.Salario,cliente.Numero_Cliente).SingleOrDefault();

                    if (id.HasValue)
                    {
                        result.Correct = true;
                    }
                   

                    
                }
            }
            catch (Exception ex)
            {
                result.ex = ex.InnerException;
                result.Messages = ex.Message;
                result.Correct = false;
                
            }
            return result;
        }
        public static ML.Result Update(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TurboPacEntities context = new DL.TurboPacEntities())
                {
                    var respueta = context.SP_Update_Cliente(cliente.RFC, cliente.Nombre, cliente.Fecha_Control, cliente.Salario, cliente.Id,cliente.Numero_Cliente);
                    
                    
                        result.Correct = true;
                    
                }
            }
            catch (Exception ex)
            {
                result.ex = ex.InnerException;
                result.Messages = ex.Message;
                result.Correct = false;
            }
            return result;
        }
        public static  ML.Result Delete(int id)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TurboPacEntities context = new DL.TurboPacEntities())
                {
                    var delete = context.SP_Delete_Cliente(id);
                    result.Correct = false;
                }
            }
            catch (Exception ex)
            {
                result.ex = ex.InnerException;
                result.Messages = ex.Message;
                result.Correct = false;
            }
            return result;
        }
        public static ML.Result GetById(int id)
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            try
            {
                using (DL.TurboPacEntities context = new DL.TurboPacEntities())
                {
                    var list = context.SP_GetById_Cliente(id);
                    foreach (var item in list)
                    {
                        ML.Cliente cliente = new ML.Cliente();
                        cliente.Id = item.Id;
                        cliente.Nombre = item.Nombre;
                        cliente.Salario = item.Salario;
                        cliente.RFC = item.RFC;
                        cliente.Fecha_Control = item.Fecha_Control;
                        cliente.Numero_Cliente = item.Numero_Cliente;
                        result.Objects.Add(cliente);
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.ex = ex.InnerException;
                result.Messages = ex.Message;
                result.Correct = false;
            }
            return result;
        }
        public static ML.Result Convert (string file)
        { 
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            String[] columnas = null;          

            var lines = File.ReadAllLines(file);
            try
            {

           
            if (lines.Count() > 0)
            {
                columnas = lines[0].Split(new char[] { ',' });                

                for (int i = 1; i < lines.Count(); i++)
                {
                    string[] values = lines[i].Split(new char[] { '|' });
                    ML.Cliente cliente = new ML.Cliente();
                    cliente.RFC = values[0];
                    cliente.Numero_Cliente = values[1];
                    cliente.Nombre = values[2];
                    if (values[3] != "")
                    {
                        string _fecha = values[3];
                        string _fehca_parse = _fecha.Replace("/", "-");

                        cliente.Fecha_Control = DateTime.ParseExact(_fehca_parse, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
                    }
                  
                    cliente.Salario = decimal.Parse(values[4]);
                    Add(cliente);
                }
                result.Correct = true;
            }
            }
            catch (Exception ex)
            {
                result.ex = ex.InnerException;
                result.Messages = ex.Message;
                result.Correct = false;
            }

            return result;
        }
        public static ML.Result AddCarga(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();
         
            try
            {
                using (DL.TurboPacEntities context = new DL.TurboPacEntities())
                {
                    context.SP_Insert_Cliente_Carga();
                }

            }
            catch (Exception ex)
            {

                result.ex = ex.InnerException;
                result.Messages = ex.Message;
                result.Correct = false;
            }

            return result;
        }
        public static ML.Result GEtById2(int id)
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            try
            {
                using (DL.TurboPacEntities context = new DL.TurboPacEntities())
                {
                    var list = context.SP_GetById_Cliente(id);
                    foreach (var item in list)
                    {
                        ML.Cliente cliente = new ML.Cliente();
                        cliente.Id = item.Id;
                        cliente.Nombre = item.Nombre;
                        cliente.Salario = item.Salario;
                        cliente.RFC = item.RFC;
                        cliente.Fecha_Control = item.Fecha_Control;
                        cliente.Numero_Cliente = item.Numero_Cliente;
                        result.Object = cliente;
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.ex = ex.InnerException;
                result.Messages = ex.Message;
                result.Correct = false;
            }
            return result;
        }
    }
}
