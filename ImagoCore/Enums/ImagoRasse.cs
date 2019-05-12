using System;
using System.Collections.Generic;
using System.Text;

namespace ImagoCore.Enums
{
    public class ImagoRasse : Enumeration
    {
        public static readonly ImagoRasse Mensch = new ImagoRasse(0, "Mensch");
        public static readonly ImagoRasse Omori = new ImagoRasse(1, "Omori");
        public static readonly ImagoRasse Game = new ImagoRasse(2, "Game");
        public static readonly ImagoRasse Jashira = new ImagoRasse(3, "Jashira");
        
        public ImagoRasse()
        {

        }
        public ImagoRasse(int value, string displayName) : base(value, displayName)
        {

        }
        
    }
    
}
