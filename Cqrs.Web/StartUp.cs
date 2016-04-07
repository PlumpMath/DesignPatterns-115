using System;
using System.Threading.Tasks;
using Cqrs.Web.Configuration;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DefaultContainer))]