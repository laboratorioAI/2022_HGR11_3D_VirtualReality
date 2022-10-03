using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

namespace Integration
{
    public class PreguntaDispositivo : MonoBehaviour
    {
        public static PreguntaDispositivo Instance { get; private set; }

        private Button myoBtn;
        private Button gForceBtn;

        private void Start()
        {
            Instance = this;
            myoBtn = transform.Find("Myo").GetComponent<Button>();
            gForceBtn = transform.Find("Gforce").GetComponent<Button>();

            ShowQuestion(() =>
            {
                Debug.Log("Myo Arm Band");
            }, () =>
            {

                Debug.Log("GForce");
            });
        }

        public void ShowQuestion(Action myoAction, Action gForceAction)
        {
            gameObject.SetActive(true);
            myoBtn.onClick.AddListener(() =>
            {
                myoAction();
                abrirApp();
            });
            gForceBtn.onClick.AddListener(() =>
            {
                gForceAction();
                abrirApp();
            });
        }

        public void abrirApp()
        {
            SceneManager.LoadScene("Scenes/Start");
        }

    }
}