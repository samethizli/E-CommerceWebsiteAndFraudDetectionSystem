using System.ComponentModel.DataAnnotations;

namespace Ekitap.Core.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adı"), Required(ErrorMessage = "{0} Alanı Boş Geçilemez!")]
        public string Name { get; set; }
        [Display(Name = "Soyadı"), Required(ErrorMessage = "{0} Alanı Boş Geçilemez!")]
        public string Surname { get; set; }
        [Display(Name = "E-Mail")]
        public string? Email { get; set; }
        [Display(Name = "Telefon Numarası")]
        public string? Phone { get; set; }
        [Display(Name = "Mesaj"), Required(ErrorMessage = "{0} Alanı Boş Geçilemez!")]
        public string Message { get; set; }
        [Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false), Required(ErrorMessage = "{0} Alanı Boş Geçilemez!")]

        public DateTime CreateDate { get; set; } = DateTime.Now;

    }
}
