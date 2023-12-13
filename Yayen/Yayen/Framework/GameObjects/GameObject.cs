using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Framework.Components.Base;

namespace Yayen.Framework.GameObjects
{
    public class GameObject
    {
        #region Component Fields
        private List<BaseComponent> _components;
        #endregion

        public void Update(GameTime pGameTime)
        {
            UpdateComponents(pGameTime);
        }

        private void UpdateComponents(GameTime pGameTime)
        {
            for (int i = 0; i < _components.Count; i++)
            {
                //_components[i].Update(pGameTime);
            }
        }
    }
}
