using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoadParts;

namespace GestureCommands
{
    public class WaveOut : ICommand
    {
        public void execute()
        {
            LoadModels.instance.moveRight();
        }


    }
}
