using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment4.Framework.Components.Base;
using Yayen.Assignment4.Framework.Components.Mono.Base;
using Yayen.Assignment4.Framework.GameObjects;
using Yayen.Assignment4.Framework.Scenes;

namespace Yayen.Assignment4.Framework.Components.Mono
{
    /// <summary>
    /// Script to make a button switch scenes.
    /// </summary>
    public class ButtonStartAnimScript : MonoBehaviour
    {
        private Button _button;
        private SpriteSheetAnimator _spriteSheetAnimator;

        /// <summary>
        /// Create a ButtonStartAnimScript. Component.
        /// </summary>
        public ButtonStartAnimScript(SpriteSheetAnimator pSpriteSheetAnimator)
        {
            _spriteSheetAnimator = pSpriteSheetAnimator;
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
            _button.OnButtonPressed += _spriteSheetAnimator.PlayAnimation;
        }
    }
}
