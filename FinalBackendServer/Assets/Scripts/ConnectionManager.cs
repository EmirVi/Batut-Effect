using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Networking;
using UnityEngine.UI;

public class ConnectionManager : MonoBehaviour
{
    public InputField r_username;
    public InputField r_password;
    Coroutine registrationCoroutine;

    public void SubmitRegistrationForm()
    {

    }

    IEnumerator SubmitRegisterForm(string username, string password)
    {

    }
}
