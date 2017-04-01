/*
 * Copyright (C) ricardo 2017 - All Rights Reserved
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace NEW {
    public class MainScript : MonoBehaviour {

        public string prefabPath = "NEW/Theme01/YesNoCanvas";

        void Start() {

            GameObject prefab = Resources.Load(prefabPath) as GameObject;
                
            // Instantiate a Control and pass the path to the prefab.
            YesNoControl control = new YesNoControl(prefab);
            // Use control function to show the control on screen.
            control.SetAndShow("Are you sure, mate?", 
                () => {
                    Debug.Log("Clicked Yes!");
                }, () => {
                    Debug.Log("Clicked no...");
                });

            Console.WriteLine(Application.dataPath);
            Debug.Log(Application.dataPath);
        }
    }
}