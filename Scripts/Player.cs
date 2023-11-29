using Godot;
using Shooter.Tools.ConsoleLogger;

namespace Shooter.Scripts;

public partial class Player : Node2D
{
	private readonly ILogger _logger = LoggerFactory.GetLogger<Player>();

	private const float SPEED = 200f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var direction = Input.GetVector("left", "right", "up", "down");
		Position += direction * SPEED * (float)delta;

		if (Input.IsActionPressed("shoot"))
		{
			_logger.LogInfo("Shoot");
		}
	}
}
