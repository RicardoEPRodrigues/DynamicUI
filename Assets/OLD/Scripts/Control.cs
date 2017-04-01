/*
 * Copyright (C) ricardo 2017 - All Rights Reserved
 */
using System;
using UnityEngine;

namespace OLD {
    /// <summary>
    /// This class serves has a support to create and destroy a UI object.
    /// 
    /// In this implementation you should create a child class to implement
    /// bussiness code.
    /// </summary>
    [Serializable]
    public class Control {
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

        GameObject instance;

        /// <summary>
        /// Gets the canvas instantiated from the prefab.
        /// </summary>
        /// <value>Returns the canvas or null if it hasn't yet been initialized.</value>
        public GameObject Instance { get { return instance; } }

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
        public void Show() {

            if (instance == null) {
                if (prefab == null)
                    return;
                instance = (GameObject)GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
                GameObject.DontDestroyOnLoad(instance.gameObject);
                OnFirstShow();
            } else if (instance.activeSelf == false) {
                instance.SetActive(true);
                OnShow();
            }
        }

        /// <summary>
        /// Raises the first show event.
        /// </summary>
        public virtual void OnFirstShow() {
        }

        /// <summary>
        /// Raises the show event.
        /// </summary>
        public virtual void OnShow() {
        }

        /// <summary>
        /// Hide this instance.
        /// </summary>
        public void Destroy() {
            if (instance == null)
                return;

            this.OnExit();

            GameObject.Destroy(instance.gameObject);
            instance = null;
        }

        /// <summary>
        /// Disable this instance.
        /// </summary>
        public void Disable() {
            if (instance == null)
                return;

            this.OnExit();

            instance.SetActive(false);
        }

        /// <summary>
        /// Raises the exit event.
        /// </summary>
        protected virtual void OnExit() {
        }
    }
}