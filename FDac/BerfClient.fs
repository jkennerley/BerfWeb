[<AutoOpen>]
module FDac.BerfClient
 
    open System 

    let Zero =
        {
            BerfClient.id               = Guid.NewGuid()
            sessionId                   = Guid.NewGuid()
            renderId                    = Guid.NewGuid()
            ord                         =  0 
            url                         = ""
            entryType                   = ""
            source                      = ""
            created                     = DateTime.Now
            unloadEventStart            = 0.
            unloadEventEnd              = 0.
            linkNegotiationStart        = 0.
            linkNegotiationEnd          = 0.
            redirectStart               = 0.
            redirectEnd                 = 0.
            fetchStart                  = 0.
            domainLookupStart           = 0.
            domainLookupEnd             = 0.
            connectStart                = 0.
            connectEnd                  = 0.
            secureConnectionStart       = 0.
            requestStart                = 0.
            responseStart               = 0.
            responseEnd                 = 0.
            domLoading                  = 0.
            domInteractive              = 0.
            domContentLoadedEventStart  = 0.
            domContentLoadedEventEnd    = 0.
            domComplete                 = 0.
            loadEventStart              = 0.
            loadEventEnd                = 0.
            prerenderSwitch             = 0.
            redirectCount               = 0
            initiatorType               = ""
            name                        = ""
            startTime                   = 0.
            duration                    = 0.
            navigationStart             = 0.
            userName                    = ""
            clientIP                    = ""
            userAgent                   = ""
            browser                     = ""
            browserVersion              = ""
            hostMachineName             = ""
        }

    let createDefaultTest () =
        { Zero with
            BerfClient.id               = Guid.NewGuid()
            sessionId                   = Guid.NewGuid()
            renderId                    = Guid.NewGuid()
            ord                         = 0 
            url                         = "berfPacket.url"
            entryType                   = "berfPacket.entryType"
            source                      = "berfPacket.source"
            created                     = DateTime.Now
            unloadEventStart            =  1.
            unloadEventEnd              =  2.
            linkNegotiationStart        =  3.
            linkNegotiationEnd          =  4.
            redirectStart               =  5.
            redirectEnd                 =  6.
            fetchStart                  =  7.
            domainLookupStart           =  8.
            domainLookupEnd             =  9.
            connectStart                = 10.
            connectEnd                  = 11.
            secureConnectionStart       = 12.
            requestStart                = 13.
            responseStart               = 14.
            responseEnd                 = 15.
            domLoading                  = 16.
            domInteractive              = 17.
            domContentLoadedEventStart  = 18.
            domContentLoadedEventEnd    = 19.
            domComplete                 = 20.
            loadEventStart              = 21.
            loadEventEnd                = 22.
            prerenderSwitch             = 23.
            redirectCount               = 24
            initiatorType               = "berfPacket.initiatorType"
            name                        = "berfPacket.name"
            startTime                   = 26.
            duration                    = 27.
            navigationStart             = 28.
            userName                    = "httpContext.User.Identity.Name"
            clientIP                    = "httpContext.Request.UserHostAddress"
            userAgent                   = "httpContext.Request.UserAgent"
            browser                     = "httpContext.Request.Browser.Browser"
            browserVersion              = "httpContext.Request.Browser.Version"
            hostMachineName             = "hostMachineName"
        }

    let create id sessionId renderId ord url entryType source created unloadEventStart unloadEventEnd linkNegotiationStart linkNegotiationEnd  redirectStart redirectEnd fetchStart domainLookupStart domainLookupEnd connectStart connectEnd secureConnectionStart requestStart  responseStart responseEnd domLoading domInteractive domContentLoadedEventStart domContentLoadedEventEnd domComplete loadEventStart loadEventEnd prerenderSwitch redirectCount initiatorType name startTime duration navigationStart userName clientIP userAgent browser browserVersion hostMachineName =
        { Zero with 
            id                          = id
            sessionId                   = sessionId
            renderId                    = renderId
            ord                         = ord 
            url                         = url
            entryType                   = entryType
            source                      = source 
            created                     = created 
            unloadEventStart            = unloadEventStart           
            unloadEventEnd              = unloadEventEnd             
            linkNegotiationStart        = linkNegotiationStart       
            linkNegotiationEnd          = linkNegotiationEnd         
            redirectStart               = redirectStart              
            redirectEnd                 = redirectEnd                
            fetchStart                  = fetchStart                 
            domainLookupStart           = domainLookupStart          
            domainLookupEnd             = domainLookupEnd            
            connectStart                = connectStart               
            connectEnd                  = connectEnd                 
            secureConnectionStart       = secureConnectionStart      
            requestStart                = requestStart               
            responseStart               = responseStart              
            responseEnd                 = responseEnd                
            domLoading                  = domLoading                 
            domInteractive              = domInteractive             
            domContentLoadedEventStart  = domContentLoadedEventStart 
            domContentLoadedEventEnd    = domContentLoadedEventEnd   
            domComplete                 = domComplete                
            loadEventStart              = loadEventStart             
            loadEventEnd                = loadEventEnd               
            prerenderSwitch             = prerenderSwitch            
            redirectCount               = redirectCount              
            initiatorType               = initiatorType              
            name                        = name                       
            startTime                   = startTime                  
            duration                    = duration                   
            navigationStart             = navigationStart            
            userName                    = userName                   
            clientIP                    = clientIP                   
            userAgent                   = userAgent                  
            browser                     = browser                    
            browserVersion              = browserVersion             
            hostMachineName             = hostMachineName            
        }


