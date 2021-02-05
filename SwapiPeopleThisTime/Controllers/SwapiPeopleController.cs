using Microsoft.AspNetCore.Mvc;
using SwapiPeopleThisTime.Models;
using SwapiPeopleThisTime.Services;
using System.Threading.Tasks;

namespace SwapiPeopleThisTime.Controllers
{
    public class SwapiPeopleController : Controller
    {
        private readonly IPeopleClient _peopleClient;
        public SwapiPeopleController( IPeopleClient peopleClient)
        {

            _peopleClient = peopleClient;
        }
        public async Task<IActionResult> GetAllPeople()
        {

            var model = new PeopleResponse();
            var response = await _peopleClient.GetPeopleInfo();
            model.results = response.results;
            model.next = response.next;
            model.previous = response.previous;
            return View(model);
        }
        public async Task<IActionResult> ChangePagePeople(string url)
        {
            var UrlStrippedToPageInfo = url.Substring(url.Length - 14);
            var model = new PeopleResponse();
            var response = await _peopleClient.GetPeopleInfo(UrlStrippedToPageInfo);
            model.results = response.results;
            model.previous = response.previous;
            model.next = response.next;
            return View("GetAllPeople", model);
        }

    }
}

