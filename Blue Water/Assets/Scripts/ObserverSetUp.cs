using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    void Update();
    void Notify();
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
}

public interface IAction
{
    void DoSomething(ref GameObject gameObject);
}

public interface IObserver
{
    void OnNotify(Transform subject, Transform target, float distance);
}

