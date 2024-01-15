using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment3.Framework.GameObjects;
using Yayen.Assignment3.Framework.Components;

namespace Yayen.Assignment3.Framework.Components.Base
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
        {
            get
            { return _gameObject; }
            set
            {
                if (_gameObject == null)
                {
                    //if (this is SineSpriteRotator) Console.WriteLine($"Setting GameObject of SineSpriteRotator to {value.Name}");
                    _gameObject = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"WARNING: tried to rebind component {GetType()} to {value.Name} already bound component {value.Name}");
                    Console.ResetColor();
                }
            }
        }

        /// <summary>
        /// Base component constructor.
        /// </summary>
        /// <param name="pGameObject">Reference to GameObject this component is part of.</param>
        public Component()
        {

        }

        // Some methods which need to be called on multiple components
        /// <summary>
        /// Code to fire when this Component is added.
        /// </summary>
        /// <param name="pGameObject">GameObject this component is being added to.</param>
        public virtual void OnComponentAdded(GameObject pGameObject)
        {
            GameObject = pGameObject;
        }

        // TODO: Maybe make things like start into an interface instead of a virtual method.
        public virtual void Start()
        {

        }

        // Some methods which need to be called on multiple components
        /// <summary>
        /// Code to fire when this Component is removed.
        /// </summary>
        /// <param name="pGameObject">GameObject this component is being removed from.</param>
        public virtual void OnComponentRemoved(GameObject pGameObject)
        {

        }

        /// <summary>
        /// Update this components functionality.
        /// </summary>
        /// <param name="pGameTime">GameTime to use for calculations.</param>
        /// <param name="pTransform">Reference to the tranform of the GameObject this component is part of.</param>
        public virtual void Update(GameTime pGameTime)
        {

        }

        /// <summary>
        /// Draw this components graphics.
        /// </summary>
        /// <param name="pSpriteBatch">Spritebatch to use for drawing.</param>
        /// <param name="pTransform">Reference to the tranform of the GameObject this component is part of.</param>
        public virtual void Draw(SpriteBatch pSpriteBatch)
        {
        }

        // This is to destroy the component and event references
        public virtual void Destroy()
        {

        }
    }
}
