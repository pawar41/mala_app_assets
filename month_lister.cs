using UnityEngine;
using System;
using TMPro;
using System.IO;

public class month_lister : MonoBehaviour
{
    //private static readonly string monthUpdatedPref = "monthUpdatedPref";
    //private static readonly string yearUpdatedPref = "yearUpdatedPref";

    public TextMeshProUGUI yearTMP, MonthTMP;

    string filePath;
    //colourHex code : 440008

    string dataRead = "";

    DateTime readDateTime;

    DateTime currentDateTime;
    DateTime toDisplayDateTime;

    /*
    0 January - 31 days
    1 February - 28 days in a common year and 29 days in leap years
    2 March - 31 days
    3 April - 30 days
    4 May - 31 days
    5 June - 30 days
    6 July - 31 days
    7 August - 31 days
    8 September - 30 days
    9 October - 31 days
    10 November - 30 days
    11 December - 31 days
     */

    int[] daysInMonth = new int[12];
    String[] nameOfMonths = new String[12];
    String monthDispString;

    int Sep2023_startBlock;
    int currentMonthStartBlock;
    int blocksSkipped;

    bool onlyOnce;

    

    void Start()
    {

        filePath = Application.persistentDataPath + "/malaAppCountData.txt";

        
            //

        if (System.IO.File.Exists(filePath))
        {
            dataRead = File.ReadAllText(filePath);
        }
        else
        {
            System.IO.File.WriteAllText(filePath, " ");
        }


            currentDateTime = DateTime.Now;

        nameOfMonths[0] = "January";
        nameOfMonths[1] = "February";
        nameOfMonths[2] = "March";
        nameOfMonths[3] = "April";
        nameOfMonths[4] = "May";
        nameOfMonths[5] = "June";
        nameOfMonths[6] = "July";
        nameOfMonths[7] = "Agust";
        nameOfMonths[8] = "September";
        nameOfMonths[9] = "October";
        nameOfMonths[10] = "November";
        nameOfMonths[11] = "December";
        

        for (int i = 0; i < 12; i++){
            if(i == 0 || i == 2 || i == 4 || i == 6 || i == 7 || i == 9 || i == 11)
            {
                daysInMonth[i] = 31;
            } else if(i == 3 || i == 5 || i == 8 || i == 10)
            {
                daysInMonth[i] = 30;
            } else if (i == 1)
            {
                if(currentDateTime.Year % 4 == 0)
                {
                    daysInMonth[i] = 29;
                }
                else
                {
                    daysInMonth[i] = 28;
                }
            }
        }

        Sep2023_startBlock = 6;
        blocksSkipped = 0;

        //toDisplayDateTime = currentDateTime.AddMonths(5);
        toDisplayDateTime = currentDateTime;
        onlyOnce = true;

        launchCalendar();

        
        //colourUpdate();
        //Debug.Log(dataRead);
    }

    public void colourUpdate()
    {
        //dataRead = File.ReadAllText(filePath);
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











    private void Update()
    {
    }


    void pingData()
    {
        dataRead = File.ReadAllText(filePath);
    }


    void UpdateDate()
    {
        int dateTmp = 0, monthTmp = 0, yearTmp = 0;
        string dateExtracted = "";
        bool isRed = false;
        DateTime dataDateRead;

        monthDispString = nameOfMonths[toDisplayDateTime.Month - 1];
        GameObject.FindWithTag("monthUpdate").GetComponent<TextMeshProUGUI>().SetText(" " + monthDispString + " " + toDisplayDateTime.Year);


        //PlayerPrefs.SetInt(monthUpdatedPref, toDisplayDateTime.Month);
        //PlayerPrefs.SetInt(yearUpdatedPref, toDisplayDateTime.Year);

        yearTMP.SetText(toDisplayDateTime.Year.ToString());
        MonthTMP.SetText(toDisplayDateTime.Month.ToString());





        if (toDisplayDateTime.Month == 9 && toDisplayDateTime.Year == 2023)
        {
            currentMonthStartBlock = Sep2023_startBlock;
        } else
        {
            //daysInMonth[1] = FebDaysCounter(toDisplayDateTime.Year);

            if (toDisplayDateTime.Year != DateTime.Now.Year)
            {
                
                for(int i = 0; i <= toDisplayDateTime.Year - 2023; i++)
                {
                    if (i == 0)
                    {
                        daysInMonth[1] = FebDaysCounter(2023);
                        for (int j = 0; j <= (11 - 8); j++)
                        {
                            daysInMonth[1] = FebDaysCounter(2023);
                            blocksSkipped += daysInMonth[8 + j];
                        }
                    } else if (i == (toDisplayDateTime.Year - 2023)) {
                        daysInMonth[1] = FebDaysCounter(toDisplayDateTime.Year);
                        for (int j = 0; j < ((toDisplayDateTime.Month - 1)); j++)
                        {
                            blocksSkipped += daysInMonth[j];
                        }
                    } else
                    {
                        daysInMonth[1] = FebDaysCounter(2023+i);
                        for (int j = 0; j <= 11; j++)
                        {
                            blocksSkipped += daysInMonth[j];
                        }
                    }
                }

                

                currentMonthStartBlock = ((blocksSkipped + Sep2023_startBlock) % 7);
            }
            else
            {
                for (int i = 0; i < ((toDisplayDateTime.Month - 1) - 8); i++)
                {
                    blocksSkipped += daysInMonth[8 + i];
                }

                currentMonthStartBlock = ((blocksSkipped + Sep2023_startBlock) % 7);
            }

                daysInMonth[1] = FebDaysCounter(toDisplayDateTime.Year);
        }


        pingData();


        for (int i = 0; i < daysInMonth[toDisplayDateTime.Month - 1]; i++)
        {
            {
                /*if (((i + currentMonthStartBlock) - 1) <= 34 && ((i + currentMonthStartBlock) - 1) > 0)
                {

                    {
                        if(GameObject.Find(("Text (TMP) (" + ((i + currentMonthStartBlock) - 1) + ")")) == null)
                        {
                            Debug.Log("null object FOUND : " + ((i + currentMonthStartBlock) - 1) + " | i(daysinMonth) >> " + i);
                        }
                        GameObject.Find(("Text (TMP) (" + ((i + currentMonthStartBlock) - 1) + ")")).GetComponent<TextMeshProUGUI>().SetText((i + 1).ToString());

                    }
                } else
                {

                    if (GameObject.Find(("Text (TMP) (" + (((i + currentMonthStartBlock) - 1) - 35) + ")")) == null)
                    {
                        Debug.Log(monthDispString + " | startBlock >> " + currentMonthStartBlock );
                        if((currentMonthStartBlock - 1) < 0)
                            currentMonthStartBlock += 7;

                    }
                    //                GameObject.Find(("Text (TMP) (" + (((i + currentMonthStartBlock) - 1)- 35) + ")")).GetComponent<TextMeshProUGUI>().SetText((i + 1).ToString());
                }*/
            }

            for(int k = 1; k < statementCount(dataRead); k += 4)
            {
                dataDateRead = JsonUtility.FromJson<JsonDateTime>(extractData(dataRead, k));

                yearTmp = dataDateRead.Year;
                monthTmp = dataDateRead.Month;
                dateTmp = dataDateRead.Day -1;

                if (yearTmp == toDisplayDateTime.Year && monthTmp == toDisplayDateTime.Month && dateTmp == i)
                {
                    isRed = true;
                    //Debug.Log("date : " + dataDateRead.Date + " | " + dateTmp + "/" + monthTmp + "/" + yearTmp);
                    //break;
                }
            }

            if (((i + currentMonthStartBlock) - 1) >= 35)
            {
                currentMonthStartBlock = (1 -i );
            }

            if (((i + currentMonthStartBlock) - 1) < 0)
            {
                currentMonthStartBlock = (7 - i);
            }



            if (GameObject.Find(("Text (TMP) (" + ((i + currentMonthStartBlock) - 1) + ")")) == null)
            {
                //Debug.Log("No room left | obj >> " + ((i + currentMonthStartBlock) - 1));
            }

            GameObject.Find(("Text (TMP) (" + ((i + currentMonthStartBlock) - 1) + ")")).GetComponent<TextMeshProUGUI>().SetText((i + 1).ToString());

            if (isRed == true)
            {
                GameObject.Find(("Text (TMP) (" + ((i + currentMonthStartBlock) - 1) + ")")).GetComponent<TextMeshProUGUI>().color = new Color32(0xD2, 0x10, 0x03, 0xFF); // 3F 23 05
                isRed = false;

                //Debug.Log(" objetc >> " + ((i + currentMonthStartBlock) - 1));
            }

        }

        blocksSkipped = 0;


    }

    int FebDaysCounter(int yearOfCount)
    {
        if(yearOfCount % 4 == 0)
        {
            return (29);
        } else
        {
            return (28);
        }
    }

    public void launchCalendar()
    {
        toDisplayDateTime = DateTime.Now;
        UpdateDate();
    }

    public void incrementCalendar()
    {
        toDisplayDateTime = toDisplayDateTime.AddMonths(1);
        clearCalendar();
        UpdateDate();
    }

    public void decrementCalendar()
    {
        
        if (toDisplayDateTime.Month >= 9 && toDisplayDateTime.Year == 2023)
        {
            toDisplayDateTime = toDisplayDateTime.AddMonths(-1);
        } else if(toDisplayDateTime.Year >= 2023)
        {
            toDisplayDateTime = toDisplayDateTime.AddMonths(-1);
        }

        clearCalendar();
        UpdateDate();

    }

    void clearCalendar()
    {
        for (int i = 0; i <= 34; i++)
        {
            GameObject.Find(("Text (TMP) (" + i + ")")).GetComponent<TextMeshProUGUI>().SetText("");
            GameObject.Find(("Text (TMP) (" + i + ")")).GetComponent<TextMeshProUGUI>().color = new Color32(0x3F, 0x23, 0x05, 0xFF); // 3F 23 05;
        }
    }
}
