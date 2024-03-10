using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле \"Имя\" обязательно к заполнению!"), MinLength(2, ErrorMessage = "Имя не может быть меньше двух символов")]
        [DisplayName("Имя")]
        public string? FirstName { get; set; }
        [Required( ErrorMessage = "Поле \"Фамилия\" обязательно к заполнению!"), MinLength(2, ErrorMessage = "Имя не может быть меньше двух символов")]
        [DisplayName("Фамилия")]
        public string? LastName { get; set;}
        [Required(ErrorMessage = "Поле \"Электронная почта\" обязательно к заполнению!"), EmailAddress]
        [DisplayName("Электронная почта")]
        public string? Email { get; set; }
    }
}
