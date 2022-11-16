using Microsoft.AspNetCore.Mvc;

namespace EventApp.ViewComponents.Home
{
    public class SliderComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
