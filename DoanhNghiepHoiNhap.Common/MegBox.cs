using System;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.UI;

namespace DoanhNghiepHoiNhap.Common
{
    public class WebMsgBox
    {
        protected static Hashtable handlerPages = new Hashtable();

        private WebMsgBox()
        {
        }

        public static void Show(string Message)
        {
            if (!(handlerPages.Contains(HttpContext.Current.Handler)))
            {
                var currentPage = (Page) HttpContext.Current.Handler;
                if (!((currentPage == null)))
                {
                    var messageQueue = new Queue();
                    messageQueue.Enqueue(Message);
                    handlerPages.Add(HttpContext.Current.Handler, messageQueue);
                    currentPage.Unload += CurrentPageUnload;
                }
            }
            else
            {
                var queue = ((Queue) (handlerPages[HttpContext.Current.Handler]));
                queue.Enqueue(Message);
            }
        }

        private static void CurrentPageUnload(object sender, EventArgs e)
        {
            var queue = ((Queue) (handlerPages[HttpContext.Current.Handler]));
            if (queue != null)
            {
                var builder = new StringBuilder();
                int iMsgCount = queue.Count;
                builder.Append("<script language='javascript'>");
                string sMsg;
                while ((iMsgCount > 0))
                {
                    iMsgCount = iMsgCount - 1;
                    sMsg = Convert.ToString(queue.Dequeue());
                    sMsg = sMsg.Replace("\"", "'");
                    builder.Append("alert( \"" + sMsg + "\" );");
                }
                builder.Append("</script>");
                handlerPages.Remove(HttpContext.Current.Handler);
                HttpContext.Current.Response.Write(builder.ToString());
            }
        }
    }
}