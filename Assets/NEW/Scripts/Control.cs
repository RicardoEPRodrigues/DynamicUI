/*
 * Copyright (C) ricardo 2017 - All Rights Reserved
 */
using System;
using UnityEngine;

namespace NEW {
    /// <summary>
    /// This class serves has a support to create and destroy a UI object.
    /// 
    /// In this implementation you should create a child class to implement
    /// bussiness code.
    /// </summary>
    [Serializable]
    public class Control {
        public enum ShowResult {
            // First time the UI is shown.
            FIRST,
            // The UI was shown.
            OK,
            // The UI wasn't able to be shown.
            FAIL
        }

        /// <summary>
        /// The prefab should be initialized with an UI prefab of you choice.
        /// 
        /// To initialize the prefab you can:
        ///     Make a Control class public in a MonoBehaviour 
        ///     and use Unity to select a prefab
        /// 
        ///     OR
        /// 
        ///     Use a function like LoadAssetAtPath to load it in C#:
        ///         control.prefab = UnityEditor.AssetDatabase.LoadAssetAtPath(
        ///                 "Assets/Path/To/prefab.prefab", typeof(Canvas))
        ///                  as Canvas;
        /// 
        /// </summary>
        [SerializeField]
        public GameObject prefab;

        /// <summary>
        /// The instance of the prefab. This variable is initiated after the
        /// call of <c>Show()</c> where the class creates for the first time the
        /// UI.
        /// 
        /// IT MAY BE NULL!
        /// </summary>
        public GameObject instance;

        /// <summary>
        /// Gets a value indicating whether this instance is visible.
        /// </summary>
        /// <value><c>true</c> if this instance is visible; otherwise, <c>false</c>.</value>
        public bool IsVisible {
            get {
                return instance != null && instance.activeSelf;
            }
        }

        public Control() {
        }

        public Control(GameObject prefab) {
            this.prefab = prefab;
        }

        /// <summary>
        /// Show this instance.
        /// </summary>
        /// <returns>
        /// <c>ShowResult.FIRST</c> if the UI was shown for the first time;
        /// <c>ShowResult.OK</c> if the UI was shown without a problem;
        /// <c>ShowResult.FAIL</c> if the UI couldn't be shown;
        /// </returns>
        public ShowResult Show() {
            if (instance == null) {
                if (prefab == null)
                    return ShowResult.FAIL; 
                instance = (GameObject)GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
                if (!instance) {
                    return ShowResult.FAIL;
                }
                GameObject.DontDestroyOnLoad(instance.gameObject);
                return ShowResult.FIRST;
            } else if (instance.activeSelf == false) {
                instance.SetActive(true);
            }
            return ShowResult.OK;
        }

        /// <summary>
        /// This method destroys the instance of the prefab, if that is not
        /// what you want please use <c>Disable()</c>.
        /// </summary>
        public void Destroy() {
            if (instance == null)
                return;

            GameObject.Destroy(instance.gameObject);
            instance = null;
        }

        /// <summary>
        /// Disable this instance.
        /// </summary>
        public void Disable() {
            if (instance == null)
                return;

            instance.SetActive(false);
        }
    }
}