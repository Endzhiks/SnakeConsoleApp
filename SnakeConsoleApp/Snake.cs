using SnakeConsoleApp;
using System;

public class Snake : Shape
{
	DirectionEnum _direction;
	public Snake()
	{
		_points = new List<Point>();
	}
	public void GreateSnake(int length, Point snakeTail, DirectionEnum direction)
	{
		_direction = direction;
		for (int i = 0; i < length; i++)
		{
			Point point = new Point(snakeTail);
			point.SetDirection(i, direction);
			_points.Add(point);
		}
	}

	public void Move()
	{
		Point snakeTail = _points.First();
		_points.Remove(snakeTail);
		
		Point head = new Point(_points.Last());
		head.SetDirection(1, _direction);
		_points.Add(head);

		snakeTail.ClearPoint();
		head.Draw();
	}

	public void PressKey(ConsoleKey key)
	{
		if (key == ConsoleKey.LeftArrow)
			_direction = DirectionEnum.Left;
		else if (key == ConsoleKey.RightArrow)
			_direction = DirectionEnum.Right;
		else if (key == ConsoleKey.UpArrow)
			_direction = DirectionEnum.Up;
		else if (key == ConsoleKey.DownArrow)
			_direction = DirectionEnum.Down;
	}

	public bool ColisionWithOwnTail()
	{
		Point head = new Point(_points.Last());

		for (int i = 0; i < _points.Count - 1 ; i++)
		{
			if (head.ComparePoints(_points[i]))
				return true;
		}
		return false;
	}

	public bool Eat(Point food)
	{
		Point head = new Point(_points.Last());
		head.SetDirection(1, _direction);

		if (head.ComparePoints(food))
		{
			food.Symbol = head.Symbol;
			_points.Add(food);
			return true;
		}
		return false;
	}
}
