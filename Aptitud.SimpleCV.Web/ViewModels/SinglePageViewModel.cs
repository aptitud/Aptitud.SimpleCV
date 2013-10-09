using System.Collections.Generic;

namespace Aptitud.SimpleCV.Web.ViewModels
{
    public interface IHaveMainMenu
    {
        IEnumerable<LinkItemViewModel> MainMenu { get; set; }
    }

    public class SinglePageViewModel : IHaveMainMenu
    {
        public IEnumerable<LinkItemViewModel> MainMenu { get; set; }
    }
}