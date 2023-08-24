using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cascadedropdown.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress, ErrorMessage ="E-mail is not Valid")]
        public string EmailId { get; set; }


        [Required]
        [ForeignKey("Country")]
        [DisplayName("Country")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }



        [Required]
        [ForeignKey("City")]
        [DisplayName("City")]
        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}
