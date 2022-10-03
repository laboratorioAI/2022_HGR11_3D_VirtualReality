using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoadParts;
using UnityEngine.SceneManagement;

namespace GestureCommands
{
    public class Backward : ICommand
    {
        public void execute()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name.Equals("Galery"))
            {
                LoadModels.instance.cancel();
            }
            else if (currentScene.name.Equals("Start"))
            {
                LoadApplication.instance.cancel();
            }

        }

    }
}
