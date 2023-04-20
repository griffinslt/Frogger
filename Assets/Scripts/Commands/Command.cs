using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    protected IEntity _entity;

    public Command(IEntity e)
    {
        _entity = e;
        
    }

    public abstract void Execute();
    
}
