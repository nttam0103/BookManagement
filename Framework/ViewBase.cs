using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Framework
{
     public class ViewBase   
    {
        protected object Model;
        protected Router Router = Router.Instance;
        public ViewBase()
        {
            
        }
        public ViewBase(object model)
        {
            Model = Model;
        }
        public void RenderToFile(string path)
        {
            ViewHelp.WriteLine($"Saving date to file '{path}'");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Model);
            File.WriteAllText(path, json);
            ViewHelp.WriteLine("Done !!");
        }
    }
}
