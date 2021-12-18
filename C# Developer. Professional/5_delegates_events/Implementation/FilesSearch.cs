namespace Implementation
{
    public class FilesSearch
    {
        private string _path;
        private bool _subscription = true;

        public event EventHandler FileFound;

        public FilesSearch(string path)
        {
            _path = path;
        }

        private void CatalogSearch(string path)
        {
            foreach (string dir in Directory.GetDirectories(path))
            {
                FileSearch(dir);
            }
        }

        private void FileSearch(string path)
        {
            foreach (string file in Directory.GetFiles(path))
            {
                if (!_subscription)
                {
                    return;
                }
                FileFound?.Invoke(this, new FileArgs(file));
                Thread.Sleep(1000);
            }
            CatalogSearch(path);
        }

        public void Start()
        {
            if (Directory.Exists(_path))
            {
                FileSearch(_path);
            }
            else if (string.IsNullOrEmpty(_path))
            {
                throw new ArgumentNullException("Path is null or empty!");
            }
            else if (!(Directory.Exists(_path)))
            {
                throw new DirectoryNotFoundException("Path not found!");
            }
        }

        public void Stop()
        {
            _subscription = false;
        }
    }
}