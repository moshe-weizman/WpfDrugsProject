using System.Collections.Generic;
using System.Linq;
using RestSharp;
using DataFormat = RestSharp.DataFormat;
using Newtonsoft.Json;
using System.Xml;

namespace Drugs2020.DAL
{
    public class DrugConflictTest: IDrugsConflict
    {

        public List<string> ConflictReq(string uri)
        {
            var client = new RestClient(uri);
            client.Timeout = -1;
            var request = new RestRequest(uri, DataFormat.Json);

            IRestResponse response = client.Execute(request);
            Root tagList = JsonConvert.DeserializeObject<Root>(response.Content);
            List<string> result = new List<string>();

            result.Add($"{tagList.fullInteractionTypeGroup.ElementAt(0).fullInteractionType.ElementAt(0).minConcept.ElementAt(0).name}");
            result.Add($"{tagList.fullInteractionTypeGroup.ElementAt(0).fullInteractionType.ElementAt(0).interactionPair.ElementAt(0).description}");
            return result;
        }

        public List<string> ConflictTest(string IdCodeOfNewDrug, List<string> drugsTakenPatient)
        {
            List<string> result = new List<string>();
            if ((drugsTakenPatient == null) || (drugsTakenPatient.Count() < 1))
                return result;

            for (int i = 0; i < drugsTakenPatient.Count(); i++)
            {
                if (IdCodeOfNewDrug != drugsTakenPatient[i])
                {
                    var uri = @"https://rxnav.nlm.nih.gov/REST/interaction/list.json?rxcuis=";
                    uri += IdCodeOfNewDrug;
                    uri += "+" + drugsTakenPatient.ElementAt(i);
                    
                    List<string> drogs = ConflictReq(uri);
                    if ((drogs.ElementAt(0) != null) && (drogs.ElementAt(1) != null))
                    {
                        result.Add(drogs.ElementAt(0));
                        result.Add(drogs.ElementAt(1));
                    }
                }
            }
            return result;
        }

       
        public int ResolveRxcuiFromName(string name)
        {
            XmlDocument drugsNums = new XmlDocument();
            drugsNums.Load("mainxml.xml");

            int result = 0;
            XmlElement root = drugsNums.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("minConcept"); // You can also use XPath here
            foreach (XmlNode node in nodes)
            {
                XmlNodeList properties = node.ChildNodes;
                if (properties[1].InnerText == name)
                {
                    result = int.Parse(properties[0].InnerText);
                    break;
                }
            }
            return result;
        }
    }

    #region helper class
    public class UserInput
    {
        public List<string> sources { get; set; }
        public List<string> rxcuis { get; set; }
    }

    public class MinConcept
    {
        public string rxcui { get; set; }
        public string name { get; set; }
        public string tty { get; set; }
    }

    public class MinConceptItem
    {
        public string rxcui { get; set; }
        public string name { get; set; }
        public string tty { get; set; }
    }

    public class SourceConceptItem
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class InteractionConcept
    {
        public MinConceptItem minConceptItem { get; set; }
        public SourceConceptItem sourceConceptItem { get; set; }
    }

    public class InteractionPair
    {
        public List<InteractionConcept> interactionConcept { get; set; }
        public string description { get; set; }
    }

    public class FullInteractionType
    {
        public string comment { get; set; }
        public List<MinConcept> minConcept { get; set; }
        public List<InteractionPair> interactionPair { get; set; }
    }

    public class FullInteractionTypeGroup
    {
        public string sourceDisclaimer { get; set; }
        public string sourceName { get; set; }
        public List<FullInteractionType> fullInteractionType { get; set; }
    }

    public class Root
    {
        public string nlmDisclaimer { get; set; }
        public UserInput userInput { get; set; }
        public List<FullInteractionTypeGroup> fullInteractionTypeGroup { get; set; }
    }
    #endregion
}