/*
 * Copyright (C) ricardo 2017 - All Rights Reserved
 */
using System;
using UnityEngine;

namespace NEW {
    /// <summary>
    /// The NEW Control is no to be inherited, but to be used has a component,
    /// this means that the following example should be simpler and easier to use.
    /// </summary>
    [Serializable]
    public class YesNoControl {
        /// <summary>
        /// Control for the UI.
        /// </summary>
        private Control control;

        public YesNoControl(string prefabPath) : base() {
            GameObject prefab = UnityEditor.AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject)) as GameObject;
            control = new Control();
            control.prefab = prefab;
        }

        public void SetAndShow(string message, Hooks.VoidFunc yes, Hooks.VoidFunc no) {
            var result = control.Show();
            if (result == Control.ShowResult.FIRST) {
                var hooks = control.instance.GetComponent<YesNoHooks>();
                if (hooks == null)
                    return;

                hooks.Content = message;
                hooks.OnYes = yes;
                hooks.OnNo = no;
            }
        }

        public void Disable() {
            control.Disable();
        }
    }
}