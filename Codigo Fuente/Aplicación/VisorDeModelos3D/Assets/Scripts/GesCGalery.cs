using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;
using System.IO;
using GestureCommands;
using LoadParts;
namespace ListeningCommands
{
    public class GesCGalery : MonoBehaviour
    {

        ICommand command;



        // Use this for initialization\u8232     
        TcpListener listener;
        // the msg is the value that you put in the msg matrix in matlab\u8232     
        String msg;
        // Start is called before the first frame update\u8232
        // 
        bool visible = false;

        void Start()
        {


            // LISTEN TO MATLAB. Set up unity listening to matlab         
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 55001);
            listener.Start();
            Debug.Log("Is listening");
        }


        void Update()
        {
            msg = "";
            bool yesNoOption = false;
            if (!listener.Pending())
            {
                //Espera
            }
            else
            {
                TcpClient client = listener.AcceptTcpClient();
                NetworkStream ns = client.GetStream();
                StreamReader reader = new StreamReader(ns);
                msg = reader.ReadToEnd();
            }

            switch (msg.ToLower())
            {
                case "wavein":
                    {
                        ICommand left = new WaveIn();
                        setCommand(left);
                        waveInGesture();
                        break;
                    }
                case "waveout":
                    {
                        ICommand right = new WaveOut();
                        setCommand(right);
                        waveOutGesture();
                        break;
                    }
                case "open":
                    {
                        ICommand open = new Open();
                        setCommand(open);
                        openGesture();
                        break;
                    }
                case "fist":
                    {
                        ICommand fist = new Fist();
                        setCommand(fist);
                        fistGesture();
                        break;
                    }
                case "pinch":
                    {
                        ICommand pinch = new Pinch();
                        setCommand(pinch);
                        pinchGesture();
                        visible = true;
                        break;
                    }
                case "forward":
                    {
                        ICommand forward = new Forward();
                        setCommand(forward);
                        forwardGesture();
                        yesNoOption = true;
                        break;
                    }
                case "backward":
                    {
                        ICommand backward = new Backward();
                        setCommand(backward);
                        backwardGesture();
                        yesNoOption = true;
                        break;
                    }
                default:
                    {

                        break;
                    }
            }

            if (visible)
            {
                if (yesNoOption)
                {
                    if (LoadModels.instance.answerToDelete)
                    {
                        LoadModels.instance.delete();
                        LoadModels.instance.answerToDelete = false;
                            
                    }
                    else
                    {
                        LoadModels.instance.noDelete();
                        Debug.Log("No se ha eliminado");
                    }
                    visible = false;
                }
            }
        }


        public void setCommand(ICommand command)
        {
            this.command = command;
        }

        public void waveInGesture()
        {
            command.execute();
        }

        public void waveOutGesture()
        {
            command.execute();
        }

        public void openGesture()
        {
            command.execute();
        }

        public void pinchGesture()
        {
            command.execute();
        }

        public void forwardGesture()
        {
            command.execute();
        }

        public void backwardGesture()
        {
            command.execute();
        }
        public void fistGesture()
        {
            command.execute();
        }
    }
}