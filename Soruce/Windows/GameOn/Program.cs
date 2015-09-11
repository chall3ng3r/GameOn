using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace GameOn
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormMain f = new FormMain();
            f.Text += " by chall3ng3r.com - v" + Application.ProductVersion;

            foreach (string s in args)
            {
                try
                {
                    // TODO: replace with regex for better parsing
                    Uri uri = new Uri(s);
                    //Console.WriteLine("arg: " + s);
                    string strURL = "http://";
                    strURL += uri.GetComponents(UriComponents.HostAndPort, UriFormat.UriEscaped);
                    strURL += "/" + uri.GetComponents(UriComponents.Path, UriFormat.UriEscaped);

                    // get size from querystring
                    string[] query = uri.GetComponents(UriComponents.Query, UriFormat.Unescaped).Split(',');

                    switch (query.Length)
                    {
                        case 1:
                            if (query[0] == "fullscreen")
                                f.WindowState = FormWindowState.Maximized;
                            break;
                        case 2:
                            int w = Convert.ToInt32(query[0]);
                            int h = Convert.ToInt32(query[1]);

                            f.Width = w;
                            f.Height = h;
                            break;
                        default:
                            break;
                    }

                    f.initUnity(strURL);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }

            Application.Run(f);
        }
    }
}
