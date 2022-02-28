using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace NetWorkedData.PackageUpdate
{
    public abstract class NWDMenuPackage
    {
        public const string K_NETWORKEDDATA = "Net-Worked-Data v3/Team Dev/";
        public const int K_START_INDEX = 0;
        public const string K_VERSION = "1.5.2a";
        [MenuItem(K_NETWORKEDDATA + "Update Git Package " + K_VERSION, false, K_START_INDEX + 300)]
        public static void DevelopedBy()
        {
            if (!EditorUtility.DisplayDialog(
                "Update manifest file",
                "Remove hash information and force update all Git packages?",
                "Cancel",
                "Update"))
            {
                string tPackagesFolderPath = Path.Combine(Application.dataPath, "../Packages");
                string tFilePath = tPackagesFolderPath + "/packages-lock.json";
                string tFileContent = File.ReadAllText(tFilePath);
                //Debug.Log("tFileContent = " + tFileContent);
                Regex rgx = new Regex("(\\,(\\n|\\r| )*\"hash\"( )*\\:( )*\"[A-Za-z0-9]*\")");
                string tRresult = rgx.Replace(tFileContent, string.Empty);
                //Debug.Log("tRresult = " + tRresult);
                File.WriteAllText(tFilePath, tRresult);
                Application.OpenURL("https://github.com/NetWorkedData/NWD3_Dev_Dependencies");
            }
        }

    }
}
