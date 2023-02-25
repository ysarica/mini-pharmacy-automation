namespace EczaneOtomasyon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLRecete")]
    public partial class TBLRecete
    {
        [Key]
        public int RctID { get; set; }

        public int? DoktorID { get; set; }

        public int? HastaID { get; set; }

        [StringLength(50)]
        public string Durum { get; set; }

        public string ReceteAciklama { get; set; }

        [StringLength(50)]
        public string Tarih { get; set; }
    }
}
