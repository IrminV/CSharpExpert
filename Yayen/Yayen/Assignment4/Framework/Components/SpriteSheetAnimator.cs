using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment4.Framework.Components.Base;
using Yayen.Assignment4.Framework.Components.Interfaces;

namespace Yayen.Assignment4.Framework.Components
{
    public class SpriteSheetAnimator : Component, IUpdatableComponent
    {
        private SpriteRenderer _spriteRenderer;
        private List<SpriteSheetAnimation> _animations = new List<SpriteSheetAnimation>();
        int _currentAnimIndex = 0;

        private bool _runAnimations = true;

        public SpriteSheetAnimator(SpriteRenderer pSpriteRenderer, params SpriteSheetAnimation[] pAnimations)
        {
            _spriteRenderer = pSpriteRenderer;
            for (int i = 0; i < pAnimations.Length; i++)
            {
                _animations.Add(pAnimations[i]);
            }
        }

        public override void Start()
        {
            SwitchSpriteSheet(0);
        }

        public void Update(GameTime pGameTime)
        {
            UpdateCurrentAnimation();
        }

        public void UpdateCurrentAnimation()
        {
            if (!_runAnimations) { return; }

            _animations[_currentAnimIndex].Update();
        }

        public void SwitchSpriteSheet(int pIndex)
        {
            _animations[_currentAnimIndex].StopAnimation();
            _animations[_currentAnimIndex].ResetAnimation();
            _currentAnimIndex = pIndex;
            _animations[_currentAnimIndex].ResetAnimation();
            _animations[_currentAnimIndex].StartAnimation();
        }

    }
}
