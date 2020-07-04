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
                new PropertyMangementManager());

            view.Start();

            Console.Read();
        }
    }
}
