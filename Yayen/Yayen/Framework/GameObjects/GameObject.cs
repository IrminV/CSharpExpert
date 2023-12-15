using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Framework.Components;
using Yayen.Framework.Components.Base;

namespace Yayen.Framework.GameObjects
{
    public class GameObject
    {
        #region Component Fields
        Transform2D _transform;
        public SpriteRenderer _spriteRenderer;
        private List<Component> _components;
        #endregion

        public GameObject(float pX = 0, float pY = 0, float pRotation = 0, float pScaleX = 1, float pScaleY =1)
        {
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
            UpdateComponents(pGameTime);
        }

        public void Draw(SpriteBatch pSpriteBatch)
        {
            _spriteRenderer?.Draw(pSpriteBatch, _transform);
        }

        #region ComponentMethods
        private void UpdateComponents(GameTime pGameTime)
        {
            for (int i = 0; i < _components.Count; i++)
            {
                //_components[i].Update(pGameTime);
            }
        }
        // We might want to make this private later
        public void AddComponent(Component pComponent)
        {
            if (!HasComponentOfType(pComponent))
            {
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
        #endregion

    }
}
