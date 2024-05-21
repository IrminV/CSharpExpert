using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment4.Framework.Components.Base;
using Yayen.Assignment4.Framework.Components.Interfaces;
using Yayen.Assignment4.Framework.GameObjects;

namespace Yayen.Assignment4.Framework.Components
{
    /// <summary>
    /// A SpriteRenderer used to display animation. This works together with a SpriteAnimator and SpriteAnimation. (These are not components yet)
    /// </summary>
    public class AnimatedSpriteRenderer : Component, IUpdatableComponent, IDrawableComponent
    {
        /* What does a sprite renderer do?
         * 
         * It draws a sprite
         * It uses MonoGame SpriteEffects to be able to mirror sprites
         * It uses a colormask as desribed in the MonoGame documentation for SpriteBatch: https://docs.monogame.net/api/Microsoft.Xna.Framework.Graphics.SpriteBatch.html 
         * It uses layerDepth to make us able to decide drawing order.
         * 
         * We can use an origin to decide where to draw form position point.
         */

        private Texture2D _sprite;
        private SpriteSheetAnimator _spriteSheetAnimator;
        private SpriteEffects _spriteEffects = SpriteEffects.None;
        private Color _colorMask = Color.White;
        private float _layerDepth = 0;
        private Vector2 _origin;
        private Transform2D _transform;

        private ContentManager _content;
        //private Timer _testTimer = new(10f);
        public Texture2D Sprite { get { return _sprite; } set { _sprite = value; } }
        public SpriteSheetAnimator SpriteSheetAnimator { get { return _spriteSheetAnimator; } }
        public Color ColorMask { get { return _colorMask; } set { _colorMask = value; } }
        public float LayerDepth { get { return _layerDepth; } }

        /// <summary>
        /// Base constructor, which can already work with just a sprite.
        /// </summary>
        /// <param name="pSprite">Sprite to draw.</param>
        /// <param name="pSpriteEffects">Mirror option to use.</param>
        /// <param name="pLayerDepth">Layerdepth for the order of drawing things.</param>
        /// <param name="pOriginX">Draw origin X.</param>
        /// <param name="pOriginY">Draw origin Y.</param>
        /// <param name="pSpriteEffects">MonoGame SpriteEffects, used to mirror sprites.</param>
        public AnimatedSpriteRenderer(ContentManager pContent, float pLayerDepth = 0, float pOriginX = 0.5f, float pOriginY = 0.5f, SpriteEffects pSpriteEffects = SpriteEffects.None)
        {
            _content = pContent;
            //_colorMask = new Color(0, 0, 0, 255);
            _layerDepth = pLayerDepth;
            _origin = new Vector2(pOriginX, pOriginY);
            _spriteEffects = pSpriteEffects;
        }

        public override void Start()
        {
            base.Start();
            _transform = GameObject.GetComponent<Transform2D>();
            _spriteSheetAnimator.Start();
        }

        public void Update(GameTime pGameTime)
        {
            // Update animation here
            _spriteSheetAnimator.Update(pGameTime);
        }

        public void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(_sprite,
                new Vector2(_transform.GlobalPosition.X, _transform.GlobalPosition.Y),
                _spriteSheetAnimator.GetSourceRectangle(),
                _colorMask,
                MathHelper.ToRadians(_transform.GlobalRotation),
                new Vector2(_spriteSheetAnimator.GetSourceRectangle().Width * _origin.X, _spriteSheetAnimator.GetSourceRectangle().Height * _origin.Y),
                _transform.GlobalScale,
                _spriteEffects,
                _layerDepth);
        }

        /// <summary>
        /// Gets the width and height of a spriteRenderer sprite with scaling included.
        /// </summary>
        /// <returns>the width and height of the spriteRenderer sprite with scaling included.</returns>
        public Vector2 GetSpriteBounds()
        {
            return new Vector2(_sprite.Width * _transform.Scale.X, _sprite.Height * _transform.Scale.Y);
        }

        public void SetAnimator(SpriteSheetAnimator pSpriteSheetAnimator)
        {
            _spriteSheetAnimator = pSpriteSheetAnimator;
        }


    }
}