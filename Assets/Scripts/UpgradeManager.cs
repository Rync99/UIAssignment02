﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {

    public static UpgradeManager upgrademanager;

    public List<Upgrade> m_upgradeList = new List<Upgrade>();

    // Use this for initialization
    void Start () {
        upgrademanager = this;

    }

}
