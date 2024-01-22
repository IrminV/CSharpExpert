using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Yayen.Assignment3.Framework.Components
{
    public class SpriteSheet
    {
        private int _pixelHeight;
        private int _pixelWidth;
        private int _startingIndex = 0;
        private int _finalIndex;

        public SpriteSheet(Texture2D pSpriteSheet, Vector2 pSpriteDimensions) 
        {
            _pixelHeight = pSpriteSheet.Height;
            _pixelWidth = pSpriteSheet.Width;
            _finalIndex = (pSpriteSheet.Width / (int)pSpriteDimensions.X) * pSpriteSheet.Height;
        }

    }
}
