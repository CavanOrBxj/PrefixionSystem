using System;
using System.Linq;
using System.IO;
using MSWord = Microsoft.Office.Interop.Word;

namespace PrefixionSystem.DataModule
{
    class CreatWord
    {
        public static string CreateWordFile(string fielpath,string content)
        {
            string message = "";
            try
            {
                object path;                              //文件路径变量
                string strContent;                        //文本内容变量
                Object Nothing = System.Reflection.Missing.Value;
                object filename = fielpath;  //文件保存路径
               // path = Environment.CurrentDirectory + "\\CNSI_" + DateTime.Now.ToLongDateString() + ".doc";
                //创建Word文档
                Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                Microsoft.Office.Interop.Word.Document WordDoc = WordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);


                #region 行间距与缩进、文本字体、字号、加粗、斜体、颜色、下划线、下划线颜色设置
                WordApp.Selection.ParagraphFormat.LineSpacing = 16f;//设置文档的行间距
               // WordApp.Selection.ParagraphFormat.FirstLineIndent = 80;//首行缩进的长度
              
                object unite = MSWord.WdUnits.wdStory;
                WordApp.Selection.EndKey(ref unite, ref Nothing);//将光标移到文本末尾
                WordApp.Selection.ParagraphFormat.FirstLineIndent = 30;//取消首行缩进的长度
                strContent = "江津区应急广播消息文本\n";
                WordDoc.Paragraphs.Last.Range.Font.Name = "微软雅黑";
                WordDoc.Paragraphs.Last.Range.Font.Size = 20;
                WordDoc.Paragraphs.Last.Range.Text = strContent;


                WordApp.Selection.ParagraphFormat.LineSpacing = 10f;//设置文档的行间距
                WordApp.Selection.ParagraphFormat.FirstLineIndent = 100;//取消首行缩进的长度
                strContent = content+"\n"; //
                WordApp.Selection.EndKey(ref unite, ref Nothing);//这一句不加，有时候好像也不出问题，不过还是加了安全
                WordDoc.Paragraphs.Last.Range.Font.Size = 15;
                WordDoc.Paragraphs.Last.Range.Text = strContent;
             
                #endregion

                object count = 14;
                object WdLine = Microsoft.Office.Interop.Word.WdUnits.wdLine;//换一行;
                WordApp.Selection.MoveDown(ref WdLine, ref count, ref Nothing);//移动焦点
                WordApp.Selection.TypeParagraph();//插入段落
                WordDoc.Paragraphs.Last.Range.Text = "文档创建时间：" + DateTime.Now.ToString();//“落款”
                WordDoc.Paragraphs.Last.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;

                //看是不是要打印
                //wordDoc.PrintOut();

                //文件保存
                WordDoc.SaveAs(ref filename, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                WordDoc.Close(ref Nothing, ref Nothing, ref Nothing);
                WordApp.Quit(ref Nothing, ref Nothing, ref Nothing);
                Console.WriteLine("文档生成成功!");

                #region//再次打开这个文档
                // MSWord.Application app = new MSWord.Application();
                // MSWord.Document doc = null;
                // try
                // {
                //    object unknow = Type.Missing;
                //    app.Visible = true;
                //    string str = Environment.CurrentDirectory + "\\MyWord_Print.doc";
                //    object file = str;
                //    doc = app.Documents.Open(ref file,
                //        ref unknow, ref unknow, ref unknow, ref unknow,
                //        ref unknow, ref unknow, ref unknow, ref unknow,
                //        ref unknow, ref unknow, ref unknow, ref unknow,
                //        ref unknow, ref unknow, ref unknow);
                //    string temp = doc.Paragraphs[1].Range.Text.Trim();
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
                //WordDoc = doc;
                //WordDoc.Paragraphs.Last.Range.Text += "我真的不打算再写了,就写这么多吧";
                #endregion
            }
            catch (Exception ex)
            {
                message = "保存失败！";
                Console.WriteLine(ex.Message);
            }
            return message;
        }
    }
}
