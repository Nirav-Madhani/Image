using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class ImageServer : MonoBehaviour
{   
    Mirror.NetworkManager manager; 
    kcp2k.KcpTransport transport;
    ushort port;
    public string serverAddress = "http://127.0.0.1:10000/";
    public ushort interval = 5;
    private void Awake()
    {        
        manager = GetComponent<Mirror.NetworkManager>();
        transport = GetComponent<kcp2k.KcpTransport>();
        string[] arguments = Environment.GetCommandLineArgs();
        #if UNITY_SERVER
        Debug.Log("Server Build");       
        if(arguments.Length > 1){
            //Debug.Log("Arg1"+arguments[1]);
            port = ushort.Parse(arguments[1]);
            transport.Port = port;
        }
        #endif
        InvokeRepeating("HeartBeat",0,interval);
    }
    void HeartBeat(){
        string url = String.Format("{0}update?port={1}&players={2}",serverAddress,port,manager.numPlayers);        
        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SendWebRequest();
    }
}
