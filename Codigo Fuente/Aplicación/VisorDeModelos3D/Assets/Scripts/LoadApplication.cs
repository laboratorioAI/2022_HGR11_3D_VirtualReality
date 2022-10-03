using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace LoadParts
{
    public class LoadApplication : MonoBehaviour
    {
        public static LoadApplication instance { get; private set; }

        public bool answerToClose = false;
        public GameObject options;


        void Start()
        {
            instance = this;
        }


        public void goToGalery()
        {
            SceneManager.LoadSceneAsync("Scenes/Galery");
        }

        public void closeApp()
        {
            Application.Quit();
        }

        public void noClose()
        {
            options.transform.position = new Vector3(-1000f, -1000f, -100f);
        }

        public void goToIntructions()
        {
            SceneManager.LoadScene("Scenes/Instructions");
        }

        public void optionsClose()
        {
            options.transform.position = new Vector3(0,1,0);
            options.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        }

        public void accept()
        {
            this.answerToClose=true;
        }

        public void cancel()
        {
            this.answerToClose = false;
        }
    }
}