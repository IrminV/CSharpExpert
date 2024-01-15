using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment3.Framework.CollisionSystem;
using Yayen.Assignment3.Framework.Components.Colliders.Base;
using Yayen.Assignment3.Framework.GameObjects;

namespace Yayen.Assignment3.Framework.Components.Colliders.RectangleCollision
{
    public class RectangleCollider : Collider
    {
        //private GameObject _gameObject;
        //private List<CollisionRectangle> _collidingRectangles = new();
        //private bool _hasBeenDestroyed = false;

        // REMINDER: In Monogame the 0, 0 point is in the top left, the starting point of this script should also be in the top left of the sprite you want to add collision to
        private Vector2 _origin;
        private Vector2 _startingPoint;
        private Vector2 _endPoint;
        private Vector2 _midPoint;
        private float _width = 2;
        private float _height = 2;

        private Transform2D _transform;

        private SpriteRenderer _spriteRenderer;

        //public List<CollisionRectangle> CollidingRectangles { get { return _collidingRectangles; } }
        //public bool HasBeenDestroyed { get { return _hasBeenDestroyed; } }
        //public GameObject ConnectedGameObject
        //{
        //    get { return _gameObject; }
        //}

        public Vector2 MidPoint
        {
            get { return _midPoint; }
        }

        public float Width { get { return _width; } set { _width = value; } }
        public float Height { get { return _height; } set { _height = value; } }

        /// <summary>
        /// Create a RectangleCollider..
        /// </summary>
        /// <param name="pRectangleCollisionSystem">Reference to the RectangleCollisionSystem this collider is going to be part of.</param>
        /// <param name="pOriginX">Origin on the X axis.</param>
        /// <param name="pOriginY">Origin on the Y axis.</param>
        public RectangleCollider(RectangleCollisionSystem pRectangleCollisionSystem, float pOriginX = 0.5f, float pOriginY = 0.5f)
        {
            pRectangleCollisionSystem.AddCollider(this);
            _origin.X = pOriginX;
            _origin.Y = pOriginY;
        }

        public override void Start()
        {
            _transform = GameObject.GetComponent<Transform2D>();
            _spriteRenderer = GameObject.GetComponent<SpriteRenderer>();
            if(_spriteRenderer != null) SetSizeToRenderBounds();
        }

        public override void Update(GameTime pGameTime)
        {
            base.Update(pGameTime);
            _startingPoint = new Vector2(_transform.GlobalPosition.X - _origin.X * _width, _transform.GlobalPosition.Y - _origin.Y * _height);
            _endPoint = new Vector2(_startingPoint.X + _width, _startingPoint.Y + _height);
            _midPoint = GetMidPoint();
        }

        // I created some extra methods to get the edges of the rectangle, these are unused as of now. But i thought it was a pretty neat idea.
        // If i ever were to need this, it can simply be calculated here, inside the rectangle
        public Vector2 GetLeftUpCollisionEdge()
        {
            return _startingPoint;
        }
        public Vector2 GetRightUpCollisionEdge()
        {
            return new Vector2(_startingPoint.X + _width, _startingPoint.Y);
        }

        public Vector2 GetRightDownCollisionEdge()
        {
            return new Vector2(_startingPoint.X + _width, _startingPoint.Y + _height);
        }
        public Vector2 GetLeftDownCollisionEdge()
        {
            return new Vector2(_startingPoint.X, _startingPoint.Y + _height);
        }

        public Vector2 GetMidPoint()
        {
            return new Vector2(_startingPoint.X + _width * 0.5f, _startingPoint.Y + _height * 0.5f);
        }

        public float GetLeftXCollisionEdge()
        {
            return _startingPoint.X;
        }

        public float GetRightXCollisionEdge()
        {
            return _endPoint.X;
        }

        public float GetUpperYCollisionEdge()
        {
            return _startingPoint.Y;
        }

        public float GetBottomYCollisionEdge()
        {
            return _endPoint.Y;
        }

        /// <summary>
        /// Sets the size of the collider to the render bound of the GameObject.
        /// </summary>
        public void SetSizeToRenderBounds()
        {
            Vector2 renderBounds = _spriteRenderer.GetSpriteBounds();
            Width = renderBounds.X;
            Height = renderBounds.Y;
        }
    }
}
