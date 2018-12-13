using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour, IObserver
{

    GameObject gameObject;
    IAction action;
    bool startedFollowing;


    public Follower(GameObject gameObject, IAction action)
    {
        this.gameObject = gameObject;
        this.action = action;
        startedFollowing = false;
    }

    public void OnNotify(Transform point, Transform target, float distance)
    {
        if (!startedFollowing && point.transform.position.y - target.transform.position.y < distance)
        {
            print("Bottles!");
            action.DoSomething(ref gameObject);
            startedFollowing = true;
        }
    }
}

public class FollowObject : MonoBehaviour
{

    GameObject target;
    float moveSpeed;
    float rotationSpeed;
    void Start()
    {
        target = GameObject.Find("Target");
        moveSpeed = 5;
        rotationSpeed = 1;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion qt = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, qt, Time.deltaTime * rotationSpeed);

    }
}
public class Follow : MonoBehaviour, IAction
{
    public void DoSomething(ref GameObject gameObject)
    {
        gameObject.AddComponent<FollowObject>();
    }
}
