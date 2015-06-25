using UnityEngine;
using System.Collections;

public class SocketScript : MonoBehaviour {

    public int sockets;
    public GameObject socketgo;
    public GameObject[] socketarray;

    public void AddSockets(int level)
    {
        int sockets_rng;
        int max_sockets = 0;

        if (level <= 14) { max_sockets = 2; }
        if (level > 14 && level<= 27) { max_sockets = 3; }
        if (level > 27 && level <= 34) { max_sockets = 4; }
        if (level > 34 && level <= 49) { max_sockets = 5; }
        if (level >= 50) { max_sockets = 6; }

        //Debug.Log("max sockets " +max_sockets);

        sockets_rng = Random.Range(0, max_sockets + 1);
        if (sockets_rng > 0)
        {
            socketarray = new GameObject[sockets_rng];
            for (int i = 0; i < socketarray.Length; i++)
            {
                if (socketarray[i] == null)
                {
                    socketarray[i] = Instantiate(socketgo) as GameObject;
                }
                //Debug.Log(socketarray.Length + "sockets!");
            }
            LinkSockets(socketarray, socketarray.Length); 
        }
    }

    public void LinkSockets(GameObject[] socketarray, int length)
    {
        int links = Random.Range(0, length);

        for (int i = 0; i <= links; i++)
        {
            if (i < links)
            {
                socketarray[i].gameObject.SendMessage("LinksTo", socketarray[i + 1]);
                //linking logic
            }
        }
    }
}
