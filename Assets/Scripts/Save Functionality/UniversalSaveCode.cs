using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
public class UniveralSaveCode : MonoBehaviour
{
	public Asset saveSlot1;
	private string filepath;
	private string globalSaveData = Application.dataPath + "/Scripts/Save Functionality/GlobalSaveData.json";
	private string[] fileRead;
	private string[] dataTypes = {"kicks", "punches", "wins", "loses", "time", "name"};
	private int dataLevel;
	private string currentdataType;
	private string prevLine;
	public TMP_InputField currentName;
	public TMP_Text TimeText1;
	public string currentTime;
	public int currentHours;
	public int currentMinutes;
	public int currentSeconds;
	public float currentSecondsF;
	public int currentSaveSlot;
	public int currentLoses;
	public int currentWins;
	public int localPunches;
	public int localKicks;
	public int globalKicks;
	public int globalPunches;
	public TMP_Text localStatBoard;
	public TMP_Text GlobalStatBoard;
	
	public void Save(int saveSlot = 0)
	{
		filepath = Application.dataPath;
		if (saveSlot == 0)
		{
			currentSaveSlot = PlayerPrefs.GetInt("currentSaveSlot");
			saveSlot = currentSaveSlot;
		}
		else
			currentSaveSlot = saveSlot;
		PlayerPrefs.SetInt("currentSaveSlot", saveSlot);
		filepath += "/Scripts/Save Functionality/LocalSaveData" + saveSlot + ".json";
		Debug.Log(filepath);
		System.IO.File.WriteAllText(filepath, "{\r\n\t\"LocalSaveData\": [\r\n\t\t{\r\n\t\t\t\"kicks\": \n\t\t\t\t" + localKicks + "\n\t\t\t\t,\r\n\t\t\t\"punches\": \n\t\t\t\t" + localPunches + "\n\t\t\t\t,\r\n\t\t\t\"wins\": \n\t\t\t\t" + currentWins + "\n\t\t\t\t,\r\n\t\t\t\"loses\": \n\t\t\t\t" + currentLoses + "\n\t\t\t\t,\r\n\t\t\t\"time\": \n\t\t\t\t" + ((currentHours*3600)+(currentMinutes*60)+currentSeconds) + "\n\t\t\t\t,\r\n\t\t\t\"name\": \n\"" + currentName.text + "\"\r\n\t\t}\r\n\t]\r\n}");
	}
	public void Load(int saveSlot)
	{
		currentSaveSlot=saveSlot;
		PlayerPrefs.SetInt("currentSaveSlot", saveSlot);
		filepath = Application.dataPath;
		filepath += "/Scripts/Save Functionality/LocalSaveData" + currentSaveSlot + ".json";
		fileRead =System.IO.File.ReadAllLines(filepath);
		foreach(string line in fileRead)
		{
			if (currentdataType == null)
			{

			}
			else if (prevLine.Contains(currentdataType))
			{
				switch (currentdataType)
				{
					case "kick":
						localKicks = strToInt(line);
						break;
					case "punches":
						localPunches = strToInt(line);
						break;
					case "wins":
						currentWins = strToInt(line);
						break;
					case "loses":
						currentLoses = strToInt(line);
						break;
					case "time":
						currentSeconds = strToInt(line);
						break;
					case "name":
						currentName.text = line.Replace("\"", "");
						break;
				}
			}
			foreach (char c in line)
			{
				if (c == '\"')
				{
					dataLevel = -1;
					foreach(string str in dataTypes)
					{
						dataLevel++;
						if (line.Contains(str))
						{
							currentdataType = str;
							break;
						}
					}
				}
			}
			prevLine = line;
		}
		localStatBoard.text =	"Save File:"+currentSaveSlot+"\n"+
								"Kicks:"+localKicks+"\n"+
								"Punches:"+localPunches+"\n"+
								"Wins:"+currentWins+"\n"+
								"Loses:"+currentLoses+"\n"+
								"Time Played:"+currentSeconds;
	}
	public void ResetSaveFile(int saveSlot)
	{
		System.IO.File.WriteAllText(filepath, "{\r\n\t\"LocalSaveData\": [\r\n\t\t{\r\n\t\t\t\"kicks\": \n\t\t\t\t" + 0 + "\n\t\t\t\t,\r\n\t\t\t\"punches\": \n\t\t\t\t" + 0 + "\n\t\t\t\t,\r\n\t\t\t\"wins\": \n\t\t\t\t" + 0 + "\n\t\t\t\t,\r\n\t\t\t\"loses\": \n\t\t\t\t" + 0 + "\n\t\t\t\t,\r\n\t\t\t\"time\": \n\t\t\t\t" + 0 + "\n\t\t\t\t,\r\n\t\t\t\"name\": \n\"" + "\"\"" + "\"\r\n\t\t}\r\n\t]\r\n}");
	}
	public int strToInt(string str)
	{
		int i;
		try
		{
			i = int.Parse(str);
		}
		catch (Exception e)
		{
			Debug.LogException(e);
			return 0;
		}
		return i;
	}
}
