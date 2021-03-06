﻿module Berf {
    var performance = window.performance || <any>{};

    export class Logger {
        timeout = 5000;

        url: string;

        queue: Array<any>;

        constructor() {
            this.queue = [];

            var tag = document.querySelector ? document.querySelector("[berf-url]") : <any>{ getAttribute: function () { } };

            this.url = tag.getAttribute("berf-url");

            var addEventListener = typeof window.addEventListener === "undefined" ? function () { } : window.addEventListener;

            addEventListener("beforeunload", (e: BeforeUnloadEvent) => {
                this.onBeforeUnload(e);
            });

            addEventListener("load", (e: UIEvent) => {
                this.onLoad(e);
            });
        }

        logResources() {
            if (typeof performance.getEntriesByType === "function") {
                var resources = performance.getEntriesByType("resource");
                if (resources.length > 0) {
                    for (var i = 0; i < resources.length; i++) {
                        var resource = resources[i];
                        resource["Source"] = "Navigation2";
                        resource["Url"] = window.location.toString();
                        this.enqueue(resource);
                    }
                }
            }
        }

        log() {
            if (typeof performance.getEntriesByType === "function") {
                var timing2 = performance.getEntriesByType("navigation");
                if (timing2.length > 0) {
                    timing2[0]["Source"] = "Navigation2";
                    timing2[0]["Url"] = window.location.toString();
                    this.enqueue(timing2[0]);
                }

                this.logResources();
            }

            if (typeof performance.timing === "object") {
                var timing1 = new Navigation(performance.timing);
                timing1["Source"] = "Navigation1";
                timing1["Url"] = window.location.toString();
                this.enqueue(timing1);
            }
        }

        onLoad(e: UIEvent) {
            // logging on load
            // this.log();
            // this.send(false);
        }

        onBeforeUnload(e: BeforeUnloadEvent) {
            // logging on unload
            this.log();
            this.send(false);
        }

        send(async: boolean = true, queue: Array<any> = this.queue) {
            if (queue.length > 0) {
                this.post(this.url, queue, async);
            }
        }

        enqueue(data: any) {
            var inQueue = this.contains(this.queue, data);

            if (!inQueue) {
                this.queue.push(data);
            }
        }

        contains(queue: Array<any>, value: any) {
            for (var i = 0; i < queue.length; i++) {
                if (this.equals(queue[i], value)) {
                    return true;
                }
            }

            return false;
        }

        equals(value: any, other: any) {
            for (var key in value) {
                if (typeof value[key] !== "undefined" && typeof other[key] === "undefined") {
                    return false;
                }

                if (value[key] !== other[key]) {
                    return false;
                }
            }

            for (var otherKey in other) {
                if (typeof other[otherKey] !== "undefined") {
                    if (typeof value[otherKey] === "undefined") {
                        return false;
                    }
                }
            }

            return true;
        }

        post(url: string, data: any, async: boolean = true) {
            var json = JSON.stringify(data);

            var http = new XMLHttpRequest();

            http.open("POST", url, async);

            http.setRequestHeader("Content-type", "application/json;charset=UTF-8");

            http.setRequestHeader("X-Requested-With", "XMLHttpRequest");

            var upload = http.upload || <any>{ addEventListener: function () { } };

            upload.addEventListener("error", (e: any) => {
                throw e;
            }, false);

            upload.addEventListener("progress", (e: ProgressEvent) => {
                this.onSuccess(e);
            }, false);

            http.send(json);
        }

        onSuccess(e: ProgressEvent) {
            this.queue = [];
        }

        extend = function (toExtend: {}, extender: {}) {
            for (var key in extender) {
                toExtend[key] = extender[key];
            }

            return toExtend;
        };
    }

    export class BerfCookie {
        static XmlHttpRequest(uri: string, serverStartDt: string): Array<any> {
            var value = BerfCookie.value("berf." + uri + "." + serverStartDt);

            return value;
        }

        static Navigation(): any {
            return BerfCookie.value("berf.navigation");
        }

        private static value(name: string) {
            var json = BerfCookie.getCookie(name);
            var value = json === "" ? {} : JSON.parse(json);

            return value;
        }

        private static getCookie(cname: string) {
            var name = cname + "=";
            var ca = document.cookie.split(";");
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i].trim();
                if (c.indexOf(name) === 0) {
                    return c.substring(name.length, c.length);
                }
            }
            return "";
        }
    }

    export class Navigation {
        navigationStart: number;
        unloadEventStart: number;
        unloadEventEnd: number;
        redirectStart: number;
        redirectEnd: number;
        redirectCount: number;
        fetchStart: number;
        domainLookupStart: number;
        domainLookupEnd: number;
        connectStart: number;
        connectEnd: number;
        secureConnectionStart: number;
        requestStart: number;
        responseStart: number;
        responseEnd: number;
        domLoading: number;
        domInteractive: number;
        domContentLoadedEventStart: number;
        domContentLoadedEventEnd: number;
        domComplete: number;
        loadEventStart: number;
        loadEventEnd: number;

        duration: number;
        startTime: number;

        constructor(nav?: any) {
            if (!nav) {
                nav = performance.timing;
            }
            this.navigationStart = this.delta(nav.navigationStart, nav.navigationStart);
            this.unloadEventStart = this.delta(nav.navigationStart, nav.unloadEventStart);
            this.unloadEventEnd = this.delta(nav.navigationStart, nav.unloadEventEnd);
            this.redirectStart = this.delta(nav.navigationStart, nav.redirectStart);
            this.redirectEnd = this.delta(nav.navigationStart, nav.redirectEnd);
            this.fetchStart = this.delta(nav.navigationStart, nav.fetchStart);
            this.domainLookupStart = this.delta(nav.navigationStart, nav.domainLookupStart);
            this.domainLookupEnd = this.delta(nav.navigationStart, nav.domainLookupEnd);
            this.connectStart = this.delta(nav.navigationStart, nav.connectStart);
            this.connectEnd = this.delta(nav.navigationStart, nav.connectEnd);
            this.secureConnectionStart = this.delta(nav.navigationStart, nav.secureConnectionStart);
            this.requestStart = this.delta(nav.navigationStart, nav.requestStart);
            this.responseStart = this.delta(nav.navigationStart, nav.responseStart);
            this.responseEnd = this.delta(nav.navigationStart, nav.responseEnd);
            this.domLoading = this.delta(nav.navigationStart, nav.domLoading);
            this.domInteractive = this.delta(nav.navigationStart, nav.domInteractive);
            this.domContentLoadedEventStart = this.delta(nav.navigationStart, nav.domContentLoadedEventStart);
            this.domContentLoadedEventEnd = this.delta(nav.navigationStart, nav.domContentLoadedEventEnd);
            this.domComplete = this.delta(nav.navigationStart, nav.domComplete);
            this.loadEventStart = this.delta(nav.navigationStart, nav.loadEventStart);
            this.loadEventEnd = this.delta(nav.navigationStart, nav.loadEventEnd);
            this.redirectCount = nav.redirectCount;
            // the duration attribute MUST return a DOMHighResTimeStamp eq-to difference  { loadEventEnd, startTime }
            this.startTime = this.navigationStart;
            this.duration = this.loadEventEnd - this.navigationStart;
        }

        delta(tZero: number, n: number) {
            return n === 0 ? 0 : n - tZero;
        }
    }
}

try {
    /*var berf = */
    (new Berf.Logger());
} catch (ex) {
    if (typeof console === "object" && typeof console.log === "function") {
        console.log(ex);
    }
}