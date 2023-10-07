using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication11.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Product")]
    public class ProductsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [MaxLength(200)]
        public string nama_barang { get; set; }
        [MaxLength(50)]
        public string kode_barang { get; set; }
        public int jumlah_barang { get; set; }
        public DateTime? tanggal { get; set; }

    }
}
