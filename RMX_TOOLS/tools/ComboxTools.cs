using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.common;

namespace RMX_TOOLS.tools
{
    public class ComboBoxItem
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private object _value;

        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class ComboxTools
    {
    }
}
