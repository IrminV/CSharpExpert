using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment3.Framework.Components;
using Microsoft.Xna.Framework.Graphics;
using Yayen.Assignment3.Framework.Components.Base;
using Yayen.Assignment3.Framework.Components.Colliders.RectangleCollision;
using Yayen.Assignment3.Framework.GameObjects;
using Yayen.Assignment3.Framework.MonoGameBase;
using Yayen.Assignment3.Framework.Scenes;
using Yayen.Assignment3.Framework.Scenes.Base;

namespace Yayen.Assignment3.Gameplay.Scenes
{
    public class LayerDepthTest : Scene
    {
        public LayerDepthTest(SceneSystem sceneSystem, ContentManager content, Game1 game1, string name = "Scene") : base(sceneSystem, content, game1, name) { }

        /// <summary>
        /// Method where we load all objects for this scene.
        /// </summary>
        /// <param name="pContent">ContentManager to load content with.</param>
        /// <param name="pGame1">Reference to MonoGame Game1.</param>
        public override void LoadContent(ContentManager pContent, Game1 pGame1)
        {
            // Next Test Button
            base.LoadContent(pContent, pGame1);
            GameObject newGameObject = new(this, "Block", _graphicsDevice.Viewport.Width - 96, _graphicsDevice.Viewport.Height - 96, 0, 3, 1);
            newGameObject.AddComponent(new SpriteRenderer(pContent, pContent.Load<Texture2D>("GreyBlock64"), 0f));
            newGameObject.AddComponent(new RectangleCollider(_RectangleCollisionSystem));
            newGameObject.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "To Sine Rotation Test"));
            newGameObject.AddComponent(new Button());
            newGameObject.AddComponent(new ButtonSceneSwitchScript(_sceneSystem, "SineRotationTest"));
            _GameObjects.Add(newGameObject);

            // Previous Test Button
            base.LoadContent(pContent, pGame1);
            GameObject newGameObject2 = new(this, "Block", 96, _graphicsDevice.Viewport.Height - 96, 0, 3, 1);
            newGameObject2.AddComponent(new SpriteRenderer(pContent, pContent.Load<Texture2D>("GreyBlock64"), 0f));
            newGameObject2.AddComponent(new RectangleCollider(_RectangleCollisionSystem));
            newGameObject2.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "To Origin Test"));
            newGameObject2.AddComponent(new Button());
            newGameObject2.AddComponent(new ButtonSceneSwitchScript(_sceneSystem, "OriginTest"));
            _GameObjects.Add(newGameObject2);

            // Mouse Object
            GameObject mouse = new(this, "Mouse", 96 + 128, 96 + 128, 0);
            //Component mouseSpriteRenderer = new SpriteRenderer(mouse, pContent, pContent.Load<Texture2D>("GreyBlock64"), 0f);
            //mouse.AddComponent(mouseSpriteRenderer);
            mouse.AddComponent(new RectangleCollider(_RectangleCollisionSystem));
            mouse.AddComponent(new MouseSelector());
            _GameObjects.Add(mouse);

            // Scene Description
            GameObject SceneDescription = new(this, "SceneDescription", _graphicsDevice.Viewport.Width / 2, 32, 0, 0.5f, 0.5f);
            //SceneDescription.AddComponent(new SpriteRenderer(SceneDescription, pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            //SceneDescription.AddComponent(new RectangleCollider(SceneDescription, _RectangleCollisionSystem));
            SceneDescription.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "LayerDepth Test", 0, 0));
            _GameObjects.Add(SceneDescription);

            // Test Objects
            GameObject obj1 = new(this, "Obj1", _graphicsDevice.Viewport.Width / 2, _graphicsDevice.Viewport.Height / 2, 0, 2f, 2f);
            obj1.AddComponent(new SpriteRenderer(pContent, pContent.Load<Texture2D>("LittleStar"), 0.5f));
            obj1.AddComponent(new RectangleCollider(_RectangleCollisionSystem));
            obj1.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "LayerDepth 0.5", 0, 74 + 128));
            _GameObjects.Add(obj1);
            //Console.WriteLine($"LayerDepth of Obj1 is {((SpriteRenderer)obj1.GetComponent<SpriteRenderer>()).LayerDepth}");

            GameObject obj2 = new(this, "Obj2", _graphicsDevice.Viewport.Width / 2 - 96, 352, 0, 0.5f, 0.5f);
            obj2.AddComponent(new SpriteRenderer(pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            obj2.AddComponent(new RectangleCollider(_RectangleCollisionSystem));
            obj2.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "LayerDepth 0", 0, 50));
            _GameObjects.Add(obj2);
            //Console.WriteLine($"LayerDepth of Obj2 is {((SpriteRenderer)obj2.GetComponent<SpriteRenderer>()).LayerDepth}");

            GameObject obj3 = new(this, "Obj3", _graphicsDevice.Viewport.Width / 2 + 96, 352, 0, 0.5f, 0.5f);
            obj3.AddComponent(new SpriteRenderer(pContent, pContent.Load<Texture2D>("LittleStar"), 1f));
            obj3.AddComponent(new RectangleCollider(_RectangleCollisionSystem));
            obj3.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "LayerDepth 1", 0, 50));
            _GameObjects.Add(obj3);
            //Console.WriteLine($"LayerDepth of Obj3 is {((SpriteRenderer)obj3.GetComponent<SpriteRenderer>()).LayerDepth}");

            GameObject obj4 = new(this, "Obj4", _graphicsDevice.Viewport.Width / 2 + 158, 96, 0, 0.5f, 0.5f);
            obj4.AddComponent(new SpriteRenderer(pContent, pContent.Load<Texture2D>("LittleStar"), 2f));
            obj4.AddComponent(new RectangleCollider(_RectangleCollisionSystem));
            obj4.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "LayerDepth 2 (invisable)", 0, 50));
            _GameObjects.Add(obj4);

            GameObject obj5 = new(this, "Obj5", _graphicsDevice.Viewport.Width / 2 - 158, 96, 0, 0.5f, 0.5f);
            obj5.AddComponent(new SpriteRenderer(pContent, pContent.Load<Texture2D>("LittleStar"), -0.1f));
            obj5.AddComponent(new RectangleCollider(_RectangleCollisionSystem));
            obj5.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "layerDepth - 0.1 (invisible)", 0, 50));
            _GameObjects.Add(obj5);
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            base.Draw(pSpriteBatch);
        }
    }
}
