using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//singleton
public class ScoreBoardDataControl : MonoBehaviour 
{
	public static ScoreBoardDataControl instance;

	private ScoreData data;

	private const int Places = 3;
	private const string Filename = "/scoreInfo.dat";

	//only one instance allowed in the scene
	void Awake()
	{
		if (instance == null) {
			DontDestroyOnLoad (gameObject);
			LoadData ();
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	void LoadData()
	{
		if (File.Exists (Application.persistentDataPath + Filename)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + Filename, FileMode.Open);
			data = (ScoreData) bf.Deserialize (file);
			file.Close ();
		} else {
			//if file doesn't exist, initiate one, then save
			InitData ();
			SaveData ();
		}


	}

	void InitData()
	{
		data = new ScoreData ();
		data.scores = new int[Places];
		data.playerTypes = new int[Places];

		for (int i = 0; i < Places; i++) {
			data.scores [i] = 0;
			data.playerTypes [i] = -1;
		}
	}

	//save the data to local disk
	void SaveData()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + Filename);
		bf.Serialize (file, data);
		file.Close ();
	}

	//new score occurs (end of game)
	public void NewScore(int playerType, int score)
	{
		//find the placement of the score
		int place = Places - 1;
		while (place >= 0 && score > data.scores [place]) {
			place--;
		}

		place++;

		//not enough to reach the scoreboard
		if (place >= Places)
			return;

		//update the positions of the scores
		for (int i = Places - 2; i >= place; i--) {
			data.scores [i + 1] = data.scores [i];
			data.playerTypes [i + 1] = data.playerTypes [i];
		}

		//insert the new score
		data.scores [place] = score;
		data.playerTypes [place] = playerType;

		//save data to the local disk
		SaveData ();
	}

	public int GetScore(int place)
	{
		return data.scores [place];
	}

	public int GetPlayerType(int place)
	{
		return data.playerTypes [place];
	}
}

[Serializable]
class ScoreData
{
	public int[] scores;
	public int[] playerTypes;
}