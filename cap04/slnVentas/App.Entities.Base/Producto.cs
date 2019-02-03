namespace App.Entities.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Script.Serialization;

    [Table("Producto")]
    public partial class Producto
    {
        public int ProductoID { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductoCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public int CategoriaID { get; set; }

        public int MarcaID { get; set; }

        public int UnidadMedidaID { get; set; }

        public decimal PrecioMayor { get; set; }

        public decimal PrecioMenor { get; set; }

        public decimal StockActual { get; set; }

        public decimal StockMinimo { get; set; }

        public bool Estado { get; set; }

        public Guid UsuarioCreador { get; set; }

        public DateTime FechaCreacion { get; set; }

        public Guid? UsuarioModificador { get; set; }

        public DateTime? FechaModificacion { get; set; }
        //[ScriptIgnore]
        public virtual Categoria Categoria { get; set; }
        //[ScriptIgnore]
        public virtual Marca Marca { get; set; }
        //[ScriptIgnore]
        public virtual UnidadMedida UnidadMedida { get; set; }
    }
}
