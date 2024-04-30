using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Interface
{
    public interface IHelper
    {
        string ViewToString(ControllerContext controllerContext, PartialViewResult pvr, ICompositeViewEngine _viewEngine);

    }
}
