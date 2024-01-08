using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment2.Framework.Components;
using Yayen.Assignment2.Framework.Components.Base;
using Yayen.Assignment2.Framework.Scenes.Base;

namespace Yayen.Assignment2.Framework.GameObjects
{
    public class GameObject
    {
        private Scene _scene;
        private string _name = "GameObject";

        #region Component Fields
        private Transform2D _transform;
        private SpriteRenderer _spriteRenderer;
        private List<Component> _components = new();
        #endregion

        public string Name { get { return _name; } }

        #region Constructors
        /// <summary>
        /// Create a new standard GameObject
        /// </summary>
        /// <param name="pScene">Reference to Scene this GameObject is part of.</param>
        /// <param name="pX">Position on the X axis.</param>
        /// <param name="pY">Position on the Y axis.</param>
        /// <param name="pRotation">Rotation.</param>
        /// <param name="pScaleX">Scale on the X axis.</param>
        /// <param name="pScaleY">Scale on the Y axis.</param>
        public GameObject(Scene pScene, float pX = 0, float pY = 0, float pRotation = 0, float pScaleX = 1, float pScaleY = 1)
        {
            _scene = pScene;

            Transform2D _newTransform = new(this, pX, pY, pRotation, pScaleX, pScaleY);
            if (_newTransform == null)
            {
                Console.WriteLine("_newTransform is null");
            }
            AddComponent(_newTransform);

        }

        /// <summary>
        /// Create a new standard GameObject with name.
        /// </summary>
        /// <param name="pScene">Reference to Scene this GameObject is part of.</param>
        /// <param name="pName">The name of this GameObject.</param>
        /// <param name="pX">Position on the X axis.</param>
        /// <param name="pY">Position on the Y axis.</param>
        /// <param name="pRotation">Rotation.</param>
        /// <param name="pScaleX">Scale on the X axis.</param>
        /// <param name="pScaleY">Scale on the Y axis.</param>
        public GameObject(Scene pScene, string pName, float pX = 0, float pY = 0, float pRotation = 0, float pScaleX = 1, float pScaleY = 1) : this(pScene, pX, pY, pRotation, pScaleX, pScaleY) { _name = pName; }
        #endregion

        public void Update(GameTime pGameTime)
        {
            UpdateComponents(pGameTime, _transform);
        }

        public void Draw(SpriteBatch pSpriteBatch)
        {
            DrawComponents(pSpriteBatch, _transform);
        }

        #region ComponentMethods

        /// <summary>
        /// Update all components this GameObject has.
        /// </summary>
        /// <param name="pGameTime">GameTime to use for calculations.</param>
        /// <param name="pTransform">Reference to the Transform of the GameObject.</param>
        private void UpdateComponents(GameTime pGameTime, Transform2D pTransform)
        {
            for (int i = 0; i < _components.Count; i++)
            {
                _components[i].Update(pGameTime, _transform);
            }
        }

        /// <summary>
        /// Draw all components this GameObject has.
        /// </summary>
        /// <param name="pSpriteBatch">SpriteBatch to use for drawing.</param>
        /// <param name="pTransform">Reference to the Transform of the GameObject.</param>
        private void DrawComponents(SpriteBatch pSpriteBatch, Transform2D pTransform)
        {
            for (int i = 0; i < _components.Count; i++)
            {
                _components[i].Draw(pSpriteBatch, _transform);
            }
        }

        /// <summary>
        /// Add a component to this GameObject.
        /// </summary>
        /// <param name="pComponent">Component to add.</param>
        public void AddComponent(Component pComponent)
        {
            if (!HasComponentOfType(pComponent))
            {
                //pComponent.GameObject = this;
                _components.Add(pComponent);
                // TODO: Make it so we don't have to check types here
                if (pComponent is SpriteRenderer)
                {
                    //Console.WriteLine("Added SR");
                    _spriteRenderer = (SpriteRenderer)pComponent;
                }

                if (pComponent is Transform2D)
                {
                    //Console.WriteLine("Added Transform");
                    _transform = (Transform2D)pComponent;
                }

                pComponent.OnComponentAdded(this);
            }
        }

        /// <summary>
        /// Check if this GameObject has a component of a type.
        /// </summary>
        /// <param name="pComponent">Component of type to check.</param>
        /// <returns></returns>
        public bool HasComponentOfType(Component pComponent)
        {
            //if (_components == null || _components.Count == 0) return false;
            for (int i = 0; i < _components.Count; i++)
            {
                if (pComponent.GetType() == _components[i].GetType())
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Check if this GameObject has a component of a type.
        /// </summary>
        /// <param name="pType">Type to check.</param>
        /// <returns></returns>
        public bool HasComponentOfType(Type pType)
        {
            //if (_components == null || _components.Count == 0) return false;
            for (int i = 0; i < _components.Count; i++)
            {
                if (pType == _components[i].GetType())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns the bounds of spriterenderer sprite.
        /// </summary>
        /// <returns>Bounds of spriterenderer sprite.</returns>
        public Vector2 GetRenderBounds()
        {
            if (_spriteRenderer == null) return Vector2.Zero;
            return _spriteRenderer.GetSpriteBounds();
        }

        /// <summary>
        /// Gets a component of <type> from this GameObject.
        /// </summary>
        /// <typeparam name="tValue">Type of component.</typeparam>
        /// <returns>Component of <type> found on this GameObject.</returns>
        public Component GetComponent<tValue>() where tValue : Component
        {
            for (int i = 0; i < _components.Count; i++)
            {
                if (typeof(tValue) == _components[i].GetType())
                {
                    return _components[i];
                }
            }
            return null;
        }

        #endregion

        /// <summary>
        /// Method to call when destroying this GameObject.
        /// </summary>
        public void Destroy()
        {
            // First we need to stop the object from updating.
            _scene.DestroyGameObject(this);

            // Then we can nullify everything else
            _spriteRenderer = null;
            _transform = null;
            _components.Clear();
        }
    }
}