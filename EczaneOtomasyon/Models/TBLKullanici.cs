namespace EczaneOtomasyon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLKullanici")]
    public partial class TBLKullanici
    {
        [Key]
        public int KID { get; set; }

        [StringLength(50)]
        public string TC { get; set; }

        [StringLength(50)]
        public string Sifre { get; set; }

        [StringLength(50)]
        public string KullaniciTip { get; set; }

        [StringLength(50)]
        public string AdSoyad { get; set; }

        [StringLength(50)]
        public string Cinsiyet { get; set; }

        [StringLength(50)]
        public string KullaniciKat { get; set; }
    }
}
