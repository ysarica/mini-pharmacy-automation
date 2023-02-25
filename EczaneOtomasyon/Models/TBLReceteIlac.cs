namespace EczaneOtomasyon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLReceteIlac")]
    public partial class TBLReceteIlac
    {
        [Key]
        public int RIlacID { get; set; }

        public int? ReceteID { get; set; }

        public int? Adet { get; set; }
        public int? IlacID { get; set; }

    }
}
