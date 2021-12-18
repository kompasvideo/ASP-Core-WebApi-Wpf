using DevExpress.Mvvm;
using HomeWork_22_2_WPFClient.Pages;
using HomeWork_22_2_WPFClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeWork_22_2_WPFClient.ViewModel
{
    public class PageErrorViewModel : ViewModelBase
    {
        private static PageService pageService;

        public PageErrorViewModel(PageService p_pageService)
        {
            pageService = p_pageService;
        }
        public PageErrorViewModel()
        {
        }

        public ICommand ButtonOkClickCommand
        {
            get
            {
                return new DelegateCommand(() => { pageService.ChangePage(new Page1()); });
            }
        }
    }
}