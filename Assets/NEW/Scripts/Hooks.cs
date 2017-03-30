/*
 * Copyright (C) ricardo 2017 - All Rights Reserved
 */
using UnityEngine;
using System.Collections;
using System;

namespace NEW {
    public class Hooks : MonoBehaviour {
        public delegate void IntFunc(int value);

        public delegate void BoolFunc(bool value);

        public delegate void StringFunc(string value);

        public delegate void VoidFunc();

        public delegate void GameObjectFunc(GameObject gameObj);
    }
}