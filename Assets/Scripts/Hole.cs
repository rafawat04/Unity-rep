using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public string targetTag;
    bool isHolding;

    // Getter 
    public bool IsHolding()
    {
        return isHolding;
    }

    // isTriggerのColliderに何か侵入してきた時に動くMethod
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == targetTag) //.gameObject Unity Object all Inspector window  string(tag) == string(targetTag)
        {
            isHolding = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == targetTag)    
        {
            isHolding = false;
        }
    }
    //接触している間動くMethod
    void OnTriggerStay(Collider other) {
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        Vector3 direction = other.gameObject.transform.position 
        - transform.position; //いきなりTransform書くというのはObjectのことを指している
        direction.Normalize();

        if(other.gameObject.tag == targetTag)
        {
            r.velocity *= 0.9f;
            r.AddForce(direction * -20.0f, ForceMode.Acceleration);
        }
        else
        {
            r.AddForce(direction * 80.0f, ForceMode.Acceleration);
        }
    }
}
