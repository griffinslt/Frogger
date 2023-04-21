using UnityEngine;

namespace Commands
{
    public abstract class MoveCommand : Command
    {
        protected float _speed;
        protected Transform entityTransform;
        protected Vector2 movement;
        public MoveCommand(IEntity e, float speed) : base(e)
        {
            _speed = speed;
            entityTransform = Entity.transform;
            movement = Vector2.zero;
        }

        public abstract override Vector2 Execute();
    }
}
