using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : SteeringBehavior
{
    public Kinematic character;

    float maxAcceleration = 1f;


    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        Vector3 targetPosition = getTargetPosition(); //Out
        if (targetPosition == Vector3.positiveInfinity)//If the vector3 breaks this will keep it from throwing an error
        {
            return null;//Pause movement until it is fixed
        }

        result.linear = targetPosition - character.transform.position;

        // give full acceleration along this direction

        //I know this was obsolete but I was worried about the maxAcceleration
        result.linear.Normalize();
        result.linear *= maxAcceleration;
        

        //result.angular = 0;


        return result;
    }

    protected virtual Vector3 getTargetPosition() //In
    {
        //Produces a random coordinate for the wanderer to move to
        Vector3 WanderSpot = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        //Debug.Log(WanderSpot); //I was having trouble with the randoms but work now
        return WanderSpot;
    }
}