using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTreeRunner : MonoBehaviour
{
    SOBehaviorTree tree;

    private void Start()
    {
        tree = ScriptableObject.CreateInstance<SOBehaviorTree>();

        var log = ScriptableObject.CreateInstance<DebugLogNode>();
        log.message = "I hate B _ _ G _ R S";

        var loop = ScriptableObject.CreateInstance<RepeatNode>();
        loop.child = log;

        tree.rootNode = loop;
    }
    private void Update()
    {
        tree.Update();
    }


}
