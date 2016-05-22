﻿using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace NuGetGallery
{
    public static class RouteCollectionExtensions
    {
        /// <summary>
        /// Maps the specified URL route using a lowercase URL. Does not change casing in the querystring, if any.
        /// </summary>
        /// <param name="routes">A collection of routes for the application.</param>
        /// <param name="name">The name of the route to map.</param>
        /// <param name="url">The URL pattern for the route.</param>
        /// <returns>A reference to the mapped route.</returns>
        public static Route MapRouteSeo(this RouteCollection routes, string name, string url)
        {
            return MapRouteSeo(routes, name, url, null, null, null);
        }

        /// <summary>
        /// Maps the specified URL route using a lowercase URL and sets default route values. Does not change casing in the querystring, if any.
        /// </summary>
        /// <param name="routes">A collection of routes for the application.</param>
        /// <param name="name">The name of the route to map.</param>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="defaults">An object that contains default route values.</param>
        /// <returns>A reference to the mapped route.</returns>
        public static Route MapRouteSeo(this RouteCollection routes, string name, string url, object defaults)
        {
            return MapRouteSeo(routes, name, url, defaults, null, null);
        }

        /// <summary>
        /// Maps the specified URL route using a lowercase URL and sets the namespaces. Does not change casing in the querystring, if any.
        /// </summary>
        /// <param name="routes">A collection of routes for the application.</param>
        /// <param name="name">The name of the route to map.</param>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="namespaces">A set of namespaces for the application.</param>
        /// <returns>A reference to the mapped route.</returns>
        public static Route MapRouteSeo(this RouteCollection routes, string name, string url, string[] namespaces)
        {
            return MapRouteSeo(routes, name, url, null, null, namespaces);
        }

        /// <summary>
        /// Maps the specified URL route using a lowercase URL and sets default route values and constraints. Does not change casing in the querystring, if any.
        /// </summary>
        /// <param name="routes">A collection of routes for the application.</param>
        /// <param name="name">The name of the route to map.</param>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="defaults">An object that contains default route values.</param>
        /// <param name="constraints">A set of expressions that specify valid values for a URL parameter.</param>
        /// <returns>A reference to the mapped route.</returns>
        public static Route MapRouteSeo(this RouteCollection routes, string name, string url, object defaults, object constraints)
        {
            return MapRouteSeo(routes, name, url, defaults, constraints, null);
        }

        /// <summary>
        /// Maps the specified URL route using a lowercase URL and sets default route values and namespaces. Does not change casing in the querystring, if any.
        /// </summary>
        /// <param name="routes">A collection of routes for the application.</param>
        /// <param name="name">The name of the route to map.</param>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="defaults">An object that contains default route values.</param>
        /// <param name="namespaces">A set of namespaces for the application.</param>
        /// <returns>A reference to the mapped route.</returns>
        public static Route MapRouteSeo(this RouteCollection routes, string name, string url, object defaults, string[] namespaces)
        {
            return MapRouteSeo(routes, name, url, defaults, null, namespaces);
        }

        /// <summary>
        /// Maps the specified URL route and sets default route values, constraints, and namespaces. Does not change casing in the querystring, if any.
        /// </summary>
        /// <param name="routes">A collection of routes for the application.</param>
        /// <param name="name">The name of the route to map.</param>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="defaults">An object that contains default route values.</param>
        /// <param name="constraints">A set of expressions that specify valid values for a URL parameter.</param>
        /// <param name="namespaces">A set of namespaces for the application.</param>
        /// <returns>A reference to the mapped route.</returns>
        public static Route MapRouteSeo(this RouteCollection routes, string name, string url, object defaults, object constraints, string[] namespaces)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }

            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            var route = new SeoRoute(url, new HyphenatedRouteHandler())
            {
                Defaults = new RouteValueDictionary(defaults),
                Constraints = new RouteValueDictionary(constraints),
                DataTokens = new RouteValueDictionary(namespaces),
            };

            if (namespaces != null && namespaces.Length > 0)
            {
                route.DataTokens["Namespaces"] = namespaces;
            }

            routes.Add(name, route);

            return route;
        }
    }
}