using MVP.Models;
using MVP.Presenters;
using MVP.Repositories;
using MVP.Views;
using System.Configuration;

namespace MVP
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            string sqlConnectionString = ConfigurationManager.ConnectionStrings["MVP.Properties.Settings.SqlConnection1"].ConnectionString;
            
            IPetView view = new PetView();
            IPetRepository repository = new PetRepository(sqlConnectionString);

            new PetPresenter(view, repository);
            Application.Run((Form)view);

            //IMainView view = new MainView();
            //new MainPresenter(view, sqlConnectionString);


            //Application.Run(new Form1());
        }
    }
}