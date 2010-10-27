 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Off = Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using OESXML;

namespace oesdemo
{
    public class Correct
    {

        public static int Correctppt(String path2, String path3)
        {

            OfficeXML oxml = new OfficeXML("test.xml");
            oxml.getAllAnsPath();

            PowerPoint.Application ppt2 = new Microsoft.Office.Interop.PowerPoint.ApplicationClass();
            PowerPoint.Application ppt3 = new Microsoft.Office.Interop.PowerPoint.ApplicationClass();


            PowerPoint.Presentation ppp2 = ppt2.Presentations.Open(path2, Off.MsoTriState.msoFalse, Off.MsoTriState.msoFalse, Off.MsoTriState.msoFalse);
            PowerPoint.Presentation ppp3 = ppt3.Presentations.Open(path3, Off.MsoTriState.msoFalse, Off.MsoTriState.msoFalse, Off.MsoTriState.msoFalse);


            int right = 0;
            int sln;
            int shn;

            foreach (List<OfficeElement> op in oxml.AnsPaths)
            {
                sln = 0;
                shn = 0;
                foreach (OfficeElement oe in op)
                {
                    if (oe.AttribName == "Presentation")
                    {
                        continue;
                    }

                    if (oe.AttribName == "Slides")
                    {
                        sln = int.Parse(oe.AttribValue);
                        continue;
                    }

                    if (oe.AttribName == "Shapes")
                    {
                        shn = int.Parse(oe.AttribValue);
                        continue;
                    }

                    if (oe.AttribName == "TextFrame")
                    {
                        continue;
                    }

                    if (oe.AttribName == "TextRange")
                    {
                        continue;
                    }

                    if (oe.AttribName == "Font")
                    {
                        continue;
                    }

                    if (oe.AttribName == "Text")
                    {
                        if (ppp2.Slides[sln].Shapes[shn].TextFrame.TextRange.Text == ppp3.Slides[sln].Shapes[shn].TextFrame.TextRange.Text)
                            right++;
                        continue;
                    }

                    if (oe.AttribName == "Name")
                    {
                        if (ppp2.Slides[sln].Shapes[shn].TextFrame.TextRange.Font.Name == ppp3.Slides[sln].Shapes[shn].TextFrame.TextRange.Font.Name)
                            right++;
                        continue;
                    }

                    if (oe.AttribName == "Bold")
                    {
                        if (ppp2.Slides[sln].Shapes[shn].TextFrame.TextRange.Font.Bold == ppp3.Slides[sln].Shapes[shn].TextFrame.TextRange.Font.Bold)
                            right++;
                        continue;
                    }

                    if (oe.AttribName == "Italic")
                    {
                        if (ppp2.Slides[sln].Shapes[shn].TextFrame.TextRange.Font.Italic == ppp3.Slides[sln].Shapes[shn].TextFrame.TextRange.Font.Italic)
                            right++;
                        continue;
                    }

                    if (oe.AttribName == "Size")
                    {
                        if (ppp2.Slides[sln].Shapes[shn].TextFrame.TextRange.Font.Size == ppp3.Slides[sln].Shapes[shn].TextFrame.TextRange.Font.Size)
                            right++;
                        continue;
                    }

                    if (oe.AttribName == "Color")
                    {
                        if (ppp2.Slides[sln].Shapes[shn].TextFrame.TextRange.Font.Color == ppp3.Slides[sln].Shapes[shn].TextFrame.TextRange.Font.Color)
                            right++;
                        continue;
                    }

                    if (oe.AttribName == "Underline")
                    {
                        if (ppp2.Slides[sln].Shapes[shn].TextFrame.TextRange.Font.Underline == ppp3.Slides[sln].Shapes[shn].TextFrame.TextRange.Font.Underline)
                            right++;
                        continue;
                    }

                    if (oe.AttribName == "Hyperlinks")
                    {
                        for (int hn = 1; hn <= ppp2.Slides[sln].Hyperlinks.Count; hn++)
                        {
                            if (hn <= ppp3.Slides[sln].Hyperlinks.Count)
                            {
                                if (ppp2.Slides[sln].Hyperlinks[hn].SubAddress == ppp3.Slides[sln].Hyperlinks[hn].SubAddress)
                                    right++;
                            }
                        }
                        continue;
                    }

                    if (oe.AttribName == "TemplateName")
                    {
                        if (ppp2.TemplateName == ppp3.TemplateName)
                            right++;
                        continue;
                    }

                    if (oe.AttribName == "Layout")
                    {
                        if (ppp2.Slides[sln].Layout == ppp3.Slides[sln].Layout)
                            right++;
                        continue;
                    }

                    if (oe.AttribName == "BackColor")
                    {
                        if (ppp2.Slides[sln].Background.Fill.BackColor.RGB == ppp3.Slides[sln].Background.Fill.BackColor.RGB)
                            right++;
                        continue;
                    }

                    if (oe.AttribName == "Commentstext")
                    {
                        for (int cn = 1; cn <= ppp2.Slides[sln].Comments.Count; cn++)
                        {
                            if (cn <= ppp3.Slides[sln].Comments.Count)
                            {
                                if (ppp2.Slides[sln].Comments[cn].Text == ppp3.Slides[sln].Comments[cn].Text)
                                    right++;
                            }
                        }
                        continue;
                    }


                    }
                }
                ppp2.Close();
                ppp3.Close();

                ppt2.Quit();
                ppt3.Quit();  
                return right;              

            }
          

    }


}

   
