using InventarioApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace InventarioApp.DataAccess
{
    public class MovInventarioRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<MovInventario> Consultar(DateTime? fechaInicio, DateTime? fechaFin, string tipoMovimiento, string nroDocumento)
        {
            var lista = new List<MovInventario>();

            tipoMovimiento = string.IsNullOrWhiteSpace(tipoMovimiento) ? null : tipoMovimiento;
            nroDocumento = string.IsNullOrWhiteSpace(nroDocumento) ? null : nroDocumento;

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_Consultar_MovInventario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaInicio", (object)fechaInicio ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaFin", (object)fechaFin ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TipoMovimiento", (object)tipoMovimiento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NroDocumento", (object)nroDocumento ?? DBNull.Value);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new MovInventario
                        {
                            CodCia = reader["COD_CIA"].ToString(),
                            CompaniaVenta3 = reader["COMPANIA_VENTA_3"].ToString(),
                            AlmacenVenta = reader["ALMACEN_VENTA"].ToString(),
                            TipoMovimiento = reader["TIPO_MOVIMIENTO"].ToString(),
                            TipoDocumento = reader["TIPO_DOCUMENTO"].ToString(),
                            NroDocumento = reader["NRO_DOCUMENTO"].ToString(),
                            CodItem2 = reader["COD_ITEM_2"].ToString(),
                            Proveedor = reader["PROVEEDOR"]?.ToString(),
                            AlmacenDestino = reader["ALMACEN_DESTINO"]?.ToString(),
                            Cantidad = reader["CANTIDAD"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["CANTIDAD"]),
                            DocRef1 = reader["DOC_REF_1"]?.ToString(),
                            DocRef2 = reader["DOC_REF_2"]?.ToString(),
                            DocRef3 = reader["DOC_REF_3"]?.ToString(),
                            DocRef4 = reader["DOC_REF_4"]?.ToString(),
                            DocRef5 = reader["DOC_REF_5"]?.ToString(),
                            FechaTransaccion = reader["FECHA_TRANSACCION"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["FECHA_TRANSACCION"])
                        });
                    }
                }
            }
            return lista;
        }

        public bool Insertar(MovInventario entidad)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_Insertar_MovInventario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@COD_CIA", entidad.CodCia);
                cmd.Parameters.AddWithValue("@COMPANIA_VENTA_3", entidad.CompaniaVenta3);
                cmd.Parameters.AddWithValue("@ALMACEN_VENTA", entidad.AlmacenVenta);
                cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", entidad.TipoMovimiento);
                cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", entidad.TipoDocumento);
                cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", entidad.NroDocumento);
                cmd.Parameters.AddWithValue("@COD_ITEM_2", entidad.CodItem2);
                cmd.Parameters.AddWithValue("@PROVEEDOR", string.IsNullOrEmpty(entidad.Proveedor) ? (object)DBNull.Value : entidad.Proveedor);
                cmd.Parameters.AddWithValue("@ALMACEN_DESTINO", string.IsNullOrEmpty(entidad.AlmacenDestino) ? (object)DBNull.Value : entidad.AlmacenDestino);
                cmd.Parameters.AddWithValue("@CANTIDAD", entidad.Cantidad.HasValue ? (object)entidad.Cantidad : DBNull.Value);
                cmd.Parameters.AddWithValue("@DOC_REF_1", string.IsNullOrEmpty(entidad.DocRef1) ? (object)DBNull.Value : entidad.DocRef1);
                cmd.Parameters.AddWithValue("@DOC_REF_2", string.IsNullOrEmpty(entidad.DocRef2) ? (object)DBNull.Value : entidad.DocRef2);
                cmd.Parameters.AddWithValue("@DOC_REF_3", string.IsNullOrEmpty(entidad.DocRef3) ? (object)DBNull.Value : entidad.DocRef3);
                cmd.Parameters.AddWithValue("@DOC_REF_4", string.IsNullOrEmpty(entidad.DocRef4) ? (object)DBNull.Value : entidad.DocRef4);
                cmd.Parameters.AddWithValue("@DOC_REF_5", string.IsNullOrEmpty(entidad.DocRef5) ? (object)DBNull.Value : entidad.DocRef5);
                cmd.Parameters.AddWithValue("@FECHA_TRANSACCION", entidad.FechaTransaccion.HasValue ? (object)entidad.FechaTransaccion : DBNull.Value);

                conn.Open();
                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }

        public void Actualizar(MovInventario item)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_Actualizar_MovInventario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@COD_CIA", item.CodCia);
                cmd.Parameters.AddWithValue("@COMPANIA_VENTA_3", item.CompaniaVenta3);
                cmd.Parameters.AddWithValue("@ALMACEN_VENTA", item.AlmacenVenta);
                cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", item.TipoMovimiento);
                cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", item.TipoDocumento);
                cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", item.NroDocumento);
                cmd.Parameters.AddWithValue("@COD_ITEM_2", item.CodItem2);
                cmd.Parameters.AddWithValue("@PROVEEDOR", item.Proveedor ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ALMACEN_DESTINO", item.AlmacenDestino ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CANTIDAD", item.Cantidad.HasValue ? (object)item.Cantidad.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@DOC_REF_1", item.DocRef1 ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DOC_REF_2", item.DocRef2 ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DOC_REF_3", item.DocRef3 ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DOC_REF_4", item.DocRef4 ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DOC_REF_5", item.DocRef5 ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@FECHA_TRANSACCION", item.FechaTransaccion.HasValue ? (object)item.FechaTransaccion.Value : DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public MovInventario ObtenerPorId(string codCia, string companiaVenta3, string almacenVenta, string tipoMovimiento, string tipoDocumento, string nroDocumento, string codItem2)
        {
            MovInventario item = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_Obtener_MovInventario_PorId", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@COD_CIA", codCia);
                cmd.Parameters.AddWithValue("@COMPANIA_VENTA_3", companiaVenta3);
                cmd.Parameters.AddWithValue("@ALMACEN_VENTA", almacenVenta);
                cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", tipoMovimiento);
                cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", tipoDocumento);
                cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", nroDocumento);
                cmd.Parameters.AddWithValue("@COD_ITEM_2", codItem2);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        item = new MovInventario
                        {
                            CodCia = reader["COD_CIA"].ToString(),
                            CompaniaVenta3 = reader["COMPANIA_VENTA_3"].ToString(),
                            AlmacenVenta = reader["ALMACEN_VENTA"].ToString(),
                            TipoMovimiento = reader["TIPO_MOVIMIENTO"].ToString(),
                            TipoDocumento = reader["TIPO_DOCUMENTO"].ToString(),
                            NroDocumento = reader["NRO_DOCUMENTO"].ToString(),
                            CodItem2 = reader["COD_ITEM_2"].ToString(),
                            Proveedor = reader["PROVEEDOR"]?.ToString(),
                            AlmacenDestino = reader["ALMACEN_DESTINO"]?.ToString(),
                            Cantidad = reader["CANTIDAD"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["CANTIDAD"]),
                            DocRef1 = reader["DOC_REF_1"]?.ToString(),
                            DocRef2 = reader["DOC_REF_2"]?.ToString(),
                            DocRef3 = reader["DOC_REF_3"]?.ToString(),
                            DocRef4 = reader["DOC_REF_4"]?.ToString(),
                            DocRef5 = reader["DOC_REF_5"]?.ToString(),
                            FechaTransaccion = reader["FECHA_TRANSACCION"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["FECHA_TRANSACCION"])
                        };
                    }
                }
            }
            return item;
        }

        public bool Eliminar(string codCia, string companiaVenta3, string almacenVenta, string tipoMovimiento, string tipoDocumento, string nroDocumento, string codItem2)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_Eliminar_MovInventario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@COD_CIA", codCia);
                cmd.Parameters.AddWithValue("@COMPANIA_VENTA_3", companiaVenta3);
                cmd.Parameters.AddWithValue("@ALMACEN_VENTA", almacenVenta);
                cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", tipoMovimiento);
                cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", tipoDocumento);
                cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", nroDocumento);
                cmd.Parameters.AddWithValue("@COD_ITEM_2", codItem2);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

    }
}
