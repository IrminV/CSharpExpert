using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Yayen.Framework.Components;
using Yayen.Framework.Components.Base;
using Yayen.Framework.Scenes.Base;

namespace Yayen.Framework.GameObjects
{
    public class GameObject
    {
        #region Component Fields
        private Transform2D _transform;
        private SpriteRenderer _spriteRenderer;
        private List<Component> _components;
        private Scene _scene;
        #endregion

        public GameObject(Scene pScene, float pX = 0, float pY = 0, float pRotation = 0, float pScaleX = 1, float pScaleY =1)
        {
            _scene = pScene;
            _components = new List<Component>();

            Transform2D _newTransform = new(pX, pY, pRotation, pScaleX, pScaleY);
            if (_newTransform == null)
            {
                Console.WriteLine("_newTransform is null");
            }
            AddComponent(_newTransform);
            
        }

        public void Update(GameTime pGameTime)
        {
            UpdateComponents(pGameTime, _transform);
        }

        public void Draw(SpriteBatch pSpriteBatch)
        {
            DrawComponents(pSpriteBatch, _transform);
        }

        #region ComponentMethods
        private void UpdateComponents(GameTime pGameTime, Transform2D pTransform)
        {
            for (int i = 0; i < _components.Count; i++)
            {
                _components[i].Update(pGameTime, _transform);
            }
        }

        private void DrawComponents(SpriteBatch pSpriteBatch, Transform2D pTransform)
        {
            for (int i = 0; i < _components.Count; i++)
            {
                _components[i].Draw(pSpriteBatch, _transform);
            }
        }


        // We might want to make this private later
        public void AddComponent(Component pComponent)
        {
            if (!HasComponentOfType(pComponent))
            {
                pComponent.GameObject = this;
                _components.Add(pComponent);
                // TODO: Make it so we don't have to check types here
                if (pComponent is SpriteRenderer)
                {
                    Console.WriteLine("Added SR");
                    _spriteRenderer = (SpriteRenderer)pComponent;
                }

                if (pComponent is Transform2D)
                {
                    Console.WriteLine("Added Transform");
                    _transform = (Transform2D)pComponent;
                }

                pComponent.OnComponentAdded(this);
            }
        }

        private bool HasComponentOfType(Component pComponent)
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

        public Vector2 GetRenderBounds()
        {
            if (_spriteRenderer == null) return Vector2.Zero;
            return _spriteRenderer.GetSpriteBounds();
        }

        #endregion

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
