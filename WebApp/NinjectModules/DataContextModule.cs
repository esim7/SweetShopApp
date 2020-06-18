﻿using Infrastructure.EntityFramework;
using Ninject.Modules;

namespace WebApp.NinjectModules
{
    public class DataContextModule : NinjectModule
    {
        public override void Load()
        {
            Bind<SweetShopDataContext>().ToSelf().InSingletonScope();
        }
    }
}