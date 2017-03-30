/*
 * Copyright (C) ricardo 2017 - All Rights Reserved
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NEW {
    public class MainScript : MonoBehaviour {

        public string prefabPath = "Assets/NEW/Prefabs/UI/YesNoCanvas.prefab";

        void Start() {
            // Instantiate a Control and pass the path to the prefab.
            YesNoControl control = new YesNoControl(prefabPath);
            // Use control function to show the control on screen.
            control.SetAndShow("Are you sure, mate?", () => {
                    Debug.Log("Clicked Yes!");
                }, () => {
                    Debug.Log("Clicked no...");
                });
        }
    }
}