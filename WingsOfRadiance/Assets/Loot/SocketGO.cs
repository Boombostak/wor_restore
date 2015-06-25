using UnityEngine;
using System.Collections;

public class SocketGO : MonoBehaviour {

    void LinksTo(GameObject othersocket)
    {
        Debug.Log("LinksTo recieved" + othersocket);
    }
}
