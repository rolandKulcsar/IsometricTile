using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsometricTile
{
    class Map
    {
        private List<Tile> Tiles = new List<Tile>();

        public int Width
        {
            get;
            set;
        }
        public int Height
        {
            get;
            set;
        }

        public void Generate(int[,] map, int size)
        {
            for(int x = 0; x < map.GetLength(1); x++ )
                for(int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];

                    if (number > 0)
                    {
                        Vector2 temp = twoDToIso(new Vector2(x * size, y * size));
                        Tiles.Add(new Tile(temp, number));
                    }

                    Width = (x + 1) * size;
                    Height = (y + 1) * size;
                }
        }

        public Vector2 IsoTo2D(Vector2 point)
        {
            Vector2 temp = new Vector2(0, 0);
            temp.X = (2 * point.Y + point.X) / 2;
            temp.Y = (2 * point.Y - point.X) / 2;

            return temp;
        }

        public Vector2 twoDToIso(Vector2 point)
        {
            Vector2 temp = Vector2.Zero;
            temp.X = point.X - point.Y;
            temp.Y = (point.X + point.Y) / 2;

            return temp;
        }

        public Vector2 getTileCoordinates(Vector2 point, int height)
        {
            Vector2 temp = Vector2.Zero;
            temp.X = (float)Math.Floor(point.X / height);
            temp.Y = (float)Math.Floor(point.Y / height);

            return temp;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Tile tile in Tiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}
