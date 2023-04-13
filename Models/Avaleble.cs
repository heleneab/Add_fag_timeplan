using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Example.Models
{
    public class Avaleble
    {
        public Avaleble() {}
        
        public Avaleble(DateTime date)
        {
            Date = date;
        }

        public int Id { get; set; }

     
        
        [DataType(DataType.Date)]
        [DisplayName("Birthdate")]
        public DateTime Date { get; set; }
    }
}
