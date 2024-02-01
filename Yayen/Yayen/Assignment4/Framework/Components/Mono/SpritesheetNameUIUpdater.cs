using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment4.Framework.Components.Mono.Base;
using Yayen.Assignment4.Framework.GameObjects;

namespace Yayen.Assignment4.Framework.Components.Mono
{
    /// <summary>
    /// Script to display spriteSheet name with Text.
    /// </summary>
    public class SpritesheetNameUIUpdater : MonoBehaviour
    {
        Text _text;
        Button _button;
        GameObject _animationObject;
        SpriteSheetAnimator _animator;
        string _preText = "Current Anim:\n";
        
        /// <summary>
        /// Create script to display current spritesheet
        /// </summary>
        /// <param name="pAnimationObject">Animated GameObject.</param>
        /// <param name="pText">Text Component to display text.</param>
        public SpritesheetNameUIUpdater(GameObject pAnimationObject, Text pText) { _animationObject = pAnimationObject; _text = pText; }

        public override void Start()
        {
            base.Start();
            _button = GameObject.GetComponent<Button>();
            _animator = _animationObject.GetComponent<AnimatedSpriteRenderer>().SpriteSheetAnimator;
            _button.OnButtonPressed += UpdateNameUIString;
            UpdateNameUIString();

        }

        /// <summary>
        /// Update string on cached Text object to display _preText + _animator.GetSpriteSheetName().
        /// </summary>
        private void UpdateNameUIString()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Updating Animation Name UI");
            Console.ResetColor();
            _text.String = _preText + _animator.GetSpriteSheetName();
        }
    }
}
