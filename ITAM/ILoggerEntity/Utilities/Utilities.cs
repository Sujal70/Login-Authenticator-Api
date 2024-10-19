using System.Diagnostics;

namespace ConfigReader
{
    public static class ExtensionMethods
    {
        public static List<string> AddLog(this List<string> Messages, string value)
        {
            var caller = new StackTrace().GetFrame(1).GetMethod();
            string methodName = caller.Name;
            string className = caller.ReflectedType.Name;
            string layerName = caller.Module.Name;
            Messages.Add(value + "$" + DateTime.Now.ToString() + "$" + layerName.Substring(0, layerName.LastIndexOf('.')) + "$" + className + "$" + methodName);
            return Messages;
        }
    }

}

