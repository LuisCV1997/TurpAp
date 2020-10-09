﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TurboPacEntities : DbContext
    {
        public TurboPacEntities()
            : base("name=TurboPacEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cliente> Clientes { get; set; }
    
        public virtual ObjectResult<Nullable<decimal>> SP_Add_Cliente(string rFC, string nombre, Nullable<System.DateTime> fecha, Nullable<decimal> salario, string numeroC)
        {
            var rFCParameter = rFC != null ?
                new ObjectParameter("RFC", rFC) :
                new ObjectParameter("RFC", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            var salarioParameter = salario.HasValue ?
                new ObjectParameter("Salario", salario) :
                new ObjectParameter("Salario", typeof(decimal));
    
            var numeroCParameter = numeroC != null ?
                new ObjectParameter("NumeroC", numeroC) :
                new ObjectParameter("NumeroC", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("SP_Add_Cliente", rFCParameter, nombreParameter, fechaParameter, salarioParameter, numeroCParameter);
        }
    
        public virtual int SP_Delete_Cliente(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Delete_Cliente", idParameter);
        }
    
        public virtual ObjectResult<SP_GetAll_Cliente_Result> SP_GetAll_Cliente()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetAll_Cliente_Result>("SP_GetAll_Cliente");
        }
    
        public virtual ObjectResult<SP_GetById_Cliente_Result> SP_GetById_Cliente(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetById_Cliente_Result>("SP_GetById_Cliente", idParameter);
        }
    
        public virtual int SP_Update_Cliente(string rFC, string nombre, Nullable<System.DateTime> fecha, Nullable<decimal> salario, Nullable<int> id, string numeroC)
        {
            var rFCParameter = rFC != null ?
                new ObjectParameter("RFC", rFC) :
                new ObjectParameter("RFC", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            var salarioParameter = salario.HasValue ?
                new ObjectParameter("Salario", salario) :
                new ObjectParameter("Salario", typeof(decimal));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var numeroCParameter = numeroC != null ?
                new ObjectParameter("NumeroC", numeroC) :
                new ObjectParameter("NumeroC", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Update_Cliente", rFCParameter, nombreParameter, fechaParameter, salarioParameter, idParameter, numeroCParameter);
        }
    
        public virtual int SP_Insert_Cliente_Carga()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Insert_Cliente_Carga");
        }
    
        public virtual int Carga_add(System.Data.DataTable data)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Carga_add");
        }
    }
}
