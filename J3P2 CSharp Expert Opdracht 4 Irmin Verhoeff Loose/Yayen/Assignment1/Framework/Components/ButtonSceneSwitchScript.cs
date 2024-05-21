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
    /// <summary>
    /// Script to make a button switch scenes.
    /// </summary>
    public class ButtonSceneSwitchScript : Component
    {
        Button _button;
        SceneSystem _sceneSystem;
        string _sceneName;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pGameObject">Reference to GameObject this component is part of.</param>
        /// <param name="pSceneSystem">Reference to the SceneSystem used to switch scenes.</param>
        /// <param name="pSceneName">The name of the scene we want to switch to.</param>
        public ButtonSceneSwitchScript(GameObject pGameObject, SceneSystem pSceneSystem, string pSceneName) : base(pGameObject)
        {
            _sceneSystem = pSceneSystem;
            _sceneName = pSceneName;
            ConstructInitializer();
        }

        private void ConstructInitializer()
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
