using System;
using System.IO;

namespace FCK.Studio.Utility
{
    public class FileHelper
    {
        /// <summary>
        /// 文件是否存在
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsExist(string filePath)
        {
            return File.Exists(filePath);
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool CreateFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    File.Create(filePath);
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="FilePathName"></param>
        /// <returns></returns>
        public static bool DeleteFile(string FilePathName)
        {
            try
            {
                FileInfo DeleFile = new FileInfo(FilePathName);
                if (DeleFile.Exists)
                {
                    DeleFile.Delete();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 获取文件类型
        /// </summary>
        /// <param name="fileurl"></param>
        /// <returns></returns>
        public static string GetFileType(string fileurl)
        {
            if (fileurl != null)
            {
                FileInfo file = new FileInfo(fileurl);
                if (file.Exists)
                {
                    return file.Extension.Replace('.', ' ').Trim();
                }
                else
                    return "";
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获取文件名
        /// </summary>
        /// <param name="fileurl"></param>
        /// <returns></returns>
        public static string GetFileName(string fileurl)
        {
            if (fileurl != null)
            {
                FileInfo file = new FileInfo(fileurl);
                if (file.Exists)
                {
                    return file.Name;
                }
                else
                    return "";
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获取文件大小
        /// </summary>
        /// <param name="fileurl"></param>
        /// <returns></returns>
        public static long GetFileSize(string fileurl)
        {
            if (fileurl != null)
            {
                FileInfo file = new FileInfo(fileurl);
                if (file.Exists)
                {
                    long filesize = file.Length / 1024;
                    return filesize;
                }
                else
                    return 0;
            }
            else
            {
                return 0;
            }
        }
    }
}
