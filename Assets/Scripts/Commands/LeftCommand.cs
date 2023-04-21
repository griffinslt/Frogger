using UnityEngine;

namespace Commands
{
    public class LeftCommand : MoveCommand
    {
        public LeftCommand(IEntity e, float speed) : base(e, speed)
        {
        }

        public override Vector2 Execute()
        {
            //set orientation
            EntityTransform.eulerAngles = new Vector3(0,0,90);
            //set movement
            Movement += new Vector2(-Speed, 0);
            return Movement;
        }
    }
}
