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
    public class SpriteRotator : Component
    {
        bool _clockwise;
        float _revolutionsPerSecond;
        Timer _secondTimer;
        float _lerpValue;
        Transform2D _transform;

        public SpriteRotator(GameObject pGameObject, bool pClockwise = true, float pRevolutionsPerSecond = 1) : base(pGameObject)
        {
            _clockwise = pClockwise;
            _revolutionsPerSecond = pRevolutionsPerSecond;
            _transform = (Transform2D)GameObject.GetComponent<Transform2D>();
            _secondTimer = new(1, "Second Timer");
            _secondTimer.OnTimeElapsed += ResetSecondTimer;
            _secondTimer.StartTimer();
        }

        public override void Update(GameTime pGameTime, Transform2D pTransform)
        {
            base.Update(pGameTime, pTransform);
            _secondTimer.Update(pGameTime);
            UpdateLerpValue();
            UpdateSpriteRotation();
        }

        public void UpdateLerpValue()
        {
            if (_clockwise)
            {
                _lerpValue = MathHelper.Lerp(0, 360 * _revolutionsPerSecond, _secondTimer.TimerTime - _secondTimer.TimerCurrentTime);
            }
            else
            {
                _lerpValue = MathHelper.Lerp(0, 360 * _revolutionsPerSecond, _secondTimer.TimerCurrentTime);
            }
            
        }

        public void UpdateSpriteRotation()
        {
            _transform.Rotation = _transform.Rotation = _lerpValue;

            Console.WriteLine($"Updated rotation to {_lerpValue}");
        }

        private void ResetSecondTimer()
        {
            _secondTimer.ResetTimer(true, true);
        }
    }
}
