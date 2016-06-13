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

        public Dictionary<string, DirInfo> FileInf = new Dictionary<string, DirInfo>();

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
                StoreFileInformation(di);
            }
        }
        void StoreFileInformation(System.IO.DirectoryInfo di)
        {
            System.IO.FileInfo[] fileNames = di.GetFiles("*.*");
            System.IO.DirectoryInfo[] Directories = di.GetDirectories("*.*");
            
            long totallength = 0;
            List<FileInform> FilesInDir = new List<FileInform>();
            foreach (System.IO.FileInfo fi in fileNames)
            {
                System.IO.DirectoryInfo parent = fi.Directory;

                string FileSize = GetFileSize(fi.Length);
                FileInform Info = new FileInform(fi.Name, fi.Extension, FileSize, fi.LastWriteTime.ToString());
                totallength = totallength + fi.Length;
                FilesInDir.Add(Info);
            }
            DirInfo NewDir = new DirInfo(di.Name, totallength.ToString(), FilesInDir);
            FileInf.Add(di.Name, NewDir);
            System.IO.DirectoryInfo[] dirInfos = di.GetDirectories("*.*");

            foreach (System.IO.DirectoryInfo d in dirInfos)
            {
                StoreFileInformation(d);
            }
        }

        private string GetFileSize(long length)
        {
            string Value = length.ToString() + " bytes";
            if (length > 1024 && length < (1024 * 1024))
            {
                Value = (length / 1024).ToString() + " KB";
            }
            else if (length > (1024 * 1024))
            {
                Value = (length / (1024 * 1024)).ToString() + " MB";
            }
            return Value;
        }
    }

    

    public class DirInfo
    {
        public string _dirname;
        public string _dirsize;
        public List<FileInform> _files;
      
        public DirInfo(string name, string size, List<FileInform> files)
        {
            this._dirname = name;
            this._dirsize = size;
            this._files = files; 
         
        }
    }

    public class FileInform
    {
        public string _filename;
        public string _extension;
        public string _size;
        public string _lastchanged;

        public FileInform(string name, string ext, string size, string changed)
        {
            this._filename = name;
            this._extension = ext;
            this._size = size;
            this._lastchanged = changed;
        }
    }
}
