using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    public KingSpawner spawner;
    public GameObject green;

    public int cornerPosition, cont, xPos, yPos, newPosition, currentPosition,
               tempY, tempComp, ulBoard, urBoard, luBoard, ldBoard, ruBoard,
               rdBoard, dlBoard, drBoard, A, B, C, D, E, F, G, H, minValue, time,
                thisPosition;

    public int[] visitedPositions = new int[100];

    public int[] moveCost = new int[8];

    public bool cornerDetected, move;

    private void Awake()
    {
        spawner = FindObjectOfType<KingSpawner>();
        cont = 0;
    }

    private void Update()
    {
        if (move) {
            time++;
            if (time == 60) {
                move = false;
                time = 0;
                MoveKing(thisPosition);
            }
        }
    }

    public void MoveKing(int pos) {

        for (int j = 0; j < moveCost.Length; j++)
        {
            moveCost[j] = 0;
        }

        currentPosition = pos;
        cont = 0;

        xPos = currentPosition / 10;
        yPos = currentPosition % 10;

        transform.position = new Vector3(xPos, -1, yPos);
        Instantiate(green, new Vector3(xPos, -0.1f, yPos), Quaternion.identity);

        visitedPositions[currentPosition] = 1;

        CheckSurroundings();
    }

    public int NewPosition() {

        newPosition = Random.Range(0, 101);

        return newPosition;
    }

    private void CheckSurroundings() {

        //Up

        //Left
        ulBoard = currentPosition - 12;

        tempY = ulBoard % 10;
        tempComp = yPos - tempY;

        if (ulBoard >= 0 && tempComp == 2 && visitedPositions[ulBoard] < 1) {
            if (ulBoard == 0) {
                cornerDetected = true;
                cornerPosition = ulBoard;
            }
            A = CheckCombinations(ulBoard);
            moveCost[cont] = A;
        }
        cont++;

        //Right
        urBoard = currentPosition + 8;

        tempY = urBoard % 10;
        tempComp = yPos - tempY;

        if (urBoard <= 99 && tempComp == 2 && visitedPositions[urBoard] < 1)
        {
            if (urBoard == 90)
            {
                cornerDetected = true;
                cornerPosition = urBoard;
            }
            B = CheckCombinations(urBoard);
            moveCost[cont] = B;
        }
        cont++;
        ////////////////

        //Left

        //Up
        luBoard = currentPosition - 21;

        tempY = luBoard % 10;
        tempComp = yPos - tempY;

        if (luBoard >= 0 && tempComp == 1 && visitedPositions[luBoard] < 1) {
            if (luBoard == 0)
            {
                cornerDetected = true;
                cornerPosition = luBoard;
            }
            C = CheckCombinations(luBoard);
            moveCost[cont] = C;
        }
        cont++;

        //Down
        ldBoard = currentPosition - 19;

        tempY = ldBoard % 10;
        tempComp = yPos - tempY;

        if (ldBoard <= 99 && tempComp == -1 && visitedPositions[ldBoard] < 1) {
            if (ldBoard == 9)
            {
                cornerDetected = true;
                cornerPosition = ldBoard;
            }
            D = CheckCombinations(ldBoard);
            moveCost[cont] = D;
        }
        cont++;
        /////////////////

        //Righ

        //Up
        ruBoard = currentPosition + 19;

        tempY = ruBoard % 10;
        tempComp = yPos - tempY;

        if (ruBoard <= 99 && tempComp == 1 && visitedPositions[ruBoard] < 1)
        {
            if (ruBoard == 90)
            {
                cornerDetected = true;
                cornerPosition = ruBoard;
            }
            E = CheckCombinations(ruBoard);
            moveCost[cont] = E;
        }
        cont++;

        //Down
        rdBoard = currentPosition + 21;

        tempY = rdBoard % 10;
        tempComp = yPos - tempY;

        if (rdBoard <= 99 && tempComp == -1 && visitedPositions[rdBoard] < 1)
        {
            if (rdBoard == 99)
            {
                cornerDetected = true;
                cornerPosition = rdBoard;
            }
            F = CheckCombinations(rdBoard);
            moveCost[cont] = F;
        }
        cont++;
        //////////////

        //Down

        //Left
        dlBoard = currentPosition - 8;

        tempY = dlBoard % 10;
        tempComp = yPos - tempY;

        if (dlBoard >= 0 && tempComp == -2 && visitedPositions[dlBoard] < 1)
        {
            if (dlBoard == 9)
            {
                cornerDetected = true;
                cornerPosition = dlBoard;
            }
            G = CheckCombinations(dlBoard);
            moveCost[cont] = G;
        }
        cont++;
        //Right
        drBoard = currentPosition + 12;

        tempY = drBoard % 10;
        tempComp = yPos - tempY;

        if (drBoard <= 99 && tempComp == -2 && visitedPositions[drBoard] < 1)
        {
            if (drBoard == 99)
            {
                cornerDetected = true;
                cornerPosition = drBoard;
            }
            H = CheckCombinations(drBoard);
            moveCost[cont] = H;
        }
        cont++;

        if (cornerDetected)
        {
            cornerDetected = false;
            move = true;
            thisPosition = cornerPosition;
        }
        else {
            int tempMin;
            int newMin = 10;

            for (int j = 0; j < moveCost.Length; j++)
            {
                tempMin = moveCost[j];

                if (tempMin < newMin && tempMin != 0) {
                    newMin = tempMin;
                    minValue = j;
                }
            }

            switch (minValue) {
                case 0:
                    move = true;
                    thisPosition = ulBoard;
                    break;
                case 1:
                    move = true;
                    thisPosition = urBoard;
                    break;
                case 2:
                    move = true;
                    thisPosition = luBoard;
                    break;
                case 3:
                    move = true;
                    thisPosition = ldBoard;
                    break;
                case 4:
                    move = true;
                    thisPosition = ruBoard;
                    break;
                case 5:
                    move = true;
                    thisPosition = rdBoard;
                    break;
                case 6:
                    move = true;
                    thisPosition = dlBoard;
                    break;
                case 7:
                    move = true;
                    thisPosition = drBoard;
                    break;
            }
        }
    }

    private int CheckCombinations(int futurePosition) {
        int combinations = 0;
        int nextY;
        int tempPos;

        //Up

        //Left
        tempPos = futurePosition - 12;
        tempY = futurePosition % 10;
        nextY = tempPos % 10;
        tempComp = tempY - nextY;

        if (tempPos >= 0 && tempComp == 2 && visitedPositions[tempPos] < 1)
        {
            combinations++;
        }

        //Right
        tempPos = futurePosition + 8;
        tempY = futurePosition % 10;
        nextY = tempPos % 10;
        tempComp = tempY - nextY;

        if (tempPos <= 99 && tempComp == 2 && visitedPositions[tempPos] < 1)
        {
            combinations++;
        }
        ////////////////

        //Left

        //Up
        tempPos = futurePosition - 21;
        tempY = futurePosition % 10;
        nextY = tempPos % 10;
        tempComp = tempY - nextY;

        if (tempPos >= 0 && tempComp == 1 && visitedPositions[tempPos] < 1)
        {
            combinations++;
        }

        //Down
        tempPos = futurePosition - 19;
        tempY = futurePosition % 10;
        nextY = tempPos % 10;
        tempComp = tempY - nextY;

        if (tempPos >= 0 && tempComp == -1 && visitedPositions[tempPos] < 1)
        {
            combinations++;
        }
        /////////////////

        //Righ

        //Up
        tempPos = futurePosition + 19;
        tempY = futurePosition % 10;
        nextY = tempPos % 10;
        tempComp = tempY - nextY;

        if (tempPos <= 99 && tempComp == 1 && visitedPositions[tempPos] < 1)
        {
            combinations++;
        }

        //Down
        tempPos = futurePosition + 21;
        tempY = futurePosition % 10;
        nextY = tempPos % 10;
        tempComp = tempY - nextY;

        if (tempPos <= 99 && tempComp == -1 && visitedPositions[tempPos] < 1)
        {
            combinations++;
        }
        //////////////

        //Down

        //Left
        tempPos = futurePosition - 8;
        tempY = futurePosition % 10;
        nextY = tempPos % 10;
        tempComp = tempY - nextY;

        if (tempPos >= 0 && tempComp == -2 && visitedPositions[tempPos] < 1)
        {
            combinations++;
        }
        //Right
        tempPos = futurePosition + 12;
        tempY = futurePosition % 10;
        nextY = tempPos % 10;
        tempComp = tempY - nextY;

        if (tempPos <= 99 && tempComp == -2 && visitedPositions[tempPos] < 1)
        {
            combinations++;
        }

        return combinations;
    }
}
