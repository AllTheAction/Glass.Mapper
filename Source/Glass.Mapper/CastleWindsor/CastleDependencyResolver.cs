/*
   Copyright 2012 Michael Edwards
 
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 
*/ 
//-CRE-

using System.Collections;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glass.Mapper.CastleWindsor
{
    public class CastleDependencyResolver : IDependencyResolver
    {
        public WindsorContainer Container { get; private set; }



        public T Resolve<T>(IDictionary<string, object> args = null)
        {
            if (args == null)
                return Container.Resolve<T>();
            else
                return Container.Resolve<T>((IDictionary)args);
        }

        public void Load(string contextName, IGlassConfiguration config)
        {

            var castleConfig = config as GlassCastleConfigBase;
            if(castleConfig == null)
                throw new MapperException("IGlassConfiguration is not of type GlassCastleConfigBase");

            Container = new WindsorContainer();
            castleConfig.Configure(Container, contextName);

        }


        public IEnumerable<T> ResolveAll<T>()
        {
            return Container.ResolveAll<T>();
        }
    }
}


