using UnityEngine;

namespace Commands
{
    public class RightCommand : MoveCommand
    {
        public RightCommand(IEntity e, float speed) : base(e, speed)
        {
        }

        public override Vector2 Execute()
        {
            //set orientation
            Entity.transform.eulerAngles = new Vector3(0,0,-90);
            //set movement
            Movement += new Vector2(Speed, 0);
            return Movement;

        }
    }
}
