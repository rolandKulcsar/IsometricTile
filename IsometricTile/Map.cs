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
                        Vector2 temp = CoordinateHelper.twoDToIso(new Vector2(x * size, y * size));
                        Tiles.Add(new Tile(temp, number));
                    }

                    Width = (x + 1) * size;
                    Height = (y + 1) * size;
                }
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
