using BerfDataContextDal;
using System.Configuration;

namespace Berf.Data
{
    public class BerfL2sBaseDal
    {
        public readonly string Cn;

        protected BerfDataContext Dc;

        public BerfL2sBaseDal()
        {
            this.Cn = ConfigurationManager.ConnectionStrings["Berf"].ConnectionString;

            Dc = new BerfDataContext(Cn);
        }
    }
}

namespace Berf.Data
{
    using System;
    using System.Linq;

    public class BerfL2sDal : BerfL2sBaseDal
    {
        public void InsertBerfClient(BerfDataContextDal.BerfClient de)
        {
            this.Dc.BerfClient.InsertOnSubmit(de);

            this.Dc.SubmitChanges();
        }

        public void Update(BerfDataContextDal.BerfClient be)
        {
            var de = this.Dc.BerfClient.FirstOrDefault(u => u.Id == be.Id);

            de.Source = be.Source;

            this.Dc.SubmitChanges();
        }

        public bool DeleteBerfClient(BerfDataContextDal.BerfClient be)
        {
            var de = new BerfDataContextDal.BerfClient();

            de.Id = be.Id;
            de.SessionId = be.SessionId;
            de.RenderId = be.RenderId;
            de.Ord = be.Ord;
            de.Url = be.Url;
            de.EntryType = be.EntryType;
            de.Source = be.Source;
            de.Created = be.Created;
            de.UnloadEventStart = be.UnloadEventStart;
            de.UnloadEventEnd = be.UnloadEventEnd;
            de.LinkNegotiationStart = be.LinkNegotiationStart;
            de.LinkNegotiationEnd = be.LinkNegotiationEnd;
            de.RedirectStart = be.RedirectStart;
            de.RedirectEnd = be.RedirectEnd;
            de.FetchStart = be.FetchStart;
            de.DomainLookupStart = be.DomainLookupStart;
            de.DomainLookupEnd = be.DomainLookupEnd;
            de.ConnectStart = be.ConnectStart;
            de.ConnectEnd = be.ConnectEnd;
            de.SecureConnectionStart = be.SecureConnectionStart;
            de.RequestStart = be.RequestStart;
            de.ResponseStart = be.ResponseStart;
            de.ResponseEnd = be.ResponseEnd;
            de.DomLoading = be.DomLoading;
            de.DomInteractive = be.DomInteractive;
            de.DomContentLoadedEventStart = be.DomContentLoadedEventStart;
            de.DomContentLoadedEventEnd = be.DomContentLoadedEventEnd;
            de.DomComplete = be.DomComplete;
            de.LoadEventStart = be.LoadEventStart;
            de.LoadEventEnd = be.LoadEventEnd;
            de.PrerenderSwitch = be.PrerenderSwitch;
            de.RedirectCount = be.RedirectCount;
            de.InitiatorType = be.InitiatorType;
            de.Name = be.Name;
            de.StartTime = be.StartTime;
            de.Duration = be.Duration;
            de.NavigationStart = be.NavigationStart;
            de.UserName = be.UserName;
            de.ClientIP = be.ClientIP;
            de.UserAgent = be.UserAgent;
            de.Browser = be.Browser;
            de.BrowserVersion = be.BrowserVersion;
            de.HostMachineName = be.HostMachineName;

            this.Dc.BerfClient.Attach(de, false);

            this.Dc.BerfClient.DeleteOnSubmit(de);

            this.Dc.SubmitChanges();

            return (true);
        }

        public BerfDataContextDal.BerfClient ReadBerfClient(Guid id)
        {
            BerfDataContextDal.BerfClient be = null;

            var de = (from item in this.Dc.BerfClient where item.Id == id select item).FirstOrDefault();

            if (de != null)
            {
                be = new BerfDataContextDal.BerfClient { Id = de.Id };
            }

            return be;
        }
    }
}
