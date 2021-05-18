using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Civil.ApplicationServices;
using Autodesk.Civil.DatabaseServices;
using Autodesk.Civil.Settings;
using Autodesk.Civil.Runtime;

namespace alignmentdeneme
{
    public class Alignment
    {
        [CommandMethod("CreateAlignment")]
        public void CreateAlignment()
        {
            {
                try
                {
                    var doc = CivilApplication.ActiveDocument;
                    Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;

                    // Ask the user to select a polyline to convert to an alignment
                    PromptEntityOptions opt = new PromptEntityOptions("\nSelect a polyline to convert to an Alignment");
                    opt.SetRejectMessage("\nObject must be a polyline.");
                    opt.AddAllowedClass(typeof(Polyline), false);
                    PromptEntityResult res = ed.GetEntity(opt);

                    // create some polyline options for creating the new alignment
                    PolylineOptions plops = new PolylineOptions();
                    plops.AddCurvesBetweenTangents = true;
                    plops.EraseExistingEntities = true;
                    plops.PlineId = res.ObjectId;

                    // uses an existing Alignment Style and Label Set Style named "Basic" (for example, from
                    // the Civil 3D (Imperial) NCS Base.dwt template.  This call will fail if the named styles
                    // don't exist.
                    ObjectId testAlignmentID = Autodesk.Civil.DatabaseServices.Alignment.Create(doc, plops, "Alignment - (1)", "0", "STANDART", "STANDART", "");
                }


                catch (System.Exception ex)
                {
                }
            }
        }
    }
}

