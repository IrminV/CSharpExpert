﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment3.Framework.Components;
using Yayen.Assignment3.Framework.Components.Base;
using Yayen.Assignment3.Framework.Scenes.Base;

namespace Yayen.Assignment3.Framework.GameObjects
{
    /// <summary>
    /// GameObject class.
    /// </summary>
    public class GameObject
    {
        #region Fields
        private Scene _scene;
        private string _name = "GameObject";

        #region Component Fields
        private Transform2D _transform;
        private List<MonoBehaviour> _components = new();
        #endregion
        #endregion

        #region Properties
        public string Name { get { return _name; } }
        public Transform2D Transform { get { return _transform; } }
        #endregion

        #region Constructors
        /// <summary>
        /// Create a new standard GameObject.
        /// </summary>
        /// <param name="pScene">Reference to Scene this GameObject is part of.</param>
        /// <param name="pX">Position on the X axis.</param>
        /// <param name="pY">Position on the Y axis.</param>
        /// <param name="pRotation">Rotation.</param>
        /// <param name="pScaleX">Scale on the X axis.</param>
        /// <param name="pScaleY">Scale on the Y axis.</param>
        /// <param name="pComponents">Components you want to add to this GameObject</param>
        public GameObject(Scene pScene, float pX = 0, float pY = 0, float pRotation = 0, float pScaleX = 1, float pScaleY = 1, params MonoBehaviour[] pComponents)
        {
            _scene = pScene;

            Transform2D _newTransform = new(pX, pY, pRotation, pScaleX, pScaleY);
            if (_newTransform == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("_newTransform is null");
                Console.ResetColor();
            }
            AddComponent(_newTransform);

            // Add all provided Components
            for (int i = 0; i < pComponents.Length; i++)
            {
                AddComponent(pComponents[i]);
            }
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
        /// <param name="pComponents">Components you want to add to this GameObject</param>
        public GameObject(Scene pScene, string pName, float pX = 0, float pY = 0, float pRotation = 0, float pScaleX = 1, float pScaleY = 1, params MonoBehaviour[] pComponents) : this(pScene, pX, pY, pRotation, pScaleX, pScaleY, pComponents) { _name = pName; }

        /// <summary>
        /// Create a new standard GameObject. With Vector2 position and scale.
        /// </summary>
        /// <param name="pScene">Reference to Scene this GameObject is part of.</param>
        /// <param name="pPosition">2D Position</param>
        /// <param name="pRotation">2D Rotation</param>
        /// <param name="pScale">2D Scale</param>
        /// <param name="pComponents">Components you want to add to this GameObject</param>
        public GameObject(Scene pScene, Vector2 pPosition, float pRotation, Vector2 pScale, params MonoBehaviour[] pComponents) : this(pScene, pPosition.X, pPosition.Y, pRotation, pScale.X, pScale.Y, pComponents) { }

        /// <summary>
        /// Create a new standard GameObject with name. With Vector2 position and scale.
        /// </summary>
        /// <param name="pScene">Reference to Scene this GameObject is part of.</param>
        /// <param name="pName">The name of this GameObject.</param>
        /// <param name="pPosition">2D Position</param>
        /// <param name="pRotation">2D Rotation</param>
        /// <param name="pScale">2D Scale</param>
        /// <param name="pComponents">Components you want to add to this GameObject</param>
        public GameObject(Scene pScene, string pName, Vector2 pPosition, float pRotation, Vector2 pScale, params MonoBehaviour[] pComponents) : this(pScene, pName, pPosition.X, pPosition.Y, pRotation, pScale.X, pScale.Y, pComponents) { }
        #endregion

        #region Public Methods

        public void Awake()
        {
            for (int component = 0; component < _components.Count; component++)
            {
                _components[component].Awake();
            }
        }

        public void Start()
        {
            for (int component = 0; component < _components.Count; component++)
            {
                _components[component].Start();
            }
        }

        /// <summary>
        /// Update the GameObject and all Components belonging to it.
        /// </summary>
        /// <param name="pGameTime">MonoGame GameTime.</param>
        public void Update(GameTime pGameTime)
        {
            UpdateComponents(pGameTime, _transform);
        }

        /// <summary>
        /// Draw all things related to this GameObject.
        /// </summary>
        /// <param name="pSpriteBatch">Monogame SpriteBatch.</param>
        public void Draw(SpriteBatch pSpriteBatch)
        {
            DrawComponents(pSpriteBatch, _transform);
        }

        /// <summary>
        /// Method to call when destroying this GameObject.
        /// </summary>
        public void Destroy()
        {
            // First we need to stop the object from updating.
            _scene.DestroyGameObject(this);

            // Then we can nullify everything else
            for (int component = 0; component < _components.Count; component++) _components[component].Destroy();
            _transform = null;
            _components.Clear();
        }
        #endregion

        #region ComponentMethods

        #region Public Component Methods
        /// <summary>
        /// Add a component to this GameObject.
        /// </summary>
        /// <param name="pComponent">Component to add.</param>
        public void AddComponent(MonoBehaviour pComponent)
        {
            _components.Add(pComponent);
            pComponent.OnComponentAdded(this, _components.Count -1);

            // If this a Transform we want to threat it a little differently.
            if (pComponent is Transform2D)
            {
                if (_transform == null)
                {
                    _transform = (Transform2D)pComponent;
                }
                else
                {
                    Transform2D replacedTransform = _transform;
                    _transform = (Transform2D)pComponent;
                    _components.Remove(replacedTransform);
                }
            }
        }

        public void AddComponents(params MonoBehaviour[] pComponents)
        {
            for (int i = 0; i < pComponents.Length; i++)
            {
                AddComponent(pComponents[i]);
            }
        }

        /// <summary>
        /// Check if this GameObject has a component of a type.
        /// </summary>
        /// <param name="pComponent">Component of type to check.</param>
        /// <returns></returns>
        public bool HasComponentOfType(MonoBehaviour pComponent)
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
        /// Gets a component of <type> from this GameObject. This will return the first match.
        /// </summary>
        /// <typeparam name="tValue">Type of component.</typeparam>
        /// <returns>Component of <type> found on this GameObject.</returns>
        public tValue GetComponent<tValue>() where tValue : MonoBehaviour
        {
            for (int i = 0; i < _components.Count; i++)
            {
                if (typeof(tValue) == _components[i].GetType())
                {
                    return (tValue)_components[i];
                }
            }
            return null;
        }

        public tValue GetComponent<tValue>(int pBeginIndex) where tValue : MonoBehaviour
        {
            for (int i = pBeginIndex; i < _components.Count; i++)
            {
                if (typeof(tValue) == _components[i].GetType())
                {
                    return (tValue)_components[i];
                }
            }
            return null;
        }

        public tValue GetComponent<tValue>(int pBeginIndex, int pEndIndex) where tValue : MonoBehaviour
        {
            for (int i = pBeginIndex; i < pEndIndex; i++)
            {
                if (typeof(tValue) == _components[i].GetType())
                {
                    return (tValue)_components[i];
                }
            }
            return null;
        }



        public List<tValue> GetComponents<tValue>() where tValue : MonoBehaviour
        {
            List<tValue> foundComponents = new List<tValue>();
            for (int i = 0; i < _components.Count; i++)
            {
                if (typeof(tValue) == _components[i].GetType())
                {
                    foundComponents.Add((tValue)_components[i]);
                }
            }
            return foundComponents;
        }
        #endregion

        #region Utility Component Functions
        /// <summary>
        /// Update all components this GameObject has.
        /// </summary>
        /// <param name="pGameTime">GameTime to use for calculations.</param>
        /// <param name="pTransform">Reference to the Transform of the GameObject.</param>
        private void UpdateComponents(GameTime pGameTime, Transform2D pTransform)
        {
            for (int i = 0; i < _components.Count; i++)
            {
                _components[i].Update(pGameTime);
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
                _components[i].Draw(pSpriteBatch);
            }
        }
        #endregion

        #endregion
    }
}