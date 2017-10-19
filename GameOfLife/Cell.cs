namespace GameOfLife
{
    public class Cell
    {
        public int PointX { set; get; } = -1;
        public int PointY { get; set; } = -1;
        public bool IsAlive { get; set; } = false;
    }
}