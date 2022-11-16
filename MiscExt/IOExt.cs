using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace System.IO
{

    public static class IOExt
    {
        /// <summary>
        /// Returns the filename without extension
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        [Obsolete("use Path.GetFileNameWithoutExtension instead")]
        public static string NameWithoutExtension(this FileInfo fi)
        {
            
            string n = fi.Name;
            if (string.IsNullOrEmpty(fi.Extension))
                return fi.Name;
            n = n.Replace(fi.Extension, "");
            return n;
        }

        /// <summary>
        /// Checks if the file exists and returns a unique filename based on the original one.
        /// Example: C:\boot.ini exists, returns boot(1).ini
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static string GetUniqueFilename(this FileInfo fi)
        {
            string path = fi.DirectoryName;
            string file = Path.GetFileNameWithoutExtension(fi.FullName);
            string ext = Path.GetExtension(fi.FullName);


            int i = 1; 

            string unique = fi.FullName;

            while (File.Exists(unique))
            {
                unique = string.Format("{0}({1}){2}", Path.Combine(path, file), i++, ext);
            }

            return unique;
        }


        /// <summary>
        /// Changes the extension of a file
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="newExtension">New extension without the dot</param>
        /// <returns></returns>
        [Obsolete("use Path.ChangeExtension instead")]
        public static string ChangeExtension(this FileInfo fi, string newExtension)
        {
            return fi.NameWithoutExtension() + "." + newExtension;
        }

        /// <summary>
        /// Returns true if read/write access is possible
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool IsFileLocked(this FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist 
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        /// <summary>
        /// Removes illegal characters from FullName
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static string StripIllegalChars(this FileInfo fi)
        {
            List<char> x = new List<char>();

            x.AddRange(Path.GetInvalidFileNameChars());
            x.AddRange(Path.GetInvalidPathChars());

            fi.FullName.RemoveAny(x.ToArray());

            return fi.FullName;
        }

        /// <summary>
        /// Changes the filename without touching the file extension.
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="newNameWithoutExtension">New filename "something" not "something.txt"</param>
        /// <returns>New FileInfo Object of the renamed file.</returns>
        public static FileInfo  ChangeFilename(this  FileInfo fi , string newNameWithoutExtension)
        {
            string newName = newNameWithoutExtension + fi.Extension;
            string full = Path.Combine(fi.DirectoryName, newName);

            return new FileInfo(full);
        }

        /// <summary>
        /// Returns a unique filename with path inside %temp% folder.
        /// </summary>
        /// <param name="fileName">The name of the original file. For example: something.txt</param>
        /// <param name="additionalSubdirectories">Additional directories that should be concatinated to the %temp% folder path.</param>
        /// <returns></returns>
        public static string GetUniqueTempFileNameFor(string fileName, params string[] additionalSubdirectories)
        {
            string tmp = Path.GetTempPath();
            for (int i = 0; i < additionalSubdirectories.Length; i++)
                tmp = Path.Combine(tmp, additionalSubdirectories[i]);

            if (!Directory.Exists(tmp))
                Directory.CreateDirectory(tmp);

            tmp = Path.Combine(tmp, fileName);

            FileInfo fi = new FileInfo(tmp);

            return fi.GetUniqueFilename();

        }

        /// <summary>
        /// returns the contents of a memorystream as string
        /// </summary>
        /// <param name="ms">Memorystream. Position will change!</param>
        /// <returns></returns>
        public static string CopyToString(this MemoryStream ms)
        {
            ms.Position = 0;

            using (var reader = new StreamReader(ms))
            {
                return reader.ReadToEnd();
            }
        }




        [DllImport("mpr.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int WNetGetConnection([MarshalAs(UnmanagedType.LPTStr)] string localName, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder remoteName, ref int length);
        public static string UncFullName(this FileInfo fi)
        {
            var sb = new StringBuilder(512);
            var size = sb.Capacity;

            var driveLetter = fi.Directory.Root.Name.RemoveAny('\\');

            var error = WNetGetConnection(driveLetter, sb, ref size);
            if (error != 0)
                throw new Exception( "WNetGetConnection failed");

            var networkpath = sb.ToString();
            var filepath = fi.FullName.Substring(driveLetter.Length);

            if (networkpath.EndsWith("\\"))
                networkpath.TrimEnd('\\');
            if (!filepath.StartsWith("\\"))
                filepath += "\\";

            return networkpath + filepath;
        }

    }


}
