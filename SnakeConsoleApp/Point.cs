namespace SnakeConsoleApp
{
    public class Point
    {
        int _left;
        int _top;
        char _symbol;

        public char Symbol 
        { get { return _symbol; } set { _symbol = value; } }

        public Point(Point point)
        {
            _left = point._left;
            _top = point._top;
            _symbol = point._symbol;
        }

        public void SetDirection(int i, DirectionEnum direction)
        {
            switch (direction)
            {
                case DirectionEnum.Left:
                    _left -= i;
                    break;
                case DirectionEnum.Right:
                    _left += i;
                    break;
                case DirectionEnum.Up:
                    _top -= i;
                    break;
                case DirectionEnum.Down:
                    _top += i;
                    break;
            }
        }

        public void ClearPoint()
        {
            _symbol = ' ';
            Draw();
        }

        public Point(int left, int top, char symbol)
        {
            _left = left; _top = top; _symbol = symbol;
        }

        public void Draw()
        {
            Console.SetCursorPosition(_left, _top);
            Console.Write(_symbol);
        }

        internal bool ComparePoints(Point food)
        {
            return (food._left == _left && food._top == _top);
        }
    }
}
