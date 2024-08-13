using System;

public class UIService
{
    private UserService _userService = new UserService();
    private User _user;
    public void GetMenu()
    {
        Console.Clear();
        Console.SetCursorPosition(30, 5);
        Console.WriteLine("||====================================================||");
        Console.SetCursorPosition(30, 6);
        Console.WriteLine("||----------------------------------------------------||");
        Console.SetCursorPosition(30, 7);
        Console.WriteLine("||----------------Welcome to snake game---------------||");
        Console.SetCursorPosition(30, 8);
        Console.WriteLine("||----------------------------------------------------||");
        Console.SetCursorPosition(30, 9);
        Console.WriteLine("||====================================================||");
        Console.SetCursorPosition(30, 11);
        Console.WriteLine("              -Press enter to start game                ");
        Console.SetCursorPosition(30, 12);
        Console.WriteLine("              -Use arrows to move                       ");
        Console.SetCursorPosition(30, 13);
        Console.WriteLine("              -Press C to create the user               ");
        Console.SetCursorPosition(30, 14);
        Console.WriteLine("              -Press S to get all scores                ");
        Console.SetCursorPosition(30, 15);
        Console.WriteLine("              -Press ESC to exit                        ");
        Console.SetCursorPosition(30, 17);
        Console.WriteLine("||----------------------------------------------------||");
        Console.SetCursorPosition(30, 18);
        Console.WriteLine("||====================================================||");
    }

    public void GetComand(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.Enter:
                StartGame();
                break;
            case ConsoleKey.C:
                CreateUserForm();
                break;
            case ConsoleKey.S:
                GetScores();
                break;
            case ConsoleKey.Escape:
                Environment.Exit(0);
                break;
            default:
                GetMenu();
                break;
        }
    }

    private void StartGame()
    {
        Console.Clear();
        GamePlay.Start(_user);
        Concede();
    }
    private void CreateUserForm()
    {
        Console.Clear();
        Console.WriteLine("User form");

        Label:
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();

        try
        {
            _user = _userService.GreateUser(userName);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            goto Label;
        }

        Console.WriteLine("User was saved");
        Console.WriteLine("Press Backspace to return");
    }
    private void GetScores()
    {
        Console.Clear();
        Console.WriteLine("Score Board");
        var users = _userService.GetAllUsers();
        foreach(var user in users)
        {
            Console.WriteLine($"{ user.Name} with score: {user.Score}");
        }
        Console.WriteLine("Press Backspace to return");
    }
    private void Concede()
    {
        Console.SetCursorPosition(2, 23);
        Console.WriteLine("Game over");
        Console.WriteLine("Press enter to try again");
        Console.WriteLine("Press backspace for menu");
    }
}
