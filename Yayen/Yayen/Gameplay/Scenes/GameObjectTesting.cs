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

namespace Yayen.Gameplay.Scenes
{
    public class GameObjectTesting : Scene
    {
        public GameObjectTesting(SceneSystem sceneSystem, ContentManager content, Game1 game1, string name = "Scene") : base(sceneSystem, content, game1, name)
        {
        }

        public override void LoadContent(ContentManager content, Game1 game1)
        {
            base.LoadContent(content, game1);
            GameObject myFirstgameObject = new();
        }
    }
}
