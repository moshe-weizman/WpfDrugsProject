﻿using System.Collections.Generic;
using System.Linq;

using RestSharp;
using DataFormat = RestSharp.DataFormat;
using Newtonsoft.Json;

namespace Drugs2020.DAL
{
    public class DrugConflictTest
    {
        public string ConflictTest(List<string> drugsTakenPatient)
        {
            if ((drugsTakenPatient==null) ||(drugsTakenPatient.Count() < 2))
                return null;

            var uri = @"https://rxnav.nlm.nih.gov/REST/interaction/list.json?rxcuis=";
            for (int i = 0; i < drugsTakenPatient.Count(); i++)
            {
                uri += (i==0?"":"+") + drugsTakenPatient.ElementAt(i);
            }
           // var uri = @"https://rxnav.nlm.nih.gov/REST/interaction/list.json?rxcuis=207106+152923+656659";

            var client = new RestClient(uri);
            client.Timeout = -1;
            var request = new RestRequest(uri, DataFormat.Json);

            IRestResponse response = client.Execute(request);
            Root tagList = JsonConvert.DeserializeObject<Root>(response.Content);

            //resultText.Text = response.Content;

            //resultText.Text = drog1.Text + drog2.Text + drog3.Text;
            string resultText = "";
            foreach (var item1 in tagList.fullInteractionTypeGroup.ElementAt(0).fullInteractionType)
            {
                resultText += "drogs:";
                resultText += "\n";
                foreach (var item2 in item1.minConcept)
                {
                    resultText += ($"{item2.name}");
                    resultText += "\n";
                }
                resultText += "\n";
                resultText += "problem:";
                resultText += "\n";
                foreach (var item2 in item1.interactionPair)
                {
                    resultText += ($"{item2.description}");
                }
                resultText += "\n";
                resultText += "\n";

            }
            return resultText;
        }

    }

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

}