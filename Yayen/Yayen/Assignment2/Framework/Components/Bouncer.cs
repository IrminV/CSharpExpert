using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment2.Framework.Components.Base;
using Yayen.Assignment2.Framework.GameObjects;

namespace Yayen.Assignment2.Framework.Components
{
    public class Bouncer : Component
    {
        private Transform2D _transform;
        private SineWave _sineWave;
        private bool _bounceActive = true;
        private Vector2 _bounceAnchor;

        private Vector2 _bounceDirection;

        public Bouncer(GameObject pGameObject, float pPeriodsPerSecond, float pAmplitude = 1, Vector2 pBounceDirection = new Vector2()) : base(pGameObject)
        {
            // If no input, use default Vector2 value for direction, else normalize Vector2 input value for direction
            if (pBounceDirection == Vector2.Zero) pBounceDirection = new Vector2(0, 1f);
            else pBounceDirection.Normalize();
            _bounceDirection = pBounceDirection;

            _transform = (Transform2D)GameObject.GetComponent<Transform2D>();
            
            _sineWave = new(pAmplitude, pPeriodsPerSecond);
            _bounceAnchor = _transform.Position;
        }

        public override void Update(GameTime pGameTime, Transform2D pTransform)
        {
            base.Update(pGameTime, pTransform);
            _sineWave.Update(pGameTime);
            UpdateBouncePosition();
        }

        private void UpdateBouncePosition()
        {
            if (_bounceActive) _transform.Position = new Vector2(_bounceAnchor.X + _sineWave.SineValue * _bounceDirection.X, _bounceAnchor.Y + _sineWave.SineValue * _bounceDirection.Y);
        }


    }
}
