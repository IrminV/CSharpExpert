using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yayen.Assignment4.Framework.Vizualization
{
    /// <summary>
    /// WIP, Unused at the moment. I wanted to try doing some things with MonoGame Matrix, would decided it would be better to focus on other things first.
    /// </summary>
    public class MatrixUtility
    {
        //private Vector2 _targetResolution = new Vector2(1920, 1080);
        private Vector2 _origin;
        private Vector2 _targetResolution = new Vector2(480, 270);
        private Vector2 _position;

        //private Vector2 _midScreenOffset;
        //public Vector2 TargetResolution { get { return _targetResolution; } set { _targetResolution = value; } }


        // By default if you scale, you scale around the origin on the top left
        public Matrix CalculateScale(Vector2 pNewScale)
        {
            float scaleX = pNewScale.X;
            float scaleY = pNewScale.Y;
            
            Matrix matrixScale = Matrix.CreateScale(pNewScale.X, pNewScale.Y, 1);
            //Matrix newMatrix = Matrix.CreateTranslation(matrixScale * );
            return matrixScale;
        }



    }
}
