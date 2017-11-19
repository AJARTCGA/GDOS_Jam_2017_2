using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score {

	static Score instance;
	int score = 0;
	Score()
	{

	}

	public static Score getInstance()
	{
		if (instance == null)
		{
			instance = new Score();
		}
		return instance;
	}

	public void add(int addedScore)
	{
		score += addedScore;
	}

	public void resetScore()
	{
		score = 0;
	}

	public int getScore()
	{
		return score;
	}




}
