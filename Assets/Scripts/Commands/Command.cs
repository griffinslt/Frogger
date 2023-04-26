using UnityEngine;

namespace Commands
{
    public abstract class Command
    {
        protected IEntity Entity;

        public Command(IEntity e)
        {
            Entity = e;
        
        }

        public abstract Vector2 Execute();
    }
}
