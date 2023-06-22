using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
public class CSVEntry
{
    public string ID;
    public string Topico;
    public string Categoria;
    public string Titulo;
    public string Texto;
    
    public string Imagem_1;
    public string Legenda_1;
    
    public string Imagem_2;
    public string Legenda_2;

    public string Imagem_3;
    public string Legenda_3;
    
    public string Imagem_4;
    public string Legenda_4;
    
    public string Imagem_5;
    public string Legenda_5;
}

public class CSVFileMap : ClassMap<CSVEntry>
{
    public CSVFileMap()
    {
        Map(m => m.ID).Name("ID");
        Map(m => m.Topico).Name("Tópico");
        Map(m => m.Categoria).Name("Categoria");
        Map(m => m.Titulo).Name("Titulo");
        Map(m => m.Texto).Name("Texto");
        Map(m => m.Imagem_1).Name("Imagem_1");
        Map(m => m.Legenda_1).Name("Legenda_1");
        Map(m => m.Imagem_2).Name("Imagem_2");
        Map(m => m.Legenda_2).Name("Legenda_2");
        Map(m => m.Imagem_3).Name("Imagem_3");
        Map(m => m.Legenda_3).Name("Legenda_3");
        Map(m => m.Imagem_4).Name("Imagem_4");
        Map(m => m.Legenda_4).Name("Legenda_4");
        Map(m => m.Imagem_5).Name("Imagem_5");
        Map(m => m.Legenda_5).Name("Legenda_5");
    }
}