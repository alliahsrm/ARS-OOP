using System.Text.Json;
class AlbumCollection
{
        public void Save(string filePath)
    {
        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(albums, options);
        File.WriteAllText(filePath, json);
    }

    public void Load(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return;
        }

        string json = File.ReadAllText(filePath);
        albums = JsonSerializer.Deserialize<List<AlbumRecord>>(json) ?? new List<AlbumRecord>();
    }
    private List<AlbumRecord> albums = new List<AlbumRecord>();

    public void Add(AlbumRecord record)
    {
        albums.Add(record);
    }

    public List<AlbumRecord> SortByReleaseYear()
    {
        return albums.OrderByDescending(a => a.ReleaseYear).ToList();
    }

    public List<AlbumRecord> SortByScore()
    {
        return albums.OrderByDescending(a => a.Rating).ToList();
    }

    public List<AlbumRecord> SortByAlbumTitle()
    {
        return albums.OrderBy(a => a.AlbumTitle).ToList();
    }

    public List<AlbumRecord> SortByArtist()
    {
        return albums.OrderBy(a => a.Artist).ToList();
    }

    public void Print(List<AlbumRecord> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("No albums yet.\n");
            return;
        }

        foreach (AlbumRecord a in list)
        {
            a.Display();
        }
    }
}