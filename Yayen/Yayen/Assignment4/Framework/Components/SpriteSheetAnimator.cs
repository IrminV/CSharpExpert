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
    public class SpriteSheetAnimator
    {
        

        private AnimatedSpriteRenderer _animSpriteRenderer;
        private List<SpriteSheetAnimation> _animations = new List<SpriteSheetAnimation>();
        int _currentAnimIndex = 0;

        public SpriteSheetAnimator(AnimatedSpriteRenderer pAnimSpriteRenderer, params SpriteSheetAnimation[] pAnimations)
        {
            

            _animSpriteRenderer = pAnimSpriteRenderer;
            for (int i = 0; i < pAnimations.Length; i++)
            {
                _animations.Add(pAnimations[i]);
            }
        }

        public void Start()
        {
            Console.WriteLine("Animator start has been called");
            SwitchAnimation(0);
            for (int i = 0; i < _animations.Count; i++)
            {
                _animations[i].Start();
            }
        }

        public void Update(GameTime pGameTime)
        {
            _animations[_currentAnimIndex].Update(pGameTime);
        }

        public void SwitchAnimation(int pIndex)
        {
            _animations[_currentAnimIndex].StopAnimation();
            _currentAnimIndex = pIndex;
            _animSpriteRenderer.Sprite = _animations[_currentAnimIndex].SpriteSheet;
            _animations[_currentAnimIndex].PlayAnimation();
        }

        public void PlayAnimation()
        {
            _animSpriteRenderer.Sprite = _animations[_currentAnimIndex].SpriteSheet;
            _animations[_currentAnimIndex].PlayAnimation();
        }

        public Rectangle GetSourceRectangle()
        {
            return _animations[_currentAnimIndex].SourceRectangle;
        }
    }
}
