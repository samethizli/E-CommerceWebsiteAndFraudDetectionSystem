using System.ComponentModel.DataAnnotations;

namespace Ekitap.Core.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adı")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
        [Display(Name = "Resim")]
        public string? Image { get; set; }
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
        [Display(Name = "Ürün Kodu")]
        public string ProductCode { get; set; }
        [Display(Name = "Stok")]
        public int Stock { get; set; }
        [Display(Name = "ISBN")]
        [StringLength(13, MinimumLength = 10)]
        public string ISBN { get; set; }
        [Display(Name = "Aktif?")]
        public bool isActive { get; set; }
        [Display(Name = "Anasayfa")]
        public bool isHome { get; set; }
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        [Display(Name = "Kategori")]
        public Category? Category { get; set; }
        [Display(Name = "Yayınevi")]
        public int YayinEviId { get; set; }
        [Display(Name = "Yayınevi")]
        public PublishingHouse? YayinEvi { get; set; }
        [Display(Name = "Yazar")]
        public int YazarId { get; set; }
        [Display(Name = "Yazar")]
        public Writer? Yazar { get; set; }
        [Display(Name = "Sıra No")]
        public int OrderNo { get; set; }
        [Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;    

    }
}
