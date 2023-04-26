using System;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

namespace Commands
{
    public class InputHandler
    { 
        public static Vector2 ForwardButtonPressed(IEntity e, float speed)
        {
            if (!Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.UpArrow)
                                             && !Input.GetKeyDown(KeyCode.Space)) return Vector2.zero;
            return new ForwardCommand(e, speed).Execute();
        }
        public static Vector2 BackwardButtonPressed(IEntity e, float speed)
        {
            if (!Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.DownArrow)) return Vector2.zero;
            return new BackCommand(e, speed).Execute();
        }
        public static Vector2 LeftButtonPressed(IEntity e, float speed)
        {
            if (!Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.LeftArrow)) return Vector2.zero;
            return new LeftCommand(e, speed).Execute();
        }
        public static Vector2 RightButtonPressed(IEntity e, float speed)
        {
            if (!Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.RightArrow)) return Vector2.zero;
            return new RightCommand(e, speed).Execute();

        }
    }
}
