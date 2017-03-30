/*
 * Copyright (C) ricardo 2017 - All Rights Reserved
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace NEW {
    public class MainScript : MonoBehaviour {

        public string prefabPath = "Assets/NEW/Prefabs/UI/YesNoCanvas.prefab";
        public bool useStandard = true;

        void Start() {
            if (useStandard) {
                
                // Instantiate a Control and pass the path to the prefab.
                YesNoControl control = new YesNoControl(prefabPath);
                // Use control function to show the control on screen.
                control.SetAndShow("Are you sure, mate?", 
                    () => {
                        Debug.Log("Clicked Yes!");
                    }, () => {
                        Debug.Log("Clicked no...");
                    });
            } else {
                // This section is a bit more complex
                // You can ignore this section of the example 
                // if you just want to see how it works.

                // This section creates a semi-theme game.
                // It selects at random one prefab for the YesNoControl that is
                // in the UI assets folder

                // This puts into an Array all prefabs IDs in a folder
                string[] assets = UnityEditor.AssetDatabase.FindAssets("", 
                                      new string[]{ "Assets/NEW/Prefabs/UI" })
                    .Distinct().ToArray();

                // Selects one at random
                var random = new System.Random();
                int index = random.Next(assets.Count());

                // Get it's full path
                string path = UnityEditor.AssetDatabase
                    .GUIDToAssetPath(assets[index]);
                // Load it
                var prefab = UnityEditor.AssetDatabase.LoadAssetAtPath(
                                 path, typeof(GameObject)) as GameObject;

                // Instantiate a Control and pass the prefab.
                YesNoControl control = new YesNoControl(prefab);
                // Use control function to show the control on screen.
                control.SetAndShow("Are you sure, mate?", 
                    () => {
                        Debug.Log("Clicked Yes!");
                    }, () => {
                        Debug.Log("Clicked no...");
                    });
            }
        }
    }
}