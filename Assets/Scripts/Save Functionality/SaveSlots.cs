using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSlots : MonoBehaviour
{
    public UniveralSaveCode saveCode = UniveralSaveCode.MyInstance;

	private static SaveSlots instance;
	public static SaveSlots MyInstance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<SaveSlots>();
			}
			return instance;
		}
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
	}
    public void Saveslot1()
    {
		while (saveCode.saveSlot1)
		{
			saveCode.seconds1 = (int)saveCode.seconds1F;
			PlayerPrefs.SetInt("seconds1", saveCode.seconds1);
			saveCode.seconds1F += Time.deltaTime * (saveCode.minutes1 + 1);
			if (saveCode.seconds1F >= 60)
			{
				saveCode.minutes1++;
				saveCode.seconds1F -= 60;
				PlayerPrefs.SetInt("minutes1", saveCode.minutes1);
				if (saveCode.minutes1 >= 60)
				{
					saveCode.hours1++;
					saveCode.minutes1 -= 60;
					PlayerPrefs.SetInt("hours1", saveCode.hours1);
				}
			}
			if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
			{
				saveCode.Time1 = saveCode.hours1 + ":" + saveCode.minutes1 + ":" + saveCode.seconds1;
				saveCode.TimeText1.text = saveCode.Time1;
			}
			PlayerPrefs.Save();
		}
	}
	public void Saveslot2()
	{
		while (saveCode.saveSlot2)
		{
			saveCode.seconds2 = (int)saveCode.seconds2F;
			PlayerPrefs.SetInt("seconds2", saveCode.seconds1);
			saveCode.seconds2F += Time.deltaTime * (saveCode.minutes2 + 1);
			if (saveCode.seconds2F >= 60)
			{
				saveCode.minutes2++;
				saveCode.seconds2F -= 60;
				PlayerPrefs.SetInt("minutes2", saveCode.minutes2);
				if (saveCode.minutes2 >= 60)
				{
					saveCode.hours2++;
					saveCode.minutes2 -= 60;
					PlayerPrefs.SetInt("hours2", saveCode.hours2);
				}
			}
			if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
			{
				saveCode.Time1 = saveCode.hours2 + ":" + saveCode.minutes2 + ":" + saveCode.seconds2;
				saveCode.TimeText2.text = saveCode.Time2;
			}
			PlayerPrefs.Save();
		}
	}
}
