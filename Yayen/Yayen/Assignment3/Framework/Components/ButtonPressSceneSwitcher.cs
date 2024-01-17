using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment3.Framework.Components.Base;
using Yayen.Assignment3.Framework.GameObjects;
using Yayen.Assignment3.Framework.Scenes;

namespace Yayen.Assignment3.Framework.Components
{
    // UNUSED ATM
    // I created this as backup, for if my buttons wouldn't work.

    /// <summary>
    /// Script to make a key switch scenes.
    /// </summary>
    public class ButtonPressSceneSwitcher : MonoBehaviour
    {
        KeyboardState _keyBoardState;
        private bool _checkPressed = true;
        SceneSystem _sceneSystem;
        Keys _key = Keys.Enter;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSceneSystem">Reference to the SceneSystem used to switch scenes.</param>
        /// <param name="pKey">Key to press to switch scenes</param>
        public ButtonPressSceneSwitcher(SceneSystem pSceneSystem, Keys pKey = Keys.Enter)
        {
            _sceneSystem = pSceneSystem;
            _key = pKey;
        }

        public override void Update(GameTime pGameTime)
        {
            base.Update(pGameTime);
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
