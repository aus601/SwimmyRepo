using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform;

public class TransferPlayerNames : MonoBehaviour
{
    public static TransferPlayerNames instance;


    public Dictionary<ulong, string> nameList = new Dictionary<ulong, string>();

    private Realtime _realtime;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void storeName(string name, ulong id)
    {
        nameList.Add(id, name);
        Debug.Log(name + " was stored to ID: " + id);
    }

    public string getName(ulong id)
    {
        if (nameList.ContainsKey(id))
            return nameList[id];
        else
            return "Unnamed #" + id;
    }
}
