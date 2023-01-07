using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexManager : MonoBehaviour
{
    [SerializeField] int boardSizeX;
    [SerializeField] int boardSizeY;
    [SerializeField] float spaceBetweenHexesX;
    [SerializeField] float spaceBetweenHexesY;
    [SerializeField] GameObject hexObject;
    [SerializeField] GameObject wallObject;

    void Start()
    {
        for (int i = 0; i < boardSizeX; i++)
        {
            for (int j = 0; j < boardSizeY; j++)
            {
                float offset = 0f;
                if (j % 2 == 0)
                {
                    offset = spaceBetweenHexesX / 2f;
                }
                Hex newHex = Instantiate(hexObject, new Vector3(i * spaceBetweenHexesX - offset, Random.Range(-.5f, .5f), j * spaceBetweenHexesY), Quaternion.identity).GetComponent<Hex>();
                newHex.transform.parent = transform;
                newHex.SetOccupant(Instantiate(wallObject).GetComponent<Occupant>());
            }
        }
    }


}
