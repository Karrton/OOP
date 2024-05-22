using LabLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_16
{
    public class MyObjectEventArgs : EventArgs
    {
        public Challenge LastObject { get; set; }
        public Challenge NewObject { get; set;}
        public MyObjectEventArgs(Challenge lastObject, Challenge newObject)
        {
            LastObject = lastObject;
            NewObject = newObject;
        }
    }
}
