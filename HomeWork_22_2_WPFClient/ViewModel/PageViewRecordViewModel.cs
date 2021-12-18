using DevExpress.Mvvm;
using HomeWork_22_2_WPFClient.Messages;
using HomeWork_22_2_WPFClient.Models;
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
    public class PageViewRecordViewModel : ViewModelBase
    {
        private static PageService pageService;
        private static MessageBus messageBus;
        public static PhoneBook PhoneBook1 { get; set; }
        public PageViewRecordViewModel(PageService p_pageService, MessageBus p_messageBus)
        {
            pageService = p_pageService;
            messageBus = p_messageBus;
            if (messageBus != null)
            {
                messageBus.Receive<PhoneBookMessages>(this, async message => { PhoneBook1 = message.phoneBook; });
            }
        }
        public PageViewRecordViewModel()
        {
        }
        public ICommand ButtonReturnClickCommand
        {
            get
            {
                return new DelegateCommand((obj) => { pageService.ChangePage(new Page1()); });
            }
        }

        public ICommand Login
        {
            get
            {
                return new DelegateCommand((obj) => { pageService.ChangePage(new PageLogin()); });
            }
        }
    }
}
