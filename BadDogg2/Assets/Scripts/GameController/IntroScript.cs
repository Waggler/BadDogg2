using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class IntroScript: MonoBehaviour
{
	public Text introText;
	public Text introTextTwo;
	public Text introTextThree;
	public Text ruleText;
	public AudioSource musicSource;
	void Start()
	{
		musicSource.gameObject.SetActive(false);
		//StartCoroutine(WaitAndLoadFirstScene());
	}

	IEnumerator WaitAndLoadFirstScene()
	{
		
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(1);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			musicSource.gameObject.SetActive(true);
			introText.gameObject.SetActive(false);
			introTextTwo.gameObject.SetActive(false);
			introTextThree.gameObject.SetActive(false);
			ruleText.text= "Use WASD to Move. Eat the Bones and Survive!";
			StartCoroutine(WaitAndLoadFirstScene());
		}
	}
}