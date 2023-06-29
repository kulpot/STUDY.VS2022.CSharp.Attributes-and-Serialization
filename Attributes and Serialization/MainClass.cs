using System;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

//ref link:https://www.youtube.com/watch?v=sztfiRPDTjQ&list=PLRwVmtr-pp05brRDYXh-OTAIi-9kYcw3r&index=17
// Serialize C# to XML
// add reference: System.Runtime.Serialization

[DataContract]
class Person
{
    [DataMember]
    public string FirstName { get; set; }
    [DataMember]
    public string LastName { get; set; }
    [DataMember]
    //[DataMember(Name = "Weight")]
    public int Age { get; set; }
}

class MainClass
{
    static void Main()
    {
        var me = new Person
        {
            FirstName = "Kulpot",
            LastName = "King",
            Age = 25
        };
        var serializer = new DataContractSerializer(me.GetType());
        var someRam = new MemoryStream(); // File IO
        serializer.WriteObject(someRam, me);
        someRam.Seek(0, SeekOrigin.Begin);
        Console.WriteLine(
            XElement.Parse( // Linq Xelement
                Encoding.ASCII.GetString(
                    someRam.GetBuffer()).Replace("\0","")));
    }
}