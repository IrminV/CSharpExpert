using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yayen.Framework.Components
{
    public class Transform
    {
        // When changing any of these 3 values (position, rotation and scale) it should first affect their local counterparts. Then we will run a conversion method which sets the global values as the local values change. This way they are connected and stable.

        Vector2 _position;
        Vector2 _localPosition;
        Vector2 _rotation;
        Vector2 _localRotation;
        Vector2 _scale;
        Vector2 _localScale;

        Transform _parent;
        List<Transform> _children;
    }
}
