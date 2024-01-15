using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment3.Framework.Components.Base;
using Yayen.Assignment3.Framework.GameObjects;

namespace Yayen.Assignment3.Framework.Components
{
    /// <summary>
    /// Mouse GameObject
    /// </summary>
    public class MouseSelector : Component
    {
        private MouseState _mouseState = new MouseState();

        private Transform2D _transform2D;

        /// <summary>
        /// Create a MouseSelector component which designates the GameObject it is part of, as a mouse.
        /// </summary>
        /// <param name="pGameObject">Reference to GameObject this component is part of.</param>
        public MouseSelector(GameObject pGameObject) : base(pGameObject)
        {
            _transform2D = GameObject.GetComponent<Transform2D>();
        }

        /// <summary>
        /// Update the position of the virtual mouse.
        /// </summary>
        /// <param name="pGameTime">MonoGame GameTime.</param>
        public override void Update(GameTime pGameTime)
        {
            base.Update(pGameTime);
            _mouseState = Mouse.GetState();
            _transform2D.Position = new Vector2(_mouseState.Position.X, _mouseState.Position.Y);
        }
    }
}
