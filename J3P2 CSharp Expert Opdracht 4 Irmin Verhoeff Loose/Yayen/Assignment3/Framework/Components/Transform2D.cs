using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment3.Framework.Components.Base;
using Yayen.Assignment3.Framework.GameObjects;

namespace Yayen.Assignment3.Framework.Components
{
    /// <summary>
    /// transform Component of a GameObject.
    /// </summary>
    public class Transform2D : Component
    {
        // When changing any of these 3 values (position, rotation and scale) it should first affect their local counterparts. Then we will run a conversion method which sets the global values as the local values change. This way they are connected and stable and really handy to use when implementing parent and child relationships.

        Vector2 _position;
        Vector2 _localPosition;
        float _rotation;
        float _localRotation;
        Vector2 _scale;
        Vector2 _localScale;

        Transform2D _parent;
        List<Transform2D> _children = new();

        // In these properties we inplement local to global conversion
        public Vector2 Position { get { return _localPosition; } set { _localPosition = value; UpdateGlobalPosition(); } }
        public float Rotation { get { return _localRotation; } set { _localRotation = value; UpdateGlobalRotation(); } }
        public Vector2 Scale { get { return _localScale; } set { _localScale = value; UpdateGlobalScale(); } }

        // With these properties we can get the global values
        public Vector2 GlobalPosition { get { return _position; } }
        public float GlobalRotation { get { return _rotation; } }
        public Vector2 GlobalScale { get { return _scale; } }

        /// <summary>
        /// Crreate the Transform Component of a GameObject.
        /// </summary>
        /// <param name="pX">Position on the X axis.</param>
        /// <param name="pY">Position on the Y axis.</param>
        /// <param name="pRotation">Rotation in degrees.</param>
        /// <param name="pScaleX">Scale on the X axis.</param>
        /// <param name="pScaleY">Scale on the Y axis.</param>
        public Transform2D(float pX, float pY, float pRotation = 0, float pScaleX = 1, float pScaleY = 1)
        {
            Position = new(pX, pY);
            Rotation = pRotation;
            Scale = new Vector2(pScaleX, pScaleY);
        }

        public override void Start()
        {
            base.Start();
        }

        public void AddChild(Transform2D pTransform2D)
        {
            _children.Add(pTransform2D);
            pTransform2D.SetParent(this);
        }

        public void SetParent(Transform2D pTransform2D)
        {
            _parent = pTransform2D;
            Position = ConvertToParentedPosition(pTransform2D);
            Console.WriteLine($"My new position is {Position}");
            Scale = ConvertToParentedScale(pTransform2D);

        }

        /// <summary>
        /// Create a new parented position which will display this Transform the same as before the parenting. If we don't do this after parenting, the visual position of the Child transform will be altered compared to the parent.
        /// </summary>
        /// <param name="pParentTransform2D">parent Transform.</param>
        /// <returns></returns>
        private Vector2 ConvertToParentedPosition(Transform2D pParentTransform2D)
        {
            Vector2 newParantedPosition = (Position - pParentTransform2D.Position) * (Vector2.One / pParentTransform2D.Scale);
            return newParantedPosition;
        }

        /// <summary>
        /// Create a new parented scale which will display this Transform the same as before the parenting. If we don't do this after parenting, the visual scale of the Child transform will be altered compared to the parent.
        /// </summary>
        /// <param name="pParentTransform">parent Transform.</param>
        /// <returns></returns>
        private Vector2 ConvertToParentedScale(Transform2D pParentTransform)
        {
            Vector2 newParentedScale = Scale * (Vector2.One / pParentTransform.Scale);
            return newParentedScale;
        }

        // Please be aware, this angle is calculated in MonoGame space where upwards is y negative. You can invert y for the true angle
        // This needs to be redone in global space i think
        //public Vector2 GetRotatedPositionAroundParent(float pDegrees, float pDegreeOffset = 0f, bool pInvertY = false)
        //{
        //    //pDegrees = pDegrees * 2;
        //    float vectorLength = MathF.Sqrt((Position.X * Position.X) + (Position.Y * Position.Y));
        //    Vector2 normalizedVector = Position;
        //    normalizedVector.Normalize();
        //    if (pInvertY) normalizedVector.Y = -normalizedVector.Y;
        //    float angle = MathF.Atan2(normalizedVector.X, normalizedVector.Y);
        //    // By default, zero degrees is ->
        //    float degreeAngle = (MathHelper.ToDegrees(angle)) + pDegreeOffset + pDegrees;
        //    degreeAngle = GetThreeSixtyDegrees(degreeAngle);
        //    angle = MathHelper.ToRadians(degreeAngle);

        //    Console.WriteLine($"Input was {pDegrees}");
        //    Console.WriteLine($"Angle is {GetThreeSixtyDegrees(MathHelper.ToDegrees(angle) + pDegreeOffset)}");
        //    //Console.WriteLine($"Vector length is {vectorLength}");
        //    //Calculating angle back to vector
        //   Vector2 newPosition = (new Vector2(MathF.Cos(angle), MathF.Sin(angle)) * vectorLength);
        //    //Console.WriteLine($"New rotated position = {newPosition}");
        //    return (newPosition);
        //}

        //public Transform2D(GameObject pGameObject) : this(pGameObject, new Vector2(0, 0), 0f, 0.5f, 0.5f) { }

        #region Update Global Values
        /// <summary>
        /// Update the global position values used as input for MonoGames render system.
        /// </summary>
        private void UpdateGlobalPosition()
        {
            _position = _parent == null ? _localPosition : _localPosition * _parent.Scale + _parent.Position;
            for (int i = 0; i < _children.Count; i++)
            {
                _children[i].UpdateGlobalPosition();
            }

        }
        /// <summary>
        /// Update the global rotation values used as input for MonoGames render system.
        /// </summary>
        private void UpdateGlobalRotation()
        {
            _rotation = _parent == null ? _localRotation : _localRotation + (MathHelper.ToDegrees(MathF.Atan2(Position.X, -Position.Y)));
            for (int i = 0; i < _children.Count; i++)
            {
                _children[i].UpdateGlobalRotation();
                //Console.WriteLine($"Rotating {_children[i]} around parent with rotation {Rotation} resulting in position{_children[i].RotatePositionAroundParent(Rotation)}");
                //_children[i].Position = _children[i].GetRotatedPositionAroundParent(this.Rotation);
            }
        }
        /// <summary>
        /// Update the global scale values used as input for MonoGames render system.
        /// </summary>
        private void UpdateGlobalScale()
        {
            _scale = _parent == null ? _localScale : _localScale * _parent.Scale;
            if (_parent != null)
            {
                Console.WriteLine($"New scale is {_localScale * _parent.Scale}");
                Console.WriteLine($"Actual new scale = {_scale}");
            }

            
            for (int i = 0; i < _children.Count; i++)
            {
                _children[i].UpdateGlobalScale();
            }
        }
        #endregion

        private float GetThreeSixtyDegrees(float pDegreeAngle)
        {
            if (pDegreeAngle >= 360)
            {
                //Console.WriteLine($"Angle % 360 = {pDegreeAngle % 360}");
                pDegreeAngle = (pDegreeAngle % 360);
            }
            if (pDegreeAngle < 0)
            {
                //Console.WriteLine($"360 - Angle % 360 = {360 +(pDegreeAngle % -360)}");
                pDegreeAngle = 360 + (pDegreeAngle % -360);
            }
            return pDegreeAngle;
        }
    }
}
