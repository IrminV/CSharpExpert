﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yayen.Assignment2.Framework.Components
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
        public Timer(float pTimerTime, string timerName = "Timer", float pTimeMultiplier = 1)
        {
            _timerTime = pTimerTime;
            ResetTimer();
            _timerName = timerName;
        }
        #endregion

        public void Update(GameTime pGameTime)
        {
            UpdateTimer(pGameTime);
        }
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
        /// Resets and activates timer
        /// </summary>
        public void SetTimer()
        {
            ResetTimer(true);
            // TODO: Doesn't Reset timer already set _timerActive to true? Can the line below be removed?
            _timerActive = true;
        }

        /// <summary>
        /// Set timer to value, 
        /// </summary>
        /// <param name="pTime"></param>
        public void SetTimer(float pTime)
        {
            _timerTime = pTime;
            ResetTimer(true);
            _timerActive = true;
        }
        public void PauseTimer()
        {
            _timerActive = false;
        }

        public void StartTimer()
        {
            _timerActive = true;
        }

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
        public void Destroy()
        {
            OnTimeElapsed = null;
        }
    }
}
