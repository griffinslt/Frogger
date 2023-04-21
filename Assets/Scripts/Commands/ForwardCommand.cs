using UnityEngine;

namespace Commands
{
    public class ForwardCommand : MoveCommand
    {
        public ForwardCommand(IEntity e, float speed) : base(e, speed)
        {
        }

        public override Vector2 Execute()
        {
            //set orientation
            entityTransform.eulerAngles = Vector3.zero;
            //set movement
            movement += new Vector2(0, _speed);
            return movement;
        }
    }
}
