using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;

namespace Lab2_BinaryFiles
{
    public class BinaryWorker
    {
        public static void BinWriter(string fileName, List<Book> structList)
        {
            FileSystem.FileOpen(1, fileName, OpenMode.Random);
            
            foreach (Book book in structList)
            {
                FileSystem.FilePut(1, book);
            }
            
            FileSystem.FileClose(1);
        }

        public static List<Book> BinReader(string fileName)
        {
            FileSystem.FileOpen(1, fileName, OpenMode.Random);
            
            List<Book> newStructList = new List<Book>();
            while (!(FileSystem.EOF(1)))
            {
                ValueType tempBook = new Book();
                FileSystem.FileGet(1, ref tempBook);
                newStructList = newStructList.Append((Book)tempBook).ToList();
            }
            FileSystem.FileClose(1);
            
            return newStructList;
        }
    }
}