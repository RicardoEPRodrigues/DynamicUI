/*
 * Copyright (C) ricardo 2017 - All Rights Reserved
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OLD {
    public class MainScript : MonoBehaviour {

        public string prefabPath = "Assets/OLD/Prefabs/UI/YesNoCanvas.prefab";

        void Start() {
            // Instantiate a Control
            YesNoControl control = new YesNoControl();
            // Load controls prefab
            // the `as` tag means that if the prefab can't be loaded it will be set to null.
            control.prefab = UnityEditor.AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject)) as GameObject;
            // Use control function to show the control on screen.
            control.SetAndShow("Are you sure, mate?", () => {
                    Debug.Log("Clicked Yes!");
                }, () => {
                    Debug.Log("Clicked no...");
                });
        }
    }
}