namespace Abstraction;

public interface ISerialize
{
    public string SerializeFromObjectToCSV(object obj);
    public T? DeserializeFromCSVToObject<T>(string csv) where T : class, new();
}