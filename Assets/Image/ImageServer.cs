using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using Mirror;
using Mirror.SimpleWeb;
using kcp2k;
public class ImageServer : MonoBehaviour
{   
    Mirror.NetworkManager manager;
    Mirror.Transport transport;
    ushort port;
    public string serverAddress = "http://127.0.0.1:10000/";
    public ushort interval = 5;
    private void Awake()
    {        
        manager = GetComponent<NetworkManager>();
        transport = GetComponent<Transport>();
        string[] arguments = Environment.GetCommandLineArgs();
#if UNITY_SERVER
        Debug.Log("Server Build");       
        if(arguments.Length > 1){
            //Debug.Log("Arg1"+arguments[1]);
            port = ushort.Parse(arguments[1]);
            if(transport is TelepathyTransport){
            var tT = (TelepathyTransport)transport;
            tT.port = port;
            }
            else if(transport is KcpTransport){
            var kT = (KcpTransport)transport;
            kT.Port = port;
            }
            else if(transport is SimpleWebTransport){
            var wT = (SimpleWebTransport)transport;
            wT.port = port;
            }
        }
#endif
        InvokeRepeating("HeartBeat",0,interval);
    }
    void HeartBeat(){
        Debug.Log("My address = " + manager.networkAddress + " " + port);
        string url = String.Format("{0}update?port={1}&players={2}",serverAddress,port,manager.numPlayers);        
        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SendWebRequest();
    }
}
