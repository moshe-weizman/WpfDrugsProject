using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.BLL
{
    class CheckConflicts
    {
//        static XmlDocument drugsNums = new XmlDocument();
//        static void Main(string[] args)
//        {
//            LoadDrugsList();
//            string result = string.Empty;

//            string drugName = string.Empty;
//            do
//            {
//                Console.WriteLine("Enter drug name: ");
//                drugName = Console.ReadLine();
//                try
//                {
//                    int drugNum = ResolveRxcuiFromName(drugName);
//                    string interactionJsonString = HttpRequest(GenerateURL(drugNum));
//                    Root interactionObj = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(interactionJsonString);
//                    if (interactionObj.interactionTypeGroup != null)
//                    {
//                        Console.WriteLine("Interaction drugs:");
//                        foreach (var item in interactionObj.interactionTypeGroup)
//                        {
//                            foreach (var item1 in item.interactionType)
//                            {
//                                foreach (var item2 in item1.interactionPair)
//                                {
//                                    foreach (var item3 in item2.interactionConcept)
//                                    {
//                                        if (item3.sourceConceptItem.name != drugName)
//                                        {
//                                            Console.WriteLine(item3.sourceConceptItem.name);
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                    }
//                    else
//                    {
//                        Console.WriteLine("No interaction for this drug.");
//                    }
//                }
//                catch
//                {
//                    Console.WriteLine("Error");
//                }
//            } while (true);
//            Console.WriteLine(result);
//        }
//        public static int ResolveRxcuiFromName(string name)
//        {
//            int result = 0;
//            XmlElement root = drugsNums.DocumentElement;
//            XmlNodeList nodes = root.SelectNodes("minConcept"); // You can also use XPath here
//            foreach (XmlNode node in nodes)
//            {
//                XmlNodeList properties = node.ChildNodes;
//                if (properties[1].InnerText == name)
//                {
//                    result = int.Parse(properties[0].InnerText);
//                    break;
//                }
//            }
//            return result;
//        }

//        public static void LoadDrugsList()
//        {
//            drugsNums.Load("mainxml.xml");
//        }


//        public static string HttpRequest(String url)
//        {

//            string html = string.Empty;
//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
//            request.AutomaticDecompression = DecompressionMethods.GZip;

//            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
//            using (Stream stream = response.GetResponseStream())
//            using (StreamReader reader = new StreamReader(stream))
//            {
//                html = reader.ReadToEnd();
//            }
//            return html;
//        }

//        public static string GenerateURL(int drugNum)
//        {
//            string first = @"https://rxnav.nlm.nih.gov/REST/interaction/interaction.json?rxcui=";
//            string second = @"&sources=ONCHigh";
//            return first + drugNum.ToString() + second;
//        }

//        public class UserInput
//        {
//            public List<string> sources { get; set; }
//            public string rxcui { get; set; }
//        }

//        public class MinConceptItem
//        {
//            public string rxcui { get; set; }
//            public string name { get; set; }
//            public string tty { get; set; }
//        }

//        public class MinConceptItem2
//        {
//            public string rxcui { get; set; }
//            public string name { get; set; }
//            public string tty { get; set; }
//        }

//        public class SourceConceptItem
//        {
//            public string id { get; set; }
//            public string name { get; set; }
//            public string url { get; set; }
//        }

//        public class InteractionConcept
//        {
//            public MinConceptItem2 minConceptItem { get; set; }
//            public SourceConceptItem sourceConceptItem { get; set; }
//        }

//        public class InteractionPair
//        {
//            public List<InteractionConcept> interactionConcept { get; set; }
//            public string severity { get; set; }
//            public string description { get; set; }
//        }

//        public class InteractionType
//        {
//            public string comment { get; set; }
//            public MinConceptItem minConceptItem { get; set; }
//            public List<InteractionPair> interactionPair { get; set; }
//        }

//        public class InteractionTypeGroup
//        {
//            public string sourceDisclaimer { get; set; }
//            public string sourceName { get; set; }
//            public List<InteractionType> interactionType { get; set; }
//        }

//        public class Root
//        {
//            public string nlmDisclaimer { get; set; }
//            public UserInput userInput { get; set; }
//            public List<InteractionTypeGroup> interactionTypeGroup { get; set; }
//        }


//    }
}
}
