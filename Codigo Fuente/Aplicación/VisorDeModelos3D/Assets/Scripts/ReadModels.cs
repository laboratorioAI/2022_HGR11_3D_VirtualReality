using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;


namespace Tools
{
    public class ReadModels:MonoBehaviour
    {
        public static ReadModels instance { get; private set; }
        public ArrayList modelList = new ArrayList { "Bear", "Dinner", "Donny", "ghibli", "gravitygun", "hot", "K9", "knife", "Knight", "Maya", "Scifi", "SodaMachine", "Spider", "Phone", "Ti", "Tiger", "traction", "WagonLow", "Water", "Sponge" };


        void Start()
        {
            instance = this;
        }

        public ArrayList readModelsOnApp()
        {
            ArrayList modelsNames = new ArrayList();

            foreach (string file in modelList)
            {
                modelsNames.Add(file);
            }

            return modelsNames;
        }
        public void deleteModel(string nombre)
        {
            this.modelList.Remove(nombre);
        }
    }
}