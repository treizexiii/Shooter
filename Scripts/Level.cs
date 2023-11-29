using Godot;
using Shooter.Configuration;
using Shooter.Tools.ConsoleLogger;

namespace Shooter.Scripts;

public partial class Level : Node2D
{
	private Logo _logo;
	private readonly ILogger _logger = LoggerFactory.GetLogger<Level>();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_logo = GetNode<Logo>("Logo");
		_logo.RotationDegrees = 90f;
		InputConfiguration.GetInstance();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_logo = GetNode<Logo>("Logo");
		_logo.RotationDegrees += 100f * (float)delta;
		_logger.LogInfo(_logo.Position.X);
		var screen = GetViewportRect();
		if (_logo.Position.X > screen.Size.X + _logo.GetSize().X)
		{
			_logo.SetPositionX(0);
		}
	}
}
