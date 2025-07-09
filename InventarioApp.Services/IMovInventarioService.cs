using InventarioApp.DataAccess;
using InventarioApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioApp.Services
{
    public interface IMovInventarioService
    {
        List<MovInventario> Consultar(DateTime? fechaInicio, DateTime? fechaFin, string tipoMovimiento, string nroDocumento);

        bool Insertar(MovInventario item);

        void Actualizar(MovInventario item);

        MovInventario ObtenerPorId(string codCia, string companiaVenta3, string almacenVenta, string tipoMovimiento, string tipoDocumento, string nroDocumento, string codItem2);

        bool Eliminar(string codCia, string companiaVenta3, string almacenVenta, string tipoMovimiento, string tipoDocumento, string nroDocumento, string codItem2);

    }

    public class MovInventarioService : IMovInventarioService
    {
        private readonly MovInventarioRepository repo = new MovInventarioRepository();

        public List<MovInventario> Consultar(DateTime? fechaInicio, DateTime? fechaFin, string tipoMovimiento, string nroDocumento)
            => repo.Consultar(fechaInicio, fechaFin, tipoMovimiento, nroDocumento);

        public bool Insertar(MovInventario item)
        {
            return repo.Insertar(item);
        }

        public void Actualizar(MovInventario item) => repo.Actualizar(item);

        public MovInventario ObtenerPorId(string codCia, string companiaVenta3, string almacenVenta, string tipoMovimiento, string tipoDocumento, string nroDocumento, string codItem2)
        {
            return repo.ObtenerPorId(codCia, companiaVenta3, almacenVenta, tipoMovimiento, tipoDocumento, nroDocumento, codItem2);
        }

        public bool Eliminar(string codCia, string companiaVenta3, string almacenVenta, string tipoMovimiento, string tipoDocumento, string nroDocumento, string codItem2)
        {
            return repo.Eliminar(codCia, companiaVenta3, almacenVenta, tipoMovimiento, tipoDocumento, nroDocumento, codItem2);
        }
    }
}
