using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsometricTile
{
    class Tile
    {
        private Texture2D texture;
        public static ContentManager Content;

        public int ID
        {
            get;
            set;
        }
        public Rectangle Rectangle
        {
            get;
            set;
        }

        public Vector2 Position
        {
            get;
            set;
        }
        public Tile(Vector2 position, int i)
        {
            this.Position = position;
            texture = Content.Load<Texture2D>("Tile" + i);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }
    }
}
