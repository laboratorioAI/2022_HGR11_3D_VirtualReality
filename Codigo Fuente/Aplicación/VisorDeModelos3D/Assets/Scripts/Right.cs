using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoadParts;
namespace GestureCommands
{
    public class Right : ICommand
    {

        public void execute()
        {
            LoadModel.instance.turnRight();
        }

    }
}