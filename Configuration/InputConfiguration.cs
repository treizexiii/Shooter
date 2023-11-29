using System;
using System.IO;
using System.Text.Json;
using Godot;
using Shooter.Tools.ConsoleLogger;
using Shooter.Tools.FileSystem;

namespace Shooter.Configuration;


// add configuration for input map here
public class InputConfiguration
{
    private static InputConfiguration _instance;

    private readonly ILogger _logger;
    private KeyConfiguration _keyConfig;

    private InputConfiguration()
    {
        _logger = LoggerFactory.GetLogger<InputConfiguration>();
        _keyConfig = KeyConfigurationManager.Load();
        LoadInputMap(_keyConfig);
        DefineInputMap();
    }

    public static InputConfiguration GetInstance()
    {
        var instance = _instance ??= new InputConfiguration();
        return instance;
    }

    private void LoadInputMap(KeyConfiguration keyConfiguration)
    {
        InputMap.LoadFromProjectSettings();
        _keyConfig = keyConfiguration;
    }

    public void DefineInputMap()
    {
        InputMap.AddAction("left");
        foreach (var left in _keyConfig.Left.Keyboard)
        {
            if (Enum.TryParse(left, out Key key))
            {
                InputMap.ActionAddEvent("left", new InputEventKey {PhysicalKeycode = key});
            }
            else
            {
                _logger.LogError("Could not parse key: " + left);
            }
        }
        InputMap.AddAction("right");
        foreach (var right in _keyConfig.Right.Keyboard)
        {
            if (Enum.TryParse(right, out Key key))
            {
                InputMap.ActionAddEvent("right", new InputEventKey {PhysicalKeycode = key});
            }
            else
            {
                _logger.LogError("Could not parse key: " + right);
            }
        }
        InputMap.AddAction("up");
        foreach (var up in _keyConfig.Up.Keyboard)
        {
            if (Enum.TryParse(up, out Key key))
            {
                InputMap.ActionAddEvent("up", new InputEventKey {PhysicalKeycode = key});
            }
            else
            {
                _logger.LogError("Could not parse key: " + up);
            }
        }
        InputMap.AddAction("down");
        foreach (var down in _keyConfig.Down.Keyboard)
        {
            if (Enum.TryParse(down, out Key key))
            {
                InputMap.ActionAddEvent("down", new InputEventKey {PhysicalKeycode = key});
            }
            else
            {
                _logger.LogError("Could not parse key: " + down);
            }
        }
        InputMap.AddAction("shoot");
        foreach (var shoot in _keyConfig.Shoot.Keyboard)
        {
            if (Enum.TryParse(shoot, out Key key))
            {
                InputMap.ActionAddEvent("shoot", new InputEventKey {PhysicalKeycode = key});
            }
            else
            {
                _logger.LogError("Could not parse key: " + shoot);
            }
        }

        foreach (var shoot in _keyConfig.Shoot.Mouse)
        {
            if (Enum.TryParse(shoot, out MouseButton button))
            {
                InputMap.ActionAddEvent("shoot", new InputEventMouseButton {ButtonIndex = button});
            }
            else
            {
                _logger.LogError("Could not parse key: " + shoot);
            }
        }
    }
}

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

public class KeyConfiguration
{
    public InputModel Left { get; set; }
    public InputModel Right { get; set; }
    public InputModel Up { get; set; }
    public InputModel Down { get; set; }
    public InputModel Shoot { get; set; }
}

public class InputModel
{
    public string[] Keyboard { get; set; }
    public string[] Mouse { get; set; }
}