using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Framework.Components.Base;
using Yayen.Framework.GameObjects;

namespace Yayen.Framework.Components
{
    /// <summary>
    /// Mouse GameObject
    /// </summary>
    public class MouseSelector : Component
    {
        private MouseState _mouseState = new MouseState();

        /// <summary>
        /// Create a MouseSelector component which designates the GameObject it is part of, as a mouse.
        /// </summary>
        /// <param name="pGameObject">Reference to GameObject this component is part of.</param>
        public MouseSelector(GameObject pGameObject) : base(pGameObject) 
        { 
        
        }

        public override void Update(GameTime pGameTime, Transform2D pTransform)
        {
            base.Update(pGameTime, pTransform);
            _mouseState = Mouse.GetState();
            pTransform.Position = new Vector2(_mouseState.Position.X, _mouseState.Position.Y);
        }
    }
}
