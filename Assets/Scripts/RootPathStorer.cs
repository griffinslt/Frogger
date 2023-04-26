using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RootPathStorer: MonoBehaviour
{

    public static readonly string RootPath = Application.persistentDataPath+ Path.DirectorySeparatorChar + "SaveFiles" + Path.DirectorySeparatorChar;
}
