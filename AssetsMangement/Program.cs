using System;
using AssetsManagement.BLL;
using AssetsManagement.View;

namespace AssetsManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            PropertyManagementView view = new PropertyManagementView(
                new AssetManager());

            view.Start();

            Console.Read();
        }
    }
}
