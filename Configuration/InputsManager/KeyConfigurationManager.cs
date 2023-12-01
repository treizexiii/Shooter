using System.IO;
using System.Text.Json;
using Shooter.Tools.FileSystem;

namespace Shooter.Configuration.InputsManager;

public static class KeyConfigurationManager
{
    private const string PATH = "config/input.json";

    public static KeyConfiguration Load()
    {
        var path = PathManager.GetPath(PATH);
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<KeyConfiguration>(json);
    }
}