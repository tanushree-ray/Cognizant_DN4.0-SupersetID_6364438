using System;

interface IDoc
{
    void Open();
}

class Word : IDoc
{
    public void Open() => Console.WriteLine("Opening Word Document");
}

class PDF : IDoc
{
    public void Open() => Console.WriteLine("Opening PDF Document");
}

class Excel : IDoc
{
    public void Open() => Console.WriteLine("Opening Excel Document");
}

abstract class DocFactory
{
    public abstract IDoc Create();
}

class WordFactory : DocFactory
{
    public override IDoc Create() => new Word();
}

class PDFFactory : DocFactory
{
    public override IDoc Create() => new PDF();
}

class ExcelFactory : DocFactory
{
    public override IDoc Create() => new Excel();
}

class Program
{
    static void Main()
    {
        IDoc doc1 = new WordFactory().Create();
        IDoc doc2 = new PDFFactory().Create();
        IDoc doc3 = new ExcelFactory().Create();

        doc1.Open();
        doc2.Open();
        doc3.Open();
    }
}
