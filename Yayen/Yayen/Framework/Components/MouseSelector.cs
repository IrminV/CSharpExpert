using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Framework.Components.Base;

namespace Yayen.Framework.Components
{
    public class MouseSelector : Component
    {
        private MouseState _mouseState = new MouseState();


        public MouseSelector() 
        { 
        
        }



        public override void Update(GameTime pGameTime, Transform2D pTransform)
        {
            base.Update(pGameTime, pTransform);
            _mouseState = Mouse.GetState();
            pTransform.Position = new Vector2(_mouseState.Position.X, _mouseState.Position.Y);
            //pTransform.Position =
        }





    }
}
