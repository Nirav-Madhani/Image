using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ImageClient : MonoBehaviour
{
    Mirror.NetworkManager manager; 
    kcp2k.KcpTransport transport;
    public string serverAddress = "http://127.0.0.1:10000/";
    public ushort interval = 5;
    private void Awake() {
        manager = GetComponent<Mirror.NetworkManager>();
        transport = GetComponent<kcp2k.KcpTransport>();
        manager.enabled =false;
        transport.enabled= false;
        StartCoroutine(GetPort());
    }
    // Start is called before the first frame update
    IEnumerator GetPort() {
       while(true){
           if(manager.isNetworkActive){
                yield return new WaitForSeconds(interval);
                continue;
            }
        UnityWebRequest www = UnityWebRequest.Get(serverAddress+"getPort");
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {           
            Debug.Log(www.downloadHandler.text);
            ushort portStr = ushort.Parse(www.downloadHandler.text);
            transport.Port = portStr;
            manager.enabled =true;
            transport.enabled= true;           
        }
        yield return new WaitForSeconds(interval);
       }
    }
}
