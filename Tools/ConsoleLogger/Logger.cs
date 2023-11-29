using System;
using Godot;

namespace Shooter.Tools.ConsoleLogger;

public class LoggerFactory
{
	public static ILogger GetLogger<T>()
	{
		return new Logger<T>();
	}
}

public interface ILogger
{
	void LogInfo(object message);
	void LogError(object message);
}

public class Logger<T> : ILogger
{
	private readonly string _name = typeof(T).Name;

	public void LogInfo(object message)
	{
		GD.Print("INFO\t" + _name + ":\t" + message);
	}

	public void LogError(object message)
	{
		GD.PrintErr("ERROR\t" + _name + ":\t" + message);
	}
}
