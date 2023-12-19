using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Framework.Components.Base;
using Yayen.Framework.Components.Colliders.RectangleCollision;
using Yayen.Framework.GameObjects;

namespace Yayen.Framework.Components.Colliders.Base
{
    public class Collider : Component
    {
        // List of all colliding object for which this object is colliding
        private List<Collider> _collidingColliders = new();

        public delegate void CollisionDelegate(Collider pCollider);
        public event CollisionDelegate OnCollisionEnter;
        public event CollisionDelegate OnCollisionExit;

        public Collider(GameObject pGameObject) : base(pGameObject) { }

        public void AddObjectToCollidingList(Collider pcollidingWithThis)
        {
            if (!_collidingColliders.Contains(pcollidingWithThis))
            {
                _collidingColliders.Add(pcollidingWithThis);
                OnCollisionEnter?.Invoke(pcollidingWithThis);
                //_connectedGameObject.CollidedWithCollider(pcollidingWithThis);
            }
        }

        public void RemoveObjectFromCollidingList(Collider pNotCollidingWithThis)
        {
            _collidingColliders.Remove(pNotCollidingWithThis);
            OnCollisionExit?.Invoke(pNotCollidingWithThis);
            //_connectedGameObject.StoppedOverlappingWithThis(pNotCollidingWithThis.ConnectedGameObject);
        }

        public List<Collider> GetCopyCurrentCollisions()
        {
            List<Collider> colliders = new List<Collider>();
            for (int i = 0; i < _collidingColliders.Count; i++)
            {
                colliders.Add(_collidingColliders[i]);
            }
            return colliders;
        }
    }
}
