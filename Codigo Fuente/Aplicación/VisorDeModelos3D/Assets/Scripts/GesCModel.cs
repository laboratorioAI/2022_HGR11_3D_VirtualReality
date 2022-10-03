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
    public class GesCModel : MonoBehaviour
    {
        ICommand command;
        TcpListener listener;
        String msg;

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


            Destroy(LoadModel.instance.instantiatedObject);
            LoadModel.instance.instantiatedObject = Instantiate(LoadModels.modelToOpen.model);

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
                case "left":
                    {
                        ICommand left = new Left();
                        setCommand(left);
                        leftGesture();
                        break;
                    }
                case "right":
                    {
                        ICommand right = new Right();
                        setCommand(right);
                        rightGesture();
                        break;
                    }
                case "down":
                    {
                        ICommand down = new Down();
                        setCommand(down);
                        downGesture();
                        break;
                    }
                case "up":
                    {
                        ICommand up = new Up();
                        setCommand(up);
                        upGesture();
                        break;
                    }
                case "fist":
                    {
                        ICommand close = new Fist();
                        setCommand(close);
                        fistGesture();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }


        public void setCommand(ICommand command)
        {
            this.command = command;
        }

        public void fistGesture()
        {
            command.execute();
        }

        public void upGesture()
        {
            command.execute();
        }

        public void downGesture()
        {
            command.execute();
        }

        public void leftGesture()
        {
            command.execute();
        }

        public void rightGesture()
        {
            command.execute();
        }

    }
}