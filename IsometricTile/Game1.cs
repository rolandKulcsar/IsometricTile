﻿#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace IsometricTile
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        #region Variables
        Map map;
        Camera camera;
        Player player;
        Texture2D highLight;
        #endregion

        public Game1(): base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.ApplyChanges();
            this.IsMouseVisible = true;

            map = new Map();
            camera = new Camera(GraphicsDevice.Viewport);
            player = new Player();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Tile.Content = Content;

            player.Load(Content);

            map.Generate(new int[,]{
                {1,1,2,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0},
                {1,1,2,2,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0},
                {2,1,1,1,1,1,1,1,1,1,1,1,2,0,0,2,2,2,2,2},
                {0,2,2,2,2,2,2,1,1,1,1,1,2,2,2,2,1,1,1,1},
                {0,0,0,0,0,0,2,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {0,0,0,0,0,0,2,1,1,1,1,1,2,2,2,2,1,1,1,1},
                {0,0,0,0,0,0,2,2,2,2,2,2,2,0,0,2,2,1,2,2},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,1,2,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0},
            }, 50);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState ms = Mouse.GetState();
            if(ms.LeftButton == ButtonState.Pressed)
                Console.WriteLine(CoordinateHelper.twoDToIso(new Vector2(ms.X, ms.Y)));

            camera.Update();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Deferred, 
                              BlendState.AlphaBlend,
                              null,null,null,null,
                              camera.Transform);
            map.Draw(spriteBatch);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
