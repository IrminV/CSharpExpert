using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment4.Framework.Components.Base;
using Yayen.Assignment4.Framework.Components.Interfaces;

namespace Yayen.Assignment4.Framework.Components.Mono.Base
{
    public class MonoBehaviour : Component, IUpdatableComponent
    {
        public virtual void Update(GameTime pGameTimer)
        {

        }
    }
}
