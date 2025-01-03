using Microsoft.AspNetCore.Mvc;
using Resume.Bus.Services.Interfaces;
using Resume.Bus.Extentions;
namespace Resume.Web.Areas.Admin.Components;

[ViewComponent]
public class LeftSideBarViewComponent : ViewComponent
{

    private readonly IUserService _userService;
    public LeftSideBarViewComponent(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await _userService.GetInformation(User.GetUserId());
        ViewData["User"]=user;
        return View("_Details");
    }
}