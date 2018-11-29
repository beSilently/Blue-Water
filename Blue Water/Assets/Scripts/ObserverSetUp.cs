using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverSetUp : MonoBehaviour {

    public List<GameObject> observers = new List<GameObject>();

    public Subject subject;

    void Start()
    {
        foreach (GameObject o in observers)
        {
            subject.AddObserver(new Attacker(o, new Attack()));
        }
    }
}


