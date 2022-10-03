using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LoadParts;
namespace GestureCommands
{
    public class Open : ICommand
    {


        public void execute()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            Debug.Log("La escena en la que estamos es " + currentScene.name);
            if (currentScene.name.Equals("Galery"))
            {
                LoadModels.instance.goToModel();
            }
            else if (currentScene.name.Equals("Start"))
            {
                LoadApplication.instance.goToGalery();
            }
        }
    }
}