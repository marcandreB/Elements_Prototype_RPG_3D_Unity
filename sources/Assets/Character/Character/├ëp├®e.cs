using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Épée : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }
        // Update is called once per frame
        void Update()
        {

        GameObject oHuman = GameObject.FindGameObjectWithTag("Jesus");
        string sJoint = "metacarpal3.R";
        Transform tHand = oHuman.transform.Find(sJoint);

        this.transform.SetPositionAndRotation(tHand.position, tHand.rotation);
        this.transform.parent = tHand;
    }

    }