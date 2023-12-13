using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yayen.Framework.Components
{
    public class SpriteRenderer
    {
        /* What does a sprite renderer do?
         * 
         * It draws a sprite
         * It uses MonoGame SpriteEffects to be able to mirror sprites
         * It uses a colormask as desribed in the MonoGame documentation for SpriteBatch: https://docs.monogame.net/api/Microsoft.Xna.Framework.Graphics.SpriteBatch.html 
         * It uses layerDepth to make us able to decide drawing order.
         * 
         * 
         */

        private Texture2D _sprite;
        private SpriteEffects _spriteEffects = SpriteEffects.None;
        private Color _colorMask = new(0, 0, 0, 0);
        private float _layerDepth = 0;

        /// <summary>
        /// Base constructor, which can already work with just a sprite.
        /// </summary>
        /// <param name="pSprite">Sprite to draw.</param>
        /// <param name="pSpriteEffects">Mirror option to use.</param>
        /// <param name="pLayerDepth">Layerdepth for the order of drawing things.</param>
        public SpriteRenderer(Texture2D pSprite, SpriteEffects pSpriteEffects = SpriteEffects.None, float pLayerDepth = 0)
        {
            _sprite = pSprite;
            _spriteEffects = pSpriteEffects;
            _colorMask = new Color(0, 0, 0, 0);
            _layerDepth = pLayerDepth;
        }
    }
}