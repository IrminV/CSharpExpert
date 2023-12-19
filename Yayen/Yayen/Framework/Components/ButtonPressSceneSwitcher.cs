using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Framework.Components.Base;
using Yayen.Framework.GameObjects;
using Yayen.Framework.Scenes;

namespace Yayen.Framework.Components
{
    public class ButtonPressSceneSwitcher : Component
    {
        KeyboardState _keyBoardState;
        private bool _checkPressed = true;
        SceneSystem _sceneSystem;
        Keys _key = Keys.Enter;

        public ButtonPressSceneSwitcher(GameObject pGameObject, SceneSystem pSceneSystem, Keys pKey = Keys.Enter) : base(pGameObject)
        {
            _sceneSystem = pSceneSystem;
            _key = pKey;
        }

        public override void Update(GameTime pGameTime, Transform2D pTransform)
        {
            base.Update(pGameTime, pTransform);
        }

        private void CheckButtonPress()
        {
            if (_checkPressed && _keyBoardState.IsKeyDown(_key))
            {

            }
        }
    }
}
