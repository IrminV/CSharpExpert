using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Framework.GameObjects;
using Yayen.Framework.MonoGameBase;
using Yayen.Framework.Scenes;
using Yayen.Framework.Scenes.Base;
using Yayen.Framework.Components;
using Microsoft.Xna.Framework.Graphics;
using Yayen.Framework.Components.Base;
using Yayen.Framework.Components.Colliders.RectangleCollision;

namespace Yayen.Gameplay.Scenes
{
    public class Test4 : Scene
    {
        public Test4(SceneSystem sceneSystem, ContentManager content, Game1 game1, string name = "Scene") : base(sceneSystem, content, game1, name) { }

        public override void LoadContent(ContentManager pContent, Game1 pGame1)
        {
            // Next Test Button
            base.LoadContent(pContent, pGame1);
            GameObject newGameObject = new(this, "Block", _graphicsDevice.Viewport.Width - 96, _graphicsDevice.Viewport.Height - 96, 0, 1, 1);
            newGameObject.AddComponent(new SpriteRenderer(newGameObject, pContent ,pContent.Load<Texture2D>("GreyBlock64"), 0f));
            newGameObject.AddComponent(new RectangleCollider(newGameObject, _RectangleCollisionSystem));
            newGameObject.AddComponent(new Text(newGameObject, pContent.Load<SpriteFont>("DefaultSpritefont"), "Test1"));
            newGameObject.AddComponent(new Button(newGameObject));
            newGameObject.AddComponent(new ButtonSceneSwitchScript(newGameObject, _sceneSystem, "Test1"));
            _GameObjects.Add(newGameObject);


            // Mouse Object
            GameObject mouse = new(this, "Mouse", 96 + 128, 96 + 128, 0);
            //Component mouseSpriteRenderer = new SpriteRenderer(mouse, pContent, pContent.Load<Texture2D>("GreyBlock64"), 0f);
            //mouse.AddComponent(mouseSpriteRenderer);
            mouse.AddComponent(new RectangleCollider(mouse, _RectangleCollisionSystem));
            mouse.AddComponent(new MouseSelector(mouse));
            _GameObjects.Add(mouse);

            // Test Objects
            

            GameObject obj2 = new(this, "Obj2", _graphicsDevice.Viewport.Width / 2 - 96, 128, 0, 0.5f, 0.5f);
            obj2.AddComponent(new SpriteRenderer(obj2, pContent, pContent.Load<Texture2D>("StarIndicators"), 0f, 0, 0));
            obj2.AddComponent(new RectangleCollider(obj2, _RectangleCollisionSystem));
            obj2.AddComponent(new Text(obj2, pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 2 Origin (0,0)", 32, 96));
            _GameObjects.Add(obj2);

            GameObject obj3 = new(this, "Obj2", _graphicsDevice.Viewport.Width / 2 - 96, 128, 0, 0.5f, 0.5f);
            obj3.AddComponent(new SpriteRenderer(obj3, pContent, pContent.Load<Texture2D>("StarIndicators"), 0f, 1, 1));
            obj3.AddComponent(new RectangleCollider(obj3, _RectangleCollisionSystem));
            obj3.AddComponent(new Text(obj3, pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 3 Origin (1,1)", -32, -74));
            _GameObjects.Add(obj3);

            GameObject obj1 = new(this, "Obj1", _graphicsDevice.Viewport.Width / 2 - 96, 128, 0, 0.5f, 0.5f);
            obj1.AddComponent(new SpriteRenderer(obj1, pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            obj1.AddComponent(new RectangleCollider(obj1, _RectangleCollisionSystem));
            obj1.AddComponent(new Text(obj1, pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 1 Origin (0.5, 0.5)", 0, 74));
            _GameObjects.Add(obj1);

            //GameObject obj2 = new(this, "Obj2", _graphicsDevice.Viewport.Width / 2 - 96, 224, 0, 0.2f, 0.2f);
            //obj2.AddComponent(new SpriteRenderer(obj2, pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            //obj2.AddComponent(new RectangleCollider(obj2, _RectangleCollisionSystem));
            //obj2.AddComponent(new Text(obj2, pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 2 Scale: 0.2 by 0.2", 0, 50));
            //_GameObjects.Add(obj2);

            //GameObject obj3 = new(this, "Obj3", _graphicsDevice.Viewport.Width / 2 - 96, 352, 0, 1f, 1f);
            //obj3.AddComponent(new SpriteRenderer(obj2, pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            //obj3.AddComponent(new RectangleCollider(obj2, _RectangleCollisionSystem));
            //obj3.AddComponent(new Text(obj3, pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 3 Scale: 1 by 1", 0, 50));
            //_GameObjects.Add(obj3);

            //GameObject obj4 = new(this, "Obj4", _graphicsDevice.Viewport.Width / 2 + 96, 96, 0, -0.5f, -0.5f);
            //obj4.AddComponent(new SpriteRenderer(obj1, pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            //obj4.AddComponent(new RectangleCollider(obj1, _RectangleCollisionSystem));
            //obj4.AddComponent(new Text(obj4, pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 4 Scale -0.5 by -0.5"));
            //_GameObjects.Add(obj4);

            //GameObject obj5 = new(this, "Obj5", _graphicsDevice.Viewport.Width / 2 + 96, 224, -90, 0.5f, 0.5f);
            //obj5.AddComponent(new SpriteRenderer(obj2, pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            //obj5.AddComponent(new RectangleCollider(obj2, _RectangleCollisionSystem));
            //obj5.AddComponent(new Text(obj5, pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 5 Position:\nMidpoint + 96 by 224", 0, 50));
            //_GameObjects.Add(obj5);

            //GameObject obj6 = new(this, "Obj6", _graphicsDevice.Viewport.Width / 2 + 96, 352, 360, 0.5f, 0.5f);
            //obj6.AddComponent(new SpriteRenderer(obj2, pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            //obj6.AddComponent(new RectangleCollider(obj2, _RectangleCollisionSystem));
            //obj6.AddComponent(new Text(obj6, pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 6 Position:\nMidpoint + 96 by 352", 0, 50));
            //_GameObjects.Add(obj6);

            //GameObject obj7 = new(this, "Obj7", _graphicsDevice.Viewport.Width / 2 + 288, 224, 450, 0.5f, 0.5f);
            //obj7.AddComponent(new SpriteRenderer(obj2, pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            //obj7.AddComponent(new RectangleCollider(obj2, _RectangleCollisionSystem));
            //obj7.AddComponent(new Text(obj7, pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 7 Position:\nMidpoint + 288 by 224", 0, 50));
            //_GameObjects.Add(obj7);


        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
