using AcademyA_CDO.Week6.ASPNETCoreWebApp_MVC.Helpers;
using AcademyA_CDO.Week6.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyA_CDO.Week6.ASPNETCoreWebApp_MVC.ViewComponents
{
    public class CodeListViewComponent : ViewComponent
    {
        private readonly IMainBusinessLayer mainBl;

        public CodeListViewComponent(IMainBusinessLayer mainBl)
        {
            this.mainBl = mainBl;
        }

        public async Task<IViewComponentResult> InvokeAsync(string code)
        {
            var employees = mainBl.FetchEmployees()
                .Where(e => e.EmployeeCode == code);

            var model = employees.ToListViewModel();

            return await Task.FromResult((IViewComponentResult)View("View", model));
        }
    }
}
