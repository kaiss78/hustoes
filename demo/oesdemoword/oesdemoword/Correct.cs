 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Off = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

namespace oesdemo
{
    public class Correct
    {      

        public static int Correctword(String path2,String path3)
        {

            Word.Application word1 = new Word.Application();
            Word.Application word2 = new Word.Application();
            object nullobj = System.Reflection.Missing.Value;
            object file1 = path2;
            object file2 = path3;
            Word.Document doc1 = word1.Documents.Open(ref file1, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj);
            Word.Document doc2 = word2.Documents.Open(ref file2, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj);
            Word.Range rangeWord1;
            Word.Range rangeWord2;
            int i=0;
            int right=0;
            foreach (Word.Paragraph s in doc1.Paragraphs)
            {
               
                i++;                   
            
                rangeWord1 = doc1.Paragraphs[i].Range;
                rangeWord2 = doc2.Paragraphs[i].Range;

                if (rangeWord1.Font.Name == rangeWord2.Font.Name)                            
                    right++;

                if (rangeWord1.Font.Color == rangeWord2.Font.Color)
                
                    right++;

                if (rangeWord1.Font.Bold == rangeWord2.Font.Bold)
                   
                    right++;

                if (rangeWord1.Font.Size == rangeWord2.Font.Size)
                   
                    right++;

                if (rangeWord1.Font.Italic == rangeWord2.Font.Italic)
                    right++;

                if (doc1.Paragraphs[i].LineSpacing == doc2.Paragraphs[i].LineSpacing)                          
                    right = right++;

                if (doc1.Paragraphs[i].FirstLineIndent == doc2.Paragraphs[i].FirstLineIndent)
                    right++;

                //if (doc1.Tables[1].Columns.Count == doc2.Tables[1].Columns.Count)
                //    right++;

                //if (doc1.InlineShapes[1].Type == doc2.InlineShapes[1].Type)
                //    right++;

                //if (doc1.InlineShapes.Count == doc2.InlineShapes.Count)
                //    right++;

            }


            doc1.Close(ref nullobj, ref nullobj, ref nullobj);
            doc2.Close(ref nullobj, ref nullobj, ref nullobj);
            word1.Quit(ref nullobj, ref nullobj, ref nullobj);
            word2.Quit(ref nullobj, ref nullobj, ref nullobj);           
            
            return right;

         }



        internal static object Correctdoc(string p, string path3)
        {
            throw new NotImplementedException();
        }
    }

       
}

   
