using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSC : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] Slider progressBar;
    [SerializeField] Image bgShow;
    [SerializeField] List<Sprite> bg = new List<Sprite>();

    [Header("Variables")]
    public float target;
    private float loadSpd;
    private void Awake()
    {
        RandLoadBG();
    }
    private IEnumerator Start()
    {
        loadSpd = 1;
        progressBar.value = 0;
        while (progressBar.value < target)
        {
            progressBar.value = Mathf.MoveTowards(progressBar.value, target, loadSpd * Time.deltaTime);
            yield return null;
        }
        SceneManager.LoadScene("MainScene");
    }

    private void RandLoadBG()
    {
        int rand = Random.Range(0, bg.Count);
        bgShow.GetComponent<Image>().sprite = bg[rand];
    }
}
