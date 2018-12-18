using UnityEngine;
using System.Collections;

public abstract class Command
{
  public abstract void Execute();
  public abstract void Undo();
}

