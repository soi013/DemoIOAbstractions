using DemoIOAbstractions;
using System;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using Xunit;

namespace TestProject1
{
public class UnitTest1
{
    private string targetFilePath = @"D:\TestFolder\2+2.txt";

    [Fact]
    public void Test_MyComponent_Success()
    {
        var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>()
        {
            [targetFilePath] = new MockFileData("5")
        });

        var myComp = new MyComponentAb(fileSystem);

        myComp.Validate();
    }

    [Fact]
    public void Test_MyComponent_ExceptionThrow()
    {
        var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>()
        {
            [targetFilePath] = new MockFileData("4")
        });

        var myComp = new MyComponentAb(fileSystem);

        Assert.Throws<NotSupportedException>(() => myComp.Validate());

        Assert.Equal("5",
            fileSystem.File.ReadAllText(targetFilePath));
    }
}
}
