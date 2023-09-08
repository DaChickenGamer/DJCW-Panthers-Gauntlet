using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public SaveSlots SaveSlots = SaveSlots.MyInstance;
	public TMP_InputField Name1;
    public TMP_Text TimeText1;
    public string Time1;
    public int hours1;
    public int minutes1;
    public int seconds1;
    public float seconds1F;
    public bool saveSlot1;
	public TMP_InputField Name2;
	public TMP_Text TimeText2;
	public string Time2;
	public int hours2;
	public int minutes2;
	public int seconds2;
	public float seconds2F;
	public bool saveSlot2;
	// Start is called before the first frame update
	private void Awake() 
    {
        if (saveSlot1)
        {
            SaveSlots.Saveslot1();
        }
		if (saveSlot2)
		{
			SaveSlots.Saveslot2();
		}
	}
	void Start()
    {
        Name1.text = PlayerPrefs.GetString("SaveSlot1Name");
        seconds1F = PlayerPrefs.GetInt("seconds1");
        minutes1 = PlayerPrefs.GetInt("minutes1");
        hours1 = PlayerPrefs.GetInt("hours1");
		Name2.text = PlayerPrefs.GetString("SaveSlot2Name");
		seconds2F = PlayerPrefs.GetInt("seconds2");
		minutes2 = PlayerPrefs.GetInt("minutes2");
		hours2 = PlayerPrefs.GetInt("hours2");
	}

    // Update is called once per frame
    void Update()
    {

    }
    public void SaveSlot1Name()
    {
        PlayerPrefs.SetString("SaveSlot1Name", Name1.text);
        PlayerPrefs.Save();
    }
    public void SaveSlot1()
    {
        saveSlot1 = true;
        SaveSlots.Saveslot1();
    }
	public void SaveSlot2Name()
	{
		PlayerPrefs.SetString("SaveSlot2Name", Name2.text);
		PlayerPrefs.Save();
	}
	public void SaveSlot2()
	{
		saveSlot1 = true;
		SaveSlots.Saveslot2();
	}
}
