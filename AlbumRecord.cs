class AlbumRecord

{
    public string Artist { get; set;}
    public string AlbumTitle { get; set;}
    public string FavoriteSong { get; set;}
    public double Rating { get; set;}
    public int ReleaseYear { get; set;}
    public string Comments { get; set;}

    public AlbumRecord(string artist, string albumTitle, string favoriteSong, double rating, int releaseYear, string comments)
    {
        Artist = artist;
        AlbumTitle = albumTitle;
        FavoriteSong = favoriteSong;
        Rating = rating;
        ReleaseYear = releaseYear;
        Comments = comments;

    }

    public void Display()
    {
        Console.WriteLine($"Artist: {Artist}");
        Console.WriteLine($"Album Title: {AlbumTitle}");
        Console.WriteLine($"Favorite Song: {FavoriteSong}");
        Console.WriteLine($"Rating: {Rating}");
        Console.WriteLine($"Release Year: {ReleaseYear}");
        Console.WriteLine($"Comments: {Comments}");
        Console.WriteLine();
    }

}
