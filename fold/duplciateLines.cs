using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

using System.Linq;

namespace duplciateLines

{
    public class vanillaComponent : GH_Component
    {
        GH_Document GrasshopperDocument;
        IGH_Component Component;
        
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public vanillaComponent(): base("duplciateLines", "description", "action description", "philsComps", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddLineParameter("lineSet", "lineSet", "lineSet", GH_ParamAccess.list);
            pManager.AddLineParameter("lineSetToFind", "lineSetToFind", "lineSetToFind", GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddLineParameter("lineSetProcessed", "lineSetProcessed", "lineSetProcessed", GH_ParamAccess.list);
            pManager.AddIntegerParameter("indexes", "indexes", "indexes", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<Line> lineSet = new List<Line>();
            List<Line> lineSetToFind = new List<Line>();
            List<Line> lineSetProcessed = new List<Line>();
            List<int> indexes = new List<int>();

            DA.GetDataList(0, lineSet);
            DA.GetDataList(1, lineSetToFind);


            for (int i = 0; i < lineSet.Count(); i++)
            {
                for (int j = 0; j < lineSetToFind.Count(); j++)
                {
                    if (lineSet[i].PointAt(0.5) == lineSetToFind[j].PointAt(0.5))
                    {
                        indexes.Add(i);
                    }
                }
            }

            
            for (int i = 0; i < indexes.Count(); i++)
            {
                lineSet.RemoveAt(indexes[i] - i);
            }
            

            lineSetProcessed = lineSet;
            DA.SetDataList(0, lineSetProcessed);
            DA.SetDataList(1, indexes);
        }


        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("FD73BA2D-ACE8-4CEF-8D09-7ADB4F1184DB"); }
        }
        
    }
}
