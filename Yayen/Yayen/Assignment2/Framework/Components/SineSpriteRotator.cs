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
    public class SineSpriteRotator : Component
    {
        float _minRot;
        float _maxRot;
        bool _clockwise;
        //Timer _secondTimer;
        float _lerpValue;
        Transform2D _transform;
        
        SineWave _sineWave;

        public SineSpriteRotator(GameObject pGameObject, float pMinRot, float pMaxRot, bool pClockwise = true, float pRevolutionsPerSecond = 1) : base(pGameObject)
        {
            _minRot = pMinRot;
            _maxRot = pMaxRot;
            _clockwise = pClockwise;
            _transform = (Transform2D)GameObject.GetComponent<Transform2D>();
            Console.WriteLine($"SineSpriteRotator: Getting transform component of GameObjct {GameObject.Name}");
            _sineWave = new(1, pRevolutionsPerSecond, true);
            //_secondTimer = new(1, "Second Timer");
            //_secondTimer.OnTimeElapsed += ResetSecondTimer;
            //_secondTimer.StartTimer();
        }

        public override void Update(GameTime pGameTime, Transform2D pTransform)
        {
            base.Update(pGameTime, pTransform);
            //_secondTimer.Update(pGameTime);
            _sineWave.Update(pGameTime);
            UpdateLerpValue();
            UpdateSpriteRotation();
        }

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

        public void UpdateSpriteRotation()
        {
            _transform.Rotation = _transform.Rotation = _lerpValue;
        }
    }
}
