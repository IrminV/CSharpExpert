using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment2.Framework.Components.Base;
using Yayen.Assignment2.Framework.GameObjects;

namespace Yayen.Assignment2.Framework.Components
{
    /// <summary>
    /// Text Component. Displays text at position local to GameObject.
    /// </summary>
    public class Text : Component
    {
        SpriteFont _font;
        private string _text;
        //float _fontSize;
        //Vector2 _position;
        Vector2 _textSize;
        Color _color = Color.White;
        Vector2 _position;
        float _rotation = 0;
        Vector2 _origin = Vector2.Zero;
        float _scale = 1;
        SpriteEffects _spriteEffects = SpriteEffects.None;
        float _layerDepth = 0;

        Transform2D _transform;

        public Color Color { get { return _color; } set { _color = value; } }
        /// <summary>
        /// Create a Text component which displays text at a position local to the GameObject it is part of.
        /// </summary>
        /// <param name="pGameObject">Reference to GameObject this component is part of.</param>
        /// <param name="pFont">Font to use when drawing text.</param>
        /// <param name="text">String of text to display.</param>
        /// <param name="pPosX">Position on the X axis.</param>
        /// <param name="pPosY">Position on the Y axis</param>
        public Text(GameObject pGameObject, SpriteFont pFont, string text, float pPosX = 0, float pPosY = 0, float pLayerDepth = -1) : base(pGameObject)
        {
            _font = pFont;
            _text = text;
            _position = new Vector2(pPosX, pPosY);
            if (pLayerDepth == -1) UpdateLayerDepthToAboveSprite();
            else _layerDepth = pLayerDepth;
            ConstructInitializer();

            _transform = GameObject.GetComponent<Transform2D>();
        }

        private void ConstructInitializer()
        {
            UpdateTextSize();
        }

        /// <summary>
        /// Draw text on screen.
        /// </summary>
        /// <param name="pSpriteBatch">SpriteBatch used to draw.</param>
        /// <param name="pTransform">Reference to the transform of the gameobject this is part of.</param>
        public override void Draw(SpriteBatch pSpriteBatch)
        {

            base.Draw(pSpriteBatch);
            pSpriteBatch.DrawString(_font, _text, new Vector2(_transform.GlobalPosition.X - _textSize.X / 2 + _position.X, _transform.GlobalPosition.Y - _textSize.Y / 2 + _position.Y), _color, _rotation, _origin, _scale, _spriteEffects, _layerDepth);

        }

        /// <summary>
        /// Updates _textSize variable to contain the size of the currently established string.
        /// </summary>
        public void UpdateTextSize()
        {
            _textSize = _font.MeasureString(_text);
        }

        /// <summary>
        /// Generate a layerdepth 0.1f higher than the SpriteRenderer this is part of. Does nothing if no SpriteRenderer is detected.
        /// </summary>
        public void UpdateLayerDepthToAboveSprite()
        {
            SpriteRenderer spriteRenderer = (SpriteRenderer)GameObject.GetComponent<SpriteRenderer>();

            if (spriteRenderer == null) { /*Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"Warning no spriterender found for text layerdepth on object {GameObject.Name}"); Console.ResetColor();*/ return; }
            _layerDepth = Math.Clamp(spriteRenderer.LayerDepth + 0.1f, 0, 1);
        }
    }
}
