using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Framework.Components.Base;
using Yayen.Framework.GameObjects;

namespace Yayen.Framework.Components
{
    public class Transform2D : Component
    {
        // When changing any of these 3 values (position, rotation and scale) it should first affect their local counterparts. Then we will run a conversion method which sets the global values as the local values change. This way they are connected and stable.

        Vector2 _position;
        Vector2 _localPosition;
        float _rotation;
        float _localRotation;
        Vector2 _scale;
        Vector2 _localScale;

        Transform2D _parent;
        List<Transform2D> _children;

        // In these properties we inplement local to global conversion
        public Vector2 Position { get { return _localPosition; } set { _localPosition = value; UpdateGlobalPosition(); } }
        public float Rotation { get { return _localRotation; } set { _localRotation = value; UpdateGlobalRotation(); } }
        public Vector2 Scale { get { return _localScale; } set { _localScale = value; UpdateGlobalScale(); } }

        // With these properties we can get the global values
        public Vector2 GlobalPosition { get { return _position; } }
        public float GlobalRotation { get { return _rotation; } }
        public Vector2 GlobalScale { get { return _scale; } }

        public Transform2D(GameObject pGameObject, float pX, float pY, float pRotation = 0, float pScaleX = 1, float pScaleY = 1) : base(pGameObject)
        {
            Position = new(pX, pY);
            Rotation = pRotation;
            Scale = new Vector2(pScaleX, pScaleY);
        }

        //public Transform2D(GameObject pGameObject) : this(pGameObject, new Vector2(0, 0), 0f, 0.5f, 0.5f) { }

        #region Update Global Values
        private void UpdateGlobalPosition()
        {
            _position = _parent == null ? _localPosition :  (_localPosition * _parent.Scale) + _parent.Position;
        }

        private void UpdateGlobalRotation()
        {
            _rotation = _parent == null ? _localRotation : _localRotation + _parent.Rotation;
        }

        private void UpdateGlobalScale()
        {
            _scale = _parent == null ? _localScale : _localScale + _parent.Scale;
        }
        #endregion
    }
}
