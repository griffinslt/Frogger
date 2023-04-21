using System;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

namespace Commands
{
    public class InputHandler
    {
        
        public static bool ForwardButtonPressed()
        { 
            return Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        }

        public static bool BackwardButtonPressed()
        {
            return Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
        }

        public static bool LeftButtonPressed()
        {
            return Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        }

        public static bool RightButtonPressed()
        {
            return Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        }
    }
}
