using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(menuName = "HexManager")]

public class HexManager : ScriptableObject
{
    [SerializeField] int boardSizeX;
    [SerializeField] int boardSizeY;
    [SerializeField] float spaceBetweenHexesX;
    [SerializeField] float spaceBetweenHexesY;
    [SerializeField] GameObject hexObject;
    [SerializeField] float[] probablities;
    [SerializeField] GameObject[] startingOccupants;
    [SerializeField] GameObject lanternObject;

    Hex[,] hexes;


    public void NewGame()
    {
        hexes = new Hex[boardSizeX, boardSizeY];
        for (int i = 0; i < boardSizeX; i++)
        {
            for (int j = 0; j < boardSizeY; j++)
            {
                bool isValid = true;

                float offset = 0f;
                if (j % 2 == 0)
                {
                    offset = spaceBetweenHexesX / 2f;
                }

                if (i >= boardSizeX - 2 || i < 2 || j <= 3 || j >= boardSizeY - 3)
                {
                    isValid = false;
                }

                Hex newHex = Instantiate(hexObject, new Vector3(i * spaceBetweenHexesX - offset, Random.Range(-.25f, .25f), j * spaceBetweenHexesY), Quaternion.identity).GetComponent<Hex>();
                hexes[i, j] = newHex;


                newHex.SetHexIndex(i, j, isValid);



                if (i > 4 && i < 8 && j < 10)
                {
                    if (j == 7 && i == 6)
                    {
                        newHex.SetOccupant(Instantiate(lanternObject).GetComponent<Occupant>());
                    }
                }
                else
                {
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

    public Hex[] GetAdjacentHexes(int x, int y)
    {
        Hex[] hexArray = new Hex[6];

        if (x >= boardSizeX - 2 || x < 2 || y <= 3 || y >= boardSizeY - 3)
        {
            return hexArray;
        }


        if (y % 2 == 0)
        {
            hexArray[0] = hexes[x, y - 1];
            hexArray[1] = hexes[x, y - 2];
            hexArray[2] = hexes[x - 1, y - 1];
            hexArray[3] = hexes[x - 1, y + 1];
            hexArray[4] = hexes[x, y + 2];
            hexArray[5] = hexes[x, y + 1];
        } else
        {
            hexArray[0] = hexes[x + 1, y - 1];
            hexArray[1] = hexes[x, y - 2];
            hexArray[2] = hexes[x, y - 1];
            hexArray[3] = hexes[x, y + 1];
            hexArray[4] = hexes[x, y + 2];
            hexArray[5] = hexes[x + 1, y + 1];
        }

        return hexArray;
    }

    public Hex[] GetHexesInRange2(int x, int y)
    {
        Hex[] hexArray = new Hex[12];

        if (y % 2 == 0)
        {
            hexArray[0] = hexes[x + 1, y];
            hexArray[1] = hexes[x + 1, y - 2];
            hexArray[2] = hexes[x, y - 3];
            hexArray[3] = hexes[x, y - 4];
            hexArray[4] = hexes[x - 1, y - 3];
            hexArray[5] = hexes[x - 1, y - 2];
            hexArray[6] = hexes[x - 1, y];
            hexArray[7] = hexes[x - 1, y + 2];
            hexArray[8] = hexes[x - 1, y + 3];
            hexArray[9] = hexes[x, y + 4];
            hexArray[10] = hexes[x, y + 3];
            hexArray[11] = hexes[x + 1, y + 2];
        }
        else
        {
            hexArray[0] = hexes[x + 1, y];
            hexArray[1] = hexes[x + 1, y - 2];
            hexArray[2] = hexes[x + 1, y - 3];
            hexArray[3] = hexes[x, y - 4];
            hexArray[4] = hexes[x, y - 3];
            hexArray[5] = hexes[x - 1, y - 2];
            hexArray[6] = hexes[x - 1, y];
            hexArray[7] = hexes[x - 1, y + 2];
            hexArray[8] = hexes[x, y + 3];
            hexArray[9] = hexes[x, y + 4];
            hexArray[10] = hexes[x + 1, y + 3];
            hexArray[11] = hexes[x + 1, y + 2];
        }

        return hexArray;
    }

}
