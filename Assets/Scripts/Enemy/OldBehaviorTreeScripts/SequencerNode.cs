using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem.HID;

public abstract class SequenceNode : CompositeNode
{
    /*
    int current;

    protected override void OnStart()
    {
        current = 0;
    }
    protected override void OnStop()
    {

    }
    protected override State OnUpdate()
    {
        var child = children[current];
        switch(child.Update())
        {
            case State.Running: 
                return State.Running;
            case State.Faliure:
                return State.Faliure;
            case State.Success:
                return State.Success;
            current++;
            break;
        }
        return current == children.Count ? State.Success : State.Running;
    }
    */
}


