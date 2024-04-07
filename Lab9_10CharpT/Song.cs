namespace Lab9_10CharpT
{
    internal class Song
    {
        public string Title { get; private set; }
        public string Artist { get; private set; }

        public Song(string title, string artist)
        {
            Title = title;
            Artist = artist;
        }

        public override string ToString()
        {
            return $"{Title} by {Artist}";
        }
    }
}
