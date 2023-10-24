using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.IO;
using System;

// months in 1 to 12




public class onButtonClick : MonoBehaviour
{
    TextMeshProUGUI dateAndTime, malaCount, maniCount, timerString;

    public TextMeshProUGUI yearDataPref, monthDataPref;
    string filePath;

    string dataRead = "";

    int dateTmp = 0, monthTmp = 0, yearTmp = 0;



    public GameObject toPopulateContent;
    public GameObject parentOfContent;

    Color giverColor;


    GameObject[] toResetDestroyList;




    private void updatePrefData()
    {
        yearTmp = Convert.ToInt32(yearDataPref.text);
        monthTmp = Convert.ToInt32(monthDataPref.text);
    }


    void Start()
    {
        filePath = Application.persistentDataPath + "/malaAppCountData.txt";

    }

    public void DetectButtonName()
    {

        dateTmp = 0;
        monthTmp = 0;
        yearTmp = 0;
        string dateExtracted = "";
        bool isRed = false;
        DateTime dataDateRead;
        bool listedOnce = true;

        GameObject tmpObject; //var myArray : int[]

        tmpObject = EventSystem.current.currentSelectedGameObject;
        string clickedButtonText = tmpObject.GetComponent<TextMeshProUGUI>().text;

        if (clickedButtonText != "")
        {
            //change some clicks;
            giverColor = tmpObject.GetComponent<TextMeshProUGUI>().color;

            resetCalendarBits();
            destroyAllInitializations();

            giverColor.a = 0.7f;
            tmpObject.GetComponent<TextMeshProUGUI>().color = giverColor;

            pingData();

            for (int k = 1; k < statementCount(dataRead); k += 4)
            {
                dataDateRead = JsonUtility.FromJson<JsonDateTime>(extractData(dataRead, k));
                updatePrefData();
                dateTmp = Convert.ToInt32(clickedButtonText);

                if (yearTmp == dataDateRead.Year && monthTmp == dataDateRead.Month && dateTmp == dataDateRead.Day)
                {
                    if (listedOnce)
                    {
                        toPopulateContent.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(dataDateRead.ToString());
                        toPopulateContent.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().SetText(extractData(dataRead, k + 1));
                        toPopulateContent.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().SetText(extractData(dataRead, k + 2));
                        toPopulateContent.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().SetText(extractData(dataRead, k + 3));
                        listedOnce = false;
                    }
                    else
                    {
                        tmpObject = Instantiate(toPopulateContent, parentOfContent.transform);
                        tmpObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(dataDateRead.ToString());
                        tmpObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().SetText(extractData(dataRead, k + 1));
                        tmpObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().SetText(extractData(dataRead, k + 2));
                        tmpObject.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().SetText(extractData(dataRead, k + 3));
                    }

                }
            }
        }
    }

    void pingData()
    {
        dataRead = File.ReadAllText(filePath);
    }


    public void destroyAllInitializations()
    {
        // contentGenerator(Clone)
        toResetDestroyList = GameObject.FindGameObjectsWithTag("contentGenrator");

        foreach (GameObject tmpObj in toResetDestroyList)
        {
            if (tmpObj.name == "contentGenerator")
            {
                tmpObj.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText("");
                tmpObj.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().SetText("");
                tmpObj.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().SetText("");
                tmpObj.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().SetText("");
            }
            else
            {
                Destroy(tmpObj);
            }
        }
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
            if (!foundStatment)
            {
                if (dataString[i] == ',' || dataString[i] == ';')
                {
                    if (statementNum == (statementInc + 1))
                    {
                        foundStatment = true;
                    }
                    else
                    {
                        dataRecovered = "";
                    }
                    statementInc++;

                }
                else
                {
                    dataRecovered += dataString[i];
                }
            }
        }
        return dataRecovered;
    }


    void resetCalendarBits()
    {
        for (int i = 0; i <= 34; i++)
        {
            //giverColor = GameObject.Find(("Text (TMP) (" + i + ")")).GetComponent<TextMeshProUGUI>().color;
            //giverColor.a = 1f;
            // GameObject.Find(("Text (TMP) (" + i + ")")).GetComponent<TextMeshProUGUI>().color = giverColor; // 3F 23 05;
            GameObject.Find("Text (TMP) (" + i + ")").GetComponent<TextMeshProUGUI>().alpha = 1f;
        }
    }
}
