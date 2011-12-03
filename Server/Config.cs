using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using System.Configuration;
using System.Windows.Forms;
using System.Xml.Linq;
using System.ComponentModel;

namespace ServiceHost_Form
{
    class Config
    {
        private const string ContractName = "ServiceLibrary.IService";

        public static string ServerMapPath(string subPath)
        {
            return Application.StartupPath.Replace(@"bin\Debug", "") + subPath;
        }

        public static BindingList<Endpoint> GetListConfigEnpoint()
        {
            XDocument configDoc = XDocument.Load(ServerMapPath("App.config"));
            XElement servicesNode = configDoc.Root.Element("system.serviceModel")
                .Element("services").Element("service");
            BindingList<Endpoint> resultList = new BindingList<Endpoint>();
            foreach (XElement endpointNode in servicesNode.Elements("endpoint"))
            {
                string address = endpointNode.Attribute("address").Value;
                string binding = endpointNode.Attribute("binding").Value;
                resultList.Add(new Endpoint(address, binding));
            }
            return resultList;
        }
        public static void SaveEndpointAddressLinQ(BindingList<Endpoint> endpointList)
        {
            XDocument configDoc = XDocument.Load(ServerMapPath("App.config"));
            XElement servicesNode = configDoc.Root.Element("system.serviceModel")
                .Element("services").Element("service");

            servicesNode.Elements("endpoint").Remove();//Delete all <endpoint>
            foreach (Endpoint item in endpointList)
            {
                XElement endpointNode = new XElement("endpoint",
                    new XAttribute("address", item.Address),
                    new XAttribute("binding", item.Binding),
                    new XAttribute("contract", ContractName),
                    item.Binding == "basicHttpBinding" ?
                    new XElement("identity",
                        new XElement("dns",
                            new XAttribute("value", "localhost")))
                    : null
                    );
                servicesNode.Add(endpointNode);
            }
            configDoc.Save(ServerMapPath("App.config"));
        }
    }
}
