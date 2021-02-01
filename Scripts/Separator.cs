using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separator: Kinematic
{
    Separation myMoveType;
    LookWhereGoing myRotationType;

    public Kinematic[] targets;

    public bool flee = false;

    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new Separation();
        myMoveType.character = this;
        myMoveType.targets = targets;

        myRotationType = new LookWhereGoing();
        myRotationType.character = this;
        myRotationType.target = myTarget;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = myRotationType.getSteering().angular;
        base.Update();
    }
}