namespace RepositoryPattern_Youtube.Models
{
    public class Music
    {
        public string Id { get; set; }
        public string Title { get; set; }   
        public DateTime ReleaseDate { get; set; }
        public string Artist { get; set; }
        public int Rate { get; set; }
    }
}
