using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LoadParts;

namespace GestureCommands
{
    public class Pinch : ICommand
    {


        public void execute()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name.Equals("Galery"))
            {
                LoadModels.instance.optionsDelete();
            }
            else if (currentScene.name.Equals("Start"))
            {
                LoadApplication.instance.goToIntructions();
            }

        }


    }
}