
public class Song
{
    private const int MIN_NAME_LENGTH = 3;
    private const int MAX_ARTIST_NAME_LENGTH = 20;
    private const int MAX_SONG_NAME_LENGTH = 30;
    private const int MIN_MINUTES = 0;
    private const int MAX_MINUTES = 14;
    private const int MIN_SECONDS = 0;
    private const int MAX_SECONDS = 59;

    private string artist;
    private string songName;
    private int minutes;
    private int seconds;
    
    public Song(string artist, string songName, int minutes, int seconds)
    {
        Artist = artist;
        SongName = songName;
        Minutes = minutes;
        Seconds = seconds;
    }

    public string Artist
    {
        get { return artist; }
        set
        {
            if (value.Length < MIN_NAME_LENGTH || value.Length > MAX_ARTIST_NAME_LENGTH)
            {
                throw new InvalidArtistNameException();
            }
            artist = value;
        }
    }
    
    public string SongName
    {
        get { return songName; }
        set
        {
            if (value.Length < MIN_NAME_LENGTH || value.Length > MAX_SONG_NAME_LENGTH)
            {
                throw new InvalidSongNameException();
            }
            songName = value;
        }
    }

    public int Minutes
    {
        get { return minutes; }
        set
        {
            ValidateSongLength();
            if (value < MIN_MINUTES || value > MAX_MINUTES)
            {
                throw new InvalidSongMinutesException();
            }
            minutes = value;
        }
    }
    
    public int Seconds
    {
        get { return seconds; }
        set
        {
            if (value < MIN_SECONDS || value > MAX_SECONDS)
            {
                throw new InvalidSongSecondsException();
            }
            seconds = value;
        }
    }

    private void ValidateSongLength()
    {
        if ((Minutes < MIN_MINUTES && Seconds < MIN_SECONDS) || (Minutes > MAX_MINUTES && Seconds > MAX_SECONDS))
        {
            throw new InvalidSongLengthException();
        }
    }
}
