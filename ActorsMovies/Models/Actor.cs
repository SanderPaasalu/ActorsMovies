using System.ComponentModel.DataAnnotations;

namespace ActorsMovies.Models
{
    public class Actor
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public ICollection<ActorsInMovie> ActorsInMovies { get; set; }

    }
}
