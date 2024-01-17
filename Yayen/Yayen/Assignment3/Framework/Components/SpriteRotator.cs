using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment3.Framework.Components.Base;
using Yayen.Assignment3.Framework.GameObjects;

namespace Yayen.Assignment3.Framework.Components
{
    public class SpriteRotator : MonoBehaviour
    {
        private bool _clockwise;
        private float _revolutionsPerSecond;
        private Timer _secondTimer;
        private float _lerpValue;
        private Transform2D _transform;
        
        /// <summary>
        /// Create a SpriteRotator which rotates the sprite of the attached GameObject.
        /// </summary>
        /// <param name="pClockwise">Do want a clockwis or counterclockwise rotation.</param>
        /// <param name="pRevolutionsPerSecond">How many rotation per second do we want?</param>
        public SpriteRotator(bool pClockwise = true, float pRevolutionsPerSecond = 1)
        {
            _clockwise = pClockwise;
            _revolutionsPerSecond = pRevolutionsPerSecond;
            
            _secondTimer = new(1 / pRevolutionsPerSecond, "Second Timer");
            
        }

        public override void Start()
        {
            base.Start();
            _transform = (Transform2D)GameObject.GetComponent<Transform2D>();
            _secondTimer.OnTimeElapsed += ResetSecondTimer;
            _secondTimer.StartTimer();
        }

        /// <summary>
        /// Update SpriteRotator Component.
        /// </summary>
        /// <param name="pGameTime">MonoGame GameTime.</param>
        public override void Update(GameTime pGameTime)
        {
            base.Update(pGameTime);
            _secondTimer.Update(pGameTime);
            UpdateLerpValue();
            UpdateSpriteRotation();
        }

        /// <summary>
        /// Update the lerp value between 0 and 360 degrees with _secondTimer.TimerTime as time value input.
        /// </summary>
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

        /// <summary>
        /// Update the visual rotation of this GameObjects Sprite.
        /// </summary>
        public void UpdateSpriteRotation()
        {
            _transform.Rotation = _transform.Rotation = _lerpValue;
        }

        /// <summary>
        /// Reset the _secondTimer.
        /// </summary>
        private void ResetSecondTimer()
        {
            _secondTimer.ResetTimer(true, true);
        }

        public override void Destroy()
        {
            base.Destroy();
            _secondTimer.Destroy();
        }
    }
}
