using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace Lab13
{
    class SDALog
    {
        private static string path = @"D:\Git\Labs\OOP\Lab13\sdalogfile.txt";
        public static void Write(string info, string method_name)
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {


                sw.WriteLine(DateTime.Now + " " + "Method: " + method_name + " " + info);
            }
        }
        public static void Read()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        public static void Search(string info)
        {
            string[] data;
            using (StreamReader sr = new StreamReader(path))
            {
                bool found = false;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (found == false)
                    {
                        data = line.Split(" ");
                        for (int i = 0; i < data.Length; i++)
                        {
                            if (data[i] == info)
                            {
                                found = true;
                                for (int j = 0; j < data.Length; j++)
                                {
                                    Console.Write(data[j] + " ");
                                }
                                Console.WriteLine();
                                break;
                            }
                        }
                    }
                    else break;
                }

            }
        }
    }
    class SDADiskInfo
    {
        private static DriveInfo[] drives = DriveInfo.GetDrives();
        public static void FreeSpace(string label) 
        {
            foreach (DriveInfo d in drives)
            {
                if (d.VolumeLabel == label)
                {
                    Console.WriteLine(d.TotalFreeSpace + " bytes");
                }
            }
        }
        public static void FileSystem(string label) 
        {
            foreach (DriveInfo d in drives)
            {
                if (d.VolumeLabel == label)
                {
                    Console.WriteLine(d.DriveFormat);
                }
            }
        }
        public static void DrivesInfo() 
        {
            foreach (DriveInfo d in drives)
            {
                Console.WriteLine(d.Name);
                Console.WriteLine("Total: "+d.TotalSize);
                Console.WriteLine("Free space: "+d.TotalFreeSpace);
                Console.WriteLine(d.VolumeLabel);
                
            }
        }
    }
    class SDAFileInfo 
    {
        public static void FileInfo(string filename) 
        {
            string path = $@"D:\Git\Labs\OOP\Lab13\{filename}";
            FileInfo info = new FileInfo(path);
            if (info.Exists) 
            {
                Console.WriteLine(info.Length + " bytes");
                Console.WriteLine(info.Extension);
                Console.WriteLine(info.FullName);
                DateTime creation = File.GetCreationTime(path);
                Console.WriteLine(creation);
                Console.WriteLine(info.LastWriteTime);
            }
        }
    }
    class SDADirInfo 
    {
        public static void DirInfo(string dir) 
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            if (Directory.Exists(dir)) 
            {
                string[] dirs = Directory.GetFiles(dir);
                Console.WriteLine("Number of files: "+dirs.Length);
                DateTime creation = Directory.GetCreationTime(dir);
                Console.WriteLine(creation);
                dirs = Directory.GetDirectories(dir);
                Console.WriteLine("Number of subdirs: " + dirs.Length);
                Console.WriteLine("Parent: " + Directory.GetParent(dir));
            }
        }
    }
    class SDAFileManager 
    {
        public static void CreateDir(string path) 
        {
            Directory.CreateDirectory(path);
        }
        public static void CopyExt(string path, string path1) 
        {
            string[] files = Directory.GetFiles(path);
            foreach(string file in files)
            {
                FileInfo fileInf = new FileInfo(file);
                if(fileInf.Extension == ".txt") 
                {
                    fileInf.CopyTo(path1+fileInf.Name);
                }
            }
        }
        public static void CreateFile(string path, string info) 
        {
            File.Create(path);
        }
        public static void CopyRenameWrite(string path_from,string path_to) 
        {
            File.Create(path_to);
            File.Delete(path_from);
        }
        public static void MoveDirectory(string path_from, string path_to) 
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path_from);
            if (dirInfo.Exists && Directory.Exists(path_to) == false)
            {
                dirInfo.MoveTo(path_to);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SDALog.Write("info","twe");
            SDALog.Read();
            SDALog.Search("info");
            SDADiskInfo.FreeSpace("D");
            SDADiskInfo.FileSystem("D");
            SDADiskInfo.DrivesInfo();
            SDAFileInfo.FileInfo("file1.txt");
            SDADirInfo.DirInfo(@"D:\Git\Labs\OOP\Lab13\");
            SDAFileManager.CreateDir(@"D:\Git\Labs\OOP\Lab13\SDAInspect1");
            //SDAFileManager.CreateFile(@"D:\Git\Labs\OOP\Lab13\sdadirinfo.txt", "info");
            SDAFileManager.CopyRenameWrite(@"D:\Git\Labs\OOP\Lab13\sdadirinfo.txt", @"D:\Git\Labs\OOP\Lab13\bin\sdadirinfoNew.txt");
            SDAFileManager.CreateDir(@"D:\Git\Labs\OOP\Lab13\SDAFiles");
            SDAFileManager.CopyExt(@"D:\Git\Labs\OOP\Lab13\", @"D:\Git\Labs\OOP\Lab13\SDAFiles\");
            SDAFileManager.MoveDirectory(@"D:\Git\Labs\OOP\Lab13\SDAFiles", @"D:\Git\Labs\OOP\Lab13\SDAInspect\");
            string sourceFolder = @"D:\Git\Labs\OOP\Lab13\SDAInspect"; // исходная папка
            string zipFile = @"D:\Git\Labs\OOP\Lab13\zip.zip"; // сжатый файл
            string targetFolder = @"D:\Git\Labs\OOP\Lab13\.vs"; // папка, куда распаковывается файл

            ZipFile.CreateFromDirectory(sourceFolder, zipFile);
            Console.WriteLine($"Папка {sourceFolder} архивирована в файл {zipFile}");
            ZipFile.ExtractToDirectory(zipFile, targetFolder);

            Console.WriteLine($"Файл {zipFile} распакован в папку {targetFolder}");
            Console.ReadLine();

        }

    }
}
