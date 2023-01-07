using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HexManager : MonoBehaviour
{
    [SerializeField] int boardSizeX;
    [SerializeField] int boardSizeY;
    [SerializeField] float spaceBetweenHexesX;
    [SerializeField] float spaceBetweenHexesY;
    [SerializeField] GameObject hexObject;
    [SerializeField] float[] probablities;
    [SerializeField] GameObject[] startingOccupants;


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
                Hex newHex = Instantiate(hexObject, new Vector3(i * spaceBetweenHexesX - offset, Random.Range(-.25f, .25f), j * spaceBetweenHexesY), Quaternion.identity).GetComponent<Hex>();
                newHex.transform.parent = transform;
                float roll = Random.Range(0f, 1f);
                GameObject startingOccupant = null;
                for (int k = 0; k < probablities.Length; k++)
                {
                    if (roll <= probablities[k])
                    {
                        startingOccupant = startingOccupants[k];
                    }
                }
                if (startingOccupant)
                {
                    newHex.SetOccupant(Instantiate(startingOccupant).GetComponent<Occupant>());
                }


            }
        }
    }


}
