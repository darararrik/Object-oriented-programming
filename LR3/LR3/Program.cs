using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using ClassLibrary;
internal class Program
{
    private static void Main(string[] args)
    {
        var lib = Assembly.LoadFrom(@"C:\Users\imyam\source\repos\darararrik\Object-oriented-programming\LR3\LR3\lib\ClassLibrary.dll");
        var Types = lib.GetTypes();
        foreach (var Type in Types)
        {
            Console.WriteLine(Type.FullName);
        }
        ExampleClass ob = new ExampleClass();
        var type = ob.GetType();
        FieldInfo field = type.GetField("publicField",
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        GetMainInfoAboutField(field);


    }
    static void GetMainInfoAboutField(FieldInfo fieldInfo)
    {
        Console.WriteLine($"Статический член? {fieldInfo.IsStatic}");
        Console.WriteLine($"Приватный член? {fieldInfo.IsPrivate}");
        Console.WriteLine($"Открытый член? {fieldInfo.IsPublic}");
    }
}