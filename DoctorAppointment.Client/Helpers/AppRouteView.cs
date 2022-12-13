using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Net;

namespace DoctorAppointment.Client.Helpers
{
    public class AppRouteView : RouteView
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAccountService AccountService { get; set; }

        //protected override void Render(RenderTreeBuilder builder)
        //{
        //    if (AccountService.User == null)
        //    {
        //        var returnUrl = WebUtility.UrlEncode(new Uri(NavigationManager.Uri).PathAndQuery);
        //        NavigationManager.NavigateTo($"employees/listall?returnUrl={returnUrl}");
        //    }
        //    else
        //    {
        //        base.Render(builder);
        //    }
        //}
    }
}