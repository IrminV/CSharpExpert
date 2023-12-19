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
    public class Test2 : Scene
    {
        public Test2(SceneSystem sceneSystem, ContentManager content, Game1 game1, string name = "Scene") : base(sceneSystem, content, game1, name) { }

        public override void LoadContent(ContentManager pContent, Game1 pGame1)
        {
            base.LoadContent(pContent, pGame1);
            GameObject newGameObject = new(this, "Block", 352, 96, 0);
            newGameObject.AddComponent(new SpriteRenderer(newGameObject, pContent ,pContent.Load<Texture2D>("GreyBlock64"), 0f));
            newGameObject.AddComponent(new RectangleCollider(newGameObject, _RectangleCollisionSystem));
            newGameObject.AddComponent(new Text(newGameObject, pContent.Load<SpriteFont>("DefaultSpritefont"), "Text"));
            newGameObject.AddComponent(new Button(newGameObject));
            _GameObjects.Add(newGameObject);


            // Mouse Object
            GameObject mouse = new(this, "Mouse", 96 + 128, 96 + 128, 0);
            Component mouseSpriteRenderer = new SpriteRenderer(mouse, pContent, pContent.Load<Texture2D>("GreyBlock64"), 0f);
            mouse.AddComponent(mouseSpriteRenderer);
            mouse.AddComponent(new RectangleCollider(mouse, _RectangleCollisionSystem));
            mouse.AddComponent(new MouseSelector(mouse));
            _GameObjects.Add(mouse);


        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
