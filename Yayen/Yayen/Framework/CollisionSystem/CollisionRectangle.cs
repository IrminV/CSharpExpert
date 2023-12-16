﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Framework.GameObjects;

namespace Yayen.Framework.CollisionSystem
{
    public class CollisionRectangle
    {
        private GameObject _connectedGameObject;
        //private List<CollisionRectangle> _collidingRectangles = new();
        //private bool _hasBeenDestroyed = false;

        // REMINDER: In Monogame the 0, 0 point is in the top left, the starting point of this script
        // should also be in the top left of the sprite you want to add collision to
        private Vector2 _startingPoint;
        private Vector2 _endPoint;
        private Vector2 _midPoint;
        private float _width;
        private float _height;

        //public List<CollisionRectangle> CollidingRectangles { get { return _collidingRectangles; } }
        //public bool HasBeenDestroyed { get { return _hasBeenDestroyed; } }
        public GameObject ConnectedGameObject
        {
            get { return _connectedGameObject; }
        }

        public Vector2 MidPoint
        {
            get { return _midPoint; }
        }

        public float Width { get { return _width; } }
        public float Height { get { return _height; } }

        public CollisionRectangle(float width, float height, GameObject pconnectedGameObject)
        {
            _width = width;
            _height = height;
            _connectedGameObject = pconnectedGameObject;
        }

        public CollisionRectangle(Texture2D ptextureForBounds, GameObject pconnectedGameObject)
        {
            _connectedGameObject = pconnectedGameObject;
            if (ptextureForBounds != null)
            {
                _width = ptextureForBounds.Width;
                _height = ptextureForBounds.Height;
            }
            else
            {
                //Console.WriteLine($"Object with name {_connectedGameObject.ObjectName} has no texureBounds for it's CollisionRectangle. Is this intentional? Default collisionbounds apply");
                _width = 2;
                _height = 2;
            }
        }



        public void Update(Vector2 startingPoint)
        {
            _startingPoint = startingPoint;
            _endPoint = new Vector2(startingPoint.X + _width, startingPoint.Y + _height);
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

        //public void Destroy()
        //{
        //    _hasBeenDestroyed = true;
        //}
    }
}