/*
 * Copyright (C) ricardo 2017 - All Rights Reserved
 */
using UnityEngine;
using UnityEngine.UI;

namespace OLD {
    public class YesNoHooks : Hooks {

        [SerializeField]
        private Text contentText = null;

        public VoidFunc OnYes;
        public VoidFunc OnNo;

        public string Content {
            get { return this.contentText.text; }
            set {
                if (!string.IsNullOrEmpty(value) && !value.Equals(this.contentText.text)) {
                    this.contentText.text = value;
                }
            }
        }

        public void UIYes() {
            if (OnYes != null)
                OnYes();
        }

        public void UINo() {
            if (OnNo != null)
                OnNo();
        }
    }
}