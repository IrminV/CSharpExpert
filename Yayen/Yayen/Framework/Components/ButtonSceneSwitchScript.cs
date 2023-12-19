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
    public class ButtonSceneSwitchScript : Component
    {
        Button _button;
        SceneSystem _sceneSystem;
        string _sceneName;

        public ButtonSceneSwitchScript(GameObject pGameObject, SceneSystem pSceneSystem, string pSceneName) : base(pGameObject)
        {
            _sceneSystem = pSceneSystem;
            _sceneName = pSceneName;
            ConstructInitializer();
        }

        private void ConstructInitializer()
        {
            _button = (Button)GameObject.GetComponent<Button>();
            _button.OnButtonPressed += SwitchScene;
        }

        private void SwitchScene()
        {
            _sceneSystem.SwitchScene(_sceneName);
        }


    }
}
