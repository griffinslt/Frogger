using UnityEngine;

namespace Commands
{
    public class BackCommand : MoveCommand
    {
        public BackCommand(IEntity e, float speed) : base(e, speed)
        {
        }

        public override Vector2 Execute()
        {
            //set orientation
            Entity.transform.eulerAngles = new Vector3(0,0,180);
            //set movement
            Movement += new Vector2(0, -Speed);
            return Movement;
        }
    }
}
