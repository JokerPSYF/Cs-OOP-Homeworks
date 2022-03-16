using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigatedClass);

            FieldInfo[] classFields = classType.GetFields((BindingFlags)60);

            StringBuilder stringBuilder = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            stringBuilder.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
            {
                stringBuilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return stringBuilder.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);

            FieldInfo[] classFields = classType.GetFields((BindingFlags) 28);

            MethodInfo[] classpublicMethods = classType.GetMethods((BindingFlags) 20);

            MethodInfo[] classPrivateMethods = classType.GetMethods((BindingFlags) 36);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (FieldInfo field in classFields)
            {
                stringBuilder.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo method in classPrivateMethods.Where(m => m.Name.StartsWith("get")))
            {
                stringBuilder.AppendLine($"{method.Name} have to be public!");
            }

            foreach (MethodInfo method in classpublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                stringBuilder.AppendLine($"{method.Name} have to be private!");
            }

            return stringBuilder.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);

            MethodInfo[] classPrivateMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"All Private Methods of Class: {className}");

            stringBuilder.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (MethodInfo method in classPrivateMethods)
            {
                stringBuilder.AppendLine(method.Name);
            }

            return stringBuilder.ToString().Trim();
        }

        public string CollectGettersAnSetters(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);

            MethodInfo[] classmethods = classType.GetMethods((BindingFlags) 60);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (MethodInfo method in classmethods.Where(m => m.Name.StartsWith("get")))
            {
                stringBuilder.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in classmethods.Where(m => m.Name.StartsWith("set")))
            {
                stringBuilder.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            return stringBuilder.ToString().Trim();
        }
    }
}