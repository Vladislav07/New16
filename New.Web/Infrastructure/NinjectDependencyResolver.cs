using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Moq;
using Ninject;
using New.Domain.Abstract;
using New.Domain.Entities;
using New.Domain.Concrete;

namespace New.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        
            private IKernel kernel;

            public NinjectDependencyResolver(IKernel kernelParam)
            {
                kernel = kernelParam;
                AddBindings();
            }

            public object GetService(Type serviceType)
            {
                return kernel.TryGet(serviceType);
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return kernel.GetAll(serviceType);
            }

            private void AddBindings()
            {
                Mock<IMatRepository> mock = new Mock<IMatRepository>();
                mock.Setup(m => m.Materials).Returns(new List<Material>
    {
        new Material {index=1, type="Балка", name ="Б1", Description="8", Dlina=11750,Cena =40  },
        new Material {index=2, type="Лист", name ="г/к", Description="16", Dlina=6000,Cena =40 },
        new Material {index=3, type="Труба", name ="Э/С", Description="159х8", Dlina=11750,Cena =40 },
        new Material {index=4, type="Труба", name ="Профильная", Description="40х40х2", Dlina=6000,Cena=50 },
        new Material {index=5, type="Труба", name ="Б/ш", Description="108х4", Dlina=10000,Cena=50 },
        new Material {index=6, type="Швелер", name ="П", Description="27", Dlina=12000 ,Cena=50},
        new Material {index=7, type="Уголок", name ="равнополочный", Description="50х5", Dlina=11750,Cena=50 },
        new Material {index=8, type="Арматура", name ="рифл", Description="20", Dlina=11750,Cena=50 }
    });
                kernel.Bind<IMatRepository>().ToConstant(mock.Object);
              
                //kernel.Bind<IMatRepository>().To <EFMatRepository>();
                Mock<ISheetRepository> mock1 = new Mock<ISheetRepository>();
                mock1.Setup(n => n.Sheets).Returns(new List<Sheet>
                {
                    new Sheet{MatID=1,length=11750,width=100,thick=25,quantity=100},
                    new Sheet{MatID=2,length=6000,width=1500,thick=10,quantity=100},                    
                    new Sheet{MatID=3,length=19750,width=100,thick=159,quantity=100},
                    new Sheet{MatID=4,length=18750,width=100,thick=25,quantity=100},
                    new Sheet{MatID=5,length=16750,width=100,thick=25,quantity=100},
                    new Sheet{MatID=6,length=1750,width=100,thick=25,quantity=100},
                    new Sheet{MatID=7,length=10750,width=100,thick=25,quantity=100},
                    new Sheet{MatID=9,length=12750,width=100,thick=25,quantity=100},
                });

                kernel.Bind<ISheetRepository>().ToConstant(mock1.Object);

                EmailSettings emailSettings = new EmailSettings
                {
                    WriteAsFile = bool.Parse(ConfigurationManager
                        .AppSettings["Email.WriteAsFile"] ?? "false")
                };

                kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
                    .WithConstructorArgument("settings", emailSettings);

            }
        }

    }
