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

        float _sineTimerValue = 1;

        Timer _sineSecondTimer;

        private float _sineScale;
        private float _increment;
        private float _periodsPerSecond;
        // Time till full rotation is completed
        private float _periodTimeFloat;

        private float _currentSineValue = 0;

        public float SineValue { get { return _currentSineValue; } }

        /// <summary>
        /// Create a Text component which rotates GameObject this component is part of based on rotations per second.
        /// </summary>
        /// <param name="pGameObject">Reference to GameObject this component is part of.</param>
        /// <param name="pSineScale">Rotations this object rotates in a single second.</param>
        public SineWave(float pSineScale = 0.5f, float pIncrement = 0.5f, float pPeriodsPerSecond = 1)
        {
            _sineScale = pSineScale;
            _increment = pIncrement;
            _periodsPerSecond = pPeriodsPerSecond;
            _periodTimeFloat = 1 / pSineScale;

            _sineSecondTimer = new(_sineTimerValue, "SineSecondTimer");
            _sineSecondTimer.OnTimeElapsed += RestartSineSecondTimer;
            _sineSecondTimer.StartTimer();
        }

        public void Update(GameTime pGameTime)
        {
            UpdateCurrentSineValue();
            UpdateSineSecondTimer(pGameTime);
        }

        private void UpdateSineSecondTimer(GameTime pGameTime)
        {
            _sineSecondTimer.Update(pGameTime);
        }

        private void RestartSineSecondTimer()
        {
            _sineSecondTimer.ResetTimer(true, true);
            Console.WriteLine("");
            Console.WriteLine("New Sine period");
            Console.WriteLine("");
        }

        private void UpdateCurrentSineValue()
        {
            if (_sineTimerValue - _sineSecondTimer.TimerCurrentTime < 0)
            {
                Console.WriteLine($"Anomaly occured timer time = {_sineSecondTimer.TimerTime}");
            }
            //Console.WriteLine($"Current sine value is {_sineTimerValue - _sineSecondTimer.TimerCurrentTime}");
            _currentSineValue = GetSineValue((_sineTimerValue - _sineSecondTimer.TimerCurrentTime) * _periodsPerSecond);
        }

        private float GetSineValue(float pXInput)
        {
            float sineValue = MathF.Sin(pXInput * (MathF.PI * 2)) * _sineScale;
            Console.WriteLine($"Returning {sineValue} while at reverse time value: {pXInput}");
            sineValue += _increment;
            Console.WriteLine($"Sine Value incremented by {_increment} to {sineValue}");
            return sineValue;
        }
    }
}
