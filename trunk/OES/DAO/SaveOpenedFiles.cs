using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;

namespace OES.DAO
{
    public class SaveOpenedFiles
    {
        Word.Application word;
        Word.Document doc;
        //关闭Word文档
        public void CloseWord(string filePath)
        {
            try
            {
                word = new Word.Application();
                Object file_path = filePath;
                Object confirmConversions = Type.Missing;
                Object readOnly = false;
                Object addToRecentFiles = Type.Missing;
                Object passwordDocument = Type.Missing;
                Object passwordTemplate = Type.Missing;
                Object revert = Type.Missing;
                Object writePasswordDocument = Type.Missing;
                Object writePasswordTemplate = Type.Missing;
                Object format = Type.Missing;
                Object encoding = Type.Missing;
                Object visible = Type.Missing;
                Object openConflictDocument = Type.Missing;
                Object openAndRepair = Type.Missing;
                Object documentDirection = Type.Missing;
                Object noEncodingDialog = Type.Missing;
                doc = word.Documents.Open(ref file_path, ref confirmConversions,
                    ref readOnly, ref addToRecentFiles, ref passwordDocument,
                    ref passwordTemplate, ref revert, ref writePasswordDocument,
                    ref writePasswordTemplate, ref format, ref encoding, ref visible,
                    ref openConflictDocument, ref openAndRepair, ref documentDirection,
                    ref noEncodingDialog);
                word.Visible = true;
                Object saveChanges = Word.WdSaveOptions.wdSaveChanges;
                Object originalFormat = Type.Missing;
                Object routeDocument = Type.Missing;

                doc.Close(ref saveChanges,
                  ref originalFormat, ref routeDocument);
                doc = null;

                word.Quit(ref saveChanges,
                    ref originalFormat, ref routeDocument);
                word = null;

            }
            catch(Exception e) 
            {
                Console.WriteLine(e.ToString());
            }
            GC.Collect();
        }
    }
}
