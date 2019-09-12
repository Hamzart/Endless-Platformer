using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor.UI;

public class PlatformGenerator : MonoBehaviour {
	[System.Serializable]
	public class Block 
	{
		public string worldName;
		public string blockType;
		public int blockDifficulty;
		public List<GameObject> blocksList;

	}
		
	[Header ("Current Level Stats")]
	public string currentWorld="Forest";
	public string currentBlockType ="A";
	public string NexttBlockType ="A";
	public int difficulty=1;

	public int level=0;
	public int distanceTraveled;
	GameObject player;
	Vector3 initialPos;

	public List<GameObject> CurrentList;

	[Header ("Block Types Relations")]
		public bool aToB;
		public bool bToA;
		public bool C;
	public List<string> allBlockTypes;

	[Header ("Endless Runner Blocks")]

	public GameObject transitionWorld1;

	public List<Block> worlds;


	public void CreateNewBlock (Vector3 blockposition)
	{
		level++;
		Shuffle ();
		currentBlockType = NexttBlockType;
		FilterBlocks ();
		Instantiate (CurrentList [Random.Range (0, CurrentList.Count)], blockposition, Quaternion.identity);

	}

	public void Shuffle()
	{ 

		int random;

		if (currentBlockType == "A" | currentBlockType == "B") {
			if (allBlockTypes.Count > 0)
				allBlockTypes.Clear ();
		

			if (aToB) {
				allBlockTypes.Add ("B");
			}
			if (bToA) {
				allBlockTypes.Add ("A");
			}
			if (C) {
				allBlockTypes.Add ("C");
			}
			random = Random.Range (0, allBlockTypes.Count);

			if (allBlockTypes.Count > 0) {
				NexttBlockType = allBlockTypes.ElementAt (random);
				print ("Next Block Type is : " + NexttBlockType);
			}
		}

		else
		{
			random = Random.Range (0, 1);
			if(random ==0) {
				NexttBlockType = "A";
			}

			else if(random ==1)  {

				NexttBlockType = "B";

			}

		}


	}

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		initialPos = player.transform.position;
	}
	void FixedUpdate()
	{
		distanceTraveled = Mathf.RoundToInt (player.transform.position.x - initialPos.x) ;

	
	}

	public void FilterBlocks()
	{
		var levelslookfor =
			from result in worlds
				where result.worldName == currentWorld & result.blockType == currentBlockType & result.blockDifficulty == difficulty
			select result.blocksList;

		// TESTING PURPOSE
		//print (levelslookfor.First().First().name); 

		CurrentList = levelslookfor.First ();

		// CONDITION TO ADD NEW BLOCK
		if(level > 5 & currentWorld == "Forest")
		{
			if (!CurrentList.Contains(transitionWorld1))
			CurrentList.Add(transitionWorld1);
		}

	}

}



