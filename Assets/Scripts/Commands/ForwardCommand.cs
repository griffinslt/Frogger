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
            EntityTransform.eulerAngles = Vector3.zero;
            //set movement
            Movement += new Vector2(0, Speed);
            return Movement;
        }
    }
}
