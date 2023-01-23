using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamestart : MonoBehaviour
{
	public void onclick(){
		SceneManager.LoadScene("Battle01");
	}
}
