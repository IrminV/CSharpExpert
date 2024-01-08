using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Security.AccessControl;
using Yayen.Assignment2.Framework.Scenes;
using Yayen.Assignment2.Gameplay.Scenes;

namespace Yayen.Assignment2.Framework.MonoGameBase
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SceneSystem _sceneSystem;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        // NOTE: LoadContent() is called in base.Initialize
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _sceneSystem = new(Content, this);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Test1 _test1 = new(_sceneSystem, Content, this, "RotationTest");
            Test2 _test2 = new(_sceneSystem, Content, this, "PositionTest");
            Test3 _test3 = new(_sceneSystem, Content, this, "ScaleTest");
            Test4 _test4 = new(_sceneSystem, Content, this, "OriginTest");
            Test5 _test5 = new(_sceneSystem, Content, this, "LayerdepthTest");

            _sceneSystem.AddScene(_test1);
            _sceneSystem.AddScene(_test2);
            _sceneSystem.AddScene(_test3);
            _sceneSystem.AddScene(_test4);
            _sceneSystem.AddScene(_test5);
            _sceneSystem.SwitchScene(_test1);
        }

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