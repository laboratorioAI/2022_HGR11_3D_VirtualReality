using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;
using System.IO;
using LoadParts;
using GestureCommands;

namespace ListeningCommands
{
    public class GesCStart : MonoBehaviour
    {

        ICommand command;
        TcpListener listener;
        String msg;
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
                case "open":
                    {
                        ICommand open = new Open();
                        setCommand(open);
                        openGesture();
                        break;
                    }
                case "pinch":
                    {
                        ICommand pinch = new Pinch();
                        setCommand(pinch);
                        pinchGesture();
                        
                        break;
                    }
                case "fist":
                    {
                        ICommand fist = new Fist();
                        setCommand(fist);
                        fistGesture();
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
                    if (LoadApplication.instance.answerToClose)
                    {
                        LoadApplication.instance.closeApp();
                        LoadApplication.instance.answerToClose = false;

                    }
                    else
                    {
                        LoadApplication.instance.noClose();
                        Debug.Log("No ha finalizado la app");
                    }
                    visible = false;
                }
            }

        }


        public void setCommand(ICommand command)
        {
            this.command = command;
        }

        public void openGesture()
        {
            command.execute();
        }

        public void pinchGesture()
        {
            command.execute();
        }
        public void fistGesture()
        {
            command.execute();
        }
        public void backwardGesture()
        {
            command.execute();
        }
        public void forwardGesture()
        {
            command.execute();
        }
    }
}