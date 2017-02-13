using System.Collections;
using System.Collections.Generic;

namespace MyWebServer.Models
{
    public class CookieCollection: IEnumerable<Cookie>
    {
        public Dictionary<string,Cookie> Cookies { get; set; }
        public int Count { get { return this.Cookies.Count; } }

        public Cookie this[string cookieName]
        {
            get { return this.Cookies[cookieName]; }
            set
            {
                if (this.Cookies.ContainsKey(cookieName))
                {
                    this.Cookies[cookieName] = value;
                }
                else
                {
                    this.Cookies.Add(cookieName,new Cookie(cookieName,null));
                }
            }
        }

        public CookieCollection()
        {
            this.Cookies = new Dictionary<string, Cookie>();
        }

        public bool Contains(string cookie)
        {
            return this.Cookies.ContainsKey(cookie);
        }

        public void Add(Cookie cookie)
        {
            
            this.Cookies.Add(cookie.Name,cookie);
        }
        public IEnumerator<Cookie> GetEnumerator()
        {
            return this.Cookies.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join("; ", this.Cookies.Values);
        }
    }
}