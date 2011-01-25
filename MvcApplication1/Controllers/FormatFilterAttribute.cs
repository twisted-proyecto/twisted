using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.IO;
using MvcContrib.ActionResults;
namespace MvcApplication1.Controllers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class FormatFilterAttribute : FilterAttribute, IActionFilter
    {
        /// <summary>
        /// The type of files we can server the requested content in
        /// </summary>
        private enum FileFormat { Html, Json, Xml }

        

        public FormatFilterAttribute()
        {
            Disallow = string.Empty;
            RequestedFormat = FileFormat.Html;
        }

        /// <summary>
        /// Formats to disallow can be either Html, Json or Xml. Use comma to seperate multiple formats.
        /// </summary>
        public string Disallow { get; set; }

        /// <summary>
        /// The format that has been requested
        /// </summary>
        private FileFormat RequestedFormat { get; set; }

        /// <summary>
        /// Occurs before an action is executed
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            FileFormat format = GetFileFormat(filterContext.HttpContext.Request.Path);
            if (IsDisallowed(format))
            {
                throw new ArgumentException("Requested format has been disallowed");
            }

            RequestedFormat = format;
        }

        /// <summary>
        /// Occurs after an action is executed
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!(filterContext.Result is ViewResult))
            {
                throw new InvalidOperationException("You need to call the View method, when the FormatFilter attribute is applied");
            }

            var view = (ViewResult)(filterContext.Result);
            filterContext.Result = FormatViewResult(view);
        }

        /// <summary>
        /// Verifies if the format has been disallowed
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        private bool IsDisallowed(FileFormat format)
        {
            return Disallow.Split(',').Any(s => s.ToLower() == format.ToString().ToLower());
        }

        /// <summary>
        /// Verifies that the requested format is one that can be servered
        /// </summary>
        /// <param name="ext"></param>
        /// <returns></returns>
        private bool IsValidFileExtension(string ext)
        {
            return Enum.GetNames(typeof(FileFormat)).Any(format => format.ToLower() == ext.Substring(1).ToLower());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private FileFormat GetFileFormat(string path)
        {
            try
            {
                string ext = Path.GetExtension(path);
                if (string.IsNullOrEmpty(ext))
                {
                    return FileFormat.Html;
                }

                if (!IsValidFileExtension(ext))
                {
                    throw new FormatException("Requested format is not available");
                }

                return (FileFormat) Enum.Parse(typeof (FileFormat), ext.Substring(1), true);
            }catch(Exception e)
            {
                return (FileFormat)Enum.Parse(typeof(FileFormat), "xml", true);
            }
            
        }

        private ActionResult FormatViewResult(ViewResultBase view)
        {
            switch (RequestedFormat)
            {
                case FileFormat.Html:
                    return view;
                case FileFormat.Json:
                    return new JsonResult{ Data = view.ViewData.Model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                case FileFormat.Xml:
                    return new XmlResult(view.ViewData.Model);
                default:
                    //throw new FormatException(string.Concat("Cannot server the content in the request format: ", RequestedFormat));
                    return view;
            }
        }
    }
}