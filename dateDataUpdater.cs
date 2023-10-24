/*
 * 
 * using UnityEngine;
using System;
using TMPro;
using System.IO;

public class dateDataUpdater : MonoBehaviour
{
    string filePath;
    //colourHex code : 440008

    string dataRead = "";

    DateTime readDateTime;
    

    void Start()
    {
        //filePath = Application.persistentDataPath + "/malaAppCountData.txt";
        colourUpdate();

    }

    public void colourUpdate()
    {
        dataRead = File.ReadAllText(filePath);
        //Debug.Log(extractData(dataRead,1) + "\n");


    }



    string extractData(string dataString, int statementNum)
    {
        string dataRecovered = "";
        int statementInc = 0;

        bool foundStatment = false;
        int statementsTotal = statementCount(dataString);

        if (statementNum > statementsTotal || statementNum < 1)
        {
            return "";
        }

        for (int i = 0; i < dataString.Length; i++)
        {
            if(!foundStatment)
            {
                if (dataString[i] == ',' || dataString[i] == ';')
                {
                    if(statementNum == (statementInc+1))
                    {
                        foundStatment = true;
                    }
                    else
                    {
                        dataRecovered = "";
                    }
                    statementInc++;
                    
                }
                else {
                    dataRecovered += dataString[i];
                }
            }
        }

        
        return dataRecovered;
    }

    int statementCount(string DataStrinfToCount)
    {
        int countedStatements = 0;
        for (int i = 0; i < DataStrinfToCount.Length; i++)
        {
            if (DataStrinfToCount[i] == ';' || DataStrinfToCount[i] == ',')
            {
                countedStatements++;
            }
        }

        return countedStatements;
    }
}

*/