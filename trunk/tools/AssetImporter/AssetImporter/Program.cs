using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace AssetImporter
{
    class Program
    {
        static List<string> _files = new List<string>();
        static string mainDirName = string.Empty;
        static void Main(string[] args)
        {
            var dirName = Directory.GetCurrentDirectory();
            var dirs = Directory.GetDirectories(dirName);
            mainDirName = dirName;
            getFilesInDirs(dirName);
            loadImagesFromFiles();
            Console.Read();
        }

        private static void loadImagesFromFiles()
        {
            foreach (var file in _files)
            {
                try
                {
                    var extension = Path.GetExtension(file);
                    if (string.Compare(extension, ".png") == 0)
                    {
                        Image img = Image.FromFile(file);
                        bool resizeNeeded = false;
                        int newWidth = 0, newheight = 0;
                        if (img.Width >= img.Height)
                        {
                            //img is landscape
                            if ((double)((double)img.Width / (double)img.Height) != (double)(16.0d / 9.0d))
                            {
                                resizeNeeded = true;
                                newWidth = img.Width;
                                newheight = img.Height * 16 / 9;
                            }
                        }
                        else
                        {
                            //img is portrait
                            if ((double)((double)img.Height / (double)img.Width) != (double)(9.0d / 16.0d))
                            {
                                resizeNeeded = true;
                                newheight = img.Height;
                                newWidth = img.Width * 16 / 9;
                            }
                        }

                        if (resizeNeeded)
                        {
                            Bitmap _bmp = new Bitmap(img, new Size(newWidth, newheight));
                            Image imgToSave = (Image)_bmp;
                            var tempPath = Directory.GetParent(mainDirName);
                            if (!Directory.Exists(tempPath + "\\Data"))
                            {
                                Directory.CreateDirectory(tempPath + "\\Data\\");
                            }
                            var path = tempPath + "\\Data\\" + Path.GetFileName(file);

                            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                            imgToSave.Save(fs, ImageFormat.Png);
                            fs.Flush();
                            Console.WriteLine(fs.Name);
                            fs.Close();
                            imgToSave.Dispose();
                            img.Dispose();
                            _bmp.Dispose();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }            
        }

        private static void getFilesInDirs(string dir)
        {
            var files = Directory.GetFiles(dir).ToList();
            _files.AddRange(files);
            foreach ( var directory in Directory.GetDirectories(dir))
            {
                getFilesInDirs(directory);
            }
        }
    }
}
