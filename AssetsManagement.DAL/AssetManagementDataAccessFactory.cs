using System;

namespace AssetsManagement.DAL
{
    public class AssetManagementDataAccessFactory
    {
        public enum DataAccessType { InMem, MS_SQL }
        private IAssetManagementDataAccess dataAccess;
        private static AssetManagementDataAccessFactory instance;

        private AssetManagementDataAccessFactory()
        {
        }

        public static AssetManagementDataAccessFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AssetManagementDataAccessFactory();
                }

                return instance;
            }
        }

        public IAssetManagementDataAccess GetDataAccess()
        {
            return GetDataAccess(DataAccessType.InMem);
        }


        public IAssetManagementDataAccess GetDataAccess(DataAccessType dataAccessType)
        {
            if (dataAccess == null)
            {
                if (dataAccessType == DataAccessType.MS_SQL)
                {
                    dataAccess = new MsSqlAssetManagementDataAccess();
                }
                else 
                {
                   dataAccess = new InMemAssetManagementDataAccess();
                }
            }

            return dataAccess;
        }
    }
}
