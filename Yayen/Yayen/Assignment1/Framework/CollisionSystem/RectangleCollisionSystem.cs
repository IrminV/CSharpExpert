using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment1.Framework.Components.Colliders.RectangleCollision;
using Yayen.Assignment1.Framework.GameObjects;
using Yayen.Assignment1.Framework.Components.Colliders.Base;

namespace Yayen.Assignment1.Framework.CollisionSystem
{
    /// <summary>
    /// Collision system used to calculate rectangle collisions
    /// </summary>
    public class RectangleCollisionSystem
    {
        private List<RectangleCollider> _collidersToCheck = new();

        public RectangleCollisionSystem()
        {
        }

        public void Update()
        {
            UpdateOverlapCheck();
        }

        /// <summary>
        /// Update to check if Colliders in the _collidersToCheck list are overlapping.
        /// </summary>
        private void UpdateOverlapCheck()
        {
            for (int i = 0; i < _collidersToCheck.Count; i++)
            {
                RectangleCollider colOne = _collidersToCheck[i];
                for (int j = i; j < _collidersToCheck.Count - 1; j++)
                {
                    bool collisionShouldExists = false;
                    RectangleCollider colTwo = _collidersToCheck[j + 1];
                    if (colOne.GetCopyCurrentOverlaps().Contains(colTwo) && colTwo.GetCopyCurrentOverlaps().Contains(colOne))
                    {
                        collisionShouldExists = true;
                    }

                    bool collidingOnX = CheckIfCollidingOnX(colOne, colTwo);
                    bool collidingOnY = CheckIfCollidingOnY(colOne, colTwo);

                    if (collidingOnX && collidingOnY && !collisionShouldExists)
                    {
                        // They started to collide
                        //_collisionPairs.Add(new CollisionPair(_collisionPairs, colOne.ConnectedGameObject, colTwo.ConnectedGameObject));
                        colOne.AddObjectToOverlappingList(colTwo);
                        colTwo.AddObjectToOverlappingList(colOne);
                    }
                    else if (collidingOnX && collidingOnY && collisionShouldExists)
                    {
                        // They are still colliding
                    }
                    else if (collisionShouldExists)
                    {
                        // They stopped colliding
                        colOne.RemoveObjectFromOverlappingList(colTwo);
                        colTwo.RemoveObjectFromOverlappingList(colOne);
                    }
                }
            }
        }

        /// <summary>
        /// Add collider to _collidersToCheck list.
        /// </summary>
        /// <param name="pRectangleCollider">Collider to check for collision.</param>
        public void AddCollider(RectangleCollider pRectangleCollider)
        {
            if (_collidersToCheck.Contains(pRectangleCollider))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("WARNING: Tried to add already added collider");
                Console.ResetColor();
                return;
            }
            _collidersToCheck.Add(pRectangleCollider);
        }



        private bool CheckIfCollidingOnX(RectangleCollider colOne, RectangleCollider colTwo)
        {
            bool collidingOnX = false;
            // If we are to the left of the object and our right edge is past/within their left edge
            if (colOne.MidPoint.X < colTwo.MidPoint.X &&
                colOne.GetRightXCollisionEdge() > colTwo.GetLeftXCollisionEdge())
            {
                collidingOnX = true;
            }
            // If we are to the right of the object and our left edge is past/within their right edge
            else if (colOne.MidPoint.X > colTwo.MidPoint.X &&
                colOne.GetLeftXCollisionEdge() < colTwo.GetRightXCollisionEdge())
            {
                collidingOnX = true;
            }

            return collidingOnX;
        }

        private bool CheckIfCollidingOnY(RectangleCollider colOne, RectangleCollider colTwo)
        {
            bool collidingOnY = false;
            // If we are above the object and our bottom edge is past/within than their upper edge
            if (colOne.MidPoint.Y < colTwo.MidPoint.Y &&
                colOne.GetBottomYCollisionEdge() > colTwo.GetUpperYCollisionEdge())
            {
                collidingOnY = true;
            }
            // If we are below the object and our top is past/within their bottom edge
            else if (colOne.MidPoint.Y > colTwo.MidPoint.Y &&
                colOne.GetUpperYCollisionEdge() < colTwo.GetBottomYCollisionEdge())
            {
                collidingOnY = true;
            }
            return collidingOnY;
        }

        public void GameObjectDestroyed(GameObject pGameObject)
        {
            //for (int i = 0; i < _collisionPairs.Count; i++)
            //{
            //    if (_collisionPairs[i].CheckIfContains(pGameObject))
            //    {
            //        _collisionPairs[i].IAmDestroyed(pGameObject);
            //    }
            //}
        }
    }
}
