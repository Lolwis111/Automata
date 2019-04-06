using System;

namespace AutomataGUI
{
    public static class Statics
    {
        public static bool Debug { get; set; }
        public const string Space4 = "    ";
        public const string Space8 = Space4 + Space4;
        public static readonly Random Random = new Random();
    }
}
