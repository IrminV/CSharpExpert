﻿using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment2.Framework.Components;
using Microsoft.Xna.Framework.Graphics;
using Yayen.Assignment2.Framework.Components.Colliders.RectangleCollision;
using Yayen.Assignment2.Framework.GameObjects;
using Yayen.Assignment2.Framework.MonoGameBase;
using Yayen.Assignment2.Framework.Scenes;
using Yayen.Assignment2.Framework.Components.Base;
using Yayen.Assignment2.Framework.Scenes.Base;
using Microsoft.Xna.Framework;

namespace Yayen.Assignment2.Gameplay.Scenes
{
    public class BouncerTest : Scene
    {
        public BouncerTest(SceneSystem sceneSystem, ContentManager content, Game1 game1, string name = "Scene") : base(sceneSystem, content, game1, name) { }

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
            newGameObject.AddComponent(new SpriteRenderer(newGameObject, pContent, pContent.Load<Texture2D>("GreyBlock64"), 0f));
            newGameObject.AddComponent(new RectangleCollider(newGameObject, _RectangleCollisionSystem));
            newGameObject.AddComponent(new Text(newGameObject, pContent.Load<SpriteFont>("DefaultSpritefont"), "To Scaler Test"));
            newGameObject.AddComponent(new Button(newGameObject));
            newGameObject.AddComponent(new ButtonSceneSwitchScript(newGameObject, _sceneSystem, "ScalerTest"));
            _GameObjects.Add(newGameObject);

            // Previous Test Button
            base.LoadContent(pContent, pGame1);
            GameObject newGameObject2 = new(this, "Block", 96, _graphicsDevice.Viewport.Height - 96, 0, 3, 1);
            newGameObject2.AddComponent(new SpriteRenderer(newGameObject2, pContent, pContent.Load<Texture2D>("GreyBlock64"), 0f));
            newGameObject2.AddComponent(new RectangleCollider(newGameObject2, _RectangleCollisionSystem));
            newGameObject2.AddComponent(new Text(newGameObject2, pContent.Load<SpriteFont>("DefaultSpritefont"), "To Sine Rotation Test"));
            newGameObject2.AddComponent(new Button(newGameObject2));
            newGameObject2.AddComponent(new ButtonSceneSwitchScript(newGameObject2, _sceneSystem, "SineRotationTest"));
            _GameObjects.Add(newGameObject2);

            // Mouse Object
            GameObject mouse = new(this, "Mouse", 96 + 128, 96 + 128, 0);
            //Component mouseSpriteRenderer = new SpriteRenderer(mouse, pContent, pContent.Load<Texture2D>("GreyBlock64"), 0f);
            //mouse.AddComponent(mouseSpriteRenderer);
            mouse.AddComponent(new RectangleCollider(mouse, _RectangleCollisionSystem));
            mouse.AddComponent(new MouseSelector(mouse));
            _GameObjects.Add(mouse);

            // Scene Description
            GameObject SceneDescription = new(this, "SceneDescription", _graphicsDevice.Viewport.Width / 2, 32, 0, 0.5f, 0.5f);
            //SceneDescription.AddComponent(new SpriteRenderer(SceneDescription, pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            //SceneDescription.AddComponent(new RectangleCollider(SceneDescription, _RectangleCollisionSystem));
            SceneDescription.AddComponent(new Text(SceneDescription, pContent.Load<SpriteFont>("DefaultSpritefont"), "Bouncer Test", 0, 0));
            _GameObjects.Add(SceneDescription);



            /*
             
             GameObject g = new GameObject();
            Transform t = g.AddComponent<Transform>();
            t.position = ...;
            t.rotation = ...;
            t.scale = ...;
             
             */

            // Test Objects
            GameObject obj1 = new(this, "Obj1", _graphicsDevice.Viewport.Width / 2 - 96, 96, 0, 0.5f, 0.5f);
            obj1.AddComponent(new SpriteRenderer(obj1, pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            obj1.AddComponent(new RectangleCollider(obj1, _RectangleCollisionSystem));
            obj1.AddComponent(new Text(obj1, pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 1 Bouncer\nDirection (-0.5, 1)\nAmplitude: 32", 0, 64));
            obj1.AddComponent(new Bouncer(obj1, 1f, 32, new Vector2(-0.5f, 1)));
            _GameObjects.Add(obj1);

            GameObject obj2 = new(this, "Obj2", _graphicsDevice.Viewport.Width / 2 - 96, 224, 0, 0.5f, 0.5f);
            obj2.AddComponent(new SpriteRenderer(obj2, pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            obj2.AddComponent(new RectangleCollider(obj2, _RectangleCollisionSystem));
            obj2.AddComponent(new Text(obj2, pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 2 Bouncer\nDirection (0.5, 1)\nAmplitude: 32", 0, 64));
            obj2.AddComponent(new Bouncer(obj2, 1f, 32, new Vector2(0.5f, 1)));
            _GameObjects.Add(obj2);

            GameObject obj3 = new(this, "Obj3", _graphicsDevice.Viewport.Width / 2 - 96, 352, 0, 0.5f, 0.5f);
            obj3.AddComponent(new SpriteRenderer(obj3, pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            obj3.AddComponent(new RectangleCollider(obj3, _RectangleCollisionSystem));
            obj3.AddComponent(new Text(obj3, pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 3 Bouncer\nPeriodsPerSecond: 0.8357", 0, 64));
            obj3.AddComponent(new Bouncer(obj3, 0.8357f, 32));
            _GameObjects.Add(obj3);

            GameObject obj4 = new(this, "Obj4", _graphicsDevice.Viewport.Width / 2 + 96, 96, 0, 0.5f, 0.5f);
            obj4.AddComponent(new SpriteRenderer(obj4, pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            obj4.AddComponent(new RectangleCollider(obj4, _RectangleCollisionSystem));
            obj4.AddComponent(new Text(obj4, pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 4 Bouncer\nDirection (-0.5, 1)\nAmplitude: 16", 0, 64));
            obj4.AddComponent(new Bouncer(obj4, 1f, 16, new Vector2(-0.5f, 1)));
            _GameObjects.Add(obj4);

            GameObject obj5 = new(this, "Obj5", _graphicsDevice.Viewport.Width / 2 + 96, 224, 0, 0.5f, 0.5f);
            obj5.AddComponent(new SpriteRenderer(obj5, pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            obj5.AddComponent(new RectangleCollider(obj5, _RectangleCollisionSystem));
            obj5.AddComponent(new Text(obj5, pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 5 Bouncer\nDirection (-1, 0)\nAmplitude: 60", 0, 64));
            obj5.AddComponent(new Bouncer(obj5, 1f, 60, new Vector2(-1f, 0)));
            _GameObjects.Add(obj5);

            GameObject obj6 = new(this, "Obj6", _graphicsDevice.Viewport.Width / 2 + 96, 352, 0, 0.5f, 0.5f);
            obj6.AddComponent(new SpriteRenderer(obj6, pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            obj6.AddComponent(new RectangleCollider(obj6, _RectangleCollisionSystem));
            obj6.AddComponent(new Text(obj6, pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 6 Bouncer\nDirection (69.696969, 0)\nAmplitude: 60", 0, 64));
            obj6.AddComponent(new Bouncer(obj6, 1f, 60, new Vector2(69.696969f, 0)));
            _GameObjects.Add(obj6);

            GameObject obj7 = new(this, "Obj7", _graphicsDevice.Viewport.Width / 2 + 288, 224, 0, 0.5f, 0.5f);
            obj7.AddComponent(new SpriteRenderer(obj7, pContent, pContent.Load<Texture2D>("LittleStar"), 0f));
            obj7.AddComponent(new RectangleCollider(obj7, _RectangleCollisionSystem));
            obj7.AddComponent(new Text(obj7, pContent.Load<SpriteFont>("DefaultSpritefont"), "Obj 7 Bouncer\nPeriodsPerSecond: 2", 0, 64));
            obj7.AddComponent(new Bouncer(obj7, 2f, 32));
            _GameObjects.Add(obj7);

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
