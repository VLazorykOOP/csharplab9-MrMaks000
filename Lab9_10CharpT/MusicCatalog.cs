using System.Collections;

namespace Lab9_10CharpT
{
    internal class MusicCatalog
    {
        private Hashtable cds = new Hashtable();

        public void AddCD(MusicCD cd)
        {
            cds.Add(cd.Title, cd);
        }

        public void RemoveCD(string title)
        {
            cds.Remove(title);
        }

        public void DisplayCatalog()
        {
            Console.WriteLine("Music Catalog:");
            foreach (DictionaryEntry entry in cds)
            {
                MusicCD cd = (MusicCD)entry.Value;
                Console.WriteLine($"- {cd.Title}");
            }
        }

        public void DisplayCDContent(string cdTitle)
        {
            if (cds.ContainsKey(cdTitle))
            {
                MusicCD cd = (MusicCD)cds[cdTitle];
                cd.DisplayContent();
            }
            else
            {
                Console.WriteLine($"CD '{cdTitle}' not found.");
            }
        }

        public void SearchByArtist(string artist)
        {
            Console.WriteLine($"Search results for artist '{artist}':");
            foreach (DictionaryEntry entry in cds)
            {
                MusicCD cd = (MusicCD)entry.Value;
                if (cd.ContainsArtist(artist))
                {
                    cd.DisplayContent();
                }
            }
        }
    }
}
