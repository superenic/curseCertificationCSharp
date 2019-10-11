using ProgramingInCSharp.Contract;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProgramingInCSharp.Diagnostic
{
    class CreateClassByCode : ICommand
    {
        public string Description => "Create a instance class by coding.";

        private string generateCode()
        {
            CodeCompileUnit compileUnit = new CodeCompileUnit();

            // Create a namespace to hold the types we are going to create
            CodeNamespace personnelNameSpace = new CodeNamespace("Personnel");

            // Import the system namespace
            personnelNameSpace.Imports.Add(new CodeNamespaceImport("System"));
            // Create a Person class
            CodeTypeDeclaration personClass = new CodeTypeDeclaration("Person");
            personClass.IsClass = true;
            personClass.TypeAttributes = System.Reflection.TypeAttributes.Public;

            // Add the Person class to personnelNamespace
            personnelNameSpace.Types.Add(personClass);

            // Create a field to hold the name of a person
            CodeMemberField nameField = new CodeMemberField("String", "name");
            nameField.Attributes = MemberAttributes.Private;

            // Add the name field to the Person class
            personClass.Members.Add(nameField);

            // Add the namespace to the document
            compileUnit.Namespaces.Add(personnelNameSpace);

            // Now we need to send our document somewhere
            // Create a provider to parse the document
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            // Give the provider somewhere to send the parsed output
            StringWriter stringWriter = new StringWriter();
            // Set some options for the parse - we can use the defaults
            CodeGeneratorOptions options = new CodeGeneratorOptions();

            // Generate the C# source from the CodeDOM
            provider.GenerateCodeFromCompileUnit(compileUnit, stringWriter, options);
            // Close the output stream
            stringWriter.Close();

            // Print the C# output
            return stringWriter.ToString();
        }

        public void StartCommand()
        {
            generateCode();

            Console.ReadKey();
        }
    }
}
