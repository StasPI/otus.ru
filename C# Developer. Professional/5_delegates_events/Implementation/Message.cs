namespace Implementation
{
    public static class Message
    {
        public static void Start(object sender, EventArgs args)
        {
            Console.WriteLine("File name: " + ((FileArgs)args).File);
        }

        public static void Stop(object sender, EventArgs args)
        {
            Start(sender, args);
            ((FilesSearch)sender).Stop();
        }
    }
}
