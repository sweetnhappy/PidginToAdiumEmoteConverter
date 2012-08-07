using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using PidginToAdiumEmoteConverter.Models;

namespace PidginToAdiumEmoteConverter.Controllers
{
    public class ConversionsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ParsePidginInput(ConversionReadWriteModel model)
        {
            try
            {
                model.Parse();
            }
            catch (ArgumentException)
            {
                return Json("Parsing Error");
            }

            JavaScriptSerializer jss = new JavaScriptSerializer();
            string json = jss.Serialize(model.ParsedInput);

            return Json(json);
        }

        [HttpPost]
        public JsonResult GenerateAdiumOutput(ConversionReadWriteModel model)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            ParsedPidginInput customizedPidginInput = jss.Deserialize<ParsedPidginInput>(model.JsonDataToConvert);

            try
            {
                model.Generate(customizedPidginInput);
            }
            catch (ArgumentException)
            {
                return Json("Conversion Error");
            }

            return Json(model.AdiumOutput);
        }
    }
}
