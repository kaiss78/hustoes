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
using OESXML;

namespace oesdemo
{
    public class Correct
    {      

        public static int Correctword(String path2,String path3)
        {

            OfficeXML oxml = new OfficeXML("test.xml");
            oxml.getAllAnsPath();
            Word.Application word1 = new Word.Application();
            Word.Application word2 = new Word.Application();
            object nullobj = System.Reflection.Missing.Value;
            object file1 = path2;
            object file2 = path3;
            Word.Document doc1 = word1.Documents.Open(ref file1, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj);
            Word.Document doc2 = word2.Documents.Open(ref file2, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj);
            int i=0;
            int pn=0;
            int right=0;
            foreach (List<OfficeElement> op in oxml.AnsPaths)
            {
                pn = 0;
                foreach (OfficeElement oe in op)
                {
                    if (oe.AttribName == "Documents")
                    {
                        continue;
                    }

                    if (oe.AttribName == "Paragraphs")
                    {
                        pn = int.Parse(oe.AttribValue);
                        continue;
                    }
                    if (oe.AttribName == "Range")
                    {
                        continue;
                    }
                    if (oe.AttribName == "font")
                    {
                        if (doc1.Paragraphs[pn].Range.Font == doc2.Paragraphs[pn].Range.Font)
                            right++;
                        continue;
                    }
                    if (oe.AttribName == "Name")
                    {
                        if (doc1.Paragraphs[pn].Range.Font == doc2.Paragraphs[pn].Range.Font)
                            right++;
                        continue;
                    }
                    if (oe.AttribName == "Color")
                    {
                        if (doc1.Paragraphs[pn].Range.Font == doc2.Paragraphs[pn].Range.Font)
                            right++;
                        continue;
                    }
                    if (oe.AttribName == "Size")
                    {
                        if (doc1.Paragraphs[pn].Range.Font == doc2.Paragraphs[pn].Range.Font)
                            right++;
                        continue;
                    }
                    if (oe.AttribName == "Italic")
                    {
                        if (doc1.Paragraphs[pn].Range.Font == doc2.Paragraphs[pn].Range.Font)
                            right++;
                        continue;
                    }
                    if (oe.AttribName == "SpaceBefore")
                    {
                        if (doc1.Paragraphs[pn].Range.Font == doc2.Paragraphs[pn].Range.Font)
                            right++;
                        continue;
                    }

                    if (oe.AttribName == "Shadow")
                    {
                        if (doc1.Paragraphs[pn].Range.Font == doc2.Paragraphs[pn].Range.Font)
                            right++;
                        continue;
                    }
                    if (oe.AttribName == "Underline")
                    {
                        if (doc1.Paragraphs[pn].Range.Font == doc2.Paragraphs[pn].Range.Font)
                            right++;
                        continue;
                    }
                    if (oe.AttribName == "SpaceAfter")
                    {
                        if (doc1.Paragraphs[pn].Range.Font == doc2.Paragraphs[pn].Range.Font)
                            right++;
                        continue;
                    }
                    if (oe.AttribName == "Text")
                    {
                        if (doc1.Paragraphs[pn].Range.Text == doc2.Paragraphs[pn].Range.Text)
                            right++;
                        continue;
                    }
                    if (oe.AttribName == "LineSpacing")
                    {
                        if (doc1.Paragraphs[pn].LineSpacing == doc2.Paragraphs[pn].LineSpacing)
                            right++;
                        continue;
                    }

                    if (oe.AttribName == "FirstLineIndent")
                    {
                        if (doc1.Paragraphs[pn].FirstLineIndent == doc2.Paragraphs[pn].FirstLineIndent)
                            right++;
                        continue;
                    }

                    if (oe.AttribName == "Alignment")
                    {
                        if (doc1.Paragraphs[pn].Alignment == doc2.Paragraphs[pn].Alignment)
                            right++;
                        continue;
                    }
                    if (oe.AttribName == "Shading")
                    {
                        if (doc1.Paragraphs[pn].Shading == doc2.Paragraphs[pn].Shading)
                            right++;
                        continue;
                    }
                }  
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

   
