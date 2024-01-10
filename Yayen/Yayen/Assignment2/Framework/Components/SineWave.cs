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

        private float _amplitude;
        private float _periodsPerSecond;
        private float _increment;
        // Time till full rotation is completed
        //private float _periodTimeFloat;

        private float _currentSineValue = 0;

        private bool DebugMode = false;
        private bool _setBetweenZeroAndOne;

        public float SineScale { get { return _amplitude; } set { _amplitude = value; } }
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
        /// Create a SineWave
        /// </summary>
        /// <param name="pAmplitude">Rotations this object rotates in a single second.</param>
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
            if (DebugMode)
            {
                Console.WriteLine("");
                Console.WriteLine("New Sine period");
                Console.WriteLine("");
            }
        }

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
        private float GetSineValue(float pXInput)
        {
            float sineValue;
            if (_setBetweenZeroAndOne)
            {
                Console.WriteLine($"((Mathf.Sine(({pXInput} * ({MathF.PI} * 2)) * {_periodsPerSecond}) + 1) / 2) * {_amplitude} = {MathF.Sin((pXInput * (MathF.PI * 2)) * _periodsPerSecond) * _amplitude} ");
                sineValue = ((MathF.Sin((pXInput * (MathF.PI * 2)) * _periodsPerSecond) + 1) / 2) * _amplitude;
            }
            else
            {
                Console.WriteLine($"Mathf.Sine(({pXInput} * ({MathF.PI} * 2)) * {_periodsPerSecond}) * {_amplitude} = {MathF.Sin((pXInput * (MathF.PI * 2)) * _periodsPerSecond) * _amplitude} ");
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
