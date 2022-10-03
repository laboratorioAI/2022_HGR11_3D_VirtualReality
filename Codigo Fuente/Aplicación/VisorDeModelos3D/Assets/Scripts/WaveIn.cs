using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoadParts;
namespace GestureCommands
{
    public class WaveIn : ICommand
    {
        public void execute()
        {
            LoadModels.instance.moveLeft();
        }
    }
}