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
        Timer _frameTimer = new(0, "FrameTimer");

        private AnimatedSpriteRenderer _animSpriteRenderer;
        private List<SpriteSheetAnimation> _animations = new List<SpriteSheetAnimation>();
        int _currentAnimIndex = 0;

        //private bool _runAnimations = true;
        private bool loopAnimation = false;

        private float _animationTime;

        public SpriteSheetAnimator(AnimatedSpriteRenderer pAnimSpriteRenderer, float pAnimationTime, params SpriteSheetAnimation[] pAnimations)
        {
            _animationTime = pAnimationTime;

            _animSpriteRenderer = pAnimSpriteRenderer;
            for (int i = 0; i < pAnimations.Length; i++)
            {
                _animations.Add(pAnimations[i]);
            }
        }

        public void Start()
        {
            SwitchSpriteSheet(0);
            _frameTimer.OnTimeElapsed += RestartFrameTimer;
        }

        public void Update(GameTime pGameTime)
        {
            _frameTimer.Update(pGameTime);
        }

        //public void UpdateCurrentAnimation()
        //{
        //    if (!_runAnimations) { return; }

        //    _animations[_currentAnimIndex].NextFrame();
        //}

        public void SwitchSpriteSheet(int pIndex)
        {
            _animations[_currentAnimIndex].ResetAnimation();
            _frameTimer.OnTimeElapsed -= _animations[_currentAnimIndex].NextFrame;
            _currentAnimIndex = pIndex;
            _animSpriteRenderer.Sprite = _animations[_currentAnimIndex].SpriteSheet;
            _animations[_currentAnimIndex].ResetAnimation();
            _frameTimer.SetTimer(_animationTime / _animations[_currentAnimIndex].Frames);
            _frameTimer.OnTimeElapsed += _animations[_currentAnimIndex].NextFrame;
        }

        public Rectangle GetSourceRectangle()
        {
            return _animations[_currentAnimIndex].SourceRectangle;
        }

        public void StartAnimating()
        {
            _frameTimer.StartTimer();
        }

        public void StopAnimating()
        {
            _frameTimer.PauseTimer();
        }

        public void RestartFrameTimer()
        {
            _frameTimer.ResetTimer(true);
        }
    }
}
