using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System;

using System.IO;
using System.Text;

namespace Tools
{
    public class Visualizer
    {


        public void positionOfModels(List<Model> models)
        {


            //x cambia
            //y cambia
            //z no cambia
            int x = 0;
            int y = 0;
            int z = 0;
            int numeroDeModelo = 0;
            float espacio = 6f;


            while (numeroDeModelo < models.Count)
            {
                if (x == 4)
                {
                    models[numeroDeModelo].model.transform.position = new Vector3(x + espacio, y, z);
                    x = 0;
                    espacio = 6f;
                    y++;
                    numeroDeModelo++;
                }
                else
                {
                    models[numeroDeModelo].model.transform.position = new Vector3(x + espacio, y, z);
                    x++;
                    numeroDeModelo++;
                    espacio++;
                }

            }


        }


        //El metodo se realizó de una forma no automatica, debido a que cada modelo variaba en su fijarEscalaModelos, unidades, y medidas 
        //en el espacio, por lo que se hizo un trabajo manual para el control de las escalas y que todos
        //los modelos tengan un tamaño mas o menos igual
        public void setScaleModels(GameObject modelo)
        {


            if (modelo.name.Equals("Bear"))
            {
                modelo.transform.localScale = new Vector3(5, 5, 5);
            }

            else if (modelo.name.Equals("Dinner"))
            {
                modelo.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }
            else if (modelo.name.Equals("Donny"))
            {
                modelo.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else if (modelo.name.Equals("ghibli"))
            {
                modelo.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            }
            else if (modelo.name.Equals("gravitygun"))
            {
                modelo.transform.localScale = new Vector3(5f, 5f, 5f);
            }
            else if (modelo.name.Equals("hot"))
            {
                modelo.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }
            else if (modelo.name.Equals("K9"))
            {
                modelo.transform.localScale = new Vector3(60f, 60f, 60f);
            }
            else if (modelo.name.Equals("knife"))
            {
                modelo.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            else if (modelo.name.Equals("Knight"))
            {
                modelo.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }
            else if (modelo.name.Equals("Maya"))
            {
                modelo.transform.localScale = new Vector3(40f, 40f, 40f);
            }
            else if (modelo.name.Equals("Scifi"))
            {
                modelo.transform.localScale = new Vector3(60f, 60f, 60f);
            }
            else if (modelo.name.Equals("SodaMachine"))
            {
                modelo.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }
            else if (modelo.name.Equals("Spider"))
            {
                modelo.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            }
            else if (modelo.name.Equals("Phone"))
            {
                modelo.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }
            else if (modelo.name.Equals("Ti"))
            {
                modelo.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }
            else if (modelo.name.Equals("Tiger"))
            {
                modelo.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }
            else if (modelo.name.Equals("traction"))
            {
                modelo.transform.localScale = new Vector3(4f, 4f, 4f);
            }
            else if (modelo.name.Equals("WagonLow"))
            {
                modelo.transform.localScale = new Vector3(8f, 8f, 8f);
            }
            else if (modelo.name.Equals("Water"))
            {
                modelo.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            }
            else if (modelo.name.Equals("Sponge"))
            {
                modelo.transform.localScale = new Vector3(15f, 15f, 15f);
            }
        }

    }
}