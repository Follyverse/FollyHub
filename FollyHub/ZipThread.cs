using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Follyverse
{
    public class ZipThread
    {
        public enum OperationType { Copying, Importing }
        public enum OperationStatus { NotStarted, Started, Finished }
        public static OperationStatus status = OperationStatus.NotStarted;
        public static int processed = 0, succeeded = 0, total = 0;
        public static bool[] successful;
        public static OperationType type = OperationType.Importing;
        public static List<string> items;
        public static void CopyZipFiles(string[] filenames)
        {
            total = filenames.Length;
            succeeded = 0;
            processed = 0;
            status = OperationStatus.Started;
            successful = new bool[total];
            CopyZipFilesAsync(filenames);
        }
        async static Task<bool> CopyZipFilesAsync(string[] filenames)
        {
            items = new List<string>();
            string name;
            await Task.Run(() =>
            {
                for (int i = 0; i < filenames.Length; i++)
                {
                    successful[i] = CopyZipFile(filenames[i]);
                }
                status = OperationStatus.Finished;
            });
            return true;
        }
        static bool CopyZipFile(string name)
        {
            string fname = MainForm.GetFileName(name);
            string newName = fname;
            try
            {
                if (File.Exists(MainForm.Path + fname + ".zip") || Directory.Exists(MainForm.Path + fname))
                {
                    int n = 1;
                    while (!File.Exists(MainForm.Path + fname + "(" + n + ").zip") && !Directory.Exists(MainForm.Path + fname + "(" + n + ")"))
                        n++;
                    newName = fname + "(" + n + ")";
                }
                items.Add(newName);
                File.Copy(name, MainForm.Path + newName + ".zip");
                succeeded++;
                processed++;
                return true;
            }
            catch (Exception ex)
            {
                processed++;
                return false;
            }
        }
        public static void CopyFolder(string folder)
        {
            total = 1;
            succeeded = 0;
            processed = 0;
            status = OperationStatus.Started;
            successful = new bool[1];
            CopyFolderAsync(folder);
        }
        async static Task<bool> CopyFolderAsync(string title)
        {

            await Task.Run(() =>
            {
                string newName = title;
                //    string fname = MainForm.GetFileName(name);
                try
                {
                    if (Directory.Exists(MainForm.Path + title))
                    {
                        int n = 1;
                        while (!Directory.Exists(MainForm.Path + title + "(" + n + ")"))
                            n++;
                        newName = MainForm.Path + title + "(" + n + ")";
                    }
                    Directory.Move(title, newName);
                    succeeded++;
                    processed++;
                    successful[0] = true;
                    items = new List<string> { newName };
                }
                catch (Exception ex)
                {
                    processed++;
                    successful[1] = false;
                }
                status = OperationStatus.Finished;
            });
            return true;
        }
        public static void UnzipFiles(List<string> titles)
        {
            processed = 0;
            succeeded = 0;
            total = titles.Count;
            successful = new bool[total];
            UnzipFilesAsync(titles);
        }


        static async Task<bool> UnzipFilesAsync(List<string> titles)
        {
            string zipfile, path;
            List<string> results = new List<string>();
            await Task.Run(() =>
            {
                for (int i = 0; i < titles.Count; i++)
                    try
                    {
                        zipfile = MainForm.Path + titles[i] + ".zip";
                        bool hasDir = false;
                        ZipArchive zipArchive = ZipFile.OpenRead(zipfile);
                        var entries = zipArchive.Entries;
                        foreach (var entry in entries)
                            if (entry.Name == titles[i]) { hasDir = true; break; }
                        path = MainForm.Path;
                        if (!hasDir)
                        {
                            Directory.CreateDirectory(MainForm.Path + titles[i]);
                            path += titles[i] + '/';
                        }
                        zipArchive.ExtractToDirectory(path);
                        successful[i] = true;
                        processed++;
                        succeeded++;
                        results.Add(titles[i]);
                    }
                    catch (Exception ex)
                    {
                        successful[i] = false;
                        processed++;
                    }
                items = results;
                status = OperationStatus.Finished;
            });
            return true;
        }

    }
}
