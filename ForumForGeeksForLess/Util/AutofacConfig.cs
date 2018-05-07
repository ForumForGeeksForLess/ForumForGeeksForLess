using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using ForumForGeeksForLess;
using ForumForGeeksForLess.BL.interfaceDTO;
using ForumForGeeksForLess.BL.Services;
using System.Web.Mvc;

public class AutofacConfig
{
    public static void ConfigureContainer()
    {
        // получаем экземпляр контейнера
        var builder = new ContainerBuilder();

        // регистрируем контроллер в текущей сборке
        builder.RegisterControllers(typeof(MvcApplication).Assembly);

        // регистрируем споставление типов
        builder.RegisterType<ForumService>().As<IRepositoryBL>();

        // создаем новый контейнер с теми зависимостями, которые определены выше
        var container = builder.Build();

        // установка сопоставителя зависимостей
        DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    }
}