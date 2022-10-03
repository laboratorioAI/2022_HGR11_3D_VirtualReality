using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoadParts;
namespace GestureCommands
{
    public class Left : ICommand
    {


        public void execute()
        {
            LoadModel.instance.turnLeft();
        }


    }
}