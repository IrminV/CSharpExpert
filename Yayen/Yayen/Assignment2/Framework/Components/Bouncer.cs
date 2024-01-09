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
        Transform2D _transform;
        SineWave _sineWave;
        private bool _bounceActive = true;
        private Vector2 _bounceAnchor;

        public Bouncer(GameObject pGameObject, float pPeriodsPerSecond, float pAmplitude = 1) : base(pGameObject)
        {
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
            if (_bounceActive) _transform.Position = new Vector2(_transform.Position.X, _bounceAnchor.Y + _sineWave.SineValue);
        }


    }
}
