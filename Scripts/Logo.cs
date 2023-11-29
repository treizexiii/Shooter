using Godot;

namespace Shooter.Scripts;

public partial class Logo : Sprite2D
{
	private Vector2 _pos = Vector2.Zero;
	private int _speed = 200;
	private float _scale = 0.1f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_pos = new Vector2(300, 200);
		Position = _pos;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_pos.X += _speed * (float)delta;
		Position = _pos;
		// _scale += 0.01f;
		// Scale = new Vector2(_scale, _scale);
	}

	public Vector2 GetSize()
	{
		var x = Texture.GetSize().X * Scale.X;
		var y = Texture.GetSize().Y * Scale.Y;
		return new Vector2(x, y);
	}

	public void SetPositionX(float x)
	{
		_pos = new Vector2(x, _pos.Y);
		Position = _pos;
	}

	public void SetPositionY(float y)
	{
		_pos = new Vector2(_pos.X, y);
		Position = _pos;
	}
}
