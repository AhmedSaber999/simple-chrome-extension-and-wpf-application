using Dev_Cell_Task.Model;
using Dev_Cell_Task.View;
using Dev_Cell_Task.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Dev_Cell_Task.Model
{
    class PageDataHandler
    {
        private bool server_is_alive = false;
        private HttpListener listener;
        private Thread listen_thread;
      
        public void CloseListener()
        {
            if (listener.IsListening)
            {
                server_is_alive = false;
            }
        }
        public void IntialoizeListener()
        {
            try
            {
                server_is_alive = true;
                if (listener == null)
                {
                    listener = new HttpListener();
                    listener.Prefixes.Add("http://localhost:5000/");
                    listener.Prefixes.Add("http://127.0.0.1:5000/");
                    listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
                    listener.Start();
                }
                if (listen_thread == null)
                {
                    listen_thread = new Thread(new ParameterizedThreadStart(StartListener));
                    listen_thread.SetApartmentState(ApartmentState.STA);
                    listen_thread.Start();
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        private void StartListener(object s)
        {
            while (true)
            {
                ////blocks until a client has connected to the server
                ProcessRequest();
            }
        }
        private void ProcessRequest()
        {
            var result = listener.BeginGetContext(ListenerCallback, listener);
            result.AsyncWaitHandle.WaitOne();
        }
        private void ListenerCallback(IAsyncResult result)
        {
            var context = listener.EndGetContext(result);
            context.Response.Headers.Add("Access-Control-Allow-Origin: *");
            if (!server_is_alive)
            {
                context.Response.StatusCode = 500;
                context.Response.StatusDescription = "Server does not work.";
                context.Response.Close();
                return;
            }
            try
            {
                Thread.Sleep(1000);
                var data_text = new StreamReader(context.Request.InputStream,
                context.Request.ContentEncoding).ReadToEnd();

                var data = System.Web.HttpUtility.UrlDecode(data_text);
                var page_data = JsonConvert.DeserializeObject<PageDataRoot>(data);


                if (page_data.page == 1)
                {
                    PageDataViewModel.page1Data = page_data.data;
                }
                else if (page_data.page == 2)
                {
                    PageDataViewModel.page2Data = page_data.data;
                }

                context.Response.StatusCode = 200;
                context.Response.StatusDescription = "OK";
                context.Response.Close();
            }
            catch(ThreadAbortException abortException)
            {
                 MessageBox.Show(abortException.Message);
            }
            catch (ThreadInterruptedException threadInterruptedException)
            {
                MessageBox.Show(threadInterruptedException.Message);
            }
            catch(Exception anotherException)
            {
                MessageBox.Show(anotherException.Message);
            }
        }
    }
}
