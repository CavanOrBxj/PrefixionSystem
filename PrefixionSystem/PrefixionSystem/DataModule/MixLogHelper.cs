using System;
using System.Diagnostics;

namespace PrefixionSystem
{
    public class MixLogHelper
    {

        public static void Info(string className, string msg)
        {
            string content = DateTime.Now + "  " + className + "(Info)：" + msg;
            Trace.WriteLine(content);
        }

        public static void Debug(string className, string msg)
        {
            string content = DateTime.Now + "  " + className + "(Debug)：" + msg;
            Trace.WriteLine(content);
        }

        public static void Error(string className, string msg)
        {
            string content = DateTime.Now + "  " + className + "(Exception)：" + msg;
            Trace.WriteLine(content);
        }

        public static void Error(string className, string msg, string stackTrace)
        {
            string content = DateTime.Now + "  " + className + "(Exception)：" + msg;
            Trace.WriteLine(content);
            Trace.WriteLineIf(stackTrace != null, stackTrace);
        }
    }
}
