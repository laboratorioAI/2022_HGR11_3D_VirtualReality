using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Tools;

namespace LoadParts
{
    public class LoadModel : MonoBehaviour
    {
        public static LoadModel instance { get; private set; } 
        public GameObject instantiatedObject;
        private Model modelSelected = LoadModels.modelToOpen;
        private readonly int degrees = 45;

        void Start()
        {
            instance = this;
            instantiatedObject = Instantiate(modelSelected.model);
            modelSelected.model.transform.position = new Vector3(0, 1, 0);

        }

        public void turnRight()
        {


            float x = modelSelected.model.transform.rotation.x;
            float y = modelSelected.model.transform.rotation.y;
            float z = modelSelected.model.transform.rotation.z;

            modelSelected.model.transform.Rotate(x, y - degrees, z, Space.World);

        }

        public void turnLeft()
        {

            float x = modelSelected.model.transform.rotation.x;
            float y = modelSelected.model.transform.rotation.y;
            float z = modelSelected.model.transform.rotation.z;

            modelSelected.model.transform.Rotate(x, y + degrees, z, Space.World);
        }

        public void turnUp()
        {

            float x = modelSelected.model.transform.rotation.x;
            float y = modelSelected.model.transform.rotation.y;
            float z = modelSelected.model.transform.rotation.z;

            modelSelected.model.transform.Rotate(x + degrees, y, z, Space.World);

        }

        public void turnDown()
        {


            float x = modelSelected.model.transform.rotation.x;
            float y = modelSelected.model.transform.rotation.y;
            float z = modelSelected.model.transform.rotation.z;

            modelSelected.model.transform.Rotate(x - degrees, y, z, Space.World);
        }


        public void goToGalery()
        {
            SceneManager.LoadScene("Scenes/Galery");
        }

    }
}
