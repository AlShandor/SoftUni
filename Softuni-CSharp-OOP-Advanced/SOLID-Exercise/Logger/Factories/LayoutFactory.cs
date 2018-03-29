
using System;
using Logger.Contracts;
using Logger.Entities;
using Logger.Entities.Layouts;

namespace Logger.Factories
{
    public class LayoutFactory
    {

        public ILayout CreateLayout(string layoutType)
        {
            ILayout layout = null;
            switch (layoutType)
            {
                case "SimpleLayout":
                    layout = new SimpleLayout();
                    break;
                case "XmlLayout":
                    layout = new XmlLayout();
                    break;
                default:
                    throw new ArgumentException("Invalid Layout type!");
            }

            return layout;
        }
    }
}
