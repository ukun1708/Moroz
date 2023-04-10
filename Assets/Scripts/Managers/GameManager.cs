using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public void StartGame()
    {

    }
    public void Loss()
    {
        RestartLevel();
    }
    public void EndLevel()
    {

    }
    public void RestartLevel()
    {
        StartCoroutine(Restart(0f));
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator Restart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        //DataManager.instance.SaveData();
        //AppMetrica.Instance.ReportEvent("level_finish");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
