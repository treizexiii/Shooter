using Godot;
using Shooter.Configuration.InputsManager;
using Shooter.Tools.ConsoleLogger;

namespace Shooter.Scripts;

public partial class Level : Node2D
{
	private readonly ILogger _logger = LoggerFactory.GetLogger<Level>();

	private Player _player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		InputConfiguration.GetInstance();
		var children = GetChildren();
		foreach (var child in children)
		{
			if (child is Node2D character)
			{
				character.Scale = new Vector2(0.5f, 0.5f);
			}
		}

		_player = GetNode<Player>("Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var screen = GetViewportRect();
		if (_player.Position.X > screen.Size.X + screen.Position.X)
		{
			_player.SetPositionX(screen.Position.X);
		}
		else if (_player.Position.X < screen.Position.X)
		{
			_player.SetPositionX(screen.Size.X + screen.Position.X);
		}

		if (_player.Position.Y > screen.Size.Y + screen.Position.Y)
		{
			_player.SetPositionY(screen.Position.Y);
		}
		else if (_player.Position.Y < screen.Position.Y)
		{
			_player.SetPositionY(screen.Size.Y + screen.Position.Y);
		}


		if (Input.IsActionPressed(ActionList.QUIT))
		{
			GetTree().Quit();
		}
	}
}
