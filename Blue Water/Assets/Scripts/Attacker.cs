using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void OnNotify(Subject subject);
}

public class Attacker : MonoBehaviour, IObserver {

    readonly GameObject gameObject;
    Action action;
    bool attacked;


    public Attacker(GameObject gameObject, Action action)
    {
        this.gameObject = gameObject;
        this.action = action;
        attacked = false;
    }

    public void OnNotify(Subject subject)
    {
       
        if (!attacked && subject.transform.position.y  - subject.player.transform.position.y < subject.distance) {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            attacked = true;
            Debug.Log("Near!");

        }
    }
}

public abstract class Action
{
    public abstract void DoSomething(ref GameObject gameObject);
}


public class Attack : Action
{
    public override void DoSomething(ref GameObject gameObject)
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}

