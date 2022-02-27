using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace NetWorkedData.UnityEditor.PackageUpdate
{

    public abstract class NWDMenus
    {
        public const string K_NETWORKEDDATA = "Net-Worked-Data test/";
        public const int K_START_INDEX = 0;
        public const string K_VERSION = "1.3.1ßeta";
        [MenuItem(K_NETWORKEDDATA + "Update Git Package " + K_VERSION, false, K_START_INDEX + 1)]
        public static void DevelopedBy()
        {
            if (EditorUtility.DisplayDialog(
                "Update manifest json",
                "remove Hash and do update?",
                "cancel",
                "update"))
            {
            }
            else
            {
                string tPackagesFolderPath = Path.Combine(Application.dataPath, "../Packages");
                string tFilePath = tPackagesFolderPath + "/packages-lock.json";
                string tFileContent = File.ReadAllText(tFilePath);
                Debug.Log("tFileContent = " + tFileContent);

                //:{
                //    "com.net-worked-data.dependencies":{ "version":"https://github.com/NetWorkedData/NWD3_Dev_Dependencies.git","depth":0,"source":"git","dependencies":{ "com.unity.nuget.newtonsoft-json":"2.0.0"},"hash":"4508dd1327d1f208f7faf6f13638f4bb2f533465"}
                //}
                string tPattern = "(\\,\"hash\"\\:\"[A-Za-z0-9]*\")";
                string tReplacement = "";
                Regex rgx = new Regex(tPattern);
                string tRresult = rgx.Replace(tFileContent, tReplacement);
                Debug.Log("tRresult = " + tRresult);
                File.WriteAllText(tFilePath, tRresult);
            }
        }

    }
}
