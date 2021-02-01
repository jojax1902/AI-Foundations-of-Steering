using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : Align
{
    public Kinematic Target;
    // TODO: override Align's getTargetAngle to face the target instead of matching it's orientation
    public override float getTargetAngle()
    {
        Vector3 velocity = target.transform.position - character.transform.position; //Compare coordinates to create a direction of motion

        if (velocity.magnitude == 0) //If the character isn't moving they will face in the direction they are currently facing
        {
            return character.transform.eulerAngles.y; 
        }
        float targetAngle = Mathf.Atan2(velocity.x, velocity.z); //Extrapolate the direction of motion in radians
        targetAngle *= Mathf.Rad2Deg; //Convert radians to degrees

        return targetAngle; //return the angle to face1
    }
}
