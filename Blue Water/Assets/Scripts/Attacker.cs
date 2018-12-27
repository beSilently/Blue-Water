using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attacker : MonoBehaviour, IObserver {

    GameObject gameObject;
    IAction action;
    bool attacked;


    public Attacker(GameObject gameObject, IAction action)
    {
        this.gameObject = gameObject;
        this.action = action;
        attacked = false;
    }

    public void OnNotify(Transform point, Transform target, float distance)
    {
        if (!attacked && point.transform.position.y - target.transform.position.y < distance) {
            action.DoSomething(ref gameObject);
            attacked = true;
        }
    }
}

public class Attack : IAction
{
    public void DoSomething(ref GameObject gameObject)
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}


