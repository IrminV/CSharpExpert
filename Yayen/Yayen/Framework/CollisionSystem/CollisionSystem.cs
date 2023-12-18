using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Framework.Components.Colliders.Base;
using Yayen.Framework.GameObjects;

namespace Yayen.Framework.CollisionSystem
{
    public class CollisionSystem
    {
        //private List<Collider> _collidersToCheck;

        //public CollisionSystem(List<Collider> pCollidersToCheck)
        //{
        //    _collidersToCheck = pCollidersToCheck;
        //}

        //public void Update()
        //{
        //    UpdateOverlapCheck();
        //}

        //private void UpdateOverlapCheck()
        //{
        //    for (int i = 0; i < _collidersToCheck.Count; i++)
        //    {
        //        Collider colOne = _collidersToCheck[i];
        //        for (int j = i; j < _collidersToCheck.Count - 1; j++)
        //        {
        //            bool collisionShouldExists = false;
        //            Collider colTwo = _collidersToCheck[j + 1];
        //            if (colOne.GetCopyCurrentCollisions().Contains(colTwo) && colTwo.GetCopyCurrentCollisions().Contains(colOne))
        //            {
        //                collisionShouldExists = true;
        //            }

        //            bool collidingOnX = CheckIfCollidingOnX(colOne, colTwo);
        //            bool collidingOnY = CheckIfCollidingOnY(colOne, colTwo);

        //            if (collidingOnX && collidingOnY && !collisionShouldExists)
        //            {
        //                // They started to collide
        //                //_collisionPairs.Add(new CollisionPair(_collisionPairs, colOne.ConnectedGameObject, colTwo.ConnectedGameObject));
        //                colOne.AddObjectToCollidingList(colTwo);
        //                colTwo.AddObjectToCollidingList(colOne);
        //            }
        //            else if (collidingOnX && collidingOnY && collisionShouldExists)
        //            {
        //                // They are still colliding
        //            }
        //            else if (collisionShouldExists)
        //            {
        //                // They stopped colliding
        //                colOne.RemoveObjectFromCollidingList(colTwo);
        //                colTwo.RemoveObjectFromCollidingList(colOne);
        //            }
        //        }
        //    }
        //}

        //// The method below here are optimized for Rectangle coliders. We want ot make these more dynamic
        //private bool CheckIfCollidingOnX(Collider colOne, Collider colTwo)
        //{
        //    bool collidingOnX = false;
        //    // If we are to the left of the object and our right edge is past/within their left edge
        //    if (colOne.MidPoint.X < colTwo.MidPoint.X &&
        //        colOne.GetRightXCollisionEdge() > colTwo.GetLeftXCollisionEdge())
        //    {
        //        collidingOnX = true;
        //    }
        //    // If we are to the right of the object and our left edge is past/within their right edge
        //    else if (colOne.MidPoint.X > colTwo.MidPoint.X &&
        //        colOne.GetLeftXCollisionEdge() < colTwo.GetRightXCollisionEdge())
        //    {
        //        collidingOnX = true;
        //    }

        //    return collidingOnX;
        //}

        //private bool CheckIfCollidingOnY(CollisionRectangle colOne, CollisionRectangle colTwo)
        //{
        //    bool collidingOnY = false;
        //    // If we are above the object and our bottom edge is past/within than their upper edge
        //    if (colOne.MidPoint.Y < colTwo.MidPoint.Y &&
        //        colOne.GetBottomYCollisionEdge() > colTwo.GetUpperYCollisionEdge())
        //    {
        //        collidingOnY = true;
        //    }
        //    // If we are below the object and our top is past/within their bottom edge
        //    else if (colOne.MidPoint.Y > colTwo.MidPoint.Y &&
        //        colOne.GetUpperYCollisionEdge() < colTwo.GetBottomYCollisionEdge())
        //    {
        //        collidingOnY = true;
        //    }
        //    return collidingOnY;
        //}

        //public void GameObjectDestroyed(GameObject pGameObject)
        //{
        //    //for (int i = 0; i < _collisionPairs.Count; i++)
        //    //{
        //    //    if (_collisionPairs[i].CheckIfContains(pGameObject))
        //    //    {
        //    //        _collisionPairs[i].IAmDestroyed(pGameObject);
        //    //    }
        //    //}
        //}
    }
}
