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

        private Timer _pressCooldownTimer = new(0.5f, "PressCooldownTimer");
        private bool _canPress = false;

        private bool _mouseOverlap = false;

        public delegate void ButtonDelegate();
        public event ButtonDelegate OnButtonPressed;

        /// <summary>
        /// Create a Button Component, designating the GameObject this is part of as the Button.
        /// </summary>
        /// <param name="pGameObject">Reference to GameObject this component is part of.</param>
        /// <param name="pHoverColor">Colormask the button has when it's being hovered by a selector.</param>
        /// <param name="pPressedColor">Colormask the button has when being pressed.</param>
        /// <param name="pDisabledColor">Colormask the button has when disabled.</param>
        public Button(GameObject pGameObject, Color pHoverColor, Color pPressedColor, Color pDisabledColor) : base(pGameObject)
        {
            _hoverColor = pHoverColor;
            _pressedColor = pPressedColor;
            _disabledColor = pDisabledColor;
            ConstructInitialize();
        }

        /// <summary>
        /// Create a Button Component, designating the GameObject this is part of as the Button. 
        /// </summary>
        /// <param name="pGameObject">Reference to GameObject this component is part of.</param>
        public Button(GameObject pGameObject) :base(pGameObject) { ConstructInitialize(); }

        public void ConstructInitialize()
        {
            GetCollider();
            _collider.OnCollisionEnter += CollisionMouseCheck;
            _collider.OnCollisionExit += ExitCollisionMouseCheck;
            _pressCooldownTimer.OnTimeElapsed += AllowPress;
            _pressCooldownTimer.StartTimer();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime pGameTime, Transform2D pTransform)
        {
            base.Update(pGameTime, pTransform);
            CheckClick();
            _pressCooldownTimer.Update(pGameTime);
        }

        public void GetCollider()
        {
            _collider = (Collider)GameObject.GetComponent<RectangleCollider>();
        }

        /// <summary>
        /// Checks if MouseSelector is colliding with this button.
        /// </summary>
        /// <param name="pCollider">Collider colliding with this GameObject</param>
        public void CollisionMouseCheck(Collider pCollider)
        {
            if (pCollider.GameObject.HasComponentOfType(typeof(MouseSelector)))
            {
                Console.WriteLine($"Button {GameObject.Name} detected mouse entering overlap");
                _mouseOverlap = true;
            }
        }

        /// <summary>
        /// Checks if MouseSelector is no longer colliding with this button if mouse was colliding before.
        /// </summary>
        /// <param name="pCollider">Collider no longer colliding with this GameObject</param>
        public void ExitCollisionMouseCheck(Collider pCollider)
        {
            if (_mouseOverlap && pCollider.GameObject.HasComponentOfType(typeof(MouseSelector)))
            {
                Console.WriteLine($"Button {GameObject.Name} detected mouse exiting overlap");
                _mouseOverlap = false;
            }
        }

        /// <summary>
        /// Checks if the mouse has clicked and if so, invokes OnButtonPressed event. Should only update when mouse is hovering.
        /// </summary>
        private void CheckClick()
        {
            _mouseState = Mouse.GetState();
            if (_canPress && _mouseOverlap && _mouseState.LeftButton == ButtonState.Pressed)
            {
                Console.WriteLine("Pressing Button");
                OnButtonPressed.Invoke();
            }
        }

        #region PressCoolDownTimerMethods
        /// <summary>
        /// Allows this button to be pressed again.
        /// </summary>
        private void AllowPress()
        {
            _canPress = true;
            _pressCooldownTimer.ResetTimer();
        }

        /// <summary>
        /// Activate a press cooldown, temporarily preventing this button from being pressed.
        /// </summary>
        private void PressCooldown()
        {
            _canPress = false;
            _pressCooldownTimer.StartTimer();
        }
        #endregion
    }
}
