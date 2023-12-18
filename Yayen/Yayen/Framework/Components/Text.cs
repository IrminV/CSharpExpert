using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Framework.Components.Base;

namespace Yayen.Framework.Components
{
    public class Text : Component
    {
        private string _text;
        SpriteFont _font;
        float _fontSize;
        Vector2 _position;

        //    public override void Draw(SpriteBatch pSpriteBatch)
        //    {
        //        base.Draw(pSpriteBatch);
        //        pSpriteBatch.DrawString(_font, _text, GameObjec);
        //    }
    }
}
