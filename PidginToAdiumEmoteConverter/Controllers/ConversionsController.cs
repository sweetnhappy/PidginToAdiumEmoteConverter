using System.Linq;
using System.Web.Mvc;
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
        public ActionResult Index(ConversionInputReadModel input)
        {
            ConversionOutputReadModel output = new ConversionOutputReadModel(input);

            return View("Convert", output);
        }
    }
}
