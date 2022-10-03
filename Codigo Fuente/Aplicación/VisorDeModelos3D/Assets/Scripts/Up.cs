using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoadParts;
namespace GestureCommands
{
    public class Up : ICommand
    {

        public void execute()
        {
            LoadModel.instance.turnUp();
        }

    }
}