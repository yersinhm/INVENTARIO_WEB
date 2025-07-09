using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace InventarioApp.Entities
{
    public class MovInventario : IValidatableObject
    {
        public string CodCia { get; set; }
        public string CompaniaVenta3 { get; set; }
        public string AlmacenVenta { get; set; }
        public string TipoMovimiento { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string CodItem2 { get; set; }
        public string Proveedor { get; set; }
        public string AlmacenDestino { get; set; }
        public int? Cantidad { get; set; }
        public string DocRef1 { get; set; }
        public string DocRef2 { get; set; }
        public string DocRef3 { get; set; }
        public string DocRef4 { get; set; }
        public string DocRef5 { get; set; }
        public DateTime? FechaTransaccion { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var camposRequeridos = new List<string>
            {
                nameof(CodCia),
                nameof(CompaniaVenta3),
                nameof(AlmacenVenta),
                nameof(TipoMovimiento),
                nameof(TipoDocumento),
                nameof(NroDocumento),
                nameof(CodItem2)
            };

            foreach (var campo in camposRequeridos)
            {
                PropertyInfo propiedad = GetType().GetProperty(campo);
                object valor = propiedad?.GetValue(this);

                if (valor == null || (valor is string str && string.IsNullOrWhiteSpace(str)))
                {
                    yield return new ValidationResult(
                        $"El campo {campo} es obligatorio.",
                        new[] { campo }
                    );
                }
            }
        }
    }
}