using System.ComponentModel.DataAnnotations;

namespace Ekitap.Core.Entities
{
    public class Writer :IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adı")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
        [Display(Name = "Resim")]
        public string? Image { get; set; }
        [Display(Name = "Aktif?")]
        public bool isActive { get; set; }
        [Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Display(Name = "Sıra No")]
        public int OrderNo { get; set; }
        public IList<Product>? Products { get; set; }


    }
}
