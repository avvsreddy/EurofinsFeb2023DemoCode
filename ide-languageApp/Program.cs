using System.Collections.Generic;

namespace ide_languageApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDE ide = new IDE();
            ide.Languages.Add(new LangCSharp());
            ide.Languages.Add(new LangJava());
            ide.Languages.Add(new LangC());

            ide.WorkWithLanguages();
        }
    }


    interface ILanguage
    {
        string GetName();
        string GetUnit();
        string GetParadigm();
    }

    class IDE
    {
        //public LangJava Java { get; set; }
        //public LangCSharp CSharp { get; set; }
        //public LangC C { get; set; }

        public List<ILanguage> Languages { get; set; } = new List<ILanguage>();

        public void WorkWithLanguages()
        {
            foreach (ILanguage language in Languages)
            {
                System.Console.WriteLine(language.GetName());
                System.Console.WriteLine(language.GetUnit());
                System.Console.WriteLine(language.GetParadigm());
                System.Console.WriteLine("---------------");
            }

            //System.Console.WriteLine(CSharp.GetName());
            //System.Console.WriteLine(CSharp.GetUnit());
            //System.Console.WriteLine(CSharp.GetParadigm());
            //System.Console.WriteLine("---------------");
            //System.Console.WriteLine(C.GetName());
            //System.Console.WriteLine(C.GetUnit());
            //System.Console.WriteLine(C.GetParadigm());
        }
    }


    abstract class OOLanguage : ILanguage
    {
        public abstract string GetName();


        public string GetUnit()
        {
            return "Class";
        }
        public string GetParadigm()
        {
            return "Object Oriented";
        }
    }

    abstract class ProcLanguage : ILanguage
    {
        public abstract string GetName();

        public string GetUnit()
        {
            return "Function";
        }
        public string GetParadigm()
        {
            return "Procedural Oriented";
        }

    }

    class LangJava : OOLanguage
    {
        public override string GetName()
        {
            return "Java";
        }

    }
    class LangCSharp : OOLanguage
    {
        public override string GetName()
        {
            return "CSharp";
        }

    }
    class LangC : ProcLanguage
    {
        public override string GetName()
        {
            return "C Language";
        }

    }
}
