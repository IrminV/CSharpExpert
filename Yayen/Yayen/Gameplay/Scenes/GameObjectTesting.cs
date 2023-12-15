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

namespace Yayen.Gameplay.Scenes
{
    public class GameObjectTesting : Scene
    {
        public GameObjectTesting(SceneSystem sceneSystem, ContentManager content, Game1 game1, string name = "Scene") : base(sceneSystem, content, game1, name) { }

        public override void LoadContent(ContentManager pContent, Game1 pGame1)
        {
            base.LoadContent(pContent, pGame1);
            GameObject newGameObject = new(0, 0);
            Component newSpriteRenderer = new SpriteRenderer(pContent.Load<Texture2D>("GreyBlock64"));
            newGameObject.AddComponent(newSpriteRenderer);
            _GameObjects.Add(newGameObject);
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
