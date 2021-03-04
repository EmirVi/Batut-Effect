using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForMouseButtonDown : CustomYieldInstruction
{
    public override bool keepWaiting
    {
        get
        {
            return !Input.GetMouseButton(0);
        }
    }
    public WaitForMouseButtonDown()
    {
        Debug.Log("Wait for Mouse to get clicked");
    }
}
