using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment3.Framework.Components.Base;
using Yayen.Assignment3.Framework.Components.Interfaces;
using Yayen.Assignment3.Framework.GameObjects;

namespace Yayen.Assignment3.Framework.Components
{
    /// <summary>
    /// Component to create a scaling animation on a GameObjects Sprite.
    /// </summary>
    public class SpriteScaler : Component, IUpdatableComponent
    {
        Transform2D _transform;
        bool _scaleXActive = false;
        SineWave _sineWaveXScale;
        bool _scaleYActive = false;
        SineWave _sineWaveYScale;

        private Vector2 _minScale;

        public Vector2 Amplitude
        {
            get
            {
                return new Vector2(_sineWaveXScale.SineAmplitude, _sineWaveYScale.SineAmplitude);
            }
            set
            {
                _sineWaveXScale.SineAmplitude = value.X;
                _sineWaveYScale.SineAmplitude = value.Y;
            }
        }

        public Vector2 ScalesPerSecond { get { return new Vector2(_sineWaveXScale.PeriodsPerSecond, _sineWaveXScale.PeriodsPerSecond); } set { _sineWaveXScale.PeriodsPerSecond = value.X; _sineWaveYScale.PeriodsPerSecond = value.Y;} }

        /// <summary>
        /// Create a SpriteScaler Component. This creates a scaling animation for the connected GameObjects Sprite. This constructor gives the most indept configuration. This Constructor expects non uniform scaling with Vector 2s.
        /// </summary>
        /// <param name="pMinScale">The minimum scale of the animation, seperated by axis.</param>
        /// <param name="pMaxScale">The maximum sclae of the animation, seperated by axis.</param>
        /// <param name="pScalesPerSecond">The amount sine scales per second.</param>
        /// <param name="pXScaling">Do we activate scaling on the x axis?</param>
        /// <param name="pYScaling">Do we activate scaling on the y axis?</param>
        public SpriteScaler(Vector2 pMinScale, Vector2 pMaxScale, Vector2 pScalesPerSecond, bool pXScaling = true, bool pYScaling = true)
        {
            _minScale = pMinScale;
            float rangeX = pMaxScale.X - pMinScale.X;
            float rangeY = pMaxScale.Y - pMinScale.Y;

            // TODO: reïmplement these two
            _sineWaveXScale = new(rangeX, pScalesPerSecond.X, true);
            _sineWaveYScale = new(rangeY, pScalesPerSecond.Y, true);
            _scaleXActive = pXScaling;
            _scaleYActive = pYScaling;
        }

        /// <summary>
        /// Create a SpriteScaler Component. This creates a scaling animation for the connected GameObjects Sprite. This constuctor expects Uniform scaling.
        /// </summary>
        /// <param name="pGameObject">A reference to the GameObject this component is part of.</param>
        /// <param name="pMinscale">The minimum scale of the animation.</param>
        /// <param name="pMaxScale">The maximum sclae of the animation.</param>
        /// <param name="pScalesPerSecond">The amount sine scales per second.</param>
        /// <param name="pXscaling">Do we activate scaling on the x axis?</param>
        /// <param name="pYScaling">Do we activate scaling on the y axis?</param>
        public SpriteScaler(float pMinscale, float pMaxScale, float pScalesPerSecond, bool pXscaling = true, bool pYScaling = true) : this(new Vector2(pMinscale, pMinscale), new Vector2(pMaxScale, pMaxScale), new Vector2(pScalesPerSecond, pScalesPerSecond), pXscaling, pYScaling)
        {
        }

        /// <summary>
        /// Create a SpriteScaler Component. This creates a scaling animation for the connected GameObjects Sprite. This constuctor expects Uniform scaling and a minimum scale of zero.
        /// </summary>
        /// <param name="pGameObject">A reference to the GameObject this component is part of.</param>
        /// <param name="pMaxScale">The maximum sclae of the animation.</param>
        /// <param name="pScalesPerSecond">The amount sine scales per second.</param>
        /// <param name="pXscaling">Do we activate scaling on the x axis?</param>
        /// <param name="pYScaling">Do we activate scaling on the y axis?</param>
        public SpriteScaler(float pMaxScale, float pScalesPerSecond, bool pXscaling = true, bool pYScaling = true) : this(new Vector2(0, 0), new Vector2(pMaxScale, pMaxScale), new Vector2(pScalesPerSecond, pScalesPerSecond), pXscaling, pYScaling)
        {
        }

        public override void Start()
        {
            base.Start();
            _transform = (Transform2D)GameObject.GetComponent<Transform2D>();
        }

        /// <summary>
        /// Update the SpriteScaler Component.
        /// </summary>
        /// <param name="pGameTime"></param>
        public void Update(GameTime pGameTime)
        {
            _sineWaveXScale.Update(pGameTime);
            _sineWaveYScale.Update(pGameTime);
            UpdateScale();
        }

        /// <summary>
        /// Update the visual scale of the connected GameObjects Sprite.
        /// </summary>
        private void UpdateScale()
        {
            if (_scaleXActive) _transform.Scale = new Vector2(_minScale.X + _sineWaveXScale.SineValue, _transform.Scale.Y);
            if (_scaleYActive) _transform.Scale = new Vector2(_transform.Scale.X, _minScale.Y + _sineWaveYScale.SineValue);
        }

        public override void Destroy()
        {
            base.Destroy();
            _sineWaveXScale.Destroy();
            _sineWaveYScale.Destroy();
        }
    }
}
