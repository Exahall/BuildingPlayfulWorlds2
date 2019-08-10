using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Singleton that handles the loading and unloading of the additive scene, ensuring there are no two 'additive' scenes active at any one time.
public class SceneController : MonoBehaviour
{
    // The singleton reference
    protected static SceneController _instance;
    // The getter for the singleton. If the reference has not been set yet, find it first!
    public static SceneController instance
    {
        get
        {
            if (_instance == null) _instance = GameObject.FindObjectOfType<SceneController>();
            return _instance;
        }
    }

    // The first additive scene to load when the game starts
    public string firstAdditiveScene;
    // The currently active additive scene
    private string activeAdditive;

    // Group in UI to fade when swapping scenes
    public CanvasGroup fadeToBlack;

    private string targetScene;
    private float fade;
    public float fadeLerpSpeed;
    public float fadeMoveSpeed;

    private bool doFade;
    private bool isFadingOut;

    public float fadeDelay;
    private float fadeTimer;

    private bool doShake;
    public float screenShakeFrequency;
    public float screenShakeStrength;
    public Transform screenShakeTarget;
    public float screenShakeIncreaseSpeed;
    private float screenShakeProgress;
    private float screenShakeMultiplier;

    // On awaken, load the first additive scene, but only if there aren't additive scenes already.
    private void Awake()
    {
        fadeToBlack.alpha = 1;
        fade = 1;

        if (SceneManager.sceneCount == 1)
        {
            LoadScene(firstAdditiveScene, false, false);
        }
        else
        {
            // If there's already an additive scene, remember it! This way, it will be unloaded if something else is loaded.
            activeAdditive = SceneManager.GetSceneAt(1).name;
        }
    }

    // Load a new additive scene! If there's already an additive scene, then unload that one first.
    public void LoadScene(string scene, bool fade, bool shake)
    {
        targetScene = scene;
        if (fade || shake)
        {
            if (!isFadingOut)
            {
                doFade = fade;
                doShake = shake;
                isFadingOut = true;
                fadeTimer = fadeDelay;
                screenShakeMultiplier = 0;
                screenShakeProgress = 0;
            }
        }
        else
        {
            LoadSceneLogic();
        }
    }

    private void Update()
    {
        if (isFadingOut && doShake)
        {
            if (screenShakeMultiplier < 1)
            {
                screenShakeMultiplier = Mathf.MoveTowards(screenShakeMultiplier, 1, screenShakeIncreaseSpeed * Time.deltaTime);
            }
            screenShakeProgress += Time.deltaTime;

            Vector3 shakePos = screenShakeTarget.localPosition;
            shakePos.x = Mathf.Sin(screenShakeProgress * screenShakeFrequency * screenShakeMultiplier) * screenShakeStrength * screenShakeMultiplier;
            shakePos.y = Mathf.Cos(screenShakeProgress * screenShakeFrequency * screenShakeMultiplier) * screenShakeStrength * screenShakeMultiplier;
            screenShakeTarget.localPosition = shakePos;
        }

        if (fadeTimer > 0)
        {
            fadeTimer -= Time.deltaTime;
            if (!doFade)
            {
                LoadSceneLogic();
            }
        }
        else
        {
            float target = isFadingOut ? 1 : 0;
            if (fade != target)
            {
                fade = Mathf.Lerp(fade, target, Time.deltaTime * fadeLerpSpeed);
                fade = Mathf.MoveTowards(fade, target, Time.deltaTime * fadeMoveSpeed);
                fadeToBlack.alpha = fade;
                if (fade == target && isFadingOut)
                {
                    LoadSceneLogic();
                }
            }
        }
    }

    private void LoadSceneLogic()
    {
        if (activeAdditive != null && activeAdditive != "")
            SceneManager.UnloadSceneAsync(activeAdditive);
        activeAdditive = targetScene;
        SceneManager.LoadScene(targetScene, LoadSceneMode.Additive);
        isFadingOut = false;
        screenShakeTarget.localPosition = Vector3.zero;
    }
}