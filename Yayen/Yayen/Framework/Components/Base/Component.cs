using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Framework.GameObjects;

namespace Yayen.Framework.Components.Base
{
    /// <summary>
    /// Base component class. All components should inherit from this.
    /// </summary>
    public class Component
    {
        private GameObject _gameObject;

        /// <summary>
        /// A component should only be able to be bound to a GameObject once, upon creation.
        /// </summary>
        public GameObject GameObject 
        { get 
            { return _gameObject; } 
            set 
            {
                if (_gameObject == null)
                {
                    _gameObject = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"WARNING: tried to rebind component {this.GetType()} to {value.Name} already bound component {value.Name}");
                    Console.ResetColor();
                }
            } 
        }

        /// <summary>
        /// Base component constructor.
        /// </summary>
        /// <param name="pGameObject">Reference to GameObject this component is part of.</param>
        public Component(GameObject pGameObject)
        {
            _gameObject = pGameObject;
        }

        // Some methods which need to be called on multiple components
        public virtual void OnComponentAdded(GameObject pGameObject)
        {

        }

        public virtual void OnComponentRemoved(GameObject pGameObject)
        {

        }

        public virtual void Update(GameTime pGameTime, Transform2D pTransform)
        {

        }

        public virtual void Draw(SpriteBatch pSpriteBatch, Transform2D pTransform)
        {

        }
        


    }
}
