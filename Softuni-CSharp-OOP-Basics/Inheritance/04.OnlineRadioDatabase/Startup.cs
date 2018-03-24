
using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        int numOfInput = int.Parse(Console.ReadLine());
        List<Song> songs = new List<Song>();

        int songsAdded = 0;
        for (int i = 0; i < numOfInput; i++)
        {
            try
            {
                string[] songTokens = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                ValidateSong(songTokens);

                Song newSong = ParseSong(songTokens);
                songs.Add(newSong);
                songsAdded++;
                Console.WriteLine("Song added.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        PrintSongs(songs, songsAdded);
    }

    private static void PrintSongs(List<Song> songs, int songsAdded)
    {
        Console.WriteLine($"Songs added: {songsAdded}");
        string displayTime = GetDisplayTime(songs);
        Console.WriteLine($"Playlist length: {displayTime}");
    }

    private static string GetDisplayTime(List<Song> songs)
    {
        var totalSeconds = CalculateTotalSeconds(songs);
        TimeSpan time = TimeSpan.FromSeconds(totalSeconds);
        string displayTime = string.Format($"{time.Hours}h {time.Minutes}m {time.Seconds}s");
        return displayTime;
    }

    private static double CalculateTotalSeconds(List<Song> songs)
    {
        int totalSeconds = 0;
        totalSeconds += songs.Select(s => s.Minutes * 60).Sum();
        totalSeconds += songs.Select(s => s.Seconds).Sum();

        return totalSeconds;
    }

    private static Song ParseSong(string[] songTokens)
    {
        var artist = songTokens[0];
        var songName = songTokens[1];
        var minutes = int.Parse(songTokens[2].Split(':').First());
        var seconds = int.Parse(songTokens[2].Split(':').Skip(1).First());
        Song song = new Song(artist, songName, minutes, seconds);

        return song;
    }

    private static void ValidateSong(string[] songTokens)
    {
        if (songTokens.Length < 3)
        {
            throw new InvalidSongException();
        }
    }
}
