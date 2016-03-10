namespace DynamicXmlBuilderTest
{
    using System;

    using DynamicXmlBuilder;

    public class Program
    {
        public static void Main()
        {
            string xml = XmlBuilder.Create()
                .Customer._b_
                    .Name("Alexander", new { id = "unikat", change = "clickni" })
                    .Phone("0888-000-000")
                    .Address._b_
                        .Street("Kanala", new { @class = "css bate" })
                        .City("Sofia")
                        .Zip("Zip")
                    ._d_
                ._d_
                .Build();

            Console.WriteLine(xml);
        }
    }
}
