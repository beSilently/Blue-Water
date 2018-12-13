using System;
using System.Collections.Generic;
using UnityEngine;

public class Subject  : MonoBehaviour
{
    public GameObject coffee;

    //Needs to be seen from other scripts
    public GameObject player;
    public float distance = 6.5f;

    List<GameObject> objects = new List<GameObject>();
    List<IObserver> observers = new List<IObserver>();
   
   
    private void Start()
    {
        player = GameObject.Find("Balloon");
        objects.Add((GameObject)Instantiate(coffee, new Vector3(this.transform.position.x - 0.5f, this.transform.position.y + 1, 0), Quaternion.identity));
        objects.Add((GameObject)Instantiate(coffee, new Vector3(this.transform.position.x + 0.5f, this.transform.position.y + 1, 0), Quaternion.identity));

        foreach (GameObject o in objects)
        {
            observers.Add(new Attacker(o, new Attack()));
        }
    }
    private void Update()
    {
        if (this.transform.position.y - player.transform.position.y < distance) {
            Notify();
        }
    }

    public void Notify()
    {
            
                for (int i = 0; i < observers.Count; i++)
                {
                    observers[i].OnNotify(this);
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
