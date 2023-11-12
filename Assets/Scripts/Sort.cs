using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort : MonoBehaviour {
	int[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

	// Use this for initialization
	void Start () {
		Debug.Log(BogoSort (data));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	string BogoSort(int[] array){
		int count = 0;
		while (!isSorted (data)) {
			Debug.Log (count);
			count++;
			shuffle (data);
		}
		return "Count: " + count;
	}

	bool isSorted(int[] array){
		for (int x = 0; x < array.Length-1; x++) {
			if (array [x] > array [x + 1]) {
				return false;
			}
		}
		return true;
	}

	void shuffle(int[] array){
		for (int t = 0; t < array.Length; t++ )
		{
			int tmp = array[t];
			int r = Random.Range(t, array.Length);
			array[t] = array[r];
			array[r] = tmp;
		}
	}
}
