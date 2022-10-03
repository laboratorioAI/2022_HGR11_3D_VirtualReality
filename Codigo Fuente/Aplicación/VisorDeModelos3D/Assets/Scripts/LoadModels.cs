using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

using Tools;

namespace LoadParts
{
    public class LoadModels : MonoBehaviour
    {
        public static LoadModels instance { get; private set; }
        public List<Model> models = new List<Model>();
        public static Model modelToOpen;
        public bool answerToDelete = false;
        public GameObject options;

        //private readonly ReadModels readModelsName = new ReadModels();
        private readonly Visualizer visualizer = new Visualizer();
        private GameObject instantiatedObject;
        private static Model cursorObject;
        private int modelNumber = 0; //Metodo cargar objeto tomo el número de modelos
         
        



        void Start()
        {
            instance = this;
            showModels();
            StartCoroutine(cUpdate());
            
        }


        IEnumerator cUpdate()
        {
            while (true)
            {
                cursor(modelNumber);
                Destroy(LoadModels.instance.instantiatedObject);
                LoadModels.instance.instantiatedObject = Instantiate(cursorObject.model);
                yield return new WaitForSeconds(0.3f);
            }
        }


        public void showModels()
        {
            ArrayList nombres = ReadModels.instance.modelList;
            loadModelObjects(nombres);
            foreach (Model modelo in models)
            {
                Instantiate(modelo.model);
            }

        }

        public void loadModelObjects(ArrayList nombres)
        {
           

            foreach (string nombre in nombres)
            {
                this.models.Add(loadModelsFromResources(nombre));
            }
            this.visualizer.positionOfModels(this.models);
        }



        public Model loadModelsFromResources(string modelo)
        {

            string pathModel = "Models/" + modelo;

            GameObject loadedObj = Resources.Load(pathModel) as GameObject;


            this.visualizer.setScaleModels(loadedObj);

            Model model = new Model(loadedObj);


            return model;


        }

        public void moveRight()
        {
            if ((modelNumber >= 0) && (modelNumber <= models.Count))
            {
                if (modelNumber + 1 != models.Count)
                {
                    modelNumber = modelNumber + 1;
                   
                }
            }
            else
            {
                Debug.Log("No se puede mover mas allá");
            }

        }
        public void moveLeft()
        {
            if ((modelNumber >= 0) && (modelNumber < models.Count))
            {
                if (modelNumber != 0)
                {
                    modelNumber = modelNumber - 1;
                   
                }
            }
            else
            {
                Debug.Log("No se puede mover mas allá");
            }


        }

        public void goToModel()
        {
            SceneManager.LoadScene("Scenes/Model");
            modelToOpen = models[modelNumber];
        }

        public void goToStart()
        {
            SceneManager.LoadScene("Scenes/Start");
        }


        public void optionsDelete()
        {
            options.transform.position = new Vector3(10, 2, -1);
            options.transform.localScale = new Vector3(0.3f, 0.3f, 0.2f);

        }

        public void delete()
        {
            ReadModels.instance.deleteModel(this.models[modelNumber].model.name);
            this.models.Remove(this.models[modelNumber]);       
            options.transform.position = new Vector3(0, -1000, 0);
            resetScene();
        }

        public void resetScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void noDelete()
        {
            options.transform.position = new Vector3(0, -1000, 0);
        }
        public void accept()
        {
            this.answerToDelete = true;
        }

        public void cancel()
        {
            this.answerToDelete = false;
        }


        public void cursor(int modeloUbicado)
        {

            string pathModel = "T-M-Models/cursor/cursor";

            GameObject loadedObj = Resources.Load(pathModel) as GameObject;

            loadedObj.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            Model model = new Model(loadedObj);

            float posicionX = models[modeloUbicado].model.transform.position.x;
            float posicionY = models[modeloUbicado].model.transform.position.y;
            float posicionZ = models[modeloUbicado].model.transform.position.z;
            model.model.transform.position = new Vector3(posicionX + 0.10f, posicionY - 0.5f, posicionZ - 0.25f);
            model.model.transform.Rotate(0, -180, 0, Space.World);

            cursorObject = model;

        }


    }
}