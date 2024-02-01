using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Yayen.Assignment4.Framework.Components
{
    /// <summary>
    /// A Sprite Animation.
    /// </summary>
    public class SpriteSheetAnimation
    {
        /// <summary>
        /// When this timer hits zero, a new frame will be set.
        /// </summary>
        Timer _frameTimer = new(1, "FrameTimer");

        private Texture2D _spriteSheet;
        /// <summary>
        /// The size of the individual sprites on _spriteSheet.
        /// </summary>
        private Vector2 _spriteDimensions;

        private int _framesOnXAxis;
        private int _framesOnYAxis;
        private int _frames;
        private int _startingIndex;
        private int _finalIndex;
        private int _currentIndex;

        /// <summary>
        /// Time for the animation as a whole to complete.
        /// </summary>
        private float _animationTime;

        /// <summary>
        /// The SourceRectangle used on the spriteSheet to get the current frame.
        /// </summary>
        private Rectangle _sourceRectangle;

        private bool _loop = false;

        //public delegate void AnimationEndDelegate();
        //public event AnimationEndDelegate OnAnimationComplete;

        public Texture2D SpriteSheet { get { return _spriteSheet; } }

        /// <summary>
        /// Amount of frames possible on _spriteSheet.
        /// </summary>
        public int Frames { get { return _frames; } }
        /// <summary>
        /// Current frame index.
        /// </summary>
        public int CurrentIndex { get { return _currentIndex; } }
        /// <summary>
        /// Property to get SourceRectangle for current frame.
        /// </summary>
        public Rectangle SourceRectangle { get { return _sourceRectangle; } }

        public SpriteSheetAnimation(Texture2D pSpriteSheet, Vector2 pSpriteDimensions, float pAnimationTime, int pStartingIndex, int pFinalIndex) 
        {
            _startingIndex = pStartingIndex;
            _currentIndex = _startingIndex;
            _finalIndex = pFinalIndex;
            _spriteSheet = pSpriteSheet;
            _spriteDimensions = pSpriteDimensions;
            _sourceRectangle.Width = (int)_spriteDimensions.X;
            _sourceRectangle.Height = (int)_spriteDimensions.Y;

            SetFrameAmount();

            //_finalIndex = (int)MathF.Truncate(_spriteSheet.Width / pSpriteDimensions.X) * (int)MathF.Truncate(pSpriteSheet.Height / _spriteDimensions.Y) - 1;
            //SetSourceRectangle(Vector2.Zero);

            _animationTime = pAnimationTime;
        }

        public SpriteSheetAnimation(Texture2D pSpriteSheet, Vector2 pSpriteDimensions, float pAnimationTime = 1) : this(pSpriteSheet, pSpriteDimensions, pAnimationTime,  0, ((int)MathF.Truncate(pSpriteSheet.Width / pSpriteDimensions.X) * (int)MathF.Truncate(pSpriteSheet.Height / pSpriteDimensions.Y))) {  }

        public void Start()
        {
            _frameTimer.OnTimeElapsed += RestartFrameTimer;
            _frameTimer.OnTimeElapsed += NextFrame;

            _frameTimer.TimerTime = _animationTime / (_frames - (_finalIndex - _frames));
            Console.WriteLine($"FinalIndex is {_finalIndex}");
            //OnAnimationComplete += StopAnimation;

            UpdateFrameTime();
        }

        public void Update(GameTime pGameTime)
        {
            _frameTimer.Update(pGameTime);
        }

        /// <summary>
        /// Set _currentIndex to _startingIndex.
        /// </summary>
        public void ResetAnimation()
        {
            _currentIndex = _startingIndex;
        }

        /// <summary>
        /// Returns the amount of frames on x and y axis of the spritesheet.
        /// </summary>
        /// <returns>amount of frames on x and y axis of the spritesheet.</returns>
        private void SetFrameAmount()
        {
            _framesOnXAxis = (int)MathF.Truncate(_spriteSheet.Width / _spriteDimensions.X);
            _framesOnYAxis = (int)MathF.Truncate(_spriteSheet.Height / _spriteDimensions.Y);
            _frames = _framesOnXAxis * _framesOnYAxis;
        }

        /// <summary>
        /// Set SourceRectangle to show a frame at index.
        /// </summary>
        /// <param name="pIndex"></param>
        private void SetSourceRectangle(int pIndex)
        {
            _sourceRectangle.X = pIndex * (int)_spriteDimensions.X % _spriteSheet.Width;
            _sourceRectangle.Y = (int)(MathF.Truncate(pIndex / _framesOnXAxis) * _spriteDimensions.Y);
            _sourceRectangle.Width = (int)_spriteDimensions.X;
            _sourceRectangle.Height = (int)_spriteDimensions.Y;
        }

        /// <summary>
        /// Set the frame timer to animationtime / frames
        /// </summary>
        private void UpdateFrameTime()
        {
            _frameTimer.TimerTime = _animationTime / _frames;
        }

        /// <summary>
        /// Update Source Rectangle without moving to next frame
        /// </summary>
        private void UseCurrentFrame()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Calling first frame");
            Console.WriteLine($"Current animation index is {_currentIndex}");
            Console.WriteLine($"Current SourceRectangle position is {_sourceRectangle.Location}");
            Console.ResetColor();
            SetSourceRectangle(_currentIndex);  
        }

        /// <summary>
        /// Update _currentIndex and SourceRectangle to next frame.
        /// </summary>
        private void NextFrame()
        {
            if (_currentIndex + 1 > _finalIndex - 1)
            {
                _currentIndex = _startingIndex;
                if (!_loop) StopAnimation();
                
                //OnAnimationComplete?.Invoke();
            }
            else
            {
                _currentIndex++;
            }
            SetSourceRectangle(_currentIndex);
            Console.WriteLine($"Current animation index is {_currentIndex}");
            Console.WriteLine($"Current SourceRectangle position is {_sourceRectangle.Location}");
        }

        /// <summary>
        /// Set Source Rectangle to display current frame, reset and activate _frameTimer.
        /// </summary>
        public void PlayAnimation()
        {
            UseCurrentFrame();
            _frameTimer.ResetTimer(true);
            Console.WriteLine($"Playing animation {_frameTimer.TimerActive}");
        }

        /// <summary>
        /// Reset and don't activate _frameTimer.
        /// </summary>
        public void StopAnimation()
        {
            _frameTimer.ResetTimer();
        }

        /// <summary>
        /// reset and activate _frameTimer.
        /// </summary>
        public void RestartFrameTimer()
        {
            _frameTimer.ResetTimer(true);
        }
    }
}
