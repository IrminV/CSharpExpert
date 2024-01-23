using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yayen.Assignment4.Framework.Components
{
    /// <summary>
    /// Really handy and reusable timer.
    /// </summary>
    public class Timer
    {
        protected string _timerName;
        protected float _timeMultiplier;
        protected bool _timerActive = false;

        // How much time does the timer have?
        protected float _timerTime;
        // When does the timer evoke OnTimeElapsed?
        const float _timerMinTime = 0;
        // What is the timers current time?
        protected float _timerCurrentTime;

        // Event to be called on time elapsed
        public delegate void TimerDelegate();
        public event TimerDelegate OnTimeElapsed;

        public float TimerTime { get { return _timerTime; } set { _timerTime = value; } }
        public float TimerCurrentTime
        {
            get
            {
                if (_timerCurrentTime < 0)
                {
                    return 0;
                }
                else return _timerCurrentTime; 
            } 
        }
        public bool TimerActive { get { return _timerActive; } }


        #region Constructors
        /// <summary>
        /// Create a Timer.
        /// </summary>
        /// <param name="pTimerTime">This is the value from which we will be counting down.</param>
        /// <param name="timerName">This is the name reference of this timer. This can be handy during debugging.</param>
        /// <param name="pTimeMultiplier">This is the time multiplier value. You can use this if for some reason, you want the timer to go down twice as fast, faster or slower. Do not touch this or keep this at one if you want the usual DeltaTime accurate timer.</param>
        public Timer(float pTimerTime, string timerName = "Timer", float pTimeMultiplier = 1)
        {
            _timerTime = pTimerTime;
            ResetTimer();
            _timerName = timerName;
            _timeMultiplier = pTimeMultiplier;
        }
        #endregion

        /// <summary>
        /// Update Timer.
        /// </summary>
        /// <param name="pGameTime">MonoGame GameTime.</param>
        public void Update(GameTime pGameTime)
        {
            UpdateTimer(pGameTime);
        }

        /// <summary>
        /// Update Timer checks.
        /// </summary>
        /// <param name="pGameTime">MonoGame GameTime</param>
        private void UpdateTimer(GameTime pGameTime)
        {
            if (_timerActive)
            {
                if (_timerCurrentTime < 0)
                {
                    PauseTimer();
                    OnTimeElapsed?.Invoke();
                }
                else
                {
                    _timerCurrentTime -= (float)pGameTime.ElapsedGameTime.TotalSeconds * _timeMultiplier;
                }
            }
        }

        /// <summary>
        /// Resets and activates Timer
        /// </summary>
        public void SetTimer()
        {
            ResetTimer(true);
            // TODO: Doesn't Reset timer already set _timerActive to true? Can the line below be removed?
            _timerActive = true;
        }

        /// <summary>
        /// Set Timer to value, 
        /// </summary>
        /// <param name="pTime">Value to count down from.</param>
        public void SetTimer(float pTime)
        {
            _timerTime = pTime;
            ResetTimer(true);
            _timerActive = true;
        }
        /// <summary>
        /// Pause the Timer, leaving _timerCurrentTime intact.
        /// </summary>
        public void PauseTimer()
        {
            _timerActive = false;
        }

        /// <summary>
        /// Start the Timer, also used to resume after pausing.
        /// </summary>
        public void StartTimer()
        {
            _timerActive = true;
        }

        /// <summary>
        /// Reset Timer.
        /// </summary>
        /// <param name="pSetActive">Do want to start Timer immediatly after?</param>
        /// <param name="pKeepLeftOverTime">Do want to subtract the leftover time (time we went below zero) from the new _currentTimerTime? Possibly making timer more accurate in the long run when chain timing.</param>
        public void ResetTimer(bool pSetActive = false, bool pKeepLeftOverTime = false)
        {
            // If we want to keep left over time and we have left over time (below zero) add this to new timer time, else just reset.
            if (pKeepLeftOverTime && _timerCurrentTime < 0)
            {
                //Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine($"Timer calculating time. _timertime + {_timerCurrentTime} = {_timerTime + _timerCurrentTime}");
                //Console.ResetColor();
                _timerCurrentTime = _timerTime + _timerCurrentTime;
            }
            else _timerCurrentTime = _timerTime;

            _timerActive = pSetActive;
        }
        /// <summary>
        /// To be called upon destruction of the timer. ATM it only sets the OnTimeElapsed event to null.
        /// </summary>
        public void Destroy()
        {
            OnTimeElapsed = null;
        }
    }
}
