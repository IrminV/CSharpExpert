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
    /// <summary>
    /// A SineWave
    /// </summary>
    public class SineWave
    {
        // Note
        // Input for sine is X
        // Output is Y
        // Cosine starts at 0.5

        private float _sineTimerValue = 1;

        private Timer _sineSecondTimer;

        private float _amplitude;
        private float _periodsPerSecond;
        private float _increment;
        // Time till full rotation is completed
        //private float _periodTimeFloat;

        private float _currentSineValue = 0;

        private bool DebugMode = false;
        private bool _setBetweenZeroAndOne;

        public float SineAmplitude { get { return _amplitude; } set { _amplitude = value; } }
        public float PeriodsPerSecond 
        { 
            get { return _periodsPerSecond; } 
            set 
            { 
                _periodsPerSecond = value;
                // Calculate how many seconds are within one period. The default is one period per second, this is why we divide by 1.
                _sineTimerValue = 1 / value;
                _sineSecondTimer.TimerTime = _sineTimerValue;
            } 
        }
        public float SineValue { get { return _currentSineValue; } }

        /// <summary>
        /// Create a SineWave.
        /// </summary>
        /// <param name="pAmplitude">Rotations this object rotates in a single second.</param>
        /// <param name="pPeriodsPerSecond">How many periods per second (from 0 to 1 to -1 to 0) do we want our SineWave to have?</param>
        /// <param name="pSetBetweenOneAndZero">Do we want to go from 0 to 1 and back instead?</param>
        /// <param name="pIncrement">Do want to offset the Y value of the SinWave with an increment value? If not, leave this at zero or default.</param>
        public SineWave(float pAmplitude = 1, float pPeriodsPerSecond = 1, bool pSetBetweenOneAndZero = false, float pIncrement = 0f)
        {
            _amplitude = pAmplitude;
            _increment = pIncrement;
            //_periodTimeFloat = 1 / pSineScale;

            _sineSecondTimer = new(_sineTimerValue, "SineSecondTimer");
            PeriodsPerSecond = pPeriodsPerSecond;
            _setBetweenZeroAndOne = pSetBetweenOneAndZero;
            _sineSecondTimer.OnTimeElapsed += RestartSineSecondTimer;
            _sineSecondTimer.StartTimer();
        }

        /// <summary>
        /// Update the SineWave.
        /// </summary>
        /// <param name="pGameTime">MonoGame GameTime.</param>
        public void Update(GameTime pGameTime)
        {
            UpdateCurrentSineValue();
            UpdateSineSecondTimer(pGameTime);
        }

        /// <summary>
        /// Update the SecondTimer of the SineWave. This timer is used as input for the Mathf.Sine calculations.
        /// </summary>
        /// <param name="pGameTime">MonoGame GameTime.</param>
        private void UpdateSineSecondTimer(GameTime pGameTime)
        {
            _sineSecondTimer.Update(pGameTime);
        }

        /// <summary>
        /// Restart the SineSecond Timer. This should start a new period.
        /// </summary>
        private void RestartSineSecondTimer()
        {
            _sineSecondTimer.ResetTimer(true, true);
            if (DebugMode)
            {
                Console.WriteLine("");
                Console.WriteLine("New Sine period");
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Update the cached _currentSineValue.
        /// </summary>
        private void UpdateCurrentSineValue()
        {
            if (DebugMode && _sineTimerValue - _sineSecondTimer.TimerCurrentTime < 0)
            {
                Console.WriteLine($"Anomaly occured timer time = {_sineSecondTimer.TimerTime}");
            }
            //Console.WriteLine($"Current sine value is {_sineTimerValue - _sineSecondTimer.TimerCurrentTime}");
            _currentSineValue = GetSineValue((_sineTimerValue - _sineSecondTimer.TimerCurrentTime));
        }

        // TODO: Make this function more readable
        /// <summary>
        /// Calculate and return the current sineValue using a Mathf.Sin calculation. Remember, one sine period is 0 to 1 for this calculator.
        /// </summary>
        /// <param name="pXInput">The current progress on the sine period (from 0 to 1).</param>
        /// <returns>The outcome of the Mathf.Sine calculation with pXInput from 0 to 1 as the progress or time value of one period.</returns>
        private float GetSineValue(float pXInput)
        {
            float sineValue;
            if (_setBetweenZeroAndOne)
            {
                sineValue = ((MathF.Sin((pXInput * (MathHelper.TwoPi)) * _periodsPerSecond) + 1) / 2) * _amplitude;
            }
            else
            {
                sineValue = MathF.Sin((pXInput * (MathF.PI * 2)) * _periodsPerSecond) * _amplitude;
            }
            
            if (DebugMode) Console.WriteLine($"Returning {sineValue} while at reverse time value: {pXInput}");
            sineValue += _increment;
            if (DebugMode && _increment != 1) Console.WriteLine($"Sine Value incremented by {_increment} to {sineValue}");
            return sineValue;
        }

        // This method was replaced by the PeriodsPerSecond property
        //public void SetPeriodsPerSecond(float pPeriodsPerSecond)
        //{
        //    _periodsPerSecond = pPeriodsPerSecond;
        //    // Calculate how many seconds are within one period. The default is one period per second, this is why we divide by 1.
        //    _sineTimerValue = 1 / pPeriodsPerSecond;
        //    _sineSecondTimer.TimerTime = _sineTimerValue;
        //}
    }
}
