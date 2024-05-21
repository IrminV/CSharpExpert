using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment1.Framework.Components.Base;
using Yayen.Assignment1.Framework.GameObjects;
using Yayen.Assignment1.Framework.Scenes;

namespace Yayen.Assignment1.Framework.Components
{
    // UNUSED ATM
    // I created this as backup, for if my buttons wouldn't work.

    /// <summary>
    /// Script to make a key switch scenes.
    /// </summary>
    public class ButtonPressSceneSwitcher : Component
    {
        KeyboardState _keyBoardState;
        private bool _checkPressed = true;
        SceneSystem _sceneSystem;
        Keys _key = Keys.Enter;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pGameObject">Reference to GameObject this component is part of.</param>
        /// <param name="pSceneSystem">Reference to the SceneSystem used to switch scenes.</param>
        /// <param name="pKey">Key to press to switch scenes</param>
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
            // When checking is enabled and the key pressed, switch scenes
            if (_checkPressed && _keyBoardState.IsKeyDown(_key))
            {
                // TODO: finish this method.
            }
        }
    }
}
