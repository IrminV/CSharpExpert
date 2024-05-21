using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment3.Framework.Components.Base;
using Yayen.Assignment3.Framework.Components.Interfaces;
using Yayen.Assignment3.Framework.GameObjects;

namespace Yayen.Assignment3.Framework.Components
{
    public class ChainBouncer : Component, IUpdatableComponent
    {
        private Transform2D _transform;
        private SineWave _sineWave;
        private Vector2 _currentBounceValue = new Vector2();
        private bool _bounceActive = true;
        private Vector2 _bounceAnchor;

        private Vector2 _bounceDirection;

        private ChainBouncer _nextBouncer;
        protected Vector2 _addedPosition = Vector2.Zero;

        /// <summary>
        /// Create a Bouncer component which bounces the attached GameObject around it's original point. NOTE: Mixing this with other movement scripts could result in unexpected behaviour.
        /// </summary>
        /// <param name="pPeriodsPerSecond">The amount of periods/bounces per second.</param>
        /// <param name="pAmplitude">The amount of displacement per bounce.</param>
        /// <param name="pBounceDirection">The direction of the bounce. NOTE: Vector2.Zero input will result in default settings.</param>
        public ChainBouncer(float pPeriodsPerSecond, float pAmplitude = 1, Vector2 pBounceDirection = new Vector2())
        {
            // If no input, use default Vector2 value for direction, else normalize Vector2 input value for direction
            if (pBounceDirection == Vector2.Zero) pBounceDirection = new Vector2(0, 1f);
            else pBounceDirection.Normalize();
            _bounceDirection = pBounceDirection;
            _sineWave = new(pAmplitude, pPeriodsPerSecond);
        }

        public override void Start()
        {
            base.Start();
            _transform = (Transform2D)GameObject.GetComponent<Transform2D>();
            _nextBouncer = GetNextBouncer();
            _bounceAnchor = _transform.Position;
        }

        /// <summary>
        /// Update Bouncer Component.
        /// </summary>
        /// <param name="pGameTime">MonoGame GameTime.</param>
        public void Update(GameTime pGameTime)
        {
            _sineWave.Update(pGameTime);
            UpdateBouncePosition();
        }

        /// <summary>
        /// Update the position of the bouncing object.
        /// </summary>
        private void UpdateBouncePosition()
        {
            _currentBounceValue.X = _sineWave.SineValue * _bounceDirection.X;
            _currentBounceValue.Y = _sineWave.SineValue * _bounceDirection.Y;
            if (_bounceActive)
            {
                //_transform.Position = new Vector2(_bounceAnchor.X + _sineWave.SineValue * _bounceDirection.X, _bounceAnchor.Y + _sineWave.SineValue * _bounceDirection.Y);


                if (_nextBouncer == null)
                {
                    _transform.Position = new Vector2(_bounceAnchor.X + (_addedPosition.X + _sineWave.SineValue * _bounceDirection.X), _bounceAnchor.Y + (_addedPosition.Y + _sineWave.SineValue * _bounceDirection.Y));
                    _addedPosition.X = 0;
                    _addedPosition.Y = 0;
                }
                else
                {
                    _nextBouncer._addedPosition = _addedPosition += new Vector2(_sineWave.SineValue * _bounceDirection.X, _sineWave.SineValue * _bounceDirection.Y);
                    _addedPosition.X = 0;
                    _addedPosition.Y = 0;
                }
            }

        }

        /// <summary>
        /// Gets the first bouncer component after this one.
        /// </summary>
        /// <returns></returns>
        private ChainBouncer GetNextBouncer()
        {
            ChainBouncer nextChainBouncer = GameObject.GetComponent<ChainBouncer>(_index +1);
            return nextChainBouncer;
        }

        public override void Destroy()
        {
            base.Destroy();
            _sineWave.Destroy();
        }

    }
}
