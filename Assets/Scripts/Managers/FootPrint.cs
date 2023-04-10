using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrint : MonoBehaviour
{
    #region Singleton
    public static FootPrint instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject footLeft;
    public GameObject footRight;
    public GameObject footPrintLeft;
    public GameObject footPrintRight;

    public void FootPrintLeft()
    {
        CreatFootPrint(footLeft, footPrintLeft, 360f);
        SoundManager.instance.PlaySound(SoundManager.AudioType.step, 0.8f, Random.Range(0.95f, 1.1f), false);
    }
    public void FootPrintRight()
    {
        CreatFootPrint(footRight, footPrintRight, 390f);
        SoundManager.instance.PlaySound(SoundManager.AudioType.step, 0.8f, Random.Range(0.95f, 1.1f), false);
    }
    void CreatFootPrint(GameObject foot, GameObject footPrint, float offset)
    {
        Vector3 footPrintPos = new Vector3(foot.transform.position.x, GameController.instance.player.transform.position.y, foot.transform.position.z);
        GameObject currentPrint = Instantiate(footPrint, footPrintPos, Quaternion.identity);
        Vector3 temp = foot.transform.rotation.eulerAngles;
        currentPrint.transform.rotation = Quaternion.Euler(new Vector3(90f, temp.y, temp.z - offset));
    }
}
