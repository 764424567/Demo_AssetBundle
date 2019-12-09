using System.Collections.Generic;
using System.IO;
using UnityEditor;

public class PackBundles : Editor
{
    //选定资源打包
    [MenuItem("PackBundles/PackBundles")] 
    static void PutBundleAssetes()
    {
        List<AssetBundleBuild> buildMap = new List<AssetBundleBuild>();
        AssetBundleBuild build = new AssetBundleBuild();
        build.assetBundleName = "123.unity3d";
        build.assetNames = new[] { "Assets/Textures/123.jpg" };
        buildMap.Add(build);

        //将这些资源包放在一个名为ABs的目录下        
        string assetBundleDirectory = "Assets/ABs";
        //如果目录不存在，就创建一个目录        
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, buildMap.ToArray(), BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }

    //全部打包
    [MenuItem("PackBundles/AllPackBundles")] 
    static void PutBundleAssetesAll()
    {
        //将这些资源包放在一个名为ABs的目录下        
        string assetBundleDirectory = "Assets/ABs";
        //如果目录不存在，就创建一个目录        
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory,BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}
