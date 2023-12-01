using Godot;
using Shooter.Configuration.InputsManager;
using Shooter.Tools.ConsoleLogger;

namespace Shooter.Scripts;

public partial class Player : CharacterBody2D
{
	private readonly ILogger _logger = LoggerFactory.GetLogger<Player>();

	private Vector2 _pos = Vector2.Zero;
	private const float SPEED = 500f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_pos = new Vector2(300, 200);
		Position = _pos;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var direction = Input.GetVector(
			ActionList.LEFT,
			ActionList.RIGHT,
			ActionList.UP,
			ActionList.DOWN);
		Velocity = direction * SPEED;
		MoveAndSlide();

		if (Input.IsActionPressed(ActionList.PRIMARY_ACTION))
		{
			_logger.LogInfo(ActionList.PRIMARY_ACTION);
		}

		if (Input.IsActionPressed(ActionList.SECONDARY_ACTION))
		{
			_logger.LogInfo(ActionList.SECONDARY_ACTION);
		}
	}

	public Vector2 GetSize()
	{
		return GetNode<Sprite2D>("PlayerSprite").Texture.GetSize();
	}

	public void SetPositionX(float x)
	{
		_pos = new Vector2(x, Position.Y);
		Position = _pos;
	}

	public void SetPositionY(float y)
	{
		_pos = new Vector2(Position.X, y);
		Position = _pos;
	}
}
