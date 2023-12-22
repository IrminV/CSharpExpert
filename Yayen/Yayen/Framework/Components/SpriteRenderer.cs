using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Framework.Components.Base;
using Yayen.Framework.GameObjects;

namespace Yayen.Framework.Components
{
    public class SpriteRenderer : Component
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
        private SpriteEffects _spriteEffects = SpriteEffects.None;
        private Color _colorMask = Color.White;
        private float _layerDepth = 0;
        private Vector2 _origin;
        private Transform2D _transform;

        ContentManager _content;
        private Timer _testTimer = new(10f);

        //public Texture2D Sprite { get { return _sprite; } }
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
        public SpriteRenderer(GameObject pGameObject, ContentManager pContent, Texture2D pSprite, float pLayerDepth = 0, float pOriginX = 0.5f, float pOriginY = 0.5f, SpriteEffects pSpriteEffects = SpriteEffects.None) : base(pGameObject)
        {
            _content = pContent;
            _sprite = pSprite;
            //_colorMask = new Color(0, 0, 0, 255);
            _layerDepth = pLayerDepth;
            _origin = new Vector2(pOriginX, pOriginY);
            _spriteEffects = pSpriteEffects;

            _transform = (Transform2D)GameObject.GetComponent<Transform2D>();
        }

        public override void Update(GameTime pGameTime, Transform2D pTransform)
        {
            base.Update(pGameTime, pTransform);
            _testTimer.Update(pGameTime);
        }

        public override void Draw(SpriteBatch pSpriteBatch, Transform2D pTransform)
        {
            pSpriteBatch.Draw(_sprite,
                new Vector2(pTransform.GlobalPosition.X, pTransform.GlobalPosition.Y),
                null,
                _colorMask,
                MathHelper.ToRadians(pTransform.GlobalRotation),
                new Vector2(_sprite.Width * _origin.X, _sprite.Height * _origin.Y),
                pTransform.Scale,
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
    }
}