using System;
using System.Collections.Generic;
using UnityEngine;

public class SBottle  : MonoBehaviour, ISubject
{
    public GameObject observerPrefab;

    //Needs to be seen from other scripts
    public GameObject target;
    public float distance;
    //Set in the inspector
    public float offsetX;
    public float offsetY;

    List<GameObject> objects = new List<GameObject>();
    List<IObserver> observers = new List<IObserver>();
   
   
    private void Start()
    {
        distance = 6.5f;
        target = GameObject.Find("Target");
        objects.Add((GameObject)Instantiate(observerPrefab, new Vector3(this.transform.position.x - offsetX, this.transform.position.y + offsetY, 0), Quaternion.Euler(0,0,-135)));
        objects.Add((GameObject)Instantiate(observerPrefab, new Vector3(this.transform.position.x + offsetX, this.transform.position.y + offsetY, 0), Quaternion.Euler(0, 0, 135)));

        foreach (GameObject o in objects)
        {
            observers.Add(new Follower(o, new Follow()));
        }
    }
    public void Update()
    {
        if (this.transform.position.y - target.transform.position.y < distance) {
            Notify();
        }
    }

    public void Notify()
    {
                for (int i = 0; i < observers.Count; i++)
                {
                    observers[i].OnNotify(this.transform, target.transform, distance);
                }
    }

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }
}
