using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment4.Framework.Components.Base;
using Yayen.Assignment4.Framework.Components.Mono.Base;
using Yayen.Assignment4.Framework.GameObjects;
using Yayen.Assignment4.Framework.Scenes;
using Yayen.Assignment4.Framework.Scenes.Base;

namespace Yayen.Assignment4.Framework.Components.Mono
{
    /// <summary>
    /// Script to make a button switch scenes.
    /// </summary>
    public class ButtonSceneSwitchScript : MonoBehaviour
    {
        private Button _button;
        private SceneSystem _sceneSystem;
        private Scene _sceneToSwitchTo;

        /// <summary>
        /// Create a ButtonSceneSwitchScript Component.
        /// </summary>
        /// <param name="pSceneSystem">Reference to the SceneSystem used to switch scenes.</param>
        /// <param name="pSceneName">The name of the scene we want to switch to.</param>
        public ButtonSceneSwitchScript(SceneSystem pSceneSystem, string pSceneName)
        {
            _sceneSystem = pSceneSystem;
            _sceneToSwitchTo = _sceneSystem.GetSceneByName(pSceneName);
        }

        public ButtonSceneSwitchScript(SceneSystem pSceneSystem, Scene pScene)
        {
            _sceneSystem = pSceneSystem;
            _sceneToSwitchTo = pScene;
        }

        public ButtonSceneSwitchScript(SceneSystem pSceneSystem, int pIndex)
        {
            _sceneSystem = pSceneSystem;
            _sceneToSwitchTo = _sceneSystem.GetSceneByIndex(pIndex);
        }

        public override void Start()
        {
            base.Start();
            SetButtonEvent();
        }

        private void SetButtonEvent()
        {
            // Get the button component on this components GameObject
            _button = GameObject.GetComponent<Button>();
            // Add SwitchScene() to the OnButtonPressed event
            _button.OnButtonPressed += SwitchScene;
        }

        private void SwitchScene()
        {
            _sceneSystem.SwitchScene(_sceneToSwitchTo);
        }
    }
}
