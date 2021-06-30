using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] CanvasGroup loadingOverlay;
    [Range(0.01f, 3.0f)]
    [SerializeField] float fadeTime = 0.5f;

    public static SceneLoader Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        } // codigo fara com que exista somente um objeto com o scene loader como componente
    }

    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(PerformLoadSceneAsync(sceneName));
    }

    private IEnumerator PerformLoadSceneAsync(string sceneName)
    {
        yield return StartCoroutine(FadeIn());

        // LoadSceneAsync retorna uma operação assincrona, dizendo se esta pronta ou não
        var operation = SceneManager.LoadSceneAsync(sceneName);
        while (operation.isDone == false)
        {
            yield return null;
        }
        // enquanto a operação de carregar a cena estiver executando, a corrotina devolve o comando para a Unity
        yield return StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
        float start = 0;
        float end = 1;
        float speed = (end - start) / fadeTime;
        loadingOverlay.alpha = start;
        while (loadingOverlay.alpha < end)
        {
            loadingOverlay.alpha += speed * Time.deltaTime;
            yield return null;
        }

        loadingOverlay.alpha = end;
    }

    private IEnumerator FadeOut()
    {
        float start = 1;
        float end = 0;
        float speed = (end - start) / fadeTime;
        loadingOverlay.alpha = start;
        while (loadingOverlay.alpha > end)
        {
            loadingOverlay.alpha += speed * Time.deltaTime;
            yield return null;
        }

        loadingOverlay.alpha = end;
    }
}
