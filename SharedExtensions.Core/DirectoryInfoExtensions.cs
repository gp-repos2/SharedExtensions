using System.Collections.Generic;
using System.IO;

namespace SharedExtensions
{
    public static class DirectoryInfoExtensions
    {
        public static List<string> GetAllFilesInDirectory(string Directory, string fileSearchPattern = "")
        {
            List<string> result = new List<string>();
            Stack<string> stack = new Stack<string>();
            stack.Push(Directory);
            while (stack.Count > 0)
            {
                DirectoryInfo currentDir = new DirectoryInfo(stack.Pop());
                foreach (DirectoryInfo directoryInfo in currentDir.GetDirectories())
                    stack.Push(directoryInfo.FullName);

                if (!string.IsNullOrEmpty(fileSearchPattern))
                    foreach (FileInfo fileInfo in currentDir.GetFiles(fileSearchPattern))
                        result.Add(fileInfo.FullName);
                else
                    foreach (FileInfo fileInfo in currentDir.GetFiles())
                        result.Add(fileInfo.FullName);
            }
            return result;
        }

    }
}
