using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waynocoll : MonoBehaviour
{
    public EnemyAI enemyai = null;
    public colli colli = null;
    public GameObject no1 = null, no2 = null, no3 = null, no4 = null;
    public GameObject wayno;

    public void OnTriggerStay(Collider other) {
        if(other.tag == "waypoint")
        {
            wayno = other.gameObject;
            if(enemyai.m_target == null)
            {
                if(enemyai.nearwaypoint == true)
                {
                    enemyai.nearwaypoint = false;
                    colli.waypoints = true;

                    if(wayno == no1)
                    {
                        enemyai.m_count = 0;
                    }
                    else if(wayno == no2)
                    {
                        enemyai.m_count = 1;
                    }
                    else if(wayno == no3)
                    {
                        enemyai.m_count = 2;
                    }
                    else
                    {
                        enemyai.m_count = 3;
                    }
                }
            }
        }
    }
}
