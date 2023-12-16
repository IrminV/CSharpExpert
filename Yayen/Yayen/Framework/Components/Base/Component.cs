using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Framework.GameObjects;

namespace Yayen.Framework.Components.Base
{
    public class Component
    {
        private GameObject _gameObject;

        public GameObject GameObject 
        { get 
            { return _gameObject; } 
            set 
            {
                if (_gameObject == null)
                {
                    _gameObject = value;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"WARNING: tried to rebind {value} already bound component {value}");
                }
            } 
        }
    }
}
