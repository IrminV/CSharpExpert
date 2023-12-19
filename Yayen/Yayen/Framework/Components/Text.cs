using Microsoft.Xna.Framework;
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
    public class Text : Component
    {
        SpriteFont _font;
        private string _text;
        //float _fontSize;
        //Vector2 _position;
        Vector2 _textSize;
        Color _color = Color.White;
        Vector2 _position;

        public Color Color { get { return _color; } set { _color = value; } }

        public Text(GameObject pGameObject, SpriteFont pFont, string text, float posX = 0, float posY = 0) : base(pGameObject)
        {
            _font = pFont;
            _text = text;
            _position = new Vector2(posX, posY);
            ConstructInitializer();
        }

        private void ConstructInitializer()
        {
            UpdateTextSize();
        }

        public override void Draw(SpriteBatch pSpriteBatch, Transform2D pTransform)
        {
            
            base.Draw(pSpriteBatch, pTransform);
            pSpriteBatch.DrawString(_font, _text, new Vector2(pTransform.GlobalPosition.X - (_textSize.X / 2) + _position.X, pTransform.GlobalPosition.Y - (_textSize.Y / 2) + _position.Y), _color);

        }

        public void UpdateTextSize()
        {
            _textSize = _font.MeasureString( _text );
        }
    }
}
