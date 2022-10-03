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
    public class GesCInstructions : MonoBehaviour
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
                case "fist":
                    {
                        ICommand fist = new Fist();
                        setCommand(fist);
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
    }
}