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
        [SerializeField]
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
    public Canvas prefab;
        Canvas canvasObject;

        /// <summary>
        /// Gets the canvas instantiated from the prefab.
        /// </summary>
        /// <value>Returns the canvas or null if it hasn't yet been initialized.</value>
        public Canvas canvas { get { return canvasObject; } }

        /// <summary>
        /// Gets a value indicating whether this instance is visible.
        /// </summary>
        /// <value><c>true</c> if this instance is visible; otherwise, <c>false</c>.</value>
        public bool IsVisible {
            get {
                return canvasObject != null && canvasObject.enabled;
            }
        }

        /// <summary>
        /// Show this instance.
        /// </summary>
        public void Show() {
            if (prefab == null)
                return;

            if (canvasObject == null) {
                canvasObject = (Canvas)GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
                GameObject.DontDestroyOnLoad(canvasObject.gameObject);
                OnFirstShow();
            } else if (canvasObject.enabled == false) {
                canvasObject.enabled = true;
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
        public void Hide() {
            if (canvasObject == null)
                return;

            this.OnExit();

            GameObject.Destroy(canvasObject.gameObject);
            canvasObject = null;
        }

        /// <summary>
        /// Disable this instance.
        /// </summary>
        public void Disable() {
            if (canvasObject == null)
                return;

            this.OnExit();

            canvasObject.enabled = false;
        }

        /// <summary>
        /// Raises the level was loaded event.
        /// </summary>
        public virtual void OnLevelWasLoaded() {
        }

        /// <summary>
        /// Raises the exit event.
        /// </summary>
        protected virtual void OnExit() {
        }
    }
}