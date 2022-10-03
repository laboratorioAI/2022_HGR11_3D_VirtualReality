using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LoadParts;
namespace GestureCommands
{
    public class Fist : ICommand
    {
        //Asociación con Modelo



        public void execute()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name.Equals("Model"))
            {
                LoadModel.instance.goToGalery();
            }
            else if (currentScene.name.Equals("Galery"))
            {
                LoadModels.instance.goToStart();
            }
            else if (currentScene.name.Equals("Instructions"))
            {
                LoadInstructions.instance.goToStart();
            }
            else if (currentScene.name.Equals("Start"))
            {
                LoadApplication.instance.optionsClose();
                Debug.Log("PAsa el gesto");
            }
        }


    }
}