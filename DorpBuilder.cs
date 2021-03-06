﻿using DorpBuilder.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace DorpBuilder
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class DorpBuilder : Game
    {

        public const int DefaultWidth = 1000;

        public const int DefaultHeight = DefaultWidth / 16 * 9;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteFont font;
        Level.Level level;

        InputHandler input;

        float scale = 1.0f;

        public DorpBuilder()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            graphics.PreferredBackBufferWidth = DefaultWidth;
            graphics.PreferredBackBufferHeight = DefaultHeight;

            this.IsMouseVisible = true;
            this.Window.Title = "Dorp builder";
            this.Window.AllowUserResizing = true;
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

            input = new InputHandler(this);
            
            Level.Terrain.Init();

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

            font = Content.Load<SpriteFont>("DorpBuilderFont");
            level = new Level.Level(this.graphics.PreferredBackBufferWidth, this.graphics.PreferredBackBufferHeight);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            input.Update();

            level.Update(input);

            // TODO: Add your update logic here
            scale += 0.01f;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin();

            Size currentSize = new Size(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            //foreach (Vector2 loc in buildingLocation)
            //{
                //spriteBatch.Draw(image, new Vector2(loc.X - image.Width / 2, loc.Y - image.Height / 2), Color.White);
            //}

            //spriteBatch.Draw(image, new Vector2(mouseLocation.X-image.Width/2, mouseLocation.Y-image.Height/2), Color.White);
            
            //spriteBatch.DrawString(font, text, new Vector2(x, 150), Color.Black,1f,middle,1f,SpriteEffects.None,1f);
            //spriteBatch.DrawString(font, rotation + " f", new Vector2(250, 250), Color.Chocolate);
            //spriteBatch.DrawString(font, gameTime.ElapsedGameTime.TotalMilliseconds + "", new Vector2(300, 300), Color.DarkMagenta);
            //spriteBatch.DrawString(font, time + "", new Vector2(500, 300), Color.DarkMagenta);
            level.Render(spriteBatch,graphics.GraphicsDevice,currentSize);

            spriteBatch.DrawString(font, "This is a string", new Vector2(10, 10), Color.Black);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
