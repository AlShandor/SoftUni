using System;

class InvalidSongLengthException : Exception
{
    public override string Message => "Invalid song length.";
}
