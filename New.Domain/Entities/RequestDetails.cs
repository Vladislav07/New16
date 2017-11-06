using System.ComponentModel.DataAnnotations;

namespace New.Domain.Entities
{
    public class RequestDetails
    {
        [Required(ErrorMessage = "Укажите как вас зовут")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите контактный телефон")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
       

        [Required(ErrorMessage = "Укажите адрес электронной почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Укажите страну")]
        public string Message { get; set; }

       // public bool GiftWrap { get; set; }
    }
}