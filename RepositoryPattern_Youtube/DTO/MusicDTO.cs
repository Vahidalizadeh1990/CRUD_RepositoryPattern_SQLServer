namespace RepositoryPattern_Youtube.DTO
{
    public class MusicDTO
    {
        // To keep the DTO simple, we are going to use Id inside the Music DTO
        // We can use it in two files - one for editDTO and one for addDTO
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Artist { get; set; }
        public int Rate { get; set; } 

    }
}
