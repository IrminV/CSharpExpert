using Microsoft.Xna.Framework.Input;
using System;
using System.Drawing;
using Yayen.Framework.Components.Base;
using Yayen.Framework.Components.Colliders.Base;
using Yayen.Framework.Components.Colliders.RectangleCollision;
using Yayen.Framework.GameObjects;

namespace Yayen.Framework.Components
{
    public class Button : Component
    {
        MouseState _mouseState;

        Color _neutralColor = Color.White;
        Color _hoverColor = Color.LightBlue;
        Color _pressedColor = Color.Azure;
        Color _disabledColor = Color.Gray;
        Collider _collider;

        private bool _mouseOverlap = false;

        public delegate void ButtonDelegate();
        public event ButtonDelegate OnButtonPressed;


        public Button(GameObject pGameObject, Color pHoverColor, Color pPressedColor, Color pDisabledColor) : base(pGameObject)
        {
            _hoverColor = pHoverColor;
            _pressedColor = pPressedColor;
            _disabledColor = pDisabledColor;
            ConstructInitialize();
        }

        public Button(GameObject pGameObject) :base(pGameObject) { ConstructInitialize(); }

        public void ConstructInitialize()
        {
            GetCollider();
            _collider.OnCollisionEnter += CollisionMouseCheck;
            _collider.OnCollisionExit += ExitCollisionMouseCheck;
        }

        public override void Update(Microsoft.Xna.Framework.GameTime pGameTime, Transform2D pTransform)
        {
            base.Update(pGameTime, pTransform);
            CheckClick();
        }

        public void GetCollider()
        {
            _collider = (Collider)GameObject.GetComponent<RectangleCollider>();
        }

        public void CollisionMouseCheck(Collider pCollider)
        {
            if (pCollider.GameObject.HasComponentOfType(typeof(MouseSelector)))
            {
                Console.WriteLine($"Button {GameObject.Name} detected mouse entering overlap");
                _mouseOverlap = true;
            }
        }

        public void ExitCollisionMouseCheck(Collider pCollider)
        {
            if (pCollider.GameObject.HasComponentOfType(typeof(MouseSelector)))
            {
                Console.WriteLine($"Button {GameObject.Name} detected mouse exiting overlap");
                _mouseOverlap = false;
            }
        }

        private void CheckClick()
        {
            _mouseState = Mouse.GetState();
            if (_mouseOverlap && _mouseState.LeftButton == ButtonState.Pressed)
            {
                Console.WriteLine("Pressing Button");
                OnButtonPressed.Invoke();
            }
        }
    }
}
