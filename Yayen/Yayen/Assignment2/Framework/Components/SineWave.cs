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
    public class SineWave
    {
        // Note
        // Input for sine is X
        // Output is Y
        // Cosine starts at 0.5

        Timer _sineSecondTimer = new(1, "SineSecondTimer");

        private float _periodsPerSecond;
        // Time till full rotation is completed
        private float _periodTimeFloat;

        private float _currentSineValue = 0;

        /// <summary>
        /// Create a Text component which rotates GameObject this component is part of based on rotations per second.
        /// </summary>
        /// <param name="pGameObject">Reference to GameObject this component is part of.</param>
        /// <param name="pPeriodsPerSecond">Rotations this object rotates in a single second.</param>
        public SineWave(float pPeriodsPerSecond = 1)
        {
            _periodsPerSecond = pPeriodsPerSecond;
            _periodTimeFloat = 1 / pPeriodsPerSecond;

            _sineSecondTimer.OnTimeElapsed += RestartSineSecondTimer;
        }

        public void Update(GameTime pGameTime)
        {
            UpdateCurrentSineValue();
            UpdateSineSecondTimer(pGameTime);
            Console.WriteLine($"Current sine value is {_currentSineValue}");
        }

        private void UpdateSineSecondTimer(GameTime pGameTime)
        {
            _sineSecondTimer.Update(pGameTime);
        }

        private void RestartSineSecondTimer()
        {
            _sineSecondTimer.ResetTimer(true);
        }

        private void UpdateCurrentSineValue()
        {
            _currentSineValue = GetSineValue(_sineSecondTimer.TimerCurrentTime);
        }

        private float GetSineValue(float pXInput)
        {
            return MathF.Sin(pXInput) * _periodsPerSecond;
        }
    }
}
