using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startscenechange : MonoBehaviour

{
    public Animator foxanimator;
    bool startPressed = false;
    public string ScenetoLoad;
    public Animator transition;
    public GameObject transitioner;

    public float animationTime = 4f;
    public float transitionTime = 1f;

    // Start is called before the first frame update
    void Start()
    {

        foxanimator = gameObject.GetComponent<Animator>();


    }

    // Update is called once per frame

    public void buttonclicked()
    {
        foxanimator.SetBool("Start", true);
        StartCoroutine(Wait());
    }
    void Update()
    {

    }

    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator Wait()

    {

        yield return new WaitForSeconds(animationTime);
        transitioner.SetActive(true);
        
        yield return new WaitForSeconds(transitionTime);
        transition.SetTrigger("Start");
        SceneManager.LoadScene(ScenetoLoad);

    }

}
