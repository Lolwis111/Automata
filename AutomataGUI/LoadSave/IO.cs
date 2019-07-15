using System;
using System.IO;
using System.Xml;
using AutomataGUI.Model;
using AutomataGUI.Properties;

namespace AutomataGUI.LoadSave
{
    public static class IO
    {
        public static void WriteAutomata(string path, IOData data)
        {
            using (StreamWriter writer = new StreamWriter(File.Open(path, FileMode.Create)))
            {
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");

                writer.WriteLine("<automata>");

                writer.WriteLine($"{Statics.Space4}<idx>{data.IdX}</idx>");
                writer.WriteLine($"{Statics.Space4}<scrollX>{data.ScrollX}</scrollX>");
                writer.WriteLine($"{Statics.Space4}<scrollY>{data.ScrollY}</scrollY>");

                foreach (Drawable drawable in data.Manager.Drawables)
                {
                    writer.WriteLine(drawable.GenerateXml());

                }

                writer.WriteLine("</automata>");
            }
        }

        public static IOData LoadAutomata(string path)
        {
            XmlDocument document = new XmlDocument();
            StateMachine dataManager = new StateMachine();

            document.Load(path);

            if (!int.TryParse(document.SelectSingleNode(".//idx")?.InnerText, out int idx))
            {
                throw new InvalidDataException($"{Resources.InvalidValue} 'idx'!");
            }

            if (!int.TryParse(document.SelectSingleNode(".//scrollX")?.InnerText, out int scrollX))
            {
                throw new InvalidDataException($"{Resources.InvalidValue} 'scrollX'!");
            }

            if (!int.TryParse(document.SelectSingleNode(".//scrollY")?.InnerText, out int scrollY))
            {
                throw new InvalidDataException($"{Resources.InvalidValue} 'scrollY'!");
            }

            XmlNodeList stateNodes = document.SelectNodes(".//state");

            if (stateNodes == null)
            {
                throw new NullReferenceException();
            }

            LoadStates(dataManager, stateNodes);

            XmlNodeList transitionNodes = document.SelectNodes(".//transition");
            if (transitionNodes == null)
            {
                throw new NullReferenceException();
            }

            LoadTransitions(dataManager, transitionNodes);

            return new IOData(dataManager, idx, scrollX, scrollY);
        }

        private static void LoadTransitions(StateMachine dataManager, XmlNodeList transitionNodes)
        {
            foreach (XmlNode transitionNode in transitionNodes)
            {
                if (!int.TryParse(SaveSelectSingleNode(transitionNode, ".//id").InnerText, out int id))
                {
                    throw new InvalidDataException($"{Resources.InvalidValue} 'id'!");
                }

                if (!int.TryParse(SaveSelectSingleNode(transitionNode, ".//from").InnerText, out int fromId))
                {
                    throw new InvalidDataException($"{Resources.InvalidValue} 'from'!");
                }

                if (!int.TryParse(SaveSelectSingleNode(transitionNode, ".//to").InnerText, out int toId))
                {
                    throw new InvalidDataException($"{Resources.InvalidValue} 'to'!");
                }

                string label = SaveSelectSingleNode(transitionNode, ".//label").InnerText;

                State start = dataManager.FindStateById(fromId);
                State end = dataManager.FindStateById(toId);

                if (start == null || end == null)
                {
                    throw new InvalidDataException(Resources.InvalidTransitionError);
                }

                dataManager.AddTransition(start, end, id, label);
            }
        }

        private static void LoadStates(StateMachine dataManager, XmlNodeList stateNodes)
        {
            foreach (XmlNode stateNode in stateNodes)
            {
                Console.WriteLine(stateNode.InnerXml);

                if (!int.TryParse(SaveSelectSingleNode(stateNode, ".//id").InnerText, out int id))
                {
                    throw new InvalidDataException($"{Resources.InvalidValue} 'id'!");
                }

                if (!int.TryParse(SaveSelectSingleNode(stateNode, ".//x").InnerText, out int posX))
                {
                    throw new InvalidDataException($"{Resources.InvalidValue} 'x'!");
                }

                if (!int.TryParse(SaveSelectSingleNode(stateNode, ".//y").InnerText, out int posY))
                {
                    throw new InvalidDataException($"{Resources.InvalidValue} 'y'!");
                }

                string label = SaveSelectSingleNode(stateNode, ".//label").InnerText;

                //if (!bool.TryParse(SaveSelectSingleNode(stateNode, ".//start").InnerText, out bool isStartState))
                //{
                //    throw new InvalidDataException($"{Resources.InvalidValue} 'start'!");
                //}

                //if (!bool.TryParse(SaveSelectSingleNode(stateNode, ".//end").InnerText, out bool isEndState))
                //{
                //    throw new InvalidDataException($"{Resources.InvalidValue} 'end'!");
                //}

                // dataManager.AddState(id, posX, posY, label, isStartState, isEndState);
            }
        }

        private static XmlNode SaveSelectSingleNode(XmlNode root, string xpath)
        {
            if (root != null)
            {
                XmlNodeList nodes = root.SelectNodes(xpath);

                if (nodes.Count == 1)
                    return nodes[0];
                else
                    throw new FormatException(Resources.CorruptedSavefileError);
            }

            throw new NullReferenceException();
        }

    }
}
