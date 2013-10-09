using System;
using System.Collections.Generic;
using System.Dynamic;
using Aptitud.SimpleCV.Web.ViewModels;
using Nancy;

namespace Aptitud.SimpleCV.Web.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            After += ctx =>
                {

                    var singlePage = ctx.NegotiationContext.DefaultModel as IHaveMainMenu;
                    if(singlePage == null)
                        return;

                    var mainMenu = new List<LinkItemViewModel>
                        {
                            new LinkItemViewModel
                                {
                                    Text = "Titta",
                                    Path = "/view/",
                                },
                        };


                    if (ctx.CurrentUser != null)
                    {
                        mainMenu.Add(new LinkItemViewModel
                            {
                                Text = "Redigera",
                                Path = "/edit/",
                            });
                    }

                    mainMenu.Add(new LinkItemViewModel
                        {
                            Text = "Om",
                            Path = "/about/",
                        });

                    singlePage.MainMenu = mainMenu;
                };

            Get["/"] = parameters => View["Index", new HomePageViewModel()];
        }
    }
}