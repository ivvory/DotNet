using System.Collections.Generic;

namespace Generics
{
    public class PointComparer : IComparer<Point>
    {
        public int Compare(Point fst, Point snd)
        {
            if (fst.X > snd.X && fst.Y > snd.Y)
            {
                return 1;
            }
            else if (fst.X < snd.X && fst.Y < snd.Y)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}