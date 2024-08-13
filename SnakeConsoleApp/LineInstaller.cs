using SnakeConsoleApp;
using System;

public class LineInstaller
{
	private List<Shape> _shapes;
	public LineInstaller()
	{
		_shapes = new List<Shape>();
		HorizontalLine upLine = new HorizontalLine(0, 0, '-', 120);
		HorizontalLine downLine = new HorizontalLine(0, 20, '-', 120);
		VerticalLine leftLine = new VerticalLine(0, 1, '|', 20);
		VerticalLine righttLine = new VerticalLine(119, 1, '|', 20);

		_shapes.AddRange(new List<Shape> { upLine, downLine, leftLine, righttLine});
	}

	public void DrawShapes()
	{
		foreach (Shape shape in _shapes)
		{
			shape.DrawLine();
		}
	}

	public bool Collision(Shape shape)
	{
		foreach(Shape item in _shapes)
        {
			if (item.Colision(shape))
				return true;
        }
		return false;
	}
}
