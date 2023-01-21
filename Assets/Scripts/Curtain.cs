using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Curtain : MonoBehaviour {

    [SerializeField] private CanvasGroup curtain;
    [SerializeField] private Image loadingBar;

    private void Awake() {
        DontDestroyOnLoad(this);
    }

    public void Show() {
        gameObject.SetActive(true);
        loadingBar.fillAmount = 0f;
        curtain.alpha = 1;
    }

    public void UpdateLoadingBar(float value) {
        loadingBar.fillAmount = value;
    }

    public void Hide() => StartCoroutine(DoFadeIn());

    private IEnumerator DoFadeIn() {
        while (curtain.alpha > 0) {
            curtain.alpha -= 0.03f;
            yield return new WaitForSeconds(0.01f);
        }

        gameObject.SetActive(false);
    }

}