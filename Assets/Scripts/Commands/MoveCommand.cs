using UnityEngine;

namespace Commands
{
    public abstract class MoveCommand : Command
    {
        protected readonly float Speed;
        protected readonly Transform EntityTransform;
        protected Vector2 Movement;

        protected MoveCommand(IEntity e, float speed) : base(e)
        {
            Speed = speed;
            EntityTransform = Entity.transform;
            Movement = Vector2.zero;
        }

        public abstract override Vector2 Execute();
    }
}
