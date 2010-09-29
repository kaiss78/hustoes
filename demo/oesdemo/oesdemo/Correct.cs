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

namespace oesdemo
{
    public class Correct
    {

        public static int Correctppt(String path1, String path2, String path3)
        {
            
            PowerPoint.Application ppt1 = new Microsoft.Office.Interop.PowerPoint.ApplicationClass();
            PowerPoint.Application ppt2 = new Microsoft.Office.Interop.PowerPoint.ApplicationClass();
            PowerPoint.Application ppt3 = new Microsoft.Office.Interop.PowerPoint.ApplicationClass();
           
            PowerPoint.Presentation ppp1 = ppt1.Presentations.Open(path1, Off.MsoTriState.msoFalse, Off.MsoTriState.msoFalse, Off.MsoTriState.msoFalse);
            PowerPoint.Presentation ppp2 = ppt2.Presentations.Open(path2, Off.MsoTriState.msoFalse, Off.MsoTriState.msoFalse, Off.MsoTriState.msoFalse);
            PowerPoint.Presentation ppp3 = ppt3.Presentations.Open(path3, Off.MsoTriState.msoFalse, Off.MsoTriState.msoFalse, Off.MsoTriState.msoFalse);

            PowerPoint.TextRange pptRange1;
            PowerPoint.TextRange pptRange2;
            PowerPoint.TextRange pptRange3;
            int i=0;
            int right=0;
            foreach (PowerPoint.Slide s in ppp1.Slides)
            {
                int j = 0;
                i++;
                if (s.SlideShowTransition.EntryEffect !=ppp3.Slides[s.SlideNumber].SlideShowTransition.EntryEffect)
                {
                    if (ppp2.Slides[s.SlideNumber].SlideShowTransition.EntryEffect == ppp3.Slides[s.SlideNumber].SlideShowTransition.EntryEffect)
                        right++;
                }
                    foreach (PowerPoint.Shape ss in s.Shapes)
                    {
                        j++;
                        if (ss.TextFrame.HasText != Off.MsoTriState.msoFalse)
                        {
                            pptRange1 = ppp1.Slides[i].Shapes[j].TextFrame.TextRange;
                            pptRange2 = ppp2.Slides[i].Shapes[j].TextFrame.TextRange;
                            pptRange3 = ppp3.Slides[i].Shapes[j].TextFrame.TextRange;

                            if (pptRange1.Font.Name != pptRange3.Font.Name)
                            {
                                if (pptRange2.Font.Name == pptRange3.Font.Name)
                                    right++;
                            }

                            if (pptRange1.Font.Bold != pptRange3.Font.Bold)
                            {
                                if (pptRange2.Font.Bold == pptRange3.Font.Bold)

                                    right++;
                            }

                            if (pptRange1.Font.Size != pptRange3.Font.Size)
                            {
                                if (pptRange2.Font.Size == pptRange3.Font.Size)

                                    right++;
                            }

                            if (pptRange1.Text != pptRange3.Text)
                            {
                                if (pptRange2.Text == pptRange3.Text)

                                    right++;
                            }

                            if (pptRange1.Font.Color.RGB != pptRange3.Font.Color.RGB)
                            {
                                if (pptRange2.Font.Color.RGB == pptRange3.Font.Color.RGB)
                                    right++;
                            }

                            if (ppp1.Slides[i].Shapes[j].AnimationSettings.EntryEffect != ppp3.Slides[i].Shapes[j].AnimationSettings.EntryEffect)
                            {
                                if (ppp2.Slides[i].Shapes[j].AnimationSettings.EntryEffect == ppp3.Slides[i].Shapes[j].AnimationSettings.EntryEffect)

                                    right++;
                            }
                           
                        }
           
                    }

            }
            ppp1.Close();
            ppp2.Close();
            ppp3.Close();
            ppt1.Quit();
            ppt2.Quit();
            ppt3.Quit();
            return right;

            }


        }

       
}

   
