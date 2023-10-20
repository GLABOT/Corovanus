using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Intro : MonoBehaviour
{
    [SerializeField] private List<Image> images;

    [SerializeField] private float timeBetweenImages = 5f;
    [SerializeField] private float fadingTime = 5f;

    private int _currentImage = 0;
    bool fading;
 
    private void Start()
    {
        StartCoroutine(NextImage());
    }

    private IEnumerator NextImage()
    {
        yield return new WaitForSeconds(timeBetweenImages);
        fading = true;
        yield return new WaitForSeconds(fadingTime);
        fading = false;
        _currentImage++;

        if (images.Count > _currentImage)
        StartCoroutine(NextImage());

        if (images.Count - 1 == _currentImage)
            StartCoroutine(ToMenu());
    }

    private IEnumerator ToMenu()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        if (fading)
        StartCoroutine(c_Alpha(0.0f, fadingTime));
    }

    IEnumerator c_Alpha(float value, float time)
    {
        float k = 0.0f;
        Color c0 = images[_currentImage].color;
        Color c1 = c0;
        c1.a = value;

        while ((k += Time.deltaTime) <= time)
        {
            images[_currentImage].color = Color.Lerp(c0, c1, k / time);
            yield return null;
        }
        images[_currentImage].color = c1;
        fading = false;
    }

}
