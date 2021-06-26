using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class MoveToGoalAgent : Agent
{
    [ SerializeField ] Transform target;
    [ SerializeField ] MapController map;

public override void OnEpisodeBegin()
{
    transform.localPosition = new Vector3(0, 1, 0);
    target.localPosition = new Vector3( Random.Range(-.3f, .3f), 1, Random.Range(-.3f, .3f) );
}
    public override void CollectObservations( VectorSensor sensor )
    {
        sensor.AddObservation( transform.localPosition );
        sensor.AddObservation( target.localPosition );
    }

    [ SerializeField ] float speed = 1;
    Vector3 nextMove;
    public override void OnActionReceived(ActionBuffers actions)
    {
        nextMove.x = actions.ContinuousActions[0];
        nextMove.z = actions.ContinuousActions[1];

        transform.Translate( nextMove * Time.deltaTime * speed );
    }

    private void OnTriggerEnter(Collider other) 
    {
        if  ( other.transform == target )    
        {
            SetReward(+1);
            map.Success();
            EndEpisode();
        }
        else
        {
            SetReward(-1);
            map.Fail();
            EndEpisode();
        }
    }
}
