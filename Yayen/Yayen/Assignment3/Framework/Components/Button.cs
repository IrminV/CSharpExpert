using Microsoft.Xna.Framework.Input;
using System;
using System.Drawing;
using Yayen.Assignment3.Framework.Components.Base;
using Yayen.Assignment3.Framework.Components.Colliders.Base;
using Yayen.Assignment3.Framework.Components.Colliders.RectangleCollision;
using Yayen.Assignment3.Framework.Components.Interfaces;
using Yayen.Assignment3.Framework.GameObjects;

namespace Yayen.Assignment3.Framework.Components
{
    public class Button : Component, IUpdatableComponent
    {
        private MouseState _mouseState;

        // TODO: implement these colors
        private Color _neutralColor = Color.White;
        private Color _hoverColor = Color.LightBlue;
        private Color _pressedColor = Color.Azure;
        private Color _disabledColor = Color.Gray;
        private Collider _collider;

        private Timer _pressCooldownTimer = new(0.25f, "PressCooldownTimer");
        private bool _canPress = false;

        private bool _mouseOverlap = false;

        public delegate void ButtonDelegate();
        public event ButtonDelegate OnButtonPressed;

        private bool _debugMode = false;

        /// <summary>
        /// Create a Button Component, designating the GameObject this is part of as the Button.
        /// </summary>
        /// <param name="pHoverColor">Colormask the button has when it's being hovered by a selector.</param>
        /// <param name="pPressedColor">Colormask the button has when being pressed.</param>
        /// <param name="pDisabledColor">Colormask the button has when disabled.</param>
        public Button(Color pHoverColor, Color pPressedColor, Color pDisabledColor)
        {
            _hoverColor = pHoverColor;
            _pressedColor = pPressedColor;
            _disabledColor = pDisabledColor;
        }

        /// <summary>
        /// Create a Button Component, designating the GameObject this is part of as the Button. 
        /// </summary>
        public Button() { }

        public override void Start()
        {
            base.Start();
            SetColliderEvents();
            if(_debugMode) OnButtonPressed += DebugOnButtonPressedMessage;
        }

        public void Update(Microsoft.Xna.Framework.GameTime pGameTime)
        {
            //base.Update(pGameTime);
            CheckClick();
            _pressCooldownTimer.Update(pGameTime);
        }

        public void GetCollider()
        {
            if(GameObject.GetComponent<RectangleCollider>() == null) { Console.WriteLine($"Button could not find collider"); }
            _collider = GameObject.GetComponent<RectangleCollider>();
        }

        /// <summary>
        /// Checks if MouseSelector is colliding with this button.
        /// </summary>
        /// <param name="pCollider">Collider colliding with this GameObject</param>
        public void CollisionMouseCheck(Collider pCollider)
        {
            if (pCollider.GameObject.HasComponentOfType(typeof(MouseSelector)))
            {
                //Console.WriteLine($"Button {GameObject.Name} detected mouse entering overlap");
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
                //Console.WriteLine($"Button {GameObject.Name} detected mouse exiting overlap");
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
                //Console.WriteLine("Pressing Button");
                OnButtonPressed.Invoke();
            }
        }

        public void SetColliderEvents()
        {
            GetCollider();
            _collider.OnCollisionEnter += CollisionMouseCheck;
            _collider.OnCollisionExit += ExitCollisionMouseCheck;
            _pressCooldownTimer.OnTimeElapsed += AllowPress;
            _pressCooldownTimer.StartTimer();
        }

        private void DebugOnButtonPressedMessage()
        {
            Console.WriteLine("If this calls more than once per click, we are not destroying the OnButtonPressed event correctly.");
        }
        public override void Destroy()
        {
            base.Destroy();
            OnButtonPressed = null;
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
