using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoadParts;
using UnityEngine.SceneManagement;
namespace GestureCommands
{
    public class Forward : ICommand
    {


        public void execute()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name.Equals("Galery"))
            {
                LoadModels.instance.accept();
            }
            else if (currentScene.name.Equals("Start"))
            {
                LoadApplication.instance.accept();
            }

        }

    }
}