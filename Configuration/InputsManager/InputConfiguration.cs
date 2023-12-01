using System;
using Godot;
using Shooter.Tools.ConsoleLogger;

namespace Shooter.Configuration.InputsManager;

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
        DefineKeyboard();
        DefineMouse();
    }

    private void DefineMouse()
    {
        foreach (var primaryAction in _keyConfig.PrimaryAction.Mouse)
        {
            if (Enum.TryParse(primaryAction, out MouseButton button))
            {
                InputMap.ActionAddEvent(ActionList.PRIMARY_ACTION, new InputEventMouseButton { ButtonIndex = button });
            }
            else
            {
                _logger.LogError("Could not parse key: " + primaryAction);
            }
        }

        foreach (var secondaryAction in _keyConfig.SecondaryAction.Mouse)
        {
            if (Enum.TryParse(secondaryAction, out MouseButton button))
            {
                InputMap.ActionAddEvent(ActionList.SECONDARY_ACTION, new InputEventMouseButton { ButtonIndex = button });
            }
            else
            {
                _logger.LogError("Could not parse key: " + secondaryAction);
            }
        }
    }

    private void DefineKeyboard()
    {
        InputMap.AddAction(ActionList.LEFT);
        foreach (var left in _keyConfig.Left.Keyboard)
        {
            if (Enum.TryParse(left, out Key key))
            {
                InputMap.ActionAddEvent(ActionList.LEFT, new InputEventKey { PhysicalKeycode = key });
            }
            else
            {
                _logger.LogError("Could not parse key: " + left);
            }
        }

        InputMap.AddAction(ActionList.RIGHT);
        foreach (var right in _keyConfig.Right.Keyboard)
        {
            if (Enum.TryParse(right, out Key key))
            {
                InputMap.ActionAddEvent(ActionList.RIGHT, new InputEventKey { PhysicalKeycode = key });
            }
            else
            {
                _logger.LogError("Could not parse key: " + right);
            }
        }

        InputMap.AddAction(ActionList.UP);
        foreach (var up in _keyConfig.Up.Keyboard)
        {
            if (Enum.TryParse(up, out Key key))
            {
                InputMap.ActionAddEvent(ActionList.UP, new InputEventKey { PhysicalKeycode = key });
            }
            else
            {
                _logger.LogError("Could not parse key: " + up);
            }
        }

        InputMap.AddAction(ActionList.DOWN);
        foreach (var down in _keyConfig.Down.Keyboard)
        {
            if (Enum.TryParse(down, out Key key))
            {
                InputMap.ActionAddEvent(ActionList.DOWN, new InputEventKey { PhysicalKeycode = key });
            }
            else
            {
                _logger.LogError("Could not parse key: " + down);
            }
        }

        InputMap.AddAction(ActionList.PRIMARY_ACTION);
        foreach (var shoot in _keyConfig.PrimaryAction.Keyboard)
        {
            if (Enum.TryParse(shoot, out Key key))
            {
                InputMap.ActionAddEvent(ActionList.PRIMARY_ACTION, new InputEventKey { PhysicalKeycode = key });
            }
            else
            {
                _logger.LogError("Could not parse key: " + shoot);
            }
        }

        InputMap.AddAction(ActionList.SECONDARY_ACTION);
        foreach (var secondaryAction in _keyConfig.SecondaryAction.Keyboard)
        {
            if (Enum.TryParse(secondaryAction, out Key key))
            {
                InputMap.ActionAddEvent(ActionList.SECONDARY_ACTION, new InputEventKey { PhysicalKeycode = key });
            }
            else
            {
                _logger.LogError("Could not parse key: " + secondaryAction);
            }
        }

        InputMap.AddAction(ActionList.QUIT);
        foreach (var quit in _keyConfig.Quit.Keyboard)
        {
            if (Enum.TryParse(quit, out Key key))
            {
                InputMap.ActionAddEvent(ActionList.QUIT, new InputEventKey { PhysicalKeycode = key });
            }
            else
            {
                _logger.LogError("Could not parse key: " + quit);
            }
        }
    }
}