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
            return Vector2.zero;

        }
    }
}
