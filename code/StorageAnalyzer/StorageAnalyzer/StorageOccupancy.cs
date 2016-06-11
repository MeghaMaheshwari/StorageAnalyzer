using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageAnalyzer
{
    class StorageOccupancy
    {
        string DirectoryName;

        string _numoffiles;

        string _numofdirs;

        public string NumOfFiles
        {
            get
            {
                return _numoffiles;
            }
            set
            {
                _numoffiles = value;
            }
        }

        public string NumOfDirs
        {
            get
            {
                return _numofdirs;
            }
            set
            {
                _numofdirs = value;
            }
        }

        public StorageOccupancy(string dirname)
        {
            this.DirectoryName = dirname;
        }

        public void SetVisualAnalyzerValue()
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(this.DirectoryName);

            if (di.Exists)
            {                
                System.IO.FileInfo[] fileNames = di.GetFiles("*.*");
                System.IO.DirectoryInfo[] Directories = di.GetDirectories("*.*");

                _numoffiles = fileNames.Length.ToString();
                _numofdirs = Directories.Length.ToString();

                foreach (System.IO.FileInfo fi in fileNames)
                {
                    Console.WriteLine("{0}: {1}: {2}", fi.Name, fi.LastAccessTime, fi.Length);
                }
            }
        }
    }
}
