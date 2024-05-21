using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment4.Framework.Components.Base;
using Yayen.Assignment4.Framework.Components.Interfaces;
using Yayen.Assignment4.Framework.Components.Mono.Base;
using Yayen.Assignment4.Framework.GameObjects;

namespace Yayen.Assignment4.Framework.Components.Mono
{
    /// <summary>
    /// Mouse GameObject Component. It's like the in game virtual mouse.
    /// </summary>
    public class MouseSelector : MonoBehaviour
    {
        private MouseState _mouseState = new MouseState();

        private Transform2D _transform2D;

        /// <summary>
        /// Create a MouseSelector component which designates the GameObject it is part of, as a mouse.
        /// </summary>
        /// <param name="pGameObject">Reference to GameObject this component is part of.</param>
        public MouseSelector()
        {

        }

        public override void Start()
        {
            base.Start();
            _transform2D = GameObject.GetComponent<Transform2D>();
        }

        /// <summary>
        /// Update the position of the virtual mouse.
        /// </summary>
        /// <param name="pGameTime">MonoGame GameTime.</param>
        public override void Update(GameTime pGameTime)
        {
            _mouseState = Mouse.GetState();
            _transform2D.Position = new Vector2(_mouseState.Position.X, _mouseState.Position.Y);
        }
    }
}
