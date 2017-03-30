/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using System.Collections.Generic;
using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// This class serves both as an augmentation definition for an ImageTarget in the editor
    /// as well as a tracked image target result at runtime
    /// </summary>
    public class ImageTargetBehaviour : ImageTargetAbstractBehaviour
    {

        public GameObject kitsu, magma;

        private void Awake()
        {
            GameObject.FindGameObjectWithTag("GG").GetComponent<SwitchMonster>().kitsuGb = kitsu;
            GameObject.FindGameObjectWithTag("GG").GetComponent<SwitchMonster>().magmaGb = magma;
        }
    }
}
