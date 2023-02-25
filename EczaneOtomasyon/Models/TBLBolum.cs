namespace EczaneOtomasyon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLBolum")]
    public partial class TBLBolum
    {
        [Key]
        public int BID { get; set; }

        [StringLength(150)]
        public string BAdi { get; set; }
    }
}
