using System;
using System.IO;

namespace Shooter.Tools.FileSystem;

public static class PathManager
{
    public static string GetRoot()
    {
        var rootPath = Environment.CurrentDirectory;
        return rootPath;
    }

    public static string GetPath(string name)
    {
        return Path.Combine(GetRoot(), name);
    }
}

public static class DirectoryEnum
{
    public const string Config = "config";
    public const string Assets = "graphics";
}