using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LoadParts
{
    public class LoadInstructions : MonoBehaviour
    {
        public static LoadInstructions instance { get; private set; }
        void Start()
        {
            instance = this;
        }

        // Update is called once per frame
        public void goToStart()
        {
            SceneManager.LoadScene("Scenes/Start");
        }
    }
}