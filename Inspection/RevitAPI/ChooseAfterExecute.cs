using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Plumbing;
using System.IO;
using System.Collections.ObjectModel;

namespace RevitAPI
{
    public class ChooseAfterExecute
    {
        public static Collection<Pipe> GetChosenElements(UIDocument uiDoc)
        {
            Document doc = uiDoc.Document;
            Selection sel = uiDoc.Selection;

            try
            {
                PipeSelectionFilter psf = new PipeSelectionFilter(doc);
                //选择多个水管
                IList<Reference> piperefer = sel.PickObjects(ObjectType.Element, psf, "请选择水管：");

                /*
                //修改选中的水管（预选指定元素）
                IList<Reference> referWithPreselected = sel.PickPoints(ObjectType.Element, psf, "请修改选中的水管", refer);
                */
                Collection<Pipe> pipeCollection = new Collection<Pipe>();
                //通过遍历引用取到选中的元素
                foreach (Reference refer in piperefer)
                {
                    //通过Document.GetElement(reference)方法，获取引用指向的元素
                    var pipe = doc.GetElement(refer) as Pipe;
                    pipeCollection.Add(pipe);

                }
                
                return pipeCollection;
            }
            catch 
            {
                //statement
                return null;
            }
        }
    }

    //水管选择过滤器
    public class PipeSelectionFilter : ISelectionFilter
    {
        Document doc = null;

        public PipeSelectionFilter(Document document)
        {
            doc = document;
        }

        public bool AllowElement(Element elem)
        {
            return elem is Pipe;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            throw new NotImplementedException();
        }
    }
}
