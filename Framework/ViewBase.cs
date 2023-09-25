using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Framework
{
    public class ViewBase
    {

        protected Router Router = Router.Instance;
        public ViewBase() { }
        public virtual void Render() { }
    }

    public class ViewBase<T> : ViewBase {
        public T Model;
        public ViewBase(T model)=>Model = model;

        public virtual void RenderToFile(string path)
        {
            ViewHelp.WriteLine($"Saving date to file '{path}'");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Model);
            File.WriteAllText(path, json);
            ViewHelp.WriteLine("Done !!");
    }

    }
}
