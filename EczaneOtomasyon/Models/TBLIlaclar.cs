namespace EczaneOtomasyon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLIlaclar")]
    public partial class TBLIlaclar
    {
        [Key]
        public int IID { get; set; }

        [StringLength(150)]
        public string IlacAdi { get; set; }

        [StringLength(50)]
        public string IlacKategori { get; set; }
    }
}
