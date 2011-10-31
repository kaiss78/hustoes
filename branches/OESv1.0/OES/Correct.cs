using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using Off = Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using OESXML;
using System.Diagnostics;
using System.IO;

namespace OES
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

        public static int Correctword(String path2, String path3)
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
            int i = 0;
            int pn = 0;
            int right = 0;
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

        public static void correctPF(string path)   //程序综合题评分(不完整)
        {
            string clPath = FindVC();
            string st, name;
            Process cmd = new Process();
            FileInfo cpppath =new FileInfo(path);

            if (clPath != "")
            {                                
                cmd.StartInfo.FileName = "cmd.exe";//***

                cmd.StartInfo.UseShellExecute = false; //此处必须为false否则引发异常
                cmd.StartInfo.RedirectStandardInput = true; //标准输入
                cmd.StartInfo.RedirectStandardOutput = true; //标准输出            
                cmd.StartInfo.CreateNoWindow = true;//不显示命令行窗口界面            
                cmd.Start(); //启动进程
                cmd.StandardInput.WriteLine(clPath[1]+":");
                cmd.StandardInput.WriteLine("cd " + clPath);   //编译生成.exe文件
                cmd.StandardInput.WriteLine("VCVARS32.BAT");
                cmd.StandardInput.WriteLine(cpppath.DirectoryName[0]+":");
                cmd.StandardInput.WriteLine("cd " + cpppath.DirectoryName);
                cmd.StandardInput.WriteLine("cl " + cpppath.Name);
                name = (cpppath.Name.Split('.'))[0] + ".exe";                
                cmd.StandardInput.WriteLine("Exit");
                //MessageBox.Show("输出结果为：" + cmd.StandardOutput.ReadToEnd());
                cmd.WaitForExit();//等待控制台程序执行完成
                cmd.Close();//关闭该进程
                
                cmd.StartInfo.FileName = cpppath.DirectoryName + "\\" + name;
                cmd.Start();
                ClientControl.paper.pFunction.inp1 = "";
                cmd.StandardInput.WriteLine(ClientControl.paper.pFunction.inp1);
                MessageBox.Show("输出结果为：" + cmd.StandardOutput.ReadToEnd());
                cmd.WaitForExit();//等待控制台程序执行完成
                cmd.Close();//关闭该进程

            }
        }

        private static string GetText(String path)  //获得path路径下文件的内容
        {
            string text = "";
            if (path.Length > 0)
            {
                StreamReader TxtReader = new StreamReader(path);
                text = TxtReader.ReadToEnd();
                TxtReader.Close();
            }
            return text;
        } 

        public static void correctPC(string path)
        {
            string cpptext, st;
            int i;
            cpptext = Correct.GetText(path);
            string[] str = cpptext.Split('\n');
            i = 0;
            while (i < str.Length)
            {
                if (str[i].IndexOf(@"//") >= 0)
                {
                    st = str[i + 1];
                    i = i + 2;
                    while ((st[0] == '\t') || (st[0] == ' '))
                    {
                        st = st.Remove(0, 1);
                    }
                    while ((st.Length > 0) && ((st[st.Length - 1] == '\t') || (st[st.Length - 1] == '\r')))
                    {
                        st = st.Remove(st.Length - 1, 1);
                        //MessageBox.Show((st[st.Length - 1] == '\r').ToString());
                    }
                    MessageBox.Show("{" + st + "}");
                }
                else
                {
                    i++;
                }
            }

        }

        public static string FindVC()   //获取安装软件和路径，通过注册表得到。实例代码：
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall", false);
            {
                if (key != null)//判断对象存在
                {
                    foreach (string keyName in key.GetSubKeyNames())//遍历子项名称的字符串数组
                    {
                        using (RegistryKey key2 = key.OpenSubKey(keyName, false))//遍历子项节点
                        {
                            if (key2 != null)
                            {
                                string softwareName = key2.GetValue("DisplayName", "").ToString();//获取软件名
                                string installLocation = key2.GetValue("UninstallString", "").ToString();//获取安装路径
                                if (softwareName.Contains("Microsoft Visual C++ 6.0") == true)
                                {
                                    installLocation = installLocation.Remove(installLocation.IndexOf("Setup"));                                    
                                    return installLocation + @"Bin\";
                                }                                
                            }
                        }
                    }
                }
            }
            return "";
        }
    }
}


