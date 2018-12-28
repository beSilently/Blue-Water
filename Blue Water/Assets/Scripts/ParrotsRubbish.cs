using UnityEngine;
using System.Collections;

public class ParrotsRubbish : Rubbish
{


    public override void Start()
    {
        InitialPosition = this.GetComponent<FlyingOfRubbish>().Target;
        DisplayedOnScene = true;
    }

    public override void Update()
    {
        if (Input.GetMouseButtonUp(0) && GameObject.FindGameObjectWithTag("Parrot").GetComponent<FlyingOfParrot>().flapWings == false)
        {
            ReturnInitialPosition1();
        }
    }
    public void Remove1()
    {
        Destroy(this.gameObject);
        GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager1>().objectsOfGarbage.Remove(this.gameObject);
        GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager1>().scores += 100;

        GameObject.FindGameObjectWithTag("Parrot").GetComponent<FlyingOfParrot>().canFlyFromTree = true;
        GameObject.FindGameObjectWithTag("Parrot").GetComponent<FlyingOfParrot>().canFlyToTree = false;
        GameObject.FindGameObjectWithTag("Parrot").GetComponent<FlyingOfParrot>().flapWings = true;
    }


}

