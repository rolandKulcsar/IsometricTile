using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsometricTile
{
    static class CoordinateHelper
    {
        public static Vector2 IsoTo2D(Vector2 point)
        {
            Vector2 temp = new Vector2(0, 0);
            temp.X = (2 * point.Y + point.X) / 2;
            temp.Y = (2 * point.Y - point.X) / 2;

            return temp;
        }

        public static Vector2 twoDToIso(Vector2 point)
        {
            Vector2 temp = Vector2.Zero;
            temp.X = point.X - point.Y;
            temp.Y = (point.X + point.Y) / 2;

            return temp;
        }

        public static Vector2 getTileCoordinates(Vector2 point, int height)
        {
            Vector2 temp = Vector2.Zero;
            temp.X = (float)Math.Floor(point.X / height);
            temp.Y = (float)Math.Floor(point.Y / height);

            return temp;
        }
    }
}
