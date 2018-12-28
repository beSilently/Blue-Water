using UnityEngine;
using System.Collections;

public class Rubbish : MonoBehaviour
{

    public delegate void RubbishDelegate(Vector3 position);
    public string TypeOfRubbish;
    public bool DisplayedOnScene;
    public Vector3 InitialPosition;
    public event RubbishDelegate Deleted;
    public virtual void Start()
    {
        InitialPosition = transform.position;
        DisplayedOnScene = true;

    }
    public virtual void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ReturnInitialPosition1();
        }

    }
    public virtual void Remove()
    {
        GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager1>().scores += 100;

        Destroy(this.gameObject);
        GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager1>().objectsOfGarbage.Remove(this.gameObject);
        if (Deleted != null)
            Deleted(this.InitialPosition);

    }
    public void ReturnInitialPosition()
    {
        this.transform.position = InitialPosition;
        this.GetComponent<MovementOfRubbish>().movable = false;
        GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager1>().scores -= 25;
    }
    public void ReturnInitialPosition1()
    {
        this.transform.position = InitialPosition;
        this.GetComponent<MovementOfRubbish>().movable = false;

    }


}
