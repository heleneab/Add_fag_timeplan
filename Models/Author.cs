using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Example.Models
{
    public class Author
    {
        public Author() {}
        
        public Author(string firstName, string fag)
        {
            FirstName = firstName;
            Fag = fag;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("First name")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        [DisplayName("Fag")]
        public string Fag { get; set; } = string.Empty;
        
        

       
    }
}
