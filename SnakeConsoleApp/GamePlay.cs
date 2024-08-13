using SnakeConsoleApp;
using System;

public static class GamePlay
{
	public static void Start(User user)
	{
		UserService _userService = new UserService();

		if (user == null)
			user = new User();

		int score = 0;
		LineInstaller line = new LineInstaller();
		line.DrawShapes();


		Point food = FoodFactory.GetRandomFood(119, 20, 'O');
		Console.ForegroundColor = ColorHelper.GetRandomColor(new Random().Next(1, 5));
		food.Draw();
		Console.ResetColor();

		Snake snake = new Snake();
		snake.GreateSnake(5, new Point(5, 5, 'X'), DirectionEnum.Right);
		snake.DrawLine();

		ScoreHelper.GetScore(score);

		while (true)
		{
			if (line.Collision(snake) || snake.ColisionWithOwnTail())
			{
				break;
			}
			if (snake.Eat(food))
			{
				food = FoodFactory.GetRandomFood(119, 20, 'O');
				Console.ForegroundColor = ColorHelper.GetRandomColor(new Random().Next(1, 5));
				food.Draw();
				Console.ResetColor();
				score++;
				ScoreHelper.GetScore(score);
			}

			Thread.Sleep(100);
			snake.Move();

			if (Console.KeyAvailable)
			{
				ConsoleKeyInfo key = Console.ReadKey();
				snake.PressKey(key.Key);
			}
		}

		user.Score = score;
		_userService.SaveScore(user);
	}
}
