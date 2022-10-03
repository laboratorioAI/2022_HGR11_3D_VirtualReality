using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoadParts;
namespace GestureCommands
{
    public class Down : ICommand
    {



        public void execute()
        {
            LoadModel.instance.turnDown();
        }

    }
}