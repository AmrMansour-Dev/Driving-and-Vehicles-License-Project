using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Classess
{
    public class clsUtility
    {

        public static string GenerateGUID()
        {
            Guid guid = Guid.NewGuid();

            return guid.ToString();
        }

        public static bool CreateFolderIfNotExists(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch(Exception ex) 
                {
                    MessageBox.Show("Error Creating a Folder : ", ex.Message);
                    return false;
                }
            }
            return true;

        }
        public static string ChangeFileNameToGUID(string SourceFile)
        {
            string Extension = Path.GetExtension(SourceFile);

            return GenerateGUID() + Extension;
        }

        public static bool CopyFileToSpecificFolder(ref string SourceFile)
        {
            string DestinationFolder = @"C:\Users\user\Desktop\People PICS\";

            if (!CreateFolderIfNotExists(DestinationFolder))
            {
                return false;
            }

            string DestinationFile = DestinationFolder + ChangeFileNameToGUID(SourceFile);

            try
            {
                File.Copy(SourceFile, DestinationFile, true);
            }
            catch (IOException IOX)
            {
                MessageBox.Show(IOX.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            SourceFile = DestinationFile;
            return true;

        }
    }
}
