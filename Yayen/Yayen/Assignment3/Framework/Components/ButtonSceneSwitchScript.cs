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
    /// <summary>
    /// Script to make a button switch scenes.
    /// </summary>
    public class ButtonSceneSwitchScript : Component
    {
        private Button _button;
        private SceneSystem _sceneSystem;
        private string _sceneName;

        /// <summary>
        /// Create a ButtonSceneSwitchScript Component.
        /// </summary>
        /// <param name="pSceneSystem">Reference to the SceneSystem used to switch scenes.</param>
        /// <param name="pSceneName">The name of the scene we want to switch to.</param>
        public ButtonSceneSwitchScript(SceneSystem pSceneSystem, string pSceneName)
        {
            _sceneSystem = pSceneSystem;
            _sceneName = pSceneName;
        }

        public override void Start()
        {
            base.Start();
            SetButtonEvent();
        }

        private void SetButtonEvent()
        {
            // Get the button component on this components GameObject
            _button = (Button)GameObject.GetComponent<Button>();
            // Add SwitchScene() to the OnButtonPressed event
            _button.OnButtonPressed += SwitchScene;
        }

        private void SwitchScene()
        {
            _sceneSystem.SwitchScene(_sceneName);
        }
    }
}
