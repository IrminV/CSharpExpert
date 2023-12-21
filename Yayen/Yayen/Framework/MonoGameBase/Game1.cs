using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Security.AccessControl;
using Yayen.Framework.Scenes;
using Yayen.Gameplay.Scenes;

namespace Yayen.Framework.MonoGameBase
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
            Test1 _test1 = new(_sceneSystem, Content, this, "Test1");
            Test2 _test2 = new(_sceneSystem, Content, this, "Test2");
            Test3 _test3 = new(_sceneSystem, Content, this, "Test3");
            Test4 _test4 = new(_sceneSystem, Content, this, "Test4");
            
            _sceneSystem.AddScene(_test1);
            _sceneSystem.AddScene(_test2);
            _sceneSystem.AddScene(_test3);
            _sceneSystem.AddScene(_test4);
            _sceneSystem.SwitchScene(_test1);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _sceneSystem.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // TODO: Add your drawing code here
            _sceneSystem.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}