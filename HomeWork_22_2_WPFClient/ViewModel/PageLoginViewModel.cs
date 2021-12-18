using DevExpress.Mvvm;
using HomeWork_22_2_WPFClient.Interfaces;
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
    public class PageLoginViewModel : ViewModelBase
    {
        private static PageService pageService;
        private static MessageBus messageBus;
        /// <summary>
        /// Логин
        /// </summary>
        public static string LoginName { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public static string Password { get; set; }
        static LoginModel loginModel;
        private static IAppUser appUser;


        public PageLoginViewModel(PageService p_pageService, MessageBus p_messageBus, IAppUser p_appUser)
        {
            pageService = p_pageService;
            messageBus = p_messageBus;
            appUser = p_appUser;
        }
        public PageLoginViewModel()
        {
        }

        public ICommand ButtonReturnClickCommand
        {
            get
            {
                return new DelegateCommand(() => { pageService.ChangePage(new Page1()); });
            }
        }

        public ICommand ButtonLoginlClickCommand
        {
            get
            {
                var a = new DelegateCommand(() =>
                {
                    loginModel = new LoginModel();
                    loginModel.Password = Password;
                    loginModel.Name = LoginName;
                    if (appUser.Login(loginModel))
                    {
                        pageService.ChangePage(new Page1());
                    }
                    else pageService.ChangePage(new PageError());
                });
                return a;
            }
        }
    }
}
