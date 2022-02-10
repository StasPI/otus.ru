namespace Otus.Teaching.Concurrency.Import.Core.AppSettings
{
    public interface ISettings
    {
        public string StartType { get; set; }
        public string DataFileName { get; set; }
        public string DataFilePath { get; set; }
        public string DataFileFormat { get; set; }
        public int DataCount { get; set; }
        public string ProcessPath { get; set; }
        public string ProcessFileName { get; set; }
        public string DataFileDirectory { get; set; }
        public string ConnectionString { get; set; }
        public int CountThreads { get; set; }
        public int CountTries { get; set; }
    }
}