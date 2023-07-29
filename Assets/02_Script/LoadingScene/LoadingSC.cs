using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSC : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] Slider progressBar;

    [Header("Variables")]
    public float target;
    private float loadSpd;
    private int LoadingCountTime = 0;
    private IEnumerator Start()
    {
        loadSpd = 1;
        progressBar.value = 0;
        while (progressBar.value < target)
        {
            LoadingCountTime++;
            progressBar.value = Mathf.MoveTowards(progressBar.value, target, loadSpd * Time.deltaTime);
            yield return null;
        }
        SceneManager.LoadScene("MainScene");
    }
}
