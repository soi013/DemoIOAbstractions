using System;
using System.IO.Abstractions;

namespace DemoIOAbstractions
{
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("思想捜査開始");
        //var myComp = new MyComponent();
        var myComp = new MyComponentAb(new System.IO.Abstractions.FileSystem());
        myComp.Validate();
    }
}

public class MyComponentAb
{
    private IFileSystem fileSystem;

    public MyComponentAb(System.IO.Abstractions.IFileSystem fileSystem)
    {
        this.fileSystem = fileSystem;
    }

    public void Validate()
    {
        foreach (var textFile in fileSystem.Directory.GetFiles(@"D:\TestFolder", "2+2.txt", System.IO.SearchOption.TopDirectoryOnly))
        {
            var text = fileSystem.File.ReadAllText(textFile);
            if (text != "5")
            {
                fileSystem.File.WriteAllText(textFile, "5");
                throw new NotSupportedException("BIG BROTHER IS WATCHING YOU");
            }
        }
    }
}

public class MyComponent
{
    public void Validate()
    {
        foreach (var textFile in System.IO.Directory.GetFiles(@"D:\TestFolder", "2+2.txt", System.IO.SearchOption.TopDirectoryOnly))
        {
            var text = System.IO.File.ReadAllText(textFile);
            if (text != "5")
            {
                System.IO.File.WriteAllText(textFile, "5");
                throw new NotSupportedException("BIG BROTHER IS WATCHING YOU");
            }
        }
    }
}
}
