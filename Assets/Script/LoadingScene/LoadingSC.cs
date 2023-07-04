using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSC : MonoBehaviour
{

    [SerializeField] private Slider _progressBar;
    [SerializeField] private Text LoadingTxt;

    [SerializeField] private float _target;
    [SerializeField] private float _loadSpeed;
    private int LoadingCountTime = 0;
    private IEnumerator Start()
    {
        _progressBar.value = 0;
        while (_progressBar.value < _target)
        {
            LoadingCountTime++;
            _progressBar.value = Mathf.MoveTowards(_progressBar.value, _target, _loadSpeed * Time.deltaTime);
            yield return null;

            if(LoadingCountTime == 100)
            {
                AnimatedLoadingText();
                LoadingCountTime = 0;
            }
        }
        SceneManager.LoadScene("MainScene");
    }

    private void AnimatedLoadingText()
    {
        if (LoadingTxt.text == "Loading.")
        {
            LoadingTxt.text = "Loading..";
        }
        else if (LoadingTxt.text == "Loading..")
        {
            LoadingTxt.text = "Loading...";
        }
        else if (LoadingTxt.text == "Loading...")
        {
            LoadingTxt.text = "Loading.";
        }
        else
        {
            LoadingTxt.text = "Loading";
        }
    }

}
