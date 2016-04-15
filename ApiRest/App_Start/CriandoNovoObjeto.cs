using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ApiRest.App_Start
{
    public class CriandoNovoObjeto
    {
        public static object Criar<T>(T b, string[] fields) where T : class
        {
            var dicionario = new Dictionary<string, Type>();

            foreach (var nameField in fields)
            {
                FieldInfo fieldInfo = b.GetType().GetField(nameField);
                
                dicionario.Add(fieldInfo.Name, fieldInfo.GetValue(b).GetType());
            }

            var objectBuilder = new ObjectBuilder()
            {
                Fields = dicionario
            };
            objectBuilder.CreateNewObject();
            return objectBuilder.MyObject;
        }
    }
}