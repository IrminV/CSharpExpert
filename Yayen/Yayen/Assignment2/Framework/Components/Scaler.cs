using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment2.Framework.Components.Base;
using Yayen.Assignment2.Framework.GameObjects;

namespace Yayen.Assignment2.Framework.Components
{
    public class Scaler : Component
    {
        Transform2D _transform;
        bool _scaleXActive = false;
        SineWave _sineWaveXScale;
        bool _scaleYActive = false;
        SineWave _sineWaveYScale;

        public Vector2 Amplitude
        {
            get
            {
                return new Vector2(_sineWaveXScale.SineScale, _sineWaveYScale.SineScale);
            }
            set
            {
                _sineWaveXScale.SineScale = value.X;
                _sineWaveYScale.SineScale = value.Y;
            }
        }

        public Vector2 ScalesPerSecond { get { return new Vector2(_sineWaveXScale.PeriodsPerSecond, _sineWaveXScale.PeriodsPerSecond); } set { _sineWaveXScale.PeriodsPerSecond = value.X; _sineWaveYScale.PeriodsPerSecond = value.Y;} }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pGameObject">A reference to the GameObject this component is part of.</param>
        /// <param name="pAmplitude">The amplitude of the scaling on x and y axis, for example 2 for x and y should set the scale animation to be 2 times larger than the original sprite.</param>
        /// <param name="pScalesPerSecond">The amount of scale up and downs per second on x and y axis.</param>
        /// <param name="pXScaling">Activate scaling on x axis</param>
        /// <param name="pYScaling">Activate scaling on y axis</param>
        public Scaler(GameObject pGameObject, Vector2 pAmplitude, Vector2 pScalesPerSecond, bool pXScaling = true, bool pYScaling = true) : base(pGameObject)
        {
            _transform = (Transform2D)GameObject.GetComponent<Transform2D>();
            _sineWaveXScale = new(pAmplitude.X, pScalesPerSecond.X, true);
            _sineWaveYScale = new(pAmplitude.Y, pScalesPerSecond.Y, true);
            _scaleXActive = pXScaling;
            _scaleYActive = pYScaling;
        }

        public Scaler(GameObject pGameObject, float pAmplitude, float pScalesPerSecond) : this(pGameObject, new Vector2(pAmplitude, pAmplitude), new Vector2(pScalesPerSecond, pScalesPerSecond))
        {
        }

        public override void Update(GameTime pGameTime, Transform2D pTransform)
        {
            base.Update(pGameTime, pTransform);
            _sineWaveXScale.Update(pGameTime);
            _sineWaveYScale.Update(pGameTime);
            UpdateScale();
        }

        private void UpdateScale()
        {
            if (_scaleXActive) _transform.Scale = new Vector2(_sineWaveXScale.SineValue, _transform.Scale.Y);
            if (_scaleYActive) _transform.Scale = new Vector2(_transform.Scale.X, _sineWaveYScale.SineValue);
        }
    }
}
