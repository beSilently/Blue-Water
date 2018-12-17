using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class EdgesOfObject : MonoBehaviour
{

	public float Xmin { get; set; }
	public float Xmax { get; set; }
	public float Ymin { get; set; }
	public float Ymax { get; set; }

	public void Start ()
	{
		Bounds bounds =this.GetComponent<SkinnedMeshRenderer>().bounds;
		
		Xmin = bounds.min.x;
		Xmax = bounds.max.x;
		Ymin = bounds.min.y;
		Ymax = bounds.max.y;
    }
	
}

