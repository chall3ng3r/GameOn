using System;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
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
                    // make http URI
                    Uri uri = new Uri(s);

                    string strURL = "http://";
                    strURL += uri.GetComponents(UriComponents.HostAndPort, UriFormat.UriEscaped);
                    strURL += "/" + uri.GetComponents(UriComponents.Path, UriFormat.UriEscaped);

                    // window size from querystring
                    NameValueCollection queryVars = ParseQueryString(uri.GetComponents(UriComponents.Query, UriFormat.Unescaped));
                    string size = queryVars.Get("size");

                    if(!string.IsNullOrEmpty(size))
                    {
                        // maximize
                        if (size.ToLower() == "fullscreen")
                        {
                            f.WindowState = FormWindowState.Maximized;
                        }
                        // resize window to specified width,height
                        else
                        {
                            int w = Convert.ToInt32(size.Split(',')[0]);
                            int h = Convert.ToInt32(size.Split(',')[1]);

                            f.Width = w;
                            f.Height = h;
                        }
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

        public static NameValueCollection ParseQueryString(string s)
        {
            NameValueCollection nvc = new NameValueCollection();

            foreach (string vp in Regex.Split(s, "&"))
            {
                string[] singlePair = Regex.Split(vp, "=");
                if (singlePair.Length == 2)
                {
                    nvc.Add(singlePair[0], singlePair[1]);
                }
                else
                {
                    // only one key with no value specified in query string
                    nvc.Add(singlePair[0], string.Empty);
                }
            }

            return nvc;
        }

    }
}
