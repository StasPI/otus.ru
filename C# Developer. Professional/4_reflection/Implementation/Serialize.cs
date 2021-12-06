using Abstraction;
using System.Reflection;
using System.Text;

namespace Implementation;

public class Serialize : ISerialize
{
    private const string _separator = ",";
    private static readonly BindingFlags _bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

    public string SerializeFromObjectToCSV(object obj)
    {
        StringBuilder _sb = new StringBuilder();
        FieldInfo[] _fields = obj.GetType().GetFields(bindingAttr: _bindFlags);

        foreach (FieldInfo field in _fields)
        {
            string name = field.Name;
            string value = field.GetValue(obj).ToString();

            _sb.Append($"'{name}'{_separator}'{value}'\n");
        }
        return _sb.ToString();
    }

    public T? DeserializeFromCSVToObject<T>(string csv) where T : class, new()
    {
        var instance  = new T();
        string[] _fields = csv.Split("\n", StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < _fields.Length; i++)
        {
            string[] parts = _fields[i].Split($"{_separator}", StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                continue;
            }

            string fieldName = parts[0].Replace("'", "");
            string fieldValue = parts[1].Replace("'", "");
            FieldInfo field = instance .GetType().GetField(name: fieldName, bindingAttr: _bindFlags);

            var value = Convert.ChangeType(fieldValue, field.FieldType);
            field.SetValue(obj: instance , value: value);
        }
        return instance ;
    }
}