using ProgramingInCSharp.Contract;
using ProgramingInCSharp.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProgramingInCSharp.ValuesAndReferences
{
    [AttributeUsage(AttributeTargets.Class)]
    class ProgrammerAttribute : Attribute
    {
        private string programmerValue;

        public ProgrammerAttribute(string programmer)
        {
            programmerValue = programmer;
        }

        public string Programmer
        {
            get
            {
                return programmerValue;
            }
        }
    }

    class AnnotationStudy : ICommand
    {
        public string Description => "Annotation estrategic";

        public void StartCommand()
        {
            ValidatePersonIsSerializableAnnotation();
            printAttribute();
            printType();
            printMembers();
            setNameByReflection();
            getAssambly();
            // Assembly bankTypes = Assembly.Load("BankTypes.dll");

            Console.ReadKey();
        }

        private static void getAssambly()
        {
            //Assembly thisAssembly = Assembly.GetExecutingAssembly();

            //List<Type> AccountTypes = new List<Type>();

            //foreach (Type t in thisAssembly.GetTypes())
            //{
            //    if (t.IsInterface)
            //        continue;

            //    if (typeof(IAccount).IsAssignableFrom(t))
            //    {
            //        AccountTypes.Add(t);
            //    }
            //}
        }

        private static void setNameByReflection()
        {
            System.Type type;

            Person p = new Person();
            type = p.GetType();

            MethodInfo setMethod = type.GetMethod("set_Name");
            setMethod.Invoke(p, new object[] { "Fred" });

            Console.WriteLine("Se name by reflection" + p.Name);
        }

        private static void printMembers()
        {
            System.Type type;

            Person p = new Person();
            type = p.GetType();

            foreach (MemberInfo member in type.GetMembers())
            {
                Console.WriteLine(member.ToString());
            }
        }

        private static void printType()
        {
            System.Type type;
            Person person = new Person();
            type = person.GetType();
            Console.WriteLine("Person type: {0}", type.ToString());
        }

        private static void printAttribute()
        {
            Attribute a = Attribute.GetCustomAttribute(typeof(Person),
                            typeof(ProgrammerAttribute));
            ProgrammerAttribute p = (ProgrammerAttribute)a;
            Console.WriteLine("Programmer: {0}", p.Programmer);
        }

        private static void ValidatePersonIsSerializableAnnotation()
        {
            if (Attribute.IsDefined(typeof(Person), typeof(SerializableAttribute)))
                Console.WriteLine("Person can be serialized");
        }
    }
}
