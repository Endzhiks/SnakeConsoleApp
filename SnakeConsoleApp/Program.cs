namespace SnakeConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIService ui = new UIService();
            ui.GetMenu();

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                ui.GetComand(key.Key);
            }
        }
    }
}