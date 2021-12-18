namespace Implementation
{
    public class FileArgs : EventArgs
    {
        public string File { get; init; }

        public FileArgs(string file)
        {
            File = file;
        }
    }
}
