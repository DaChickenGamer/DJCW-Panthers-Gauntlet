using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class UniveralSaveCode : MonoBehaviour
{
	private static UniveralSaveCode instance;
	public static UniveralSaveCode MyInstance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<UniveralSaveCode>();
			}
			return instance;
		}
	}
	//public SaveSlots SaveSlots = SaveSlots.MyInstance;
	public Asset saveSlot1;
	private string filepath;
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
			currentSaveSlot = PlayerPrefs.GetInt("currentSaveSlot");
		else
			currentSaveSlot = saveSlot;
		filepath += "/Scripts/Save Functionality/LocalSaveData" + saveSlot + ".json";
		//StreamWriter jsonFile = new StreamWriter(filepath);
		//Debug.Log(jsonFile);
		Debug.Log(filepath);
		//File.WriteAllText("LocalSaveData1.json", "{\r\n\t\"LocalSaveData\": [\r\n\t\t{\r\n\t\t\t\"kicks\": " + localKicks + ",\r\n\t\t\t\"punches\": " + localPunches + ",\r\n\t\t\t\"wins\": " + currentWins + ",\r\n\t\t\t\"loses\": " + currentLoses + ",\r\n\t\t\t\"time\": " + currentSeconds + ",\r\n\t\t\t\"name\": \"" + currentName.text + "\"\r\n\t\t}\r\n\t]\r\n}");
		//localStatBoard.text ="Current Name:"+currentName.text+"\n"+"Current Time:"+currentSeconds+"\n"+"Current Loses:"+currentLoses+"\n"+"Current Wins:"+currentWins;
		System.IO.File.WriteAllText(filepath, "{\r\n\t\"LocalSaveData\": [\r\n\t\t{\r\n\t\t\t\"kicks\": " + localKicks + ",\r\n\t\t\t\"punches\": " + localPunches + ",\r\n\t\t\t\"wins\": " + currentWins + ",\r\n\t\t\t\"loses\": " + currentLoses + ",\r\n\t\t\t\"time\": " + currentSeconds + ",\r\n\t\t\t\"name\": \"" + currentName.text + "\"\r\n\t\t}\r\n\t]\r\n}");
	}
	public void Load()
	{
		currentName.text = PlayerPrefs.GetString("Name" + currentSaveSlot);
		currentSeconds = PlayerPrefs.GetInt("Seconds" + currentSaveSlot);
		currentLoses = PlayerPrefs.GetInt("Loses" + currentSaveSlot);
		currentWins = PlayerPrefs.GetInt("Wins" + currentSaveSlot);
	}
}
