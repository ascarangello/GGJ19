using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataSaver : MonoBehaviour
{
    public string username;
    public string channelName;
    public string password;
    public static dataSaver Instance;

    void Awake()
    {
     if(Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }   
     else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
