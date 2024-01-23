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
    public class SpriteSheetAnimation
    {
        private Texture2D _spriteSheet;
        private int _pixelHeight;
        private int _pixelWidth;
        private Vector2 _spriteDimensions;

        private int _framesOnXAxis;
        private int _framesOnYAxis;
        private int _frames;
        private int _startingIndex;
        private int _finalIndex;
        private int _currentIndex;

        private Rectangle _sourceRectangle;

        public Texture2D SpriteSheet { get { return _spriteSheet; } }
        public int Frames { get { return _frames; } }
        public int CurrentIndex { get { return _currentIndex; } }
        public Rectangle SourceRectangle { get { return _sourceRectangle; } }

        public SpriteSheetAnimation(Texture2D pSpriteSheet, Vector2 pSpriteDimensions, int pStartingIndex, int pFinalIndex) 
        {
            _startingIndex = pStartingIndex;
            _finalIndex = pFinalIndex;
            _spriteSheet = pSpriteSheet;
            _spriteDimensions = pSpriteDimensions;
            _sourceRectangle.Width = (int)_spriteDimensions.X;
            _sourceRectangle.Height = (int)_spriteDimensions.Y;

            _pixelHeight = _spriteSheet.Height;
            _pixelWidth = _spriteSheet.Width;

            SetFrameAmount();

            _finalIndex = (_spriteSheet.Width / (int)pSpriteDimensions.X) * pSpriteSheet.Height;
            SetSourceRectangle(Vector2.Zero);
        }

        public SpriteSheetAnimation(Texture2D pSpriteSheet, Vector2 pSpriteDimensions) : this(pSpriteSheet, pSpriteDimensions, 0, ((int)MathF.Truncate(pSpriteSheet.Width / pSpriteDimensions.X) * (int)MathF.Truncate(pSpriteSheet.Height / pSpriteDimensions.Y))) { }

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

        private void SetSourceRectangle(int pIndex)
        {
            _sourceRectangle.X = pIndex * (int)_spriteDimensions.X % _spriteSheet.Width;
            _sourceRectangle.Y = (int)MathF.Truncate(pIndex / _framesOnXAxis);
            _sourceRectangle.Width = (int)_spriteDimensions.X;
            _sourceRectangle.Height = (int)_spriteDimensions.Y;
        }

        private void SetSourceRectangle(Vector2 pGridIndex)
        {
            _sourceRectangle.X = (int)pGridIndex.X * (int)_spriteDimensions.X;
            _sourceRectangle.Y = (int)pGridIndex.Y * (int)_spriteDimensions.Y;
            
        }

        public void NextFrame()
        {
            if (_currentIndex + 1 > _frames)
            {
                _currentIndex = _startingIndex;
            }
            else
            {
                _currentIndex++;
            }
            SetSourceRectangle(_currentIndex);
            Console.WriteLine($"Current animation index is {_currentIndex}");
            Console.WriteLine($"Current SourceRectangle position is {_sourceRectangle.Location}");
        }

        //for (int Y = 0; Y < _pixelHeight; Y += (int)_spriteDimensions.Y)
        //{
        //    for (int X = 0; X < _pixelWidth; X += (int)_spriteDimensions.X)
        //    {

        //    }
        //}
    }
}
