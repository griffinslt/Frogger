using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Commands
{
    public class InputHandler: MonoBehaviour
    {

        private Command _upButton;
        private Command _downButton;
        private Command _leftButton;
        private Command _rightButton;


        public bool ForwardButtonPressed()
        {
            return false;
        }
        
        
    }
}
