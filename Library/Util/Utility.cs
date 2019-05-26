using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//hello
//hello remote

//Hellow locals
namespace Library.Utilites
{//class
    public class Utility
    {
        public static string ProjectPath;

        public static void GetProjectPath()
        {
            try
            {
                ProjectPath = System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName;
                FileInfo info = new FileInfo(ProjectPath);

                DirectoryInfo ParentDir = info.Directory;
                Console.WriteLine(ParentDir);
                ProjectPath = ParentDir.ToString();
                Console.WriteLine("Test Messagessxxxxsxxx");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            //  return ProjectPath;
        }


        public static void CreateFolder(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                   
                    Directory.Delete(path, true);
                    Directory.CreateDirectory(path);

                }
                else
                {
                    Directory.CreateDirectory(path);
                }




            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            //  return ProjectPath;
        }



    }
}
