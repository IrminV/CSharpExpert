using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment4.Framework.Components.Base;
using Yayen.Assignment4.Framework.GameObjects;
using Yayen.Assignment4.Framework.Components.Colliders.RectangleCollision;
using Microsoft.Xna.Framework;
using Yayen.Assignment4.Framework.Components.Interfaces;

namespace Yayen.Assignment4.Framework.Components.Colliders.Base
{
    public class Collider : Component, IUpdatableComponent
    {
        // List of all overlapping objects for which this object is overlapping
        private List<Collider> _overlappingColliders = new();

        // Events for other script to make use of overlapping or collision
        public delegate void CollisionDelegate(Collider pCollider);
        public event CollisionDelegate OnCollisionEnter;
        public event CollisionDelegate OnCollisionExit;

        /// <summary>
        /// Create a Base Collider.
        /// </summary>
        /// <param name="pGameObject">Reference to GameObject this component is part of.</param>
        public Collider() { }

        public void AddObjectToOverlappingList(Collider pcollidingWithThis)
        {
            if (!_overlappingColliders.Contains(pcollidingWithThis))
            {
                _overlappingColliders.Add(pcollidingWithThis);
                OnCollisionEnter?.Invoke(pcollidingWithThis);
                //_connectedGameObject.CollidedWithCollider(pcollidingWithThis);
            }
        }

        public void RemoveObjectFromOverlappingList(Collider pNotCollidingWithThis)
        {
            _overlappingColliders.Remove(pNotCollidingWithThis);
            OnCollisionExit?.Invoke(pNotCollidingWithThis);
            //_connectedGameObject.StoppedOverlappingWithThis(pNotCollidingWithThis.ConnectedGameObject);
        }

        /// <summary>
        /// Get a copy of the list of this colliders detected overlaps.
        /// </summary>
        /// <returns>A copy of the list of this colliders detected overlaps.</returns>
        public List<Collider> GetCopyCurrentOverlaps()
        {
            List<Collider> colliders = new List<Collider>();
            for (int i = 0; i < _overlappingColliders.Count; i++)
            {
                colliders.Add(_overlappingColliders[i]);
            }
            return colliders;
        }

        public override void Destroy()
        {
            base.Destroy();
            OnCollisionEnter = null;
            OnCollisionExit = null;
        }

        // RectangleCollider implements this Update so i cannot remove it yet
        // TODO: Disconnect RectangleCollider from Collider or do something else to remove this Update()
        public virtual void Update(GameTime pGameTimer)
        {

        }
    }
}
