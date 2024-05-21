﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Security.AccessControl;
using Yayen.Assignment2.Framework.Scenes;
using Yayen.Assignment2.Gameplay.Scenes;

namespace Yayen.Assignment2.Framework.MonoGameBase
{
    /// <summary>
    /// MonoGame Game1.
    /// </summary>
    public class Game1 : Game
    {
        #region Fields
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SceneSystem _sceneSystem;
        #endregion

        #region Constructors
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        #endregion

        #region Initialization
        // NOTE: LoadContent() is called in base.Initialize
        /// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _sceneSystem = new(Content, this);
            base.Initialize();
        }

        /// <summary>
        /// load sprites and scene classes. NOTE: Loadcontent is called in base.Initialize().
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            RotationTest rotationTest = new(_sceneSystem, Content, this, "RotationTest");
            PositionTest positionTest = new(_sceneSystem, Content, this, "PositionTest");
            ScaleTest scaleTest = new(_sceneSystem, Content, this, "ScaleTest");
            OriginTest originTest = new(_sceneSystem, Content, this, "OriginTest");
            LayerDepthTest layerdepthTest = new(_sceneSystem, Content, this, "LayerdepthTest");
            SineRotationTest sineRotationTest = new(_sceneSystem, Content, this, "SineRotationTest");
            BouncerTest bounceTest = new(_sceneSystem, Content, this, "BouncerTest");
            ScalerTest scalerTest = new(_sceneSystem, Content, this, "ScalerTest");

            _sceneSystem.AddScene(rotationTest);
            _sceneSystem.AddScene(positionTest);
            _sceneSystem.AddScene(scaleTest);
            _sceneSystem.AddScene(originTest);
            _sceneSystem.AddScene(layerdepthTest);
            _sceneSystem.AddScene(sineRotationTest);
            _sceneSystem.AddScene(bounceTest);
            _sceneSystem.AddScene(scalerTest);
            _sceneSystem.SwitchScene(rotationTest);
        }
        #endregion

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            _sceneSystem.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // I learned from testing that you need to have a SpriteSortMode active to be able to use the LayerDepth property of the draw function.
            _spriteBatch.Begin(SpriteSortMode.FrontToBack);
            _sceneSystem.Draw(_spriteBatch);
            base.Draw(gameTime);
            _spriteBatch.End();
        }
    }
}