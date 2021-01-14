namespace EscapeMines.Game.Strategy
{
    public class ColorContext
    {
        private Color _color;

        public ColorContext(Color color)
        {
            _color = color;
        }

        public void ContextInterface()
        {
            _color.ChangeColor();;
        }
    }
}
