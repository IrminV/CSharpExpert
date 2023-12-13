using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Yayen.Framework.GameObjects;
using Yayen.Framework.MonoGameBase;

namespace Yayen.Framework.Scenes
{
    /// <summary>
    /// The Blueprint for every other Scene
    /// </summary>
    public class BaseScene
    {
        protected string _sceneName = "Scene";
        protected List<GameObject> _GameObjects = new();
        protected SceneSystem _sceneSystem;
        protected Game1 _game1;
        protected ContentManager _content;

        public string SceneName { get { return _sceneName; } }

        public BaseScene(SceneSystem sceneSystem, ContentManager content, Game1 game1, string name = "Scene")
        {
            _sceneSystem = sceneSystem;
            _content = content;
            _game1 = game1;
            _sceneName = name;
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
            //_collisionSystem.UpdateGameObjects(_GameObjects);
            if (_sceneSystem.previousScene != null && _sceneSystem.previousScene.SceneName == SceneName)
            {
                _sceneSystem.previousScene = null;
            }
            else
            {
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
        /// Value * 64. Actually a workaround to work with units of 64 by 64 without changing gameobject or creating something new.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //protected float Unit64(float input)
        //{
        //    return input * 64;
        //}

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
                //_GameObjects[i].Update(gameTime);
            }
            //_collisionSystem.Update();
        }

        /// <summary>
        /// Call to draw all gameobjects in the scene
        /// </summary>
        /// <param name="spriteBatch"></param>
        private void DrawGameObjects(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < _GameObjects.Count; i++)
            {
                if (_GameObjects[i] == null) continue;
                //_GameObjects[i].Draw(spriteBatch);
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

        /// <summary>
        /// Quick method to create stairs.
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="height"></param>
        /// <param name="flipX"></param>
        /// <param name="flipY"></param>
        /// <param name="unitSize"></param>
        //protected void CreateStairs(Vector3 origin, int height, bool flipX = false, bool flipY = false, int unitSize = 64)
        //{
        //    int width = height;
        //    int rowsDone = 0;


        //    if (flipY)
        //    {
        //        for (int y = 0; y < height; y++)
        //        {
        //            for (int x = 0 + rowsDone; x < width; x++)
        //            {
        //                _GameObjects.Add(new(this, _content.Load<Texture2D>("GreyBlock64"), origin + new Vector3(flipX ? Unit64(-x) : Unit64(x), Unit64(y), 0), 0, Color.White, true, true, new Vector2(1, 1)));
        //            }
        //            rowsDone++;
        //        }
        //    }
        //    else
        //    {
        //        for (int y = 0; y < height; y++)
        //        {
        //            for (int x = 0 + rowsDone; x < width; x++)
        //            {
        //                _GameObjects.Add(new(this, _content.Load<Texture2D>("GreyBlock64"), origin + new Vector3(flipX ? Unit64(-x) : Unit64(x), Unit64(-y), 0), 0, Color.White, true, true, new Vector2(1, 1)));
        //            }
        //            rowsDone++;
        //        }
        //    }
        //}

        /// <summary>
        /// Quick method to make the creation of MovingPlatforms smaller and easier.
        /// </summary>
        /// <param name="checkpoints"></param>
        /// <param name="leverPos"></param>
        /// <param name="scale"></param>
        /// <param name="startMoving"></param>
        /// <param name="startDelay"></param>
        /// <returns></returns>
        //protected MovingPlatform CreateMovingPlatform(List<Vector2> checkpoints, Vector2? leverPos = null, Vector2? scale = null, bool startMoving = false, float startDelay = 0f)
        //{
        //    MovingPlatform movingPlatform = new MovingPlatform(this, _content.Load<Texture2D>("GreyBlock64"), new Vector3(checkpoints[0].X, checkpoints[0].Y, 0), 0, Color.Cyan, true, true, checkpoints, startMoving, startDelay, scale);
        //    _GameObjects.Add(movingPlatform);

        //    if (leverPos != null)
        //    {
        //        _GameObjects.Add(new LeverSystem.Lever(this, _content.Load<Texture2D>("Lever-Up"), new Vector3(Unit64(((Vector2)leverPos).X), Unit64(((Vector2)leverPos).Y), 0), true, true, movingPlatform));
        //    }

        //    return movingPlatform;
        //}
    }
}
