using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using Yaskawa.Ext.API;

namespace DemoExtension21_csharp
{
    class demoExtension21_csharp
    {
        private demoExtension21_csharp() 
        {
            var _version = new Yaskawa.Ext.Version(1,0,0);
            var _languages = new HashSet<string> { "en", "ja" } ;

            extension = new Yaskawa.Ext.Extension(
                "yai.custommenutest", 
                _version, "YEU", _languages,
                "localhost", -1);
            Console.WriteLine("API version: "+extension.apiVersion());

            pendant = extension.pendant();
            controller = extension.controller();
            Console.WriteLine("Controller software version:"+controller.softwareVersion());


        }
        protected Yaskawa.Ext.Extension extension;
        protected Yaskawa.Ext.Pendant pendant;
        protected Pendant Pendant;
        protected Yaskawa.Ext.Controller controller;
        protected bool run = true;
        protected bool update = false;
        protected double time;
        public void setup()
        {
            pendant.registerYMLFile("myUtility.yml");
            pendant.registerIntegration("util111", IntegrationPoint.TestRunPanel, "MyUtility", "NameyName", "windowName");
        }
        public void Run()
        {
            
        }
        
        static void Main(string[] args)
        {
            demoExtension21_csharp _demoExtension = null;
            try {
                // launch
                try {
                    _demoExtension = new demoExtension21_csharp();
                } catch (Exception _e) {
                    Console.WriteLine("Extension failed to start, aborting: "+ _e);
                    return;
                }

                try {
                    _demoExtension.setup();
                } catch (Exception _e) {
                    Console.WriteLine("Extension failed in setup, aborting: "+_e);
                    return;
                }

                // run 'forever' (or until API service shutsdown)
                try {
                } catch (Exception _e) {
                    Console.WriteLine("Exception occured:"+ _e);
                }

            } catch (Exception _e) {

                Console.WriteLine("Exception: "+ _e);

            } finally {
            }
        }
    }
}
