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
        SpriteRenderer _spriteRenderer;
        private List<Components.Base.Component> _components;
        #endregion

        public GameObject(float pX = 0, float pY = 0, float pRotation = 0, float pScaleX = 1, float pScaleY =1)
        {
            _transform = new(pX, pY, pRotation, pScaleX, pScaleY);
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
        private void AddComponent(Component pComponent)
        {
            if (!HasComponentOfType(pComponent))
            {
                _components.Add(pComponent);
            }
        }

        private bool HasComponentOfType(Component pComponent)
        {
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
