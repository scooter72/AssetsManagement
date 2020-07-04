using System;

namespace AssetsManagement.DAL
{
    public class PropertyManagementFactory
    {
        private IPropertyManagement propertyManagement;
        private static PropertyManagementFactory instance;

        private PropertyManagementFactory()
        {
        }

        public static PropertyManagementFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PropertyManagementFactory();
                }

                return instance;
            }
        }


        public IPropertyManagement get()
        {
            if (propertyManagement == null)
            {
                propertyManagement = new InMemPropertyManagementDataAccess();
            }

            return propertyManagement;
        }
    }
}
