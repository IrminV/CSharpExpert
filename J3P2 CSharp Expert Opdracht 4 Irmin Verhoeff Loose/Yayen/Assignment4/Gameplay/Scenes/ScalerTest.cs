﻿using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment4.Framework.Components;
using Microsoft.Xna.Framework.Graphics;
using Yayen.Assignment4.Framework.Components.Colliders.RectangleCollision;
using Yayen.Assignment4.Framework.GameObjects;
using Yayen.Assignment4.Framework.MonoGameBase;
using Yayen.Assignment4.Framework.Scenes;
using Yayen.Assignment4.Framework.Components.Base;
using Yayen.Assignment4.Framework.Scenes.Base;
using Microsoft.Xna.Framework;
using Yayen.Assignment4.Framework.Components.Mono;

namespace Yayen.Assignment4.Gameplay.Scenes
{
    public class ScalerTest : Scene
    {
        public ScalerTest(SceneSystem sceneSystem, ContentManager content, Game1 game1, string name = "Scene") : base(sceneSystem, content, game1, name) { }

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
            newGameObject.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "To ColorShifterTest"));
            newGameObject.AddComponent(new Button());
            newGameObject.AddComponent(new ButtonSceneSwitchScript(_sceneSystem, "ColorShifterTest"));
            _GameObjects.Add(newGameObject);

            // Previous Test Button
            base.LoadContent(pContent, pGame1);
            GameObject newGameObject2 = new(this, "Block", 96, _graphicsDevice.Viewport.Height - 96, 0, 3, 1);
            newGameObject2.AddComponent(new SpriteRenderer(pContent, pContent.Load<Texture2D>("GreyBlock64"), 0f));
            newGameObject2.AddComponent(new RectangleCollider(_RectangleCollisionSystem));
            newGameObject2.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "To Bouncer Test"));
            newGameObject2.AddComponent(new Button());
            newGameObject2.AddComponent(new ButtonSceneSwitchScript(_sceneSystem, "BouncerTest"));
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
            SceneDescription.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "Scaler Test", 0, 0));
            _GameObjects.Add(SceneDescription);


            // Test Objects
            GameObject obj1 = new(this, "Obj1", _graphicsDevice.Viewport.Width / 2 - 96, 96, 0, 0.5f, 0.5f);
            obj1.AddComponent(new SpriteRenderer(pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            obj1.AddComponent(new RectangleCollider(_RectangleCollisionSystem));
            obj1.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 1 Scaler:\nMaxScale:0.5\nScalingPerSec: 1", 0, 64));
            obj1.AddComponent(new SpriteScaler(0.5f, 1));
            _GameObjects.Add(obj1);

            GameObject obj2 = new(this, "Obj2", _graphicsDevice.Viewport.Width / 2 - 96, 224, 0, 0.5f, 0.5f);
            obj2.AddComponent(new SpriteRenderer(pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            obj2.AddComponent(new RectangleCollider(_RectangleCollisionSystem));
            obj2.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 2 Scaler:\nMinScale: 0.5\nMaxScale:1\nScalingPerSec: 1", 0, 64));
            obj2.AddComponent(new SpriteScaler(0.5f, 1, 1));
            _GameObjects.Add(obj2);

            GameObject obj3 = new(this, "Obj3", _graphicsDevice.Viewport.Width / 2 - 96, 352, 0, 0.5f, 0.5f);
            obj3.AddComponent(new SpriteRenderer(pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            obj3.AddComponent(new RectangleCollider(_RectangleCollisionSystem));
            obj3.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 3 Scaler:\nMinscale:X0.2,Y0.5\nMaxScale:X0.5, Y1\nScalingPerSec: X0.5 Y1", 0, 64));
            obj3.AddComponent(new SpriteScaler(new Vector2(0.2f,0.5f), new Vector2(0.5f, 1), new Vector2(0.5f, 1)));
            _GameObjects.Add(obj3);

            GameObject obj4 = new(this, "Obj4", _graphicsDevice.Viewport.Width / 2 + 96, 96, 0, 0.5f, 0.5f);
            obj4.AddComponent(new SpriteRenderer(pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            obj4.AddComponent(new RectangleCollider(_RectangleCollisionSystem));
            obj4.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 4 Scaler:\nMaxScale:-0.5\nScalingPerSec: 1", 0, 64));
            obj4.AddComponent(new SpriteScaler(-0.5f, 1));
            _GameObjects.Add(obj4);

            GameObject obj5 = new(this, "Obj5", _graphicsDevice.Viewport.Width / 2 + 96, 224, 0, 0.5f, 0.5f);
            obj5.AddComponent(new SpriteRenderer(pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            obj5.AddComponent(new RectangleCollider(_RectangleCollisionSystem));
            obj5.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 5 Scaler:\nMinScale: -0.5\nMaxScale:-1\nScalingPerSec: 1", 0, 64));
            obj5.AddComponent(new SpriteScaler(-0.5f, -1, 1));
            _GameObjects.Add(obj5);

            GameObject obj6 = new(this, "Obj6", _graphicsDevice.Viewport.Width / 2 + 96, 352, 0, 0.5f, 0.5f);
            obj6.AddComponent(new SpriteRenderer(pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            obj6.AddComponent(new RectangleCollider(_RectangleCollisionSystem));
            obj6.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 6 Scaler:\nMinscale:X0.5,Y0.2\nMaxScale:X1, Y0.5\nScalingPerSec: X1 Y0.5", 0, 64));
            obj6.AddComponent(new SpriteScaler(new Vector2(0.5f, 0.2f), new Vector2(1f, 0.5f), new Vector2(1f, 0.5f)));
            _GameObjects.Add(obj6);

            GameObject obj7 = new(this, "Obj7", _graphicsDevice.Viewport.Width / 2 + 288, 96, 0, 0.5f, 0.5f);
            obj7.AddComponent(new SpriteRenderer(pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            obj7.AddComponent(new RectangleCollider(_RectangleCollisionSystem));
            obj7.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 7 Scaler:\nMinsCale:-0.5\nMaxScale:0.5\nScalingPerSec: 0.25", 0, 64));
            obj7.AddComponent(new SpriteScaler(-0.5f, 0.5f, 0.25f));
            _GameObjects.Add(obj7);

            GameObject obj8 = new(this, "Obj8", _graphicsDevice.Viewport.Width / 2 + 288, 224, 0, 0.5f, 0.5f);
            obj8.AddComponent(new SpriteRenderer(pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            obj8.AddComponent(new RectangleCollider(_RectangleCollisionSystem));
            obj8.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 8 Scaler:\nMinScale: 0.5\nMaxScale:2\nScalingPerSec: 1\nOnly scale on X", 0, 64));
            obj8.AddComponent(new SpriteScaler(0.5f, 2, 1, true, false));
            _GameObjects.Add(obj8);
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            base.Draw(pSpriteBatch);
        }

        public override void Update(GameTime gameTime, Game1 game1)
        {
            base.Update(gameTime, game1);
        }
    }
}
