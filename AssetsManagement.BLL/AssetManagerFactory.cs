using System;
using System.Collections.Generic;
using System.Text;

namespace AssetsManagement.BLL
{
    public class AssetManagerFactory
    {
        private AssetManagerFactory() { }

        public static IAssetManager GetAssetManager() 
        {
            return new AssetManager();
        }
    }
}
