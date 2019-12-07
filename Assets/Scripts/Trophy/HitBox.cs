﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("HIT");
        Tilt parentScript = this.transform.parent.GetComponent<Tilt>();

        if (col.gameObject.CompareTag("Rat")) {
            Destroy(col.gameObject);
            if (gameObject.name == "LeftRectangle") {
                parentScript.toppleRightByRat(47000);
            }

            if (gameObject.name == "RightRectangle") {
                parentScript.toppleLeftByRat(47000);
            }
        }
    }
}
