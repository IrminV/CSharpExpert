using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Yayen.Framework.CollisionSystem;
using Yayen.Framework.Components.Colliders.Base;
using Yayen.Framework.GameObjects;
using Yayen.Framework.MonoGameBase;

namespace Yayen.Framework.Scenes.Base
{
    /// <summary>
    /// The Blueprint for every other Scene
    /// </summary>
    public class Scene
    {
        protected string _sceneName = "Scene";
        protected List<GameObject> _GameObjects = new();
        protected SceneSystem _sceneSystem;
        protected Game1 _game1;
        protected ContentManager _content;
        protected RectangleCollisionSystem _RectangleCollisionSystem = new();

        protected GraphicsDevice _graphicsDevice;

        public string SceneName { get { return _sceneName; } }

        public Scene(SceneSystem sceneSystem, ContentManager content, Game1 game1, string name = "Scene")
        {
            _sceneSystem = sceneSystem;
            _content = content;
            _game1 = game1;
            _sceneName = name;

            _graphicsDevice = _game1.GraphicsDevice;
        }

        public virtual void Update(GameTime gameTime, Game1 game1)
        {
            UpdateGameObjects(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            DrawGameObjects(spriteBatch);
        }

        /// <summary>
        /// Called when entering scene
        /// </summary>
        public virtual void EnterScene()
        {
            Console.WriteLine("Entering Scene");
            //_collisionSystem.UpdateGameObjects(_GameObjects);
            if (_sceneSystem.previousScene != null && _sceneSystem.previousScene.SceneName == SceneName)
            {
                _sceneSystem.previousScene = null;
            }
            else
            {
                Console.WriteLine("Resetting Scene on enter:");
                ResetScene(_content, _game1);
            }
        }

        /// <summary>
        /// Called when exiting scene
        /// </summary>
        public virtual void ExitScene()
        {

        }

        /// <summary>
        /// Call to remake scene
        /// </summary>
        /// <param name="content"></param>
        /// <param name="game1"></param>
        public virtual void ResetScene(ContentManager content, Game1 game1)
        {
            Console.WriteLine("Resetting Scene");
            for (int i = 0; i < _GameObjects.Count; i++)
            {
                _GameObjects[i].Destroy();
            }
            _GameObjects.Clear();
            LoadContent(content, game1);
            //_collisionSystem = new CollisionSystem();
            //_collisionSystem.UpdateGameObjects(_GameObjects);
            //if (_game1.Player.Lives <= 0)
            //{
            //    _game1.Player.Lives = 3;
            //}
        }

        /// <summary>
        /// Virtual method. Overriden by individual scenes. Empty by in blueprint by default.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="game1"></param>
        public virtual void LoadContent(ContentManager content, Game1 game1)
        {

        }

        /// <summary>
        /// Call to update all gameobjects in the scene
        /// </summary>
        /// <param name="gameTime"></param>
        private void UpdateGameObjects(GameTime gameTime)
        {
            if (_GameObjects.Count <= 0) return;
            for (int i = 0; i < _GameObjects.Count; i++)
            {
                if (_GameObjects[i] == null) continue;
                _GameObjects[i].Update(gameTime);
            }
            _RectangleCollisionSystem.Update();
        }

        /// <summary>
        /// Call to draw all gameobjects in the scene
        /// </summary>
        /// <param name="spriteBatch"></param>
        private void DrawGameObjects(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < _GameObjects.Count; i++)
            {
                if (_GameObjects[i] == null)
                {
                    Console.WriteLine($"Warning: {_GameObjects[i]} of index {i} was null");
                    continue;
                }
                _GameObjects[i].Draw(spriteBatch);
            }
        }

        /// <summary>
        ///  Call to destroy a GameObject in this scene. GameObjects can call this for themeselves.
        /// </summary>
        /// <param name="gameObject"></param>
        public void DestroyGameObject(GameObject gameObject)
        {
            _GameObjects.Remove(gameObject);
        }
    }
}
