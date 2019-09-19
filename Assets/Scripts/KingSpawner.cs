using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSpawner : MonoBehaviour
{
    public King k;
    public int[] board = new int[100];
    private int startPosition;

    // Start is called before the first frame update
    void Start() { 

        k = Instantiate(k, new Vector3(-1, -1, -1), Quaternion.identity);
        startPosition =  k.NewPosition();
        k.MoveKing(startPosition);
    }
}
