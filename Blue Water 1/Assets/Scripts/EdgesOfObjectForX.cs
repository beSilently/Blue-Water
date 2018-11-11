using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class EdgesOfObjectForX : MonoBehaviour
{

	public float Xmin { get; set; }
	public float Xmax { get; set; }

	public void Start ()
	{
		Bounds bounds =this.GetComponent<SkinnedMeshRenderer>().bounds;
		
		Xmin = bounds.min.x;
		Xmax = bounds.max.x;
    }
	
}

