using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Task2.Models {

    public class Participant {
        public Guid Id { get; set; }
        
        [Required (ErrorMessage = "Не заполнено имя участника")]
        [DisplayName("Имя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; init; } = null!;

        [DisplayName("Пол")]
        public string Gender { get; init; } = null!;

        [Required(ErrorMessage = "Заполниеть возраст участника")]
        [DisplayName("Возраст")]
        [Range(1, 110, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }

        [ExperienceLessThanAge(ErrorMessage = "Стаж не может быть больше возраста участника")]
        [Required(ErrorMessage = "Заполнеите стаж участника")]
        [DisplayName("Стаж")]
        [Range(0, 100, ErrorMessage = "Недопустимый стаж")]
        public int Experience { get; set; }
        
        [Required(ErrorMessage = "Не заполнен город проживания участника")]
        [DisplayName("Город")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 30 символов")]
        public string City { get; init; } = null!;

        public class ExperienceLessThanAgeAttribute : ValidationAttribute {
            protected override ValidationResult IsValid(object? value, ValidationContext validationContext) {
                var participant = (Participant)validationContext.ObjectInstance;
                return (participant.Experience > participant.Age ? new ValidationResult("Стаж не может быть больше возраста участника") : ValidationResult.Success)!;
            }
        }
    }

}