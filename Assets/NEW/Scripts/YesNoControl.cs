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
    public class YesNoControl : IControl {
        private Control control;
        private string message;
        private Hooks.VoidFunc yes, no;

        public YesNoControl(string prefabPath) {
            control = new Control();
            control.prefab = UnityEditor.AssetDatabase.LoadAssetAtPath(
                prefabPath, typeof(GameObject)) as GameObject;
        }

        public YesNoControl(GameObject prefab) {
            control = new Control();
            control.prefab = prefab;
        }

        public void Set(string message, Hooks.VoidFunc yes, Hooks.VoidFunc no) {
            this.message = message;
            this.yes = yes;
            this.no = no;
        }

        public ShowResult Show() {
            var ret = control.Show();
            if (ret == ShowResult.FIRST || ret == ShowResult.OK) {
                var hooks = control.instance.GetComponent<YesNoHooks>();
                if (hooks) {
                    hooks.Content = message;
                    hooks.OnYes = yes;
                    hooks.OnNo = no;
                }
            }
            return ret;
        }

        public ShowResult SetAndShow(string message, Hooks.VoidFunc yes, Hooks.VoidFunc no) {
            this.Set(message, yes, no);
            return Show();
        }

        public void Disable() {
            control.Disable();
        }

        public void Destroy() {
            control.Destroy();
        }

        public bool IsVisible() {
            return control.IsVisible();
        }
    }
}