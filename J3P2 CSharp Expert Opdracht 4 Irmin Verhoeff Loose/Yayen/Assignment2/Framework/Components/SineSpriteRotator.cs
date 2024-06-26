﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment2.Framework.Components.Base;
using Yayen.Assignment2.Framework.GameObjects;

namespace Yayen.Assignment2.Framework.Components
{
    public class SineSpriteRotator : Component
    {
        private float _minRot;
        private float _maxRot;
        private bool _clockwise;
        //Timer _secondTimer;
        private float _lerpValue;
        private Transform2D _transform;
        
        private SineWave _sineWave;

        /// <summary>
        /// Create a SineSpriteRotator Component which rotates the sprite of the GameObject this is attached to.
        /// </summary>
        /// <param name="pGameObject">Reference to the GameObject this is a part of.</param>
        /// <param name="pMinRot">The minimum rotation for the animation.</param>
        /// <param name="pMaxRot">The maximum rotation for the animation.</param>
        /// <param name="pClockwise">Do we want a clockwise or counterclockwise animation?</param>
        /// <param name="pRevolutionsPerSecond">How many sine revolutions or rotations back and forth from min to max per second do we want?</param>
        public SineSpriteRotator(GameObject pGameObject, float pMinRot, float pMaxRot, bool pClockwise = true, float pRevolutionsPerSecond = 1) : base(pGameObject)
        {
            _minRot = pMinRot;
            _maxRot = pMaxRot;
            _clockwise = pClockwise;
            _transform = (Transform2D)GameObject.GetComponent<Transform2D>();
            //Console.WriteLine($"SineSpriteRotator: Getting transform component of GameObjct {GameObject.Name}");
            _sineWave = new(1, pRevolutionsPerSecond, true);
            //_secondTimer = new(1, "Second Timer");
            //_secondTimer.OnTimeElapsed += ResetSecondTimer;
            //_secondTimer.StartTimer();
        }

        /// <summary>
        /// Update the SinSpriteRotator Component.
        /// </summary>
        /// <param name="pGameTime">MonoGame GameTime</param>
        public override void Update(GameTime pGameTime)
        {
            base.Update(pGameTime);
            //_secondTimer.Update(pGameTime);
            _sineWave.Update(pGameTime);
            UpdateLerpValue();
            UpdateSpriteRotation();
        }

        /// <summary>
        /// Lerp betweem _minRot and _maxRot with the SineValue. Get the current rotation point.
        /// </summary>
        public void UpdateLerpValue()
        {
            if (_clockwise)
            {
                _lerpValue = MathHelper.Lerp(_minRot, _maxRot, _sineWave.SineValue);
            }
            else
            {
                _lerpValue = MathHelper.Lerp(_minRot, _maxRot, -_sineWave.SineValue);
            }
            
        }

        /// <summary>
        /// Update the rotation of the sprite with the cached _lerpValue.
        /// </summary>
        public void UpdateSpriteRotation()
        {
            _transform.Rotation = _transform.Rotation = _lerpValue;
        }
    }
}
