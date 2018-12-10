using Microsoft.AspNetCore.Mvc;

namespace ExamPrep.Controllers
{
    //Attribute Based Routing:
    //about
    [Route("company/[controller]/[action]")]

    public class AboutController
    {

        [Route("")]
        public string Phone()
        {
            return "55 55 44 33";
        }

        public string Address()
        {
            return "USA";
        }
    }
}
