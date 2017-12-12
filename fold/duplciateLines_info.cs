using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace duplciateLines
{
    public class template_info : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "duplciateLines";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("FD73BA2D-ACE8-4CEF-8D09-7ADB4F1184DB"); // Tools -> Create Guid 5.
            }
        }
        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "Philipp Siedler";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "p.d.siedler@gmail.com";
            }
        }
    }
}
