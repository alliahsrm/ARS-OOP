string filePath = "albums.json";

AlbumCollection collection = new AlbumCollection();
collection.Load(filePath);

bool running = true;
while (running)
{
    Console.WriteLine("=== Album Record System ===");
    Console.WriteLine("1. Add album");
    Console.WriteLine("2. View by release year (newest first)");
    Console.WriteLine("3. View by score (highest first)");
    Console.WriteLine("4. View by album title (A-Z)");
    Console.WriteLine("5. View by artist (A-Z)");
    Console.WriteLine("0. Exit");
    Console.Write("Choose: ");

    string choice = Console.ReadLine() ?? "";
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            Console.Write("Artist: ");
            string artist = Console.ReadLine() ?? "";

            Console.Write("Album title: ");
            string albumTitle = Console.ReadLine() ?? "";

            Console.Write("Favorite song: ");
            string favoriteSong = Console.ReadLine() ?? "";

            Console.Write("Rating (0-10): ");
            double rating;
            while (!double.TryParse(Console.ReadLine(), out rating) || rating < 0 || rating > 10)
            {
                Console.Write("Enter a number from 0 to 10: ");
            }

            Console.Write("Release year (e.g. 1991): ");
            int releaseYear;
            while (!int.TryParse(Console.ReadLine(), out releaseYear) || releaseYear < 1900 || releaseYear > DateTime.Now.Year)
            {
                Console.Write($"Enter a year from 1900 to {DateTime.Now.Year}: ");
            }

            Console.Write("Comments: ");
            string comments = Console.ReadLine() ?? "";

            collection.Add(new AlbumRecord(artist, albumTitle, favoriteSong, rating, releaseYear, comments));
            collection.Save(filePath);
            Console.WriteLine("Saved!\n");
            break;

        case "2":
            collection.Print(collection.SortByReleaseYear());
            break;
        case "3":
            collection.Print(collection.SortByScore());
            break;
        case "4":
            collection.Print(collection.SortByAlbumTitle());
            break;
        case "5":
            collection.Print(collection.SortByArtist());
            break;
        case "0":
            running = false;
            break;
        default:
            Console.WriteLine("Invalid choice.\n");
            break;
    }
}