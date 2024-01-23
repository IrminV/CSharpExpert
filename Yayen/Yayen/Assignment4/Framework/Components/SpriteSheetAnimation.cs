using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yayen.Assignment4.Framework.Components
{
    public class SpriteSheetAnimation
    {
        private Texture2D _spriteSheet;
        private int _pixelHeight;
        private int _pixelWidth;
        private int _startingIndex;
        private int _finalIndex;
        private int _currentIndex;
        private Vector2 _spriteDimensions;
        private Rectangle _sourceRectangle;

        private bool _runAnimation = false;

        public Rectangle SourceRectangle { get { return _sourceRectangle; } }

        public SpriteSheetAnimation(Texture2D pSpriteSheet, Vector2 pSpriteDimensions, int pStartingIndex, int pFinalIndex) 
        {
            _startingIndex = pStartingIndex;
            _finalIndex = pFinalIndex;
            _spriteSheet = pSpriteSheet;
            _spriteDimensions = pSpriteDimensions;
            _pixelHeight = _spriteSheet.Height;
            _pixelWidth = _spriteSheet.Width;
            _finalIndex = (_spriteSheet.Width / (int)pSpriteDimensions.X) * pSpriteSheet.Height;
        }

        public SpriteSheetAnimation(Texture2D pSpriteSheet, Vector2 pSpriteDimensions) : this(pSpriteSheet, pSpriteDimensions, 0, (pSpriteSheet.Height * pSpriteSheet.Width)) { }

        public void Update()
        {
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            if (!_runAnimation) return;

            for (int Y = 0; Y < _pixelHeight; Y += (int)_spriteDimensions.Y)
            {
                for (int X = 0; X < _pixelWidth; X += (int)_spriteDimensions.X)
                {
                    //_sourceRectangle = new(x, y, (int)_spriteDimensions.X, (int)_spriteDimensions.Y);
                    _sourceRectangle.X = X;
                    _sourceRectangle.Y = Y;
                    _sourceRectangle.Width = (int)_spriteDimensions.X;
                    _sourceRectangle.Height = (int)_spriteDimensions.Y;
                }
            }
        }

        public void StartAnimation()
        {
            _runAnimation = true;
        }

        public void StopAnimation()
        {
            _runAnimation = false;
        }

        public void ResetAnimation()
        {
            _currentIndex = _startingIndex;
        }
    }
}
