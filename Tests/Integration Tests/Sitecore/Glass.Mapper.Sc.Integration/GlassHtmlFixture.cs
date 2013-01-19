﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Glass.Mapper.Sc.Configuration.Attributes;
using NUnit.Framework;
using Sitecore.SecurityModel;
using Sitecore.Sites;
using Sitecore.Web;

namespace Glass.Mapper.Sc.Integration
{
    [TestFixture]
    public class GlassHtmlFixture
    {
        #region Method - Editable

        [Test]
        public void Editable_InEditMode_StringFieldWithEditReturned()
        {
            //Assign
            string targetPath = "/sitecore/content/Tests/GlassHtml/MakeEditable/Target";

            var db = Sitecore.Configuration.Factory.GetDatabase("master");
            var context = Context.Create(new GlassConfig());
            context.Load(new SitecoreAttributeConfigurationLoader("Glass.Mapper.Sc.Integration"));
            var service = new SitecoreService(db);

            var html = new GlassHtml(service);
            
            var model = service.GetItem<StubClass>(targetPath);

            var fieldValue = "test content field";

            model.StringField = fieldValue ;

            using (new SecurityDisabler())
            {
                service.Save(model);
            }

            var doc = new XmlDocument();
            doc.LoadXml("<site name='GetHomeItem' virtualFolder='/' physicalFolder='/' rootPath='/sitecore/content/Tests/SitecoreContext/GetHomeItem' startItem='/Target1' database='master' domain='extranet' allowDebug='true' cacheHtml='true' htmlCacheSize='10MB' registryCacheSize='0' viewStateCacheSize='0' xslCacheSize='5MB' filteredItemsCacheSize='2MB' enablePreview='true' enableWebEdit='true' enableDebugger='true' disableClientData='false' />");

            var siteContext = new SiteContextStub(
                new SiteInfo(
                    doc.FirstChild
                    )
                );

            siteContext.SetDisplayMode(DisplayMode.Edit);

            Sitecore.Context.Site = siteContext;

            //Act
            var result =  html.Editable(model, x => x.StringField);

            //Assert
            Assert.IsTrue(result.Contains(fieldValue));
            //this is the webedit class
            Assert.IsTrue(result.Contains("scWebEditInput"));
            Console.WriteLine("result "+result);
        }

        [Test]
        public void Editable_NotInEditMode_StringFieldReturned()
        {
            //Assign
            string targetPath = "/sitecore/content/Tests/GlassHtml/MakeEditable/Target";

            var db = Sitecore.Configuration.Factory.GetDatabase("master");
            var context = Context.Create(new GlassConfig());
            context.Load(new SitecoreAttributeConfigurationLoader("Glass.Mapper.Sc.Integration"));
            var service = new SitecoreService(db);

            var html = new GlassHtml(service);

            var model = service.GetItem<StubClass>(targetPath);

            var fieldValue = "test content field";

            model.StringField = fieldValue;

            using (new SecurityDisabler())
            {
                service.Save(model);
            }

            var doc = new XmlDocument();
            doc.LoadXml("<site name='GetHomeItem' virtualFolder='/' physicalFolder='/' rootPath='/sitecore/content/Tests/SitecoreContext/GetHomeItem' startItem='/Target1' database='master' domain='extranet' allowDebug='true' cacheHtml='true' htmlCacheSize='10MB' registryCacheSize='0' viewStateCacheSize='0' xslCacheSize='5MB' filteredItemsCacheSize='2MB' enablePreview='true' enableWebEdit='true' enableDebugger='true' disableClientData='false' />");

            var siteContext = new SiteContextStub(
               new SiteInfo(
                   doc.FirstChild
                   )
               );

            siteContext.SetDisplayMode(DisplayMode.Normal);

            Sitecore.Context.Site = siteContext;


            //Act
            var result = html.Editable(model, x => x.StringField);

            //Assert
            Assert.IsTrue(result.Contains(fieldValue));
            //this is the webedit class
            Assert.IsFalse(result.Contains("scWebEditInput"));
            Console.WriteLine("result " + result);
        }

        [Test]
        public void Editable_SimpleLambdaInEditMode_StringFieldWithEditReturned()
        {
            //Assign
            string targetPath = "/sitecore/content/Tests/GlassHtml/MakeEditable/Target";

            var db = Sitecore.Configuration.Factory.GetDatabase("master");
            var context = Context.Create(new GlassConfig());
            context.Load(new SitecoreAttributeConfigurationLoader("Glass.Mapper.Sc.Integration"));
            var service = new SitecoreService(db);

            var html = new GlassHtml(service);

            var model = service.GetItem<StubClass>(targetPath);

            var fieldValue = "test content field";

            model.StringField = fieldValue;

            using (new SecurityDisabler())
            {
                service.Save(model);
            }

            var doc = new XmlDocument();
            doc.LoadXml("<site name='GetHomeItem' virtualFolder='/' physicalFolder='/' rootPath='/sitecore/content/Tests/SitecoreContext/GetHomeItem' startItem='/Target1' database='master' domain='extranet' allowDebug='true' cacheHtml='true' htmlCacheSize='10MB' registryCacheSize='0' viewStateCacheSize='0' xslCacheSize='5MB' filteredItemsCacheSize='2MB' enablePreview='true' enableWebEdit='true' enableDebugger='true' disableClientData='false' />");

            var siteContext = new SiteContextStub(
                new SiteInfo(
                    doc.FirstChild
                    )
                );

            siteContext.SetDisplayMode(DisplayMode.Edit);

            Sitecore.Context.Site = siteContext;

            //Act
            var result = html.Editable(model, x => x.SubStub.StringField);

            //Assert
            Assert.IsTrue(result.Contains(fieldValue));
            //this is the webedit class
            Assert.IsTrue(result.Contains("scWebEditInput"));
            Console.WriteLine("result " + result);
        }

        [Test]
        public void Editable_SimpleLambdaNotInEditMode_StringFieldReturned()
        {
            //Assign
            string targetPath = "/sitecore/content/Tests/GlassHtml/MakeEditable/Target";

            var db = Sitecore.Configuration.Factory.GetDatabase("master");
            var context = Context.Create(new GlassConfig());
            context.Load(new SitecoreAttributeConfigurationLoader("Glass.Mapper.Sc.Integration"));
            var service = new SitecoreService(db);

            var html = new GlassHtml(service);

            var model = service.GetItem<StubClass>(targetPath);

            var fieldValue = "test content field";

            model.StringField = fieldValue;

            using (new SecurityDisabler())
            {
                service.Save(model);
            }

            var doc = new XmlDocument();
            doc.LoadXml("<site name='GetHomeItem' virtualFolder='/' physicalFolder='/' rootPath='/sitecore/content/Tests/SitecoreContext/GetHomeItem' startItem='/Target1' database='master' domain='extranet' allowDebug='true' cacheHtml='true' htmlCacheSize='10MB' registryCacheSize='0' viewStateCacheSize='0' xslCacheSize='5MB' filteredItemsCacheSize='2MB' enablePreview='true' enableWebEdit='true' enableDebugger='true' disableClientData='false' />");

            var siteContext = new SiteContextStub(
               new SiteInfo(
                   doc.FirstChild
                   )
               );

            siteContext.SetDisplayMode(DisplayMode.Normal);

            Sitecore.Context.Site = siteContext;


            //Act
            var result = html.Editable(model, x => x.SubStub.StringField);

            //Assert
            Assert.IsTrue(result.Contains(fieldValue));
            //this is the webedit class
            Assert.IsFalse(result.Contains("scWebEditInput"));
            Console.WriteLine("result " + result);
        }

        [Test]
        public void Editable_ComplexLambdaInEditMode_StringFieldWithEditReturned()
        {
            //Assign
            string targetPath = "/sitecore/content/Tests/GlassHtml/MakeEditable/Target";

            var db = Sitecore.Configuration.Factory.GetDatabase("master");
            var context = Context.Create(new GlassConfig());
            context.Load(new SitecoreAttributeConfigurationLoader("Glass.Mapper.Sc.Integration"));
            var service = new SitecoreService(db);

            var html = new GlassHtml(service);

            var model = service.GetItem<StubClass>(targetPath);

            var fieldValue = "test content field";

            model.StringField = fieldValue;

            using (new SecurityDisabler())
            {
                service.Save(model);
            }

            var doc = new XmlDocument();
            doc.LoadXml("<site name='GetHomeItem' virtualFolder='/' physicalFolder='/' rootPath='/sitecore/content/Tests/SitecoreContext/GetHomeItem' startItem='/Target1' database='master' domain='extranet' allowDebug='true' cacheHtml='true' htmlCacheSize='10MB' registryCacheSize='0' viewStateCacheSize='0' xslCacheSize='5MB' filteredItemsCacheSize='2MB' enablePreview='true' enableWebEdit='true' enableDebugger='true' disableClientData='false' />");

            var siteContext = new SiteContextStub(
                new SiteInfo(
                    doc.FirstChild
                    )
                );

            siteContext.SetDisplayMode(DisplayMode.Edit);

            Sitecore.Context.Site = siteContext;

            //Act
            var result = html.Editable(model, x => x.EnumerableSubStub.First().StringField);

            //Assert
            Assert.IsTrue(result.Contains(fieldValue));
            //this is the webedit class
            Assert.IsTrue(result.Contains("scWebEditInput"));
            Console.WriteLine("result " + result);
        }

        [Test]
        public void Editable_ComplexLambdaNotInEditMode_StringFieldReturned()
        {
            //Assign
            string targetPath = "/sitecore/content/Tests/GlassHtml/MakeEditable/Target";

            var db = Sitecore.Configuration.Factory.GetDatabase("master");
            var context = Context.Create(new GlassConfig());
            context.Load(new SitecoreAttributeConfigurationLoader("Glass.Mapper.Sc.Integration"));
            var service = new SitecoreService(db);

            var html = new GlassHtml(service);

            var model = service.GetItem<StubClass>(targetPath);

            var fieldValue = "test content field";

            model.StringField = fieldValue;

            using (new SecurityDisabler())
            {
                service.Save(model);
            }

            var doc = new XmlDocument();
            doc.LoadXml("<site name='GetHomeItem' virtualFolder='/' physicalFolder='/' rootPath='/sitecore/content/Tests/SitecoreContext/GetHomeItem' startItem='/Target1' database='master' domain='extranet' allowDebug='true' cacheHtml='true' htmlCacheSize='10MB' registryCacheSize='0' viewStateCacheSize='0' xslCacheSize='5MB' filteredItemsCacheSize='2MB' enablePreview='true' enableWebEdit='true' enableDebugger='true' disableClientData='false' />");

            var siteContext = new SiteContextStub(
               new SiteInfo(
                   doc.FirstChild
                   )
               );

            siteContext.SetDisplayMode(DisplayMode.Normal);

            Sitecore.Context.Site = siteContext;


            //Act
            var result = html.Editable(model, x => x.EnumerableSubStub.First().StringField);

            //Assert
            Assert.IsTrue(result.Contains(fieldValue));
            //this is the webedit class
            Assert.IsFalse(result.Contains("scWebEditInput"));
            Console.WriteLine("result " + result);
        }
        #endregion


        #region Stubs

        [SitecoreType]
        public class StubClass
        {
            [SitecoreId]
            public virtual Guid Id { get; set; }

            [SitecoreField]
            public virtual string StringField { get; set; }

            [SitecoreField]
            public virtual string DateField { get; set; }

            [SitecoreQuery("./../*", IsRelative = true)]
            public virtual StubClass SubStub { get; set; }

            [SitecoreQuery("./../*", IsRelative = true)]
            public virtual IEnumerable<StubLambdaClass> EnumerableSubStub { get; set; }
        }

        [SitecoreType]
        public class StubLambdaClass : StubClass
        {
       
        }

        public class SiteContextStub : SiteContext
        {
            public SiteContextStub(SiteInfo info) : base(info)
            {
                
            }

            public void SetDisplayMode(DisplayMode mode)
            {
                this.SetDisplayMode(mode, DisplayModeDuration.Temporary);
            }
        }

        #endregion


    }
}