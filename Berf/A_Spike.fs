namespace BerfModel1

module Data =

    [<CLIMutable>]
    type public Packet2 = 
        { source : string;
            navigationStart: System.Double;
          unloadEventStart: System.Double;
          url: string;
          unloadEventEnd: System.Double;
          name: string;
          linkNegotiationStart: System.Double;
          linkNegotiationEnd: System.Double;
          redirectStart: System.Double;
          redirectEnd: System.Double;
          fetchStart: System.Double;
          domainLookupStart: System.Double;
          domainLookupEnd: System.Double;
          duration: System.Double;
          entryType: string;
          initiatorType: string;
          connectStart: System.Double;
          connectEnd: System.Double;
          secureConnectionStart: System.Double;
          startTime: System.Double;
          requestStart: System.Double;
          responseStart: System.Double;
          responseEnd: System.Double;
          domLoading: System.Double;
          domInteractive: System.Double;
          domContentLoadedEventStart: System.Double;
          domContentLoadedEventEnd: System.Double;
          domComplete: System.Double;
          loadEventStart: System.Double;
          loadEventEnd: System.Double;
          prerenderSwitch: System.Double
          redirectCount: int }

