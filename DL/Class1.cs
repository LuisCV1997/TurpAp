using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;




namespace DL
{
    public class Class1
    {
        public static string Conexion()
        {
            String cadena = "Data Source=DESKTOP-CFNITN1/SQLEXPRESS;Initial Catalog=TurboPac;Integrated Security=True";
            return cadena;
        }
        public static SqlCommand CreateCommand(string Query, SqlConnection contex)
        {
            contex.Open();
            SqlCommand cmd = new SqlCommand(Query, contex);
            return cmd;
        }
        public static int ExacuteCommand(SqlCommand cmd)
        {
            int RowsAffected = cmd.ExecuteNonQuery();
            return RowsAffected;
        }
        public static DataTable ExecuteCommandSelect(SqlCommand cmd)
        {
            DataTable productos = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(productos);
            return productos;
        }
        public static DataTable ExecuteCommandSelectDetalleVenta(SqlCommand cmd)
        {
            DataTable DetalleVenta = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(DetalleVenta);
            return DetalleVenta;

        }
        public static DataTable ExecuteCommandSelectVentas(SqlCommand cmd)
        {
            DataTable Ventas = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(Ventas);
            return Ventas;

        }

        public static DataTable ExecuteCommandSelectSubcategoria(SqlCommand cmd)
        {
            DataTable subcategoria = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(subcategoria);
            return subcategoria;
        }
    }
}
