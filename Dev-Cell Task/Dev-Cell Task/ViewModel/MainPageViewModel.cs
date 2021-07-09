using Dev_Cell_Task.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev_Cell_Task.ViewModel
{
    class MainPageViewModel
    {
        private static readonly PageDataHandler pageDataHandler;
        public static IEnumerable<PageData> page1Data { get; set; }
        public static IEnumerable<PageData> page2Data { get; set; }

        static MainPageViewModel()
        {
            pageDataHandler = new PageDataHandler();
        }

        public static void IntialoizeListener()=> pageDataHandler.IntialoizeListener();
        public static void CloseListener()=> pageDataHandler.CloseListener();
    
    }
}
