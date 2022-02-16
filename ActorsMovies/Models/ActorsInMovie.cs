namespace ActorsMovies.Models
{
    public class ActorsInMovie
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public Actor Actors { get; set; }
    }
}
