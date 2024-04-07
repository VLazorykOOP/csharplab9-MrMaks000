using System.Collections;

namespace Lab9_10CharpT
{
    internal class MusicCD
    {
        public string Title { get; private set; }
        private Hashtable songs = new Hashtable();

        public MusicCD(string title)
        {
            Title = title;
        }

        public void AddSong(Song song)
        {
            songs.Add(song.Title, song);
        }

        public void RemoveSong(string title)
        {
            songs.Remove(title);
        }

        public void DisplayContent()
        {
            Console.WriteLine($"Content of CD '{Title}':");
            foreach (DictionaryEntry entry in songs)
            {
                Console.WriteLine(entry.Value);
            }
        }

        public bool ContainsArtist(string artist)
        {
            foreach (DictionaryEntry entry in songs)
            {
                Song song = (Song)entry.Value;
                if (song.Artist == artist)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
