﻿using BoneFier.Basic;
using System;
using System.Collections.Generic;
using System.IO;

namespace BoneFier
{
    internal class Asset
    {
        public string AssetDirectory { get; set; }
        public Asset(string Assetpath)
        {
            AssetDirectory = Assetpath;
            if(!Directory.Exists(Assetpath))
                Directory.CreateDirectory(Assetpath);
        }

        public void AddAsset(string FilePath)
        {
            Basic.Kernel.CopyFile(FilePath, AssetDirectory);
        }

        public void DeleteAsset(string assetname)
        {
            if (!Exist(assetname))
                Debuger.PrintError($"Asset {assetname} do not exist in asset folder.");
            else
                File.Delete(AssetDirectory + assetname);
        }
        public string ReadFile(string Filename)
        {
            return (File.ReadAllText(AssetDirectory + Filename));
        }
        public void WriteFile(string Filename,string value)
        {
             File.WriteAllText(AssetDirectory + Filename, value);
        }
        public bool Exist(string Filename)
        {
            return (File.Exists(AssetDirectory + Filename));
        }
    }
}
