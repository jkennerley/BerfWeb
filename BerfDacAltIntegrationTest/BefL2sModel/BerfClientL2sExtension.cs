namespace Berf.EfTest
{
    using global::BerfDacAltIntegrationTest.BerfDataEfContext;
    using System;

    public static class BerfClientL2sExtension
    {
        public static BerfDataContextDal.BerfClient BerfClientZero()
        {
            return new BerfDataContextDal.BerfClient
            {
                Id                                      = Guid.NewGuid(),
                SessionId                               = Guid.Empty,
                RenderId                                = Guid.Empty,
                Ord                                     = 0,
                Url                                     = String.Empty,
                EntryType                               = String.Empty,
                Source                                  = String.Empty,
                Created                                 = DateTime.UtcNow.ToString(@"yyyy-MM-ddTHH\:mm\:ss"),
                UnloadEventStart                        = 0.0,
                UnloadEventEnd                          = 0.0,
                LinkNegotiationStart                    = 0.0,
                LinkNegotiationEnd                      = 0.0,
                RedirectStart                           = 0.0,
                RedirectEnd                             = 0.0,
                FetchStart                              = 0.0,
                DomainLookupStart                       = 0.0,
                DomainLookupEnd                         = 0.0,
                ConnectStart                            = 0.0,
                ConnectEnd                              = 0.0,
                SecureConnectionStart                   = 0.0,
                RequestStart                            = 0.0,
                ResponseStart                           = 0.0,
                ResponseEnd                             = 0.0,
                DomLoading                              = 0.0,
                DomInteractive                          = 0.0,
                DomContentLoadedEventStart              = 0.0,
                DomContentLoadedEventEnd                = 0.0,
                DomComplete                             = 0.0,
                LoadEventStart                          = 0.0,
                LoadEventEnd                            = 0.0,
                PrerenderSwitch                         = 0.0,
                RedirectCount                           = 0,
                InitiatorType                           = String.Empty,
                Name                                    = String.Empty,
                StartTime                               = 0.0,
                Duration                                = 0.0,
                NavigationStart                         = 0.0,
                UserName                                = String.Empty,
                ClientIP                                = String.Empty,
                UserAgent                               = String.Empty,
                Browser                                 = String.Empty,
                BrowserVersion                          = String.Empty,
                HostMachineName                         = String.Empty
            };
        }
    }
}

