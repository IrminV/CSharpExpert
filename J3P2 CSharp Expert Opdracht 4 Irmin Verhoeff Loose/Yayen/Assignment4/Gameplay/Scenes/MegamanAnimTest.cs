using Microsoft.Xna.Framework.Content;
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
    public class MegamanAnimTest: Scene
    {
        public MegamanAnimTest(SceneSystem sceneSystem, ContentManager content, Game1 game1, string name = "Scene") : base(sceneSystem, content, game1, name) { }

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
            newGameObject.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "To Rotation Test"));
            newGameObject.AddComponent(new Button());
            newGameObject.AddComponent(new ButtonSceneSwitchScript(_sceneSystem, "RotationTest"));
            _GameObjects.Add(newGameObject);

            // Previous Test Button
            base.LoadContent(pContent, pGame1);
            GameObject newGameObject2 = new(this, "Block", 96, _graphicsDevice.Viewport.Height - 96, 0, 3, 1);
            newGameObject2.AddComponent(new SpriteRenderer(pContent, pContent.Load<Texture2D>("GreyBlock64"), 0f));
            newGameObject2.AddComponent(new RectangleCollider(_RectangleCollisionSystem));
            newGameObject2.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "To FireMageAnimTest"));
            newGameObject2.AddComponent(new Button());
            newGameObject2.AddComponent(new ButtonSceneSwitchScript(_sceneSystem, "FireMageAnimTest"));
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
            SceneDescription.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "FireMageAnimTest", 0, 0));
            _GameObjects.Add(SceneDescription);

            // Test Objects

            // FireMage Test
            GameObject megaman = new(this, "Megaman", _graphicsDevice.Viewport.Width / 2, 128, 0, 1f, 1f);
            //fireMage.AddComponent(new SpriteRenderer(pContent, pContent.Load<Texture2D>("LittleStar"), 0f));

            // Creating the animation and animator
            SpriteSheetAnimation animation = new(_content.Load<Texture2D>("Megaman"), new Vector2(140, 140), 1);
            AnimatedSpriteRenderer animRenderer = (AnimatedSpriteRenderer)megaman.AddComponent(new AnimatedSpriteRenderer(_content));
            SpriteSheetAnimator megamanAnimator = new(animRenderer, animation);
            animRenderer.SetAnimator(megamanAnimator);
            _GameObjects.Add(megaman);

            // Play Animation Button
            base.LoadContent(pContent, pGame1);
            GameObject playButton = new(this, "Block", _graphicsDevice.Viewport.Width / 2, _graphicsDevice.Viewport.Height - 32, 0, 3, 1);
            playButton.AddComponent(new SpriteRenderer(pContent, pContent.Load<Texture2D>("GreyBlock64"), 0f));
            playButton.AddComponent(new RectangleCollider(_RectangleCollisionSystem));
            playButton.AddComponent(new Text(pContent.Load<SpriteFont>("DefaultSpritefont"), "Play Anim"));
            playButton.AddComponent(new Button());
            playButton.AddComponent(new ButtonStartAnimScript(megamanAnimator));
            _GameObjects.Add(playButton);
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
