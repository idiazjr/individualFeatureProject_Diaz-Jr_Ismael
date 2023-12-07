using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowedTime : MonoBehaviour
{
    bool time_stop = false;
    public Rigidbody rb;

    private void Update()
    {
        if (!time_stop)
        {
            Time.timeScale = 1;
            playerController.moveSpeed = 6;
            if (rb.velocity.magnitude == 0)
            {
                time_stop = true;
            }
        }
        else
        {
            Time.timeScale = 0.25f;
            playerController.moveSpeed = 24f;
            if (rb.velocity.magnitude != 0)
            {
                time_stop = false;
            }
        }
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
