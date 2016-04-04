using System;
using System.Collections.Generic;
using System.Reflection;

namespace SztucznaInteligencja
{
    public class HCloner
    {
        public static T DeepCopy<T>(T sourceObj)
        {
            if (sourceObj == null)
                throw new ArgumentNullException("Object cannot be null");
            return (T) Process(sourceObj, new Dictionary<object, object>() {});
        }

        private static object Process(object sourceObj, Dictionary<object, object> circular)
        {
            if (sourceObj == null)
                return null;
            Type type = sourceObj.GetType();
            if (type.IsValueType || type == typeof (string))
            {
                return sourceObj;
            }
            if (type.IsArray)
            {
                if (circular.ContainsKey(sourceObj))
                    return circular[sourceObj];
                string typeNoArray = type.FullName.Replace("[]", string.Empty);
                Type elementType = Type.GetType(typeNoArray + ", " + type.Assembly.FullName);
                var array = sourceObj as Array;
                Array copied = Array.CreateInstance(elementType, array.Length);
                circular[sourceObj] = copied;
                for (int i = 0; i < array.Length; i++)
                {
                    object element = array.GetValue(i);
                    object copy = null;
                    if (element != null && circular.ContainsKey(element))
                        copy = circular[element];
                    else
                        copy = Process(element, circular);
                    copied.SetValue(copy, i);
                }
                return Convert.ChangeType(copied, sourceObj.GetType());
            }
            if (type.IsClass)
            {
                if (circular.ContainsKey(sourceObj))
                    return circular[sourceObj];
                object toret = Activator.CreateInstance(sourceObj.GetType());
                circular[sourceObj] = toret;
                FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (FieldInfo field in fields)
                {
                    object fieldValue = field.GetValue(sourceObj);
                    if (fieldValue == null)
                        continue;
                    object copy = circular.ContainsKey(fieldValue)
                        ? circular[fieldValue]
                        : Process(fieldValue, circular);
                    field.SetValue(toret, copy);
                }
                return toret;
            }
            else
                throw new ArgumentException("Unknown type");
        }
 
    }
}