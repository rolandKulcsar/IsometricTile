using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsometricTile
{
    class Player
    {
        private Texture2D texture;
        private Vector2 position = CoordinateHelper.IsoTo2D(new Vector2(0, 150));
        public void Load(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("Player");
        }

        public void Update()
        {
            KeyboardState ks = Keyboard.GetState();

            if(ks.IsKeyDown(Keys.W))
            {
                position = CoordinateHelper.twoDToIso(position + new Vector2(0f, -50f));
            }

            Console.WriteLine("Norm position: " + position);
            Console.WriteLine("Iso pos: " + CoordinateHelper.twoDToIso(position));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
