/*
 * Copyright (C) ricardo 2017 - All Rights Reserved
 */
using System;

namespace OLD {
    [Serializable]
    public class YesNoControl : Control {
        public string Message { get; set; }

        public Hooks.VoidFunc Yes { get; set; }

        public Hooks.VoidFunc No { get; set; }

        public YesNoControl() : base() {
            Message = String.Empty;
        }

        /**
     * This function will be called the first time the UI 
     * is shown and only the first time.
     * 
     * This let's you initialize some hook related variables 
     * that only at this time are they available.
     */
        public override void OnFirstShow() {
            var hooks = canvas.GetComponent<YesNoHooks>();
            if (hooks == null)
                return;

            hooks.Content = Message;
            hooks.OnYes = Yes;
            hooks.OnNo = No;
        }

        public void SetAndShow(string message, Hooks.VoidFunc yes, Hooks.VoidFunc no) {
            this.Message = message;
            this.Yes = yes;
            this.No = no;
            this.Show();
        }
    }
}