using System.Web;
using System.Web.Mvc;
using AjaxFileUpload.Helpers;

namespace AjaxFileUpload.Controllers
{
    public class UploadController : Controller
    {
        /// <summary>
        /// Upload a file and return a JSON result
        /// </summary>
        /// <param name="file">The file to upload.</param>
        /// <returns>a FileUploadJsonResult</returns>
        /// <remarks>
        /// It is not possible to upload files using the browser's XMLHttpRequest
        /// object. So the jQuery Form Plugin uses a hidden iframe element. For a
        /// JSON response, a ContentType of application/json will cause bad browser
        /// behavior so the content-type must be text/html. Browsers can behave badly
        /// if you return JSON with ContentType of text/html. So you must surround
        /// the JSON in textarea tags. All this is handled nicely in the browser
        /// by the jQuery Form Plugin. But we need to overide the default behavior
        /// of the JsonResult class in order to achieve the desired result.
        /// </remarks>
        /// <seealso cref="http://malsup.com/jquery/form/#code-samples"/>
        public FileUploadJsonResult AjaxUpload(HttpPostedFileBase file)
        {
            // TODO: Add your business logic here and/or save the file
            System.Threading.Thread.Sleep(2000); // Simulate a long running upload

            // Return JSON
            return new FileUploadJsonResult { Data = new { message = string.Format("{0} uploaded successfully.", System.IO.Path.GetFileName(file.FileName)) } };
        }
    }
}
